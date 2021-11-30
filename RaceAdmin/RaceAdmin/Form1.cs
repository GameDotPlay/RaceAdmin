﻿namespace RaceAdmin
{
    using iRacingSdkWrapper;
    using iRacingSdkWrapper.Bitfields;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Media;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using SessionFlags = iRacingSdkWrapper.Bitfields.SessionFlags;

    public partial class RaceAdminMain : Form
    {
        /// <summary>
        /// Default session number. 1.
        /// </summary>
        public const int DefaultSessionNum = 0;

        /// <summary>
        /// Default session unique ID. 1.
        /// </summary>
        public const int DefaultSessionUniqueID = 1;

        /// <summary>
        /// Tracks the current caution state on track.
        /// </summary>
        private CautionState cautionState = CautionState.None;

        /// <summary>
        /// The rate at which to poll the live telemetry. Can be changed by the user at runtime on the Debug tab of the UI.
        /// </summary>
        private int telemetryPollRate = 4;

        /// <summary>
        /// The total count of incidents since the current session started.
        /// </summary>
        private int totalIncCount = 0;

        /// <summary>
        /// The number of incidents since the last caution.
        /// </summary>
        private int incCountSinceCaution = 0;

        /// <summary>
        /// Whether the current race meeting is a team racing event. 
        /// Updated during session initialization when processing a session info update.
        /// This value should not change once initially set though this has not been 
        /// proved through exhaustive testing.
        /// </summary>
        private bool teamRacing;

        /// <summary>
        /// Flag to indicate whether the initialization for the current session has occured.
        /// Updated during telemetry updates when a change in SessionUniqueID or SessionNum
        /// is detected. Typically both values change simultaneously.
        /// </summary>
        private bool sessionInitializationComplete = false;

        /// <summary>
        /// The number of incidents required for a caution to be triggeed. Set by user in Settings dialog.
        /// </summary>
        private int incsRequiredForCaution = 0;

        /// <summary>
        /// The current session number obtained from the live telemetry.
        /// Seems to be a 0-indexed value that can be used to index into the sessions
        /// listed in the SessionInfo.Sessions section of the SessionInfoUpdate YAML.
        /// Updated during telemetry updates.
        /// </summary>
        private int sessionNum = DefaultSessionNum;

        /// <summary>
        /// The current unique session ID number obtained from the live telemetry.
        /// This is not the same as the iRacing Session ID displayed in the results
        /// but rather seems to be a 1-indexed value based on the which session within
        /// the race meeting (practice, qualify, race).
        /// Updated during telemetry updates.
        /// </summary>
        private int sessionUniqueID = DefaultSessionUniqueID;

        /// <summary>
        /// Number of laps remaining in the race. Only valid in races with race length
        /// specified by number of laps. May also be somewhat populated in qualifying 
        /// sessions but not sure to which car this would apply. For the race it appears
        /// this value decrements each time the leader crosses the start/finish line.
        /// Note that this is the number of full laps left to be completed by the leader,
        /// so when the leader takes the white flag this value will decrement to zero.
        /// For timed races this value appears to generally be set to 32767 (2^15 - 1).
        /// Updated during telemetry updates.
        /// </summary>
        private int sessionLapsRemain = int.MaxValue;

        /// <summary>
        /// Amout of time remaining in the current session in seconds. This value is only 
        /// valid during timed sessions. It looks like practice, qualifying, and timed 
        /// races have meaningful values. For non-timed races the value appears to always
        /// be set to the length of one week in seconds and does not vary during the race.
        /// Updated during telemetry updates.
        /// </summary>
        private double sessionTimeRemain = Double.MaxValue;

        /// <summary>
        /// Bitfield which represents the current state of any flags displayed by race control.
        /// It is unclear if this value will vary during local yellows--more experimentation
        /// is required. Updated during telemetry updates.
        /// </summary>
        private SessionFlag sessionFlags;

        /// <summary>
        /// Driver dictionary keyed by driver full name. Used to store data about
        /// all drivers in the race meeting. Drivers are never removed once added.
        /// The pace car may also be contained in this dictionary.
        /// </summary>
        private Dictionary<string, Driver> drivers;

        /// <summary>
        /// Car dictionary keyed by carId. Used to store data about
        /// all cars in the race meeting. Cars are never removed once added.
        /// The pace car may also be contained in this dictionary.
        /// </summary>
        private Dictionary<int, Car> cars;

        /// <summary>
        /// List of all incidents in the session since the app was launched.
        /// </summary>
        private List<Incident> incidents;

        /// <summary>
        /// ISdkWrapper object.
        /// </summary>
        private ISdkWrapper wrapper;

        /// <summary>
        /// The caution handlers used to notify the user that a caution is advised.
        /// </summary>
        private Dictionary<string, ICautionHandler> cautionHandlers;

        /// <summary>
        /// Whether the current session within the race meeting is a race session.
        /// Further testing will be needed to understand if this is working correctly
        /// for heat racing.
        /// Updated during session initialization when processing a session info update.
        /// </summary>
        private bool raceSession;

        /// <summary>
        /// Constructor for RaceAdminMain form. Initialization of WinForm, SdkWrapper, start wrapper object.
        /// </summary>
        public RaceAdminMain(ISdkWrapper wrapper)
        {
            // Initialize WinForm
            InitializeComponent();

#if !DEBUG
            tabControl.TabPages.Remove(debugTab);
#endif

            string version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
            this.versionLabel.Text = String.Format("v{0}", version);

            this.wrapper = wrapper;
            cautionHandlers = new Dictionary<string, ICautionHandler>
            {
                { "default", new DefaultCautionHandler(this.cautionPanel) }
            };

            // Initialize variables.
            drivers = new Dictionary<string, Driver>();
            cars = new Dictionary<int, Car>();
            incidents = new List<Incident>();
            sessionFlags = new SessionFlag(0);
            telemetryPollRate = Properties.Settings.Default.telemetryPollRate;
            telemetryPollRateTextBox.Text = telemetryPollRate.ToString();
            incsRequiredForCaution = Properties.Settings.Default.incidentsRequired;
            allIncidentsTable.Sort(allIncidentsTable.Columns["incidentsTimeStamp"], System.ComponentModel.ListSortDirection.Descending);

            // Listen to events
            wrapper.AddTelemetryUpdateHandler(OnTelemetryUpdated);
            wrapper.AddSessionInfoUpdateHandler(OnSessionInfoUpdated);

            // Set telemetry update rate.
            wrapper.SetTelemetryUpdateFrequency(telemetryPollRate); // Hz

            // Start the wrapper.
            wrapper.Start();
        }

        /// <summary>
        /// Called when the session string has been updated by the simulator.
        /// Checks for new drivers that have entered the session and populates/updates list of drivers.
        /// Checks each driver for a change in incidents, logs new incident to the table if so.
        /// Updates laps completed for each driver.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Session string changed event. Contains info from session string that can be queried.</param>
        public void OnSessionInfoUpdated(object sender, SdkWrapper.SessionInfoUpdatedEventArgs e)
        {
            // Perform some initialization if this is the first time being called in this session...
            if (!this.sessionInitializationComplete)
            {
                InitializeSession(e);
                sessionInitializationComplete = true;
            }

            AddNewDrivers(e);
            AddNewCars(e);
            UpdateDriverIncidentCounts(e);
            UpdateDriverLapCounts(e);
            UpdateCarTeamIncidentCounts(e);

            var resultsOfficial = e.SessionInfo["SessionInfo"]["Sessions"]["SessionNum", sessionNum]["ResultsOfficial"].Value;
            if (raceSession && resultsOfficial == "1")
            {
                ShowIncidents();
                raceSession = false;
                Console.WriteLine("race complete");
            }
        }

        /// <summary>
        /// Called every time the live telemetry gets updates. Currently configured to 4 times per second by setting wrapper.TelemetryUpdateFrequency.
        /// Checks current session ID to see if new session initialization should take place.
        /// Checks for change in flag state. When session goes green again after a caution the incs since last caution field is reset to zero.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">TelemetryUpdated event args.</param>
        public void OnTelemetryUpdated(object sender, ITelemetryUpdatedEvent e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnTelemetryUpdated(sender, e)));
                return;
            }

            // Update Session Identifiers
            // NOTE: Current thinking is that the SessionUniqueID changes even between 
            //       pracice, qualifying, and race during one iRacing session, which does seem
            //       to be the case though it is not exactly clear what the values might be. 
            //       The SessionNum value (I think) iterates from 0, 1, 2, etc. and is an 
            //       index into the SessionInfo:Sessions data in the SessionInfoUpdate YAML.
            //       It is not clear that we need both and once we have full telemetry recording
            //       implemented this may become more clear and allow simplification of the code.
            // 2021-02-02 [CA]:
            //       I recorded a race as a spectator and the session id values for practice,
            //       qualify and race were: 1, 2 and 3. The session num values from the same race
            //       meeting were: 0, 1 and 2. So SessionNum definitely seems to be the value needed
            //       to index into the SessionInfo Sessions list. The purpose of SessionUniqueID
            //       remains unclear but it seems likely we don't need it.
            // ALSO: See comments in the SdkWrapperProxy in the telemetry update recording section
            var sessionUniqueID = SafeInt(e.TelemetryInfo.SessionUniqueID);
            var sessionNum = SafeInt(e.TelemetryInfo.SessionNum);
            var sessionLapsRemain = SafeInt(e.TelemetryInfo.SessionLapsRemain);
            var sessionTimeRemain = SafeDouble(e.TelemetryInfo.SessionTimeRemain);
            var sessionFlags = SafeSessionFlag(e.TelemetryInfo.SessionFlags);

            if (sessionUniqueID != this.sessionUniqueID
                || sessionNum != this.sessionNum
                || sessionLapsRemain != this.sessionLapsRemain
                || sessionTimeRemain != this.sessionTimeRemain
                || sessionFlags.Value != this.sessionFlags.Value)
            {
                Console.WriteLine("id = {0}, num = {1}, lapsLeft = {2}, timeLeft = {3}, flags = {4}",
                    sessionUniqueID, sessionNum, sessionLapsRemain, sessionTimeRemain, sessionFlags);
            }

            this.sessionLapsRemain = sessionLapsRemain;
            this.sessionTimeRemain = sessionTimeRemain;
            this.sessionFlags = sessionFlags;

            if (sessionUniqueID != this.sessionUniqueID || sessionNum != this.sessionNum)
            {
                this.sessionUniqueID = sessionUniqueID;
                this.sessionNum = sessionNum;
                sessionInitializationComplete = false;
            }

            UpdateLiveCarInfo(e);
            //UpdatePitConePercentages();
            UpdateIncidentCountDisplay();

#if DEBUG
            UpdateDebugTable();
#endif

            CheckFlagStateChanges(e);

            if (Properties.Settings.Default.useTotalIncidentsForCaution)
            {
                CheckIncidentLimit();
            }

            if (Properties.Settings.Default.detectTowForCaution)
            {
                CheckForTow();
            }
        }

        /// <summary>
        /// Performs some initialization of internal variables and states relevant to the current session.
        /// </summary>
        /// <param name="e">SessionInfoUpdated event args.</param>
        private void InitializeSession(SdkWrapper.SessionInfoUpdatedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => InitializeSession(e)));
                return;
            }

            var sessionType = e.SessionInfo["SessionInfo"]["Sessions"]["SessionNum", sessionNum]["SessionType"].Value;
            var sessionName = e.SessionInfo["SessionInfo"]["Sessions"]["SessionNum", sessionNum]["SessionName"].Value;
            sessionLabel.Text = sessionName;
            if (sessionType == "Race")
            {
                if (Properties.Settings.Default.hideIncidents)
                {
                    ObscureIncidents();
                }
                raceSession = true;
            }
            else
            {
                raceSession = false;
            }
            Console.WriteLine("initializing session {0} ({1})", sessionName, sessionType);

            YamlQuery query = e.SessionInfo["WeekendInfo"]["TeamRacing"];
            query.TryGetValue(out string temp);
            System.Int32.TryParse(temp, out int tempInt);
            teamRacing = tempInt > 0;
            var teamColName = RaceAdmin.Properties.Resources.TableColumn_Team;
            if (!teamRacing && incidentsTableView.Columns.Contains(teamColName))
            {
                incidentsTableView.Columns.Remove(incidentsTableView.Columns[teamColName]);
            }

            this.totalIncCount = 0;
            this.incCountSinceCaution = 0;
            ClearIncidents();

#if DEBUG
            AddNewDrivers(e);
            AddNewCars(e);
            PopulateDebugTable();
#endif
        }

        /// <summary>
        /// Hides the incident counts from the user.
        /// </summary>
        private void ObscureIncidents()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ObscureIncidents()));
                return;
            }

            incidentCountPanel.Visible = false;
        }

        /// <summary>
        /// Shows the incident counts to the user.
        /// </summary>
        private void ShowIncidents()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ShowIncidents()));
                return;
            }

            incidentCountPanel.Visible = true;
        }

        /// <summary>
        /// Iterates through all drivers in the session and updates their incident counts, logs a new incident if one is detected.
        /// </summary>
        /// <param name="e">SessionInfoUpdated event args.</param>
        private void UpdateDriverIncidentCounts(SdkWrapper.SessionInfoUpdatedEventArgs e)
        {
            int carIdx = 0;
            YamlQuery query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
            while (query.TryGetValue(out string name))
            {
                if (name == null || name == "Pace Car")
                {
                    carIdx++;
                    query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                    continue;
                }

                if (!drivers.ContainsKey(name))
                {
                    carIdx++;
                    query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                    Console.WriteLine("ERROR: driver {0} not found in session driver list", name);
                    continue;
                }

                if (teamRacing)
                {
                    drivers[name].TeamIncs = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["TeamIncidentCount"].Value;
                }

                query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["CurDriverIncidentCount"];
                query.TryGetValue(out string s_newIncs);
                System.Int32.TryParse(s_newIncs, out int i_newIncs);

                // delta can be negative if a driver or the person running the RaceAdmin program 
                // disconnects and then reconnects; overall the negative rows and then the positive
                // rows added back total up to the same amount, so we can just ignore these. The negative
                // rows cause confusion and make the incident count fluctuate unnaturally.
                var delta = i_newIncs - drivers[name].OldIncs;
                if (delta > 0)
                {
                    drivers[name].NewIncs = i_newIncs;
                    Incident newInc = new Incident(e.SessionInfo.UpdateTime, DateTime.Now, delta, carIdx);
                    incidents.Add(newInc);
                    LogNewIncident(newInc);
                    UpdateIncidentsTable(newInc);
                    drivers[name].OldIncs = drivers[name].NewIncs;
                }

                carIdx++;
                query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
            }
        }

        /// <summary>
        /// Iterates through all drivers in the session and updates their completed laps and current lap number.
        /// </summary>
        /// <param name="e">SessionInfoUpdated event args.</param>
        private void UpdateDriverLapCounts(SdkWrapper.SessionInfoUpdatedEventArgs e)
        {
            int i = 1;
            YamlQuery query = e.SessionInfo["SessionInfo"]["Sessions"]["SessionNum", this.sessionNum]["ResultsPositions"]["Position", i]["CarIdx"];
            while (query.TryGetValue(out string s_carIdx))
            {
                query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", s_carIdx]["UserName"];
                if (query.TryGetValue(out string userName))
                {
                    if (drivers.TryGetValue(userName, out Driver driver))
                    {
                        query = e.SessionInfo["SessionInfo"]["Sessions"]["SessionNum", this.sessionNum]["ResultsPositions"]["Position", i]["LapsComplete"];
                        query.TryGetValue(out string s_lapsComplete);
                        System.Int32.TryParse(s_lapsComplete, out int i_lapsComplete);
                        driver.CurrentLap = i_lapsComplete + 1;
                    }
                }

                i++;
                query = e.SessionInfo["SessionInfo"]["Sessions"]["SessionNum", this.sessionNum]["ResultsPositions"]["Position", i]["CarIdx"];
            }
        }

        /// <summary>
        /// Iterates through all cars in the session and updates the team incident count.
        /// </summary>
        /// <param name="e">SessionInfoUpdated event args.</param>
        private void UpdateCarTeamIncidentCounts(SdkWrapper.SessionInfoUpdatedEventArgs e)
		{
            int carIdx = 0;
            YamlQuery query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
            while (query.TryGetValue(out string name))
            {
                if (name == null || name == "Pace Car")
                {
                    carIdx++;
                    query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                    continue;
                }

                if (!cars.ContainsKey(carIdx))
                {
                    carIdx++;
                    query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                    Console.WriteLine("ERROR: car {0} not found in session driver list", carIdx);
                    continue;
                }

                cars[carIdx].TeamIncidentCount = SafeInt(e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["TeamIncidentCount"].Value);

                carIdx++;
                query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
            }
        }

        /// <summary>
        /// Iterates through every car in the session and checks if it has towed to pit lane since the last update.
        /// </summary>
        private void CheckForTow()
        {
            // Iterate over every car in the session and check if they have towed to pit lane since the last update.
            foreach (var car in cars.Values)
            {
                // If car is already "ApproachingPits" when tow occurs then ignore.
                if(car.TrackSurface != TrackSurfaces.AproachingPits)
				{
                    // Pit entry transition has occured.
                    if (car.BetweenPitCones != car.LastBetweenPitCones)
                    {
                        // Car has entered pit lane.
                        if (car.BetweenPitCones)
                        {
                            // Notify caution handlers
                            cautionHandlers.Values.ToList().ForEach(h => h.CautionThresholdReached());

                            // Move to next state in caution handling cycle
                            cautionState = CautionState.ThresholdReached;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Updates all live telemetry info for all cars in the session.
        /// </summary>
        /// <param name="e">Telemetry update event parameters.</param>
        private void UpdateLiveCarInfo(ITelemetryUpdatedEvent e)
		{
            foreach(KeyValuePair<int, Car> car in cars)
			{
                car.Value.PercentAroundTrack = e.TelemetryInfo.PercentAroundTrack.Value[car.Key];
                car.Value.LastBetweenPitCones = car.Value.BetweenPitCones;
                car.Value.BetweenPitCones = e.TelemetryInfo.BetweenPitCones.Value[car.Key];
                car.Value.CurrentLap = e.TelemetryInfo.CurrentLap.Value[car.Key];
                car.Value.LapsCompleted = e.TelemetryInfo.LapsCompleted.Value[car.Key];
                car.Value.OverallPositionInRace = e.TelemetryInfo.OverallPositionInRace.Value[car.Key];
                car.Value.ClassPositionInRace = e.TelemetryInfo.ClassPositionInRace.Value[car.Key];
                car.Value.TrackSurface = e.TelemetryInfo.TrackSurface.Value[car.Key];
                car.Value.TrackSurfaceMaterial = e.TelemetryInfo.TrackSurfaceMaterial.Value[car.Key];
            }
		}

        /// <summary>
        /// Runs checks on conditions to determine if a caution threshold has been reached and notifies the caution handlers.
        /// </summary>
        private void CheckIncidentLimit()
        {
            if (!raceSession)
            {
                // only trigger cautions during races
                return;
            }

            if (sessionFlags.Contains(SessionFlags.Checkered))
            {
                // don't trigger cautions after the checkered flag is out
                return;
            }

            if (!Properties.Settings.Default.useTotalIncidentsForCaution || incsRequiredForCaution == 0 || incCountSinceCaution < incsRequiredForCaution)
            {
                // app not configured to trigger caution or not enough incidents to trigger caution
                return;
            }

            if (cautionState != CautionState.None)
            {
                // already triggered a caution; nothing to do
                return;
            }

            if (sessionLapsRemain <= Properties.Settings.Default.lastLaps - 1)
            {
                // no cautions during configured number of last laps of the race if the race
                // distance is measured in laps
                return;
            }

            if (sessionTimeRemain <= (double)Properties.Settings.Default.lastMinutes * 60.0)
            {
                // no cautions during configured last minutes of the race for timed races
                return;
            }

            Console.WriteLine("caution conditions met; notifying caution handlers");

            // TODO: find a better way to do this (table contains no rows during unit testing)
            if (incidentsTableView.Rows.Count > 0)
            {
                // tag the incident row which triggered the caution with a yellow background in the table
                var lastRow = incidentsTableView.Rows[incidentsTableView.Rows.Count - 1];
                lastRow.DefaultCellStyle.BackColor = Color.FromName(Properties.Resources.ColorName_Gold);
            }

            // notify caution handlers
            cautionHandlers.Values.ToList().ForEach(h => h.CautionThresholdReached());

            // move to next state in caution handling cycle
            cautionState = CautionState.ThresholdReached;
        }

        /// <summary>
        /// Updates the text incident counters on the main tab.
        /// </summary>
        private void UpdateIncidentCountDisplay()
        {
            TotalIncidentCountNum.Text = totalIncCount.ToString();
            IncidentsSinceCautionNum.Text = incCountSinceCaution.ToString();
        }

        /// <summary>
        /// Checks for caution state changes. No caution=>Caution. Caution=>Green.
        /// </summary>
        /// <param name="e">Event parameters.</param>
        private void CheckFlagStateChanges(ITelemetryUpdatedEvent e)
        {
            // has caution flag been deployed?
            if (sessionFlags.Contains(SessionFlags.Caution) && cautionState == CautionState.ThresholdReached)
            {
                // notify caution handlers than the yellow flag has been thrown
                // and move to next state in caution handling cycle
                cautionHandlers.Values.ToList().ForEach(h => h.YellowFlagThrown());
                cautionState = CautionState.YellowFlagDeployed;
            }

            // has green flag been thrown?
            if (sessionFlags.Contains(SessionFlags.Green) && cautionState == CautionState.YellowFlagDeployed)
            {
                // notify caution handlers than the race has resumed and move back
                // to initial state in caution handling cycle
                cautionHandlers.Values.ToList().ForEach(h => h.GreenFlagThrown());
                cautionState = CautionState.None;
                // reset incident count
                incCountSinceCaution = 0;
            }
        }

        /// <summary>
        /// Clears incident counts from drivers.
        /// Clears all incident rows from main incidents table and allIncidentsTable.
        /// </summary>
        private void ClearIncidents()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ClearIncidents()));
                return;
            }

            incidentsTableView.Rows.Clear();
            allIncidentsTable.Rows.Clear();
            foreach (var driver in drivers.Values)
            {
                driver.NewIncs = 0;
                driver.OldIncs = 0;
                driver.TeamIncs = "";
            }
        }

        /// <summary>
        /// Updates the incident table after every new incident.
        /// </summary>
        private void UpdateIncidentsTable(Incident newInc)
		{
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateIncidentsTable(newInc)));
                return;
            }

            int rowId = allIncidentsTable.Rows.Add();
            DataGridViewRow newRow = allIncidentsTable.Rows[rowId];
            newRow.Cells[Properties.Resources.IncidentsTable_TimeStamp].Value = MakeTimeString(newInc.UpdateTime);
            newRow.Cells[Properties.Resources.IncidentsTable_CarNum].Value = cars[newInc.CarIdx].CarNumber;
            if (teamRacing)
            {
                newRow.Cells[Properties.Resources.IncidentsTable_TeamName].Value = cars[newInc.CarIdx].TeamName;
            }
            newRow.Cells[Properties.Resources.IncidentsTable_CurrentDriver].Value = cars[newInc.CarIdx].CurrentDriver;
            newRow.Cells[Properties.Resources.IncidentsTable_NewInc].Value = $"{newInc.Value}x";
            string total;
            if (teamRacing)
            {
                // iRacing-style team incidents. (TeamIncs,DriverIncs)
                total = $"{cars[newInc.CarIdx].TeamIncidentCount},{drivers[cars[newInc.CarIdx].CurrentDriver].NewIncs}";
            }
            else
            {
                total = drivers[cars[newInc.CarIdx].CurrentDriver].NewIncs.ToString();
            }
            newRow.Cells[Properties.Resources.IncidentsTable_TotalIncs].Value = total;
            newRow.Cells[Properties.Resources.IncidentsTable_CarLapNum].Value = cars[newInc.CarIdx].CurrentLap;

            if (allIncidentsTable.RowCount > 0)
            {
                allIncidentsTable.FirstDisplayedScrollingRowIndex = allIncidentsTable.RowCount - 1;
            }
        }

        /// <summary>
        /// Applies any user filtering to the allIncidentsTable.
        /// </summary>
        private void ApplyIncidentTableIncidentFilters()
		{
            switch(filterIncidentsComboBox.Text)
			{
                case "All":

                    foreach (DataGridViewRow row in allIncidentsTable.Rows)
                    {
                        row.Visible = true;   
                    }

                    break;

                case "1x":

                    foreach(DataGridViewRow row in allIncidentsTable.Rows)
					{
                        if(!(row.Cells["incidentsNewInc"].Value.ToString() == "1x"))
						{
                            row.Visible = false;
						}
                        else
                        {
                            row.Visible = true;
                        }
                    }

                    break;

                case "2x":

                    foreach (DataGridViewRow row in allIncidentsTable.Rows)
                    {
                        if (!(row.Cells["incidentsNewInc"].Value.ToString() == "2x"))
                        {
                            row.Visible = false;
                        }
                        else
                        {
                            row.Visible = true;
                        }
                    }

                    break;

                case "4x":

                    foreach (DataGridViewRow row in allIncidentsTable.Rows)
                    {
                        if (!(row.Cells["incidentsNewInc"].Value.ToString() == "4x"))
                        {
                            row.Visible = false;
                        }
                        else
                        {
                            row.Visible = true;
                        }
                    }

                    break;
            }
		}

        /// <summary>
        /// Populates the table on the Debug tab after session initialization.
        /// </summary>
        private void PopulateDebugTable()
		{
            if (InvokeRequired)
            {
                Invoke(new Action(() => PopulateDebugTable()));
                return;
            }

            debugTable.Rows.Clear();

            foreach (var car in cars.Values)
            {
                AddNewCarDebugTable(car);
            }
        }

        /// <summary>
        /// Updates the values for each car in the debugTable.
        /// </summary>
        private void UpdateDebugTable()
		{
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateDebugTable()));
                return;
            }

            foreach(DataGridViewRow row in debugTable.Rows)
			{
                if(filterNotInWorldCheckBox.Checked)
				{
                    if (cars[(int)row.Cells["debugCarID"].Value].TrackSurface == TrackSurfaces.NotInWorld)
                    {
                        row.Visible = false;
                        continue;
                    }
                }
                else
				{
                    row.Visible = true;
                    row.Cells["overallPositionInRace"].Value = cars[(int)row.Cells["debugCarID"].Value].OverallPositionInRace;
                    row.Cells["classPosition"].Value = cars[(int)row.Cells["debugCarID"].Value].ClassPositionInRace;
                    row.Cells["currentDriver"].Value = cars[(int)row.Cells["debugCarID"].Value].CurrentDriver;
                    row.Cells["percentAroundTrack"].Value = cars[(int)row.Cells["debugCarID"].Value].PercentAroundTrack;
                    if (cars[(int)row.Cells["debugCarID"].Value].BetweenPitCones)
                    {
                        row.Cells["betweenPitCones"].Value = Properties.Resources.ConeFull;
                    }
                    else
                    {
                        row.Cells["betweenPitCones"].Value = Properties.Resources.ConeEmpty;
                    }

                    row.Cells["currentLap"].Value = cars[(int)row.Cells["debugCarID"].Value].CurrentLap;
                    row.Cells["lapsCompleted"].Value = cars[(int)row.Cells["debugCarID"].Value].LapsCompleted;
                    row.Cells["trackSurface"].Value = cars[(int)row.Cells["debugCarID"].Value].TrackSurface;
                    row.Cells["trackSurfaceMaterial"].Value = cars[(int)row.Cells["debugCarID"].Value].TrackSurfaceMaterial;
                }
            }
        }

        /// <summary>
        /// Adds a new car row to the debugTable.
        /// </summary>
        /// <param name="newCar">The car to draw values from.</param>
        private void AddNewCarDebugTable(Car newCar)
		{
            int rowId = debugTable.Rows.Add();
            DataGridViewRow newRow = debugTable.Rows[rowId];
            newRow.Cells["debugCarID"].Value = newCar.CarIdx;
            newRow.Cells["debugCarNum"].Value = newCar.CarNumber;
            newRow.Cells["overallPositionInRace"].Value = newCar.OverallPositionInRace;
            newRow.Cells["classPosition"].Value = newCar.ClassPositionInRace;
            newRow.Cells["carClassName"].Value = newCar.CarClassShortName;
            newRow.Cells["currentDriver"].Value = newCar.CurrentDriver;
            newRow.Cells["percentAroundTrack"].Value = newCar.PercentAroundTrack;
            if (newCar.BetweenPitCones)
            {
                newRow.Cells["betweenPitCones"].Value = Properties.Resources.ConeFull;
            }
            else
            {
                newRow.Cells["betweenPitCones"].Value = Properties.Resources.ConeEmpty;
            }

            newRow.Cells["currentLap"].Value = newCar.CurrentLap;
            newRow.Cells["lapsCompleted"].Value = newCar.LapsCompleted;
            newRow.Cells["trackSurface"].Value = newCar.TrackSurface;
            newRow.Cells["trackSurfaceMaterial"].Value = newCar.TrackSurfaceMaterial;
        }

        /// <summary>
        /// Inserts new row in incident log.
        /// </summary>
        /// <param name="newInc"><see cref="Incident"/> object containing information about the latest incident.</param>
        private void LogNewIncident(Incident newInc)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => LogNewIncident(newInc)));
                return;
            }

            int rowId = incidentsTableView.Rows.Add();
            DataGridViewRow newRow = incidentsTableView.Rows[rowId];
            newRow.Cells[Properties.Resources.TableColumn_Time].Value = MakeTimeString(newInc.UpdateTime);
            newRow.Cells[Properties.Resources.TableColumn_CarNum].Value = cars[newInc.CarIdx].CarNumber;
            if (teamRacing)
            {
                newRow.Cells[Properties.Resources.TableColumn_Team].Value = cars[newInc.CarIdx].TeamName;
            }
            newRow.Cells[Properties.Resources.TableColumn_DriverName].Value = cars[newInc.CarIdx].CurrentDriver;
            newRow.Cells[Properties.Resources.TableColumn_Incident].Value = $"{newInc.Value}x";
            string total;
            if (teamRacing)
            {
                // iracing-style team incidents
                total = $"{cars[newInc.CarIdx].TeamIncidentCount},{drivers[cars[newInc.CarIdx].CurrentDriver].NewIncs}";
            }
            else
            {
                total = drivers[cars[newInc.CarIdx].CurrentDriver].NewIncs.ToString();
            }
            newRow.Cells[Properties.Resources.TableColumn_Total].Value = total;
            newRow.Cells[Properties.Resources.TableColumn_DriverLapNum].Value = cars[newInc.CarIdx].CurrentLap;
            this.totalIncCount += newInc.Value;
            this.incCountSinceCaution += newInc.Value;
            TotalIncidentCountNum.Text = this.totalIncCount.ToString();
            IncidentsSinceCautionNum.Text = this.incCountSinceCaution.ToString();
            if (newInc.Value == 4)
            {
                newRow.DefaultCellStyle.BackColor = System.Drawing.Color.FromName(Properties.Resources.ColorName_IndianRed);
            }

            if(incidentsTableView.RowCount > 0)
			{
                incidentsTableView.FirstDisplayedScrollingRowIndex = incidentsTableView.RowCount - 1;
            }
            
            Console.WriteLine("{0}; driver = {1}", newRow.Cells[Properties.Resources.TableColumn_Incident].Value, drivers[cars[newInc.CarIdx].CurrentDriver].FullName);
        }

        /// <summary>
        /// Takes a session time value from iRacing and returns a formatted time string: hh:mm:ss
        /// </summary>
        /// <param name="time">Session time value from iRacing.</param>
        /// <returns>Returns a formatted time string: hh:mm:ss</returns>
        public static string MakeTimeString(double time)
        {
            return TimeSpan.FromSeconds(time).ToString(@"hh\:mm\:ss");
        }

        /// <summary>
        /// Exports the contents of the IncidentsTableView to the given writer in CSV format.
        /// </summary>
        /// <param name="writer">The TextWriter to which the contents should be written.</param>
        public void ExportIncidentTableToCsv(TextWriter writer)
        {
            // write the column headers
            var headers = incidentsTableView.Columns.Cast<DataGridViewColumn>();
            writer.WriteLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            // iterate through each row of the incidents table and write
            foreach (DataGridViewRow row in incidentsTableView.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                writer.WriteLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }
        }

        public void IncidentsTableView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if ("CarNum".Equals(e.Column.Name))
            {
                var v1 = e.CellValue1.ToString();
                var v2 = e.CellValue2.ToString();
                var result = v1.Length - v2.Length;
                if (result == 0)
                {
                    var num1 = Int32.Parse(v1);
                    var num2 = Int32.Parse(v2);
                    result = num1 - num2;
                }
                e.SortResult = result;
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        /// <summary>
        /// Populates a Dictionary<name, Driver> of drivers in the current session.
        /// </summary>
        /// <param name="e">Session string changed event. Object that conatains info from session string that can be queried.</param>
        private void AddNewDrivers(SdkWrapper.SessionInfoUpdatedEventArgs e)
        {
            int carIdx = 0;
            YamlQuery query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
            while (query.TryGetValue(out string fullName))
            {
                if (fullName != null)
                {
                    if (!drivers.ContainsKey(fullName))
                    {
                        var driver = new Driver
                        {
                            CarIdx = carIdx,
                            FullName = fullName,
                            TeamName = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["TeamName"].Value,
                            CarNum = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["CarNumber"].Value,
                            IRating = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["IRating"].Value,
                            OldIncs = SafeInt(e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["CurDriverIncidentCount"].Value),
                            NewIncs = SafeInt(e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["CurDriverIncidentCount"].Value)
                        };

                        Console.WriteLine($"Adding driver {fullName}");
                        drivers.Add(fullName, driver);
                    }

                    carIdx++;
                    query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                }
            }
        }

        /// <summary>
        /// Populates a Dictionary<carIdx, Car> of cars in the current session.
        /// </summary>
        /// <param name="e">Session string changed event. Object that conatains info from session string that can be queried.</param>
        private void AddNewCars(SdkWrapper.SessionInfoUpdatedEventArgs e)
		{
            int carIdx = 0;
            YamlQuery query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx];
            while (query.TryGetValue(out string fullName))
            {
                if (fullName != null)
                {
                    if (!cars.ContainsKey(carIdx))
                    {
                        var car = new Car
                        {
                            CarIdx = carIdx,
                            CurrentDriver = fullName,
                            TeamName = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["TeamName"].Value,
                            TeamID = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["TeamID"].Value,
                            TeamIncidentCount = SafeInt(e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["TeamIncidentCount"].Value),
                            CarNumber = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["CarNumber"].Value,
                            CarClassID = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["CarClassID"].Value,
                            CarScreenName = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["CarScreenName"].Value,
                            CarClassShortName = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["CarClassShortName"].Value,
                        };

                        Console.WriteLine($"Adding car {carIdx}");
                        cars.Add(carIdx, car);
#if DEBUG
						AddNewCarDebugTable(car);
#endif
                    }

                    carIdx++;
                    query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx];
                }
            }
        }

        /// <summary>
        /// Sets any internal variables based on user changing settings.
        /// </summary>
        public void SettingsChanged()
        {
            this.incsRequiredForCaution = Properties.Settings.Default.incidentsRequired;
        }

        /// <summary>
        /// Attempts to parse an integer value from telemetry, returns a 0 if failed.
        /// </summary>
        /// <param name="v">Telemetry value to parse.</param>
        /// <returns>Returns an integer parsed from telemetry value.</returns>
        private int SafeInt(ITelemetryValue<int> v)
        {
            return v != null ? v.Value : 0;
        }

        /// <summary>
        /// Attempts to parse an double value from telemetry, returns a 0.0 if failed.
        /// </summary>
        /// <param name="v">Telemetry value to parse.</param>
        /// <returns>Returns a double parsed from telemetry value.</returns>
        private double SafeDouble(ITelemetryValue<double> v)
        {
            return v != null ? v.Value : 0.0;
        }

        /// <summary>
        /// Attempts to parse a <see cref="SessionFlag"/> value from telemetry, returns a 0 flag if failed.
        /// </summary>
        /// <param name="v">Telemetry value to parse.</param>
        /// <returns>Returns a <see cref="SessionFlag"/> parsed from telemetry value.</returns>
        private SessionFlag SafeSessionFlag(ITelemetryValue<SessionFlag> v)
        {
            return v != null ? v.Value : new SessionFlag(0);
        }

        /// <summary>
        /// Attempts to parse an integer value from a string, returns a 0 if failed.
        /// </summary>
        /// <param name="s">String value to parse.</param>
        /// <returns>Returns an integer parsed from string value.</returns>
        private int SafeInt(string s)
        {
            return System.Int32.TryParse(s, out int x) ? x : 0;
        }

#region EVENT_HANDLERS
        /// <summary>
        /// Performs some intialization of size and position of the main RaceAdmin form.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event args.</param>
        private void RaceAdminMain_Load(object sender, EventArgs e)
        {
            // location && size
            var location = new Point(Properties.Settings.Default.x, Properties.Settings.Default.y);
            Screen screen = Screen.FromPoint(location);
            if (location.X < screen.Bounds.X)
            {
                location.X = screen.Bounds.X;
            }
            else if (location.X > screen.Bounds.X + screen.Bounds.Width - 50)
            {
                location.X = screen.Bounds.X + screen.Bounds.Width - 400;
            }
            if (location.Y < screen.Bounds.Y)
            {
                location.Y = screen.Bounds.Y;
            }
            else if (location.Y > screen.Bounds.Y + screen.Bounds.Height - 50)
            {
                location.Y = screen.Bounds.Y + screen.Bounds.Height - 400;
            }

            Location = location;
            Size = new Size(Properties.Settings.Default.width, Properties.Settings.Default.height);
        }

        /// <summary>
        /// Handles the ResizeEnd event of the main RaceAdmin form.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event args.</param>
        private void RaceAdminMain_ResizeEnd(object sender, EventArgs e)
        {
            if (Size.Width >= MinimumSize.Width && Size.Height >= MinimumSize.Height)
            {
                Properties.Settings.Default.width = Size.Width;
                Properties.Settings.Default.height = Size.Height;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Closes the current environment when the X button is clicked.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">FormClosing event.</param>
        private void RaceAdminMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Location.X >= 0 && Location.Y >= 0)
            {
                Properties.Settings.Default.x = Location.X;
                Properties.Settings.Default.y = Location.Y;
                Properties.Settings.Default.Save();
            }

            Properties.Settings.Default.telemetryPollRate = telemetryPollRate;
            Properties.Settings.Default.Save();

            wrapper.Stop();
            Environment.Exit(0);
        }

        /// <summary>
        /// Exports the incidents table to a CSV file when the Export... button is clicked.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">EventArgs event.</param>
        private void ExportButton_Click(object sender, EventArgs e)
        {
            Thread t = new Thread((ThreadStart)(() =>
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Title = "Export...",
                    FileName = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".csv",
                    Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Stream outputStream = saveFileDialog.OpenFile();
                    if (outputStream != null)
                    {
                        var outputWriter = new StreamWriter(outputStream);
                        ExportIncidentTableToCsv(outputWriter);
                        outputWriter.Close();
                    }
                }
            }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }

        /// <summary>
        /// Opens the Settings dialog box.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">EventArgs event.</param>
        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            Form settings = new SettingsDialog(this);
            settings.Show();
        }

        /// <summary>
        /// Checks or unchecks the menu item.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event parameters.</param>
        private void hideIncidentTableMenuItem_Click(object sender, EventArgs e)
        {
            hideIncidentTableMenuItem.Checked = !hideIncidentTableMenuItem.Checked;
        }

        /// <summary>
        /// Checks or unchecks the menu item.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event parameters.</param>
        private void hideIncidentsCountMenuItem_Click(object sender, EventArgs e)
        {
            hideIncidentsCountMenuItem.Checked = !hideIncidentsCountMenuItem.Checked;
        }

        /// <summary>
        /// Checks or unchecks the menu item.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event parameters.</param>
		private void hideCautionPanelMenuItem_Click(object sender, EventArgs e)
        {
            hideCautionPanelMenuItem.Checked = !hideCautionPanelMenuItem.Checked;
        }

        /// <summary>
        /// Shows or hides the caution indicator panel based on the checked status.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event parameters.</param>
		private void hideCautionPanelMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (hideCautionPanelMenuItem.Checked)
            {
                cautionPanel.Visible = true;
            }
            else
            {
                cautionPanel.Visible = false;
            }
        }

        /// <summary>
        /// Shows or hides the incident table based on the checked status.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event parameters.</param>
		private void hideIncidentTableMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (hideIncidentTableMenuItem.Checked)
            {
                incidentsTableView.Visible = true;
            }
            else
            {
                incidentsTableView.Visible = false;
            }
        }

        /// <summary>
        /// Shows or hides the incident count panel based on the checked status.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event parameters.</param>
		private void hideIncidentsCountMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (hideIncidentsCountMenuItem.Checked)
            {
                incidentCountPanel.Visible = true;
            }
            else
            {
                incidentCountPanel.Visible = false;
            }
        }

        /// <summary>
        /// Sets the poll rate of live telemetry after the user changed the value.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event parameters.</param>
        private void telemetryPollRateTextBox_TextChanged(object sender, EventArgs e)
        {
            if(System.Int32.TryParse(telemetryPollRateTextBox.Text, out int x))
			{
                if(x > 60)
				{
                    x = 60;
				}

                if(x < 1)
				{
                    x = 1;
				}

                telemetryPollRate = x;
                wrapper.SetTelemetryUpdateFrequency(telemetryPollRate);
                telemetryPollRateTextBox.BackColor = Color.White;
            }
            else
			{
                telemetryPollRateTextBox.BackColor = Color.MistyRose;
			}
        }

        /// <summary>
        /// Handles the Exit menu item.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event parameters.</param>
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            if (Location.X >= 0 && Location.Y >= 0)
            {
                Properties.Settings.Default.x = Location.X;
                Properties.Settings.Default.y = Location.Y;
                Properties.Settings.Default.Save();
            }

            Properties.Settings.Default.telemetryPollRate = telemetryPollRate;
            Properties.Settings.Default.Save();

            wrapper.Stop();
            Environment.Exit(0);
        }

        /// <summary>
        /// Handles the event of the incidents table incident type drop down value has changed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event args.</param>
        private void filterIncidentsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyIncidentTableIncidentFilters();
        }
        #endregion EVENT_HANDLERS

#region PUBLIC_PROPERTIES
        /// <summary>
        /// Gets or sets the cautionHandlers field.
        /// </summary>
        public Dictionary<string, ICautionHandler> CautionHandlers;
#endregion PUBLIC_PROPERTIES

        // Code in the region below is used to generate test data or to simulate behavior 
        // for UI testing. To use, create buttons on the form and connect them to the various
        // event handler methods below.
#region TESTING

        // these are added for testing only
        public int IncsRequiredForCaution { get => incsRequiredForCaution; set => incsRequiredForCaution = value; }
        public int SessionUniqueID { get => sessionUniqueID; }
        public int TotalIncCount { get => totalIncCount; }
        public int IncCountSinceCaution { get => incCountSinceCaution; set => incCountSinceCaution = value; }
        public int LastLaps { set => Properties.Settings.Default.lastLaps = value; }
        public int LastMinutes { set => Properties.Settings.Default.lastMinutes = value; }
        public bool RaceSession { set => raceSession = value; }
        public CautionState CautionState { get => cautionState; }
        public Dictionary<string, Driver> Drivers { get => drivers; }
        private int testCurrentLap = 1;
        private void Test_AddIncidentRow(object sender, EventArgs e)
        {
            testCurrentLap = MakeRandomLap();

            var rng = new Random();
            var newIncidents = (int)Math.Pow(2, rng.Next(3));

            Driver driver = new Driver()
            {
                CarIdx = 0,
                FullName = MakeRandomName(),
                CarNum = MakeRandomCarNumber(),
                IRating = "",
                OldIncs = 0,
                NewIncs = newIncidents,
                CurrentLap = testCurrentLap
            };

            Incident newInc = new Incident(0.0, DateTime.Now, driver.NewIncs, driver.CarIdx);

            LogNewIncident(newInc);
        }
        private static string MakeRandomName()
        {
            var rng = new Random();
            var names = rng.Next(2, 5);

            var name = new StringBuilder();
            for (var i = 0; i < names; i++)
            {
                var characters = rng.Next(8) + 3;
                for (var j = 0; j < characters; j++)
                {
                    var character = (char)rng.Next('a', 'z');
                    if (j == 0)
                    {
                        character = character.ToString().ToUpper()[0];
                    }
                    name.Append(character);
                }
                if (i < (names - 1))
                {
                    if (rng.NextDouble() < 0.05)
                    {
                        name.Append("-");
                    }
                    else
                    {
                        name.Append(" ");
                    }
                }
            }
            return name.ToString();
        }
        private string MakeRandomCarNumber()
        {
            var rng = new Random();
            var digits = rng.Next(3) + 1;
            var sb = new StringBuilder();
            for (var i = 0; i < digits; i++)
            {
                var digit = rng.Next(10);
                sb.Append(digit.ToString());
            }
            return sb.ToString();
        }
        private int MakeRandomLap()
        {
            var rng = new Random();
            return testCurrentLap + rng.Next(2);
        }
        public void SetTestCautionHandlers(Dictionary<string, ICautionHandler> cautionHandlers)
        {
            CautionHandlers = cautionHandlers;
        }
		#endregion TESTING
		// Code in the region above is used to generate test data or to simulate behavior 
		// for UI testing. To use, create buttons on the form and connect them to the various
		// event handler methods above.
	}
}
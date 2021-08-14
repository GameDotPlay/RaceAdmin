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

namespace RaceAdmin
{
    using SessionFlags = iRacingSdkWrapper.Bitfields.SessionFlags;

    /// <summary>
    /// Tracks the current state of the caution handling system.
    /// </summary>
    public enum CautionState
    {
        /// <summary>
        /// Initial state.
        /// </summary>
        None,

        /// <summary>
        /// Indicates that the application incident threshold for a caution 
        /// has been reached.
        /// </summary>
        ThresholdReached,

        /// <summary>
        /// Indicates that a full course yellow has been initiated within
        /// iRacing.
        /// </summary>
        YellowFlagDeployed
    }

    public partial class RaceAdminMain : Form
    {
        public const int DefaultSessionNum = 0;
        public const int DefaultSessionUniqueID = 1;
        private const float IgnorePitEntryPercentageThreshold = 60f;

        /// <summary>
        /// Tracks the current caution state on track.
        /// </summary>
        private CautionState cautionState = CautionState.None;

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
        /// The number of incidents required for a caution to be triggeed. Set by user in 
        /// IncsRequiredForCautionTextBox object.
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
        private SessionFlag sessionFlags = new SessionFlag(0);

        /// <summary>
        /// Driver dictionary keyed by driver full name. Used to store data about
        /// all drivers in the race meeting. Drivers are never removed once added.
        /// The pace car may also be contained in this dictionary.
        /// </summary>
        private Dictionary<string, Driver> drivers = new Dictionary<string, Driver>();

        /// <summary>
        /// Car dictionary keyed by carId. Used to store data about
        /// all cars in the race meeting. Cars are never removed once added.
        /// The pace car may also be contained in this dictionary.
        /// </summary>
        private Dictionary<int, Car> cars = new Dictionary<int, Car>();

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
        /// List of PercentAroundTrack values for all cars as they entered pit road.
        /// </summary>
        private List<float> allCarsPitEntryLocations;

        /// <summary>
        /// List of PercentAroundTrack values for all cars as they exited pit road.
        /// </summary>
        private List<float> allCarsPitExitLocations;

        /// <summary>
        /// Running average location of the pit entry cones. Updated every time a car enters pit road. Should get more accurate over time.
        /// </summary>
        private float averagePitEntryLocation;

        /// <summary>
        /// Running average location of the pit exit cones. Updated every time a car exits pit road. Should get more accurate over time.
        /// </summary>
        private float averagePitExitLocation;


        // these are added for testing only
        public int IncsRequiredForCaution { get => incsRequiredForCaution; set => incsRequiredForCaution = value; }
        public int SessionUniqueID { get => sessionUniqueID; }
        public int TotalIncCount { get => totalIncCount; }
        public int IncCountSinceCaution { get => incCountSinceCaution; set => incCountSinceCaution = value; }
        public int LastLaps { set => lastLaps.Value = value; }
        public int LastMinutes { set => lastMinutes.Value = value; }
        public bool RaceSession { set => raceSession = value; }
        public CautionState CautionState { get => cautionState; }
        public Dictionary<string, Driver> Drivers { get => drivers; }

        /// <summary>
        /// Constructor for RaceAdminMain form. Initialization of WinForm, SdkWrapper, start wrapper object.
        /// </summary>
        public RaceAdminMain(ISdkWrapper wrapper)
        {
            // Initialize WinForm
            InitializeComponent();

            string version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
            this.versionLabel.Text = String.Format("v{0}", version);

            this.wrapper = wrapper;
            this.cautionHandlers = new Dictionary<string, ICautionHandler>
            {
                { "default", new DefaultCautionHandler(this.CautionPanel) }
            };

            // Initialize variables.
            allCarsPitEntryLocations = new List<float>();
            allCarsPitExitLocations = new List<float>();

            // Listen to events
            wrapper.AddTelemetryUpdateHandler(OnTelemetryUpdated);
            wrapper.AddSessionInfoUpdateHandler(OnSessionInfoUpdated);

            // Set telemetry update rate.
            wrapper.SetTelemetryUpdateFrequency(4); // Hz

            // Start the wrapper.
            wrapper.Start();
        }

        // used for testing only
        public void SetTestCautionHandlers(Dictionary<string, ICautionHandler> cautionHandlers)
        {
            this.cautionHandlers = cautionHandlers;
        }

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

            // full course yellow settings
            detectTowForCautionCheckBox.Checked = Properties.Settings.Default.detectTowForCaution;
            useTotalIncidentsForCautionCheckBox.Checked = Properties.Settings.Default.useTotalIncidentsForCaution;
            incidentsRequired.Value = Properties.Settings.Default.incidentsRequired;
            audioNotification.Checked = Properties.Settings.Default.audioNotification;
            autoThrowCaution.Checked = Properties.Settings.Default.autoThrowCaution;
            lastLaps.Value = Properties.Settings.Default.lastLaps;
            lastMinutes.Value = Properties.Settings.Default.lastMinutes;
            if (!useTotalIncidentsForCautionCheckBox.Checked)
            {
                incidentsRequired.Visible = false;
                incidentsRequiredForCautionLabel.Visible = false;
            }

            // general settings
            hideIncidents.Checked = Properties.Settings.Default.hideIncidents;
        }

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

            wrapper.Stop();
            Environment.Exit(0);
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

            AddNewCarsAndDrivers(e);
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
                if (hideIncidents.Checked)
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
        }

        private void ObscureIncidents()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ObscureIncidents()));
                return;
            }

            ObscurePanel1.Visible = true;
            ObscurePanel1.BringToFront();
            ObscurePanel2.Visible = true;
            ObscurePanel2.BringToFront();
        }

        private void ShowIncidents()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ShowIncidents()));
                return;
            }

            ObscurePanel1.Visible = false;
            ObscurePanel1.SendToBack();
            ObscurePanel2.Visible = false;
            ObscurePanel2.SendToBack();
        }

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

                if (!drivers.TryGetValue(name, out Driver driver))
                {
                    carIdx++;
                    query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                    Console.WriteLine("ERROR: driver {0} not found in session driver list", name);
                    continue;
                }

                if (teamRacing)
                {
                    driver.TeamIncs = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["TeamIncidentCount"].Value;
                }

                query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["CurDriverIncidentCount"];
                query.TryGetValue(out string s_newIncs);
                System.Int32.TryParse(s_newIncs, out int i_newIncs);

                // delta can be negative if a driver or the person running the RaceAdmin program 
                // disconnects and then reconnects; overall the negative rows and then the positive
                // rows added back total up to the same amount, so we can just ignore these. The negative
                // rows cause confusion and make the incident count fluctuate unnaturally.
                var delta = i_newIncs - driver.OldIncs;
                if (delta > 0)
                {
                    driver.NewIncs = i_newIncs;
                    LogNewIncident(e.SessionInfo.UpdateTime, driver, delta);
                    driver.OldIncs = driver.NewIncs;
                }

                carIdx++;
                query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
            }
        }

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

                if (!cars.TryGetValue(carIdx, out Car car))
                {
                    carIdx++;
                    query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                    Console.WriteLine("ERROR: car {0} not found in session driver list", carIdx);
                    continue;
                }

                car.TeamIncidentCount = SafeInt(e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["TeamIncidentCount"].Value);

                carIdx++;
                query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
            }
        }

        /// <summary>
        /// Called every time the live telemetry gets updates. Currently configured to 4 times per second by setting wrapper.TelemetryUpdateFrequency. No need to update this 60 times per second.
        /// Used as a known clock tick for animating color changes on CautionPanel after Incs required for caution value is reached.
        /// Checks current session ID to see if new session initialization should take place.
        /// Checks for change in flag state. When session goes green again after a caution the incs since last caution field is reset to zero.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Telemetry data changed event.</param>
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
            UpdatePitConePercentages();
            CheckIncidentLimit();
            UpdateIncidentCountDisplay();
            CheckFlagStateChanges(e);
        }

        /// <summary>
        /// Executes every OnTelemetryUpdated().
        /// Iterates through every car in the session and checks if they have entered/exited pit road.
        /// If a car has entered or exited pit road since the last update, add the respective PercentAroundTrack value to the ongoing average for all cars.
        /// </summary>
        private void UpdatePitConePercentages()
		{
            // Iterate over every car in the session and check if they've entered/exited pit road since the last update.
            foreach(KeyValuePair<int, Car> car in cars)
			{
                // Car has entered or exited pit road since last update.
                if(car.Value.BetweenPitCones != car.Value.LastBetweenPitCones)
				{
                    // To cut down on outliers...
                    // If the car hasn't completed at least this percentage of the track then ignore this pit entry for calculating averages.
                    // If the car is between the pit entry/exit zones but still on racing surface (stopped on start/finish straight for example) then ignore pit entry for calculating averages.
                    if ((car.Value.PercentAroundTrack < IgnorePitEntryPercentageThreshold) ||
                        ((car.Value.PercentAroundTrack > averagePitEntryLocation) &&
                        (car.Value.PercentAroundTrack < averagePitExitLocation) &&
                        (car.Value.TrackSurface == TrackSurfaces.OnTrack)))
                    {
                        continue;
                    }
                    else
					{
                        // Car has entered pit road since last update.
                        if (car.Value.BetweenPitCones)
                        {
                            allCarsPitEntryLocations.Add(car.Value.PercentAroundTrack);
                        }
                    }
                    
                    // Always record pit exit location.
                    if(!car.Value.BetweenPitCones) // Car has exited pit road since last update.
					{
                        allCarsPitExitLocations.Add(car.Value.PercentAroundTrack);
                    }

                    // Update the average pit entry/exit locations.
                    averagePitEntryLocation = allCarsPitEntryLocations.Average();
                    averagePitExitLocation = allCarsPitExitLocations.Average();
                }
			}
		}

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

            if (!useTotalIncidentsForCautionCheckBox.Checked || incsRequiredForCaution == 0 || incCountSinceCaution < incsRequiredForCaution)
            {
                // app not configured to trigger caution or not enough incidents to trigger caution
                return;
            }

            if (cautionState != CautionState.None)
            {
                // already triggered a caution; nothing to do
                return;
            }

            if (sessionLapsRemain <= lastLaps.Value - 1)
            {
                // no cautions during configured number of last laps of the race if the race
                // distance is measured in laps
                return;
            }

            if (sessionTimeRemain <= (double)lastMinutes.Value * 60.0)
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

        private void UpdateIncidentCountDisplay()
        {
            TotalIncidentCountNum.Text = totalIncCount.ToString();
            IncidentsSinceCautionNum.Text = incCountSinceCaution.ToString();
        }

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

        private void ClearIncidents()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ClearIncidents()));
                return;
            }

            incidentsTableView.Rows.Clear();
            foreach (var driver in drivers.Values)
            {
                driver.NewIncs = 0;
                driver.OldIncs = 0;
                driver.TeamIncs = "";
            }
        }

        /// <summary>
        /// Inserts new row in incident log.
        /// </summary>
        /// <param name="driver">Driver associated with the latest incident.</param>
        /// <param name="delta">The number of incident points gained by this driver on this occasion.</param>
        public void LogNewIncident(double timestamp, Driver driver, int delta)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => LogNewIncident(timestamp, driver, delta)));
                return;
            }

            StringBuilder sb = new StringBuilder();
            int rowId = incidentsTableView.Rows.Add();
            DataGridViewRow newRow = incidentsTableView.Rows[rowId];
            newRow.Cells[Properties.Resources.TableColumn_Time].Value = MakeTimeString(timestamp);
            newRow.Cells[Properties.Resources.TableColumn_CarNum].Value = driver.CarNum;
            if (teamRacing)
            {
                newRow.Cells[Properties.Resources.TableColumn_Team].Value = driver.TeamName;
            }
            newRow.Cells[Properties.Resources.TableColumn_DriverName].Value = driver.FullName;
            sb.Append(delta + "x");
            newRow.Cells[Properties.Resources.TableColumn_Incident].Value = sb.ToString();
            String total;
            if (teamRacing)
            {
                // iracing-style team incidents
                total = String.Format("{0},{1}", driver.TeamIncs, driver.NewIncs);
            }
            else
            {
                total = driver.NewIncs.ToString();
            }
            newRow.Cells[Properties.Resources.TableColumn_Total].Value = total;
            newRow.Cells[Properties.Resources.TableColumn_DriverLapNum].Value = driver.CurrentLap;
            this.totalIncCount += delta;
            this.incCountSinceCaution += delta;
            TotalIncidentCountNum.Text = this.totalIncCount.ToString();
            IncidentsSinceCautionNum.Text = this.incCountSinceCaution.ToString();
            if (delta == 4)
            {
                newRow.DefaultCellStyle.BackColor = System.Drawing.Color.FromName(Properties.Resources.ColorName_IndianRed);
            }
            incidentsTableView.FirstDisplayedScrollingRowIndex = incidentsTableView.RowCount - 1;

            Console.WriteLine("{0}; driver = {1}", newRow.Cells[Properties.Resources.TableColumn_Incident].Value, driver.FullName);
        }

        public static string MakeTimeString(double time)
        {
            return TimeSpan.FromSeconds(time).ToString(@"hh\:mm\:ss");
        }

        /// <summary>
        /// Populates a Dictionary<name, Driver> of drivers in the current session.
        /// Populates a Dictionary<CarIdx, Car> of cars in the current session.
        /// </summary>
        /// <param name="e">Session string changed event. Object that conatains info from session string that can be queried.</param>
        private void AddNewCarsAndDrivers(SdkWrapper.SessionInfoUpdatedEventArgs e)
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
                            OldIncs = SafeInt(e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["CurDriverIncidentCount"].Value)
                        };

                        Console.WriteLine("Adding driver {0}", fullName);
                        drivers.Add(fullName, driver);
                    }

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

                        Console.WriteLine("Adding car {0}", carIdx);
                        cars.Add(carIdx, car);
                    }

                    carIdx++;
                    query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                }
            }
        }

        /// <summary>
        /// Started making this as separate from AddNewDrivers but 80% of it is the same so I added the important bits to AddNewDrivers() and renamed the method.
        /// Might be better in the future to keep these separate so I'll keep this method here for now, but it is not used.
        /// </summary>
        /// <param name="e">Session string changed event. Object that conatains info from session string that can be queried.</param>
        private void AddNewCars(SdkWrapper.SessionInfoUpdatedEventArgs e)
		{
            int carIdx = 0;
            YamlQuery query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
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

                        Console.WriteLine("Adding car {0}", carIdx);
                        cars.Add(carIdx, car);
                    }

                    carIdx++;
                    query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                }
            }
        }

        private int SafeInt(ITelemetryValue<int> v)
        {
            return v != null ? v.Value : 0;
        }

        private double SafeDouble(ITelemetryValue<double> v)
        {
            return v != null ? v.Value : 0.0;
        }

        private SessionFlag SafeSessionFlag(ITelemetryValue<SessionFlag> v)
        {
            return v != null ? v.Value : new SessionFlag(0);
        }

        private int SafeInt(string s)
        {
            return System.Int32.TryParse(s, out int x) ? x : 0;
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

        private void DetectTowForCaution_CheckChanged(object sender, EventArgs e)
		{
            Properties.Settings.Default.detectTowForCaution = detectTowForCautionCheckBox.Checked;
            Properties.Settings.Default.Save();
		}

        private void UseTotalIncidentsForCaution_CheckChanged(object sender, EventArgs e)
		{
            incidentsRequired.Visible = !incidentsRequired.Visible;
            incidentsRequiredForCautionLabel.Visible = !incidentsRequiredForCautionLabel.Visible;

            Properties.Settings.Default.useTotalIncidentsForCaution = useTotalIncidentsForCautionCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void HideIncidents_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.hideIncidents = hideIncidents.Checked;
            Properties.Settings.Default.Save();
        }

        private void IncidentsRequired_ValueChanged(object sender, EventArgs e)
        {
            incsRequiredForCaution = (int)incidentsRequired.Value;

            Properties.Settings.Default.incidentsRequired = incsRequiredForCaution;
            Properties.Settings.Default.Save();
        }

        private void AudioNotification_CheckedChanged(object sender, EventArgs e)
        {
            if (audioNotification.Checked)
            {
                var player = new SoundPlayer(RaceAdmin.Resources.Caution);
                var handler = new AudioCautionHandler(new SoundPlayerProxy(player))
                {
                    Repeat = 5, // times
                    Interval = 1000 // ms
                };

                cautionHandlers.Add("audio", handler);
            }
            else
            {
                cautionHandlers.Remove("audio");
            }

            Properties.Settings.Default.audioNotification = audioNotification.Checked;
            Properties.Settings.Default.Save();
        }

        private void AutoThrowCaution_CheckedChanged(object sender, EventArgs e)
        {
            if (autoThrowCaution.Checked)
            {
                cautionHandlers.Add("throw", new ThrowCautionHandler());
            }
            else
            {
                cautionHandlers.Remove("throw");
            }
            Properties.Settings.Default.autoThrowCaution = autoThrowCaution.Checked;
            Properties.Settings.Default.Save();
        }

        private void LastLaps_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.lastLaps = (int)lastLaps.Value;
            Properties.Settings.Default.Save();
        }

        private void LastMinutes_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.lastMinutes = (int)lastMinutes.Value;
            Properties.Settings.Default.Save();
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

        // Code below this comment is used to generate test data or to simulate behavior 
        // for UI testing. To use, create buttons on the form and connect them to the various
        // event handler methods below.

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

            LogNewIncident(0.0, driver, newIncidents);
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

        // Code above this comment is used to generate test data or to simulate behavior 
        // for UI testing. To use, create buttons on the form and connect them to the various
        // event handler methods above.
    }
}

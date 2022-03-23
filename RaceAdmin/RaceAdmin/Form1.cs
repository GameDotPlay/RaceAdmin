namespace RaceAdmin
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
	using System.Reflection;
	using System.Text;
	using System.Threading;
	using System.Windows.Forms;
	using SessionFlags = iRacingSdkWrapper.Bitfields.SessionFlags;

	public partial class RaceAdminMain : Form
    {
        /// <summary>
        /// Default session number. 0.
        /// </summary>
        public const int DefaultSessionNum = 0;

        /// <summary>
        /// Default session unique ID. 1.
        /// </summary>
        public const int DefaultSessionUniqueID = 1;

        /// <summary>
        /// Used as an upper bounds for looping through all CarIdx in a session.
        /// Can be greater than max drivers because of unique people coming and going. 
        /// Each driver has a unique CarIdx.
        /// </summary>
        private const int MAX_CARIDX = 75;

        /// <summary>
        /// The About form window.
        /// </summary>
        private About aboutForm;

        /// <summary>
        /// Tracks the current caution state on track.
        /// </summary>
        private CautionState cautionState = CautionState.None;

        /// <summary>
        /// The rate at which to poll the live telemetry. Can be changed by the user at runtime on the Debug tab of the UI. Persists on app close. Default = 4.
        /// </summary>
        private int telemetryPollRate = 4;

        /// <summary>
        /// The total count of incidents since the current session started.
        /// </summary>
        private int totalIncCount = 0;

        /// <summary>
        /// The total number of incidents that have been logged since the creation of the table.
        /// This is tracked separately since the totalIncCount can be reset to 0.
        /// </summary>
        private int totalIncidentCountOfTable = 0;

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
        private int teamRacing;

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
        /// Backing data source for the main incidents table. Shown on UI as an AdvancedDataGridView based on user filters.
        /// </summary>
        private DataTable incidentsDataTable;

        /// <summary>
        /// Binding source for the incidents table.
        /// </summary>
        private BindingSource incidentsBindingSource;

        /// <summary>
        /// Backing data source for the debug table. Shown on UI as an AdvancedDataGridView based on user filters.
        /// </summary>
        private DataTable debugDataTable;

        /// <summary>
        /// Binding source for the debug table.
        /// </summary>
        private BindingSource debugBindingSource;

        /// <summary>
        /// Gets parsed from the time string value of the incident row. 
        /// </summary>
        private double? timeFrameFilterBegin = null;

        /// <summary>
        /// Gets parsed from the time string value of the incident row. 
        /// </summary>
        private double? timeFrameFilterEnd = null;

        /// <summary>
        /// Constructor for RaceAdminMain form. Initialization of WinForm, SdkWrapper, start wrapper object.
        /// </summary>
        public RaceAdminMain(ISdkWrapper wrapper)
        {
            // Initialize WinForm
            InitializeComponent();

#if !DEBUG
            tabControl.TabPages[0].Controls.Remove(addTestRowButton);
#endif
            InitializeDebugDataSource();
            InitializeDebugGridView();

            this.wrapper = wrapper;
            cautionHandlers = new Dictionary<string, ICautionHandler>
            {
                { "default", new DefaultCautionHandler(this.cautionPanel) }
            };
            CautionHandlers = cautionHandlers;

            // Initialize variables and starting state.
            drivers = new Dictionary<string, Driver>();
            cars = new Dictionary<int, Car>();
            sessionFlags = new SessionFlag(0);
            telemetryPollRate = Properties.Settings.Default.telemetryPollRate;
            telemetryPollRateTextBox.Text = telemetryPollRate.ToString();
            incsRequiredForCaution = Properties.Settings.Default.incidentsRequired;
            InitializeIncidentsDataSource();
            InitializeIncidentsGridView();
            incidentsTimeFilterComboBox.SelectedIndex = 0;
            timeFrameFilterErrorText.Visible = false;
            timeFrameFilterComboBox1.SelectedIndex = 0;

            // Listen to events
            wrapper.AddTelemetryUpdateHandler(OnTelemetryUpdated);
            wrapper.AddSessionInfoUpdateHandler(OnSessionInfoUpdated);

            // Set telemetry update rate.
            wrapper.SetTelemetryUpdateFrequency(telemetryPollRate); // Hz

            // Start the wrapper.
            wrapper.Start();
        }

        /// <summary>
        /// Initializes the incidents data table datasource and initializes the column types.
        /// </summary>
        private void InitializeIncidentsDataSource()
		{
            incidentsDataTable = new DataTable("incidentsDataTable");
            incidentsBindingSource = new BindingSource();
            InitializeIncidentsDataTableColumns(incidentsDataTable.Columns);
            incidentsBindingSource.DataSource = incidentsDataTable;
        }

        /// <summary>
        /// Initializes the debug data table datasource and initializes the column types.
        /// </summary>
        private void InitializeDebugDataSource()
		{
            debugDataTable = new DataTable("debugDataTable");
            debugBindingSource = new BindingSource();
            InitializeDebugDataTableColumns(debugDataTable.Columns);
            debugBindingSource.DataSource = debugDataTable;
        }

        /// <summary>
        /// Sets up column properties for the debug table.
        /// </summary>
        /// <param name="columns"><see cref="DataColumnCollection"/> of the debug columns.</param>
        private void InitializeDebugDataTableColumns(DataColumnCollection columns)
		{
            DataColumn carIdxColumn = new DataColumn(Properties.Resources.DebugTable_CarIdx, typeof(int));
            columns.Add(carIdxColumn);

            DataColumn carNumberColumn = new DataColumn(Properties.Resources.DebugTable_CarNumber, typeof(string));
            columns.Add(carNumberColumn);

            DataColumn carOverallPositionColumn = new DataColumn(Properties.Resources.DebugTable_CarOverallPosition, typeof(int));
            columns.Add(carOverallPositionColumn);

            DataColumn carClassPositionColumn = new DataColumn(Properties.Resources.DebugTable_CarClassPosition, typeof(int));
            columns.Add(carClassPositionColumn);

            DataColumn carClassShortNameColumn = new DataColumn(Properties.Resources.DebugTable_CarClassShortName, typeof(string));
            columns.Add(carClassShortNameColumn);

            DataColumn driverNameColumn = new DataColumn(Properties.Resources.DebugTable_DriverName, typeof(string));
            columns.Add(driverNameColumn);

            DataColumn carPercentAroudTrackColumn = new DataColumn(Properties.Resources.DebugTable_CarPercentAroundTrack, typeof(string));
            columns.Add(carPercentAroudTrackColumn);

            DataColumn carBetweenPitConesColumn = new DataColumn(Properties.Resources.DebugTable_CarBetweenPitCones, typeof(Image));
            columns.Add(carBetweenPitConesColumn);

            DataColumn carCurrentLapColumn = new DataColumn(Properties.Resources.DebugTable_CarCurrentLap, typeof(int));
            columns.Add(carCurrentLapColumn);

            DataColumn carLapsCompletedColumn = new DataColumn(Properties.Resources.DebugTable_CarLapsCompleted, typeof(int));
            columns.Add(carLapsCompletedColumn);

            DataColumn carTrackSurfaceColumn = new DataColumn(Properties.Resources.DebugTable_CarTrackSurface, typeof(TrackSurfaces));
            columns.Add(carTrackSurfaceColumn);

            DataColumn carTrackSurfaceMaterialColumn = new DataColumn(Properties.Resources.DebugTable_CarTrackSurfaceMaterial, typeof(TrackSurfaceMaterials));
            columns.Add(carTrackSurfaceMaterialColumn);
        }

        /// <summary>
        /// Initializes the DataGridView properties of the debug table columns.
        /// </summary>
        private void InitializeDebugGridView()
		{
            debugTable.AutoGenerateColumns = true;
            debugTable.DataSource = debugBindingSource;
            debugTable.SetDoubleBuffered();

            debugTable.Columns[Properties.Resources.DebugTable_CarIdx].HeaderText = "CarIdx";
            debugTable.Columns[Properties.Resources.DebugTable_CarIdx].Width = (int)DebugTableColumnWidths.CarIdxColumnWidth;

            debugTable.Columns[Properties.Resources.DebugTable_CarNumber].HeaderText = "Car #";
            debugTable.Columns[Properties.Resources.DebugTable_CarNumber].Width = (int)DebugTableColumnWidths.CarNumberColumnWidth;

            debugTable.Columns[Properties.Resources.DebugTable_CarOverallPosition].Width = (int)DebugTableColumnWidths.CarOverallPositionColumnWidth;
            debugTable.Columns[Properties.Resources.DebugTable_CarOverallPosition].HeaderText = "Position";

            debugTable.Columns[Properties.Resources.DebugTable_CarClassPosition].Width = (int)DebugTableColumnWidths.CarClassPositionColumnWidth;
            debugTable.Columns[Properties.Resources.DebugTable_CarClassPosition].HeaderText = "Class Position";

            debugTable.Columns[Properties.Resources.DebugTable_CarClassShortName].Width = (int)DebugTableColumnWidths.CarClassShortNameColumnWidth;
            debugTable.Columns[Properties.Resources.DebugTable_CarClassShortName].HeaderText = "Class";

            debugTable.Columns[Properties.Resources.DebugTable_DriverName].HeaderText = "Driver Name";
            debugTable.Columns[Properties.Resources.DebugTable_DriverName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            debugTable.Columns[Properties.Resources.DebugTable_CarPercentAroundTrack].Width = (int)DebugTableColumnWidths.CarPercentAroundTrackColumnWidth;
            debugTable.Columns[Properties.Resources.DebugTable_CarPercentAroundTrack].HeaderText = "% Around Track";

            debugTable.Columns[Properties.Resources.DebugTable_CarBetweenPitCones].Width = (int)DebugTableColumnWidths.CarBetweenPitConesColumnWidth;
            debugTable.Columns[Properties.Resources.DebugTable_CarBetweenPitCones].HeaderText = "Pit Cones";

            debugTable.Columns[Properties.Resources.DebugTable_CarCurrentLap].Width = (int)DebugTableColumnWidths.CarCurrentLapColumnWidth;
            debugTable.Columns[Properties.Resources.DebugTable_CarCurrentLap].HeaderText = "Current Lap";

            debugTable.Columns[Properties.Resources.DebugTable_CarLapsCompleted].Width = (int)DebugTableColumnWidths.CarLapsCompletedColumnWidth;
            debugTable.Columns[Properties.Resources.DebugTable_CarLapsCompleted].HeaderText = "Laps Completed";

            debugTable.Columns[Properties.Resources.DebugTable_CarTrackSurface].HeaderText = "Track Surface";
            debugTable.Columns[Properties.Resources.DebugTable_CarTrackSurface].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            debugTable.Columns[Properties.Resources.DebugTable_CarTrackSurfaceMaterial].HeaderText = "Surface Material";
            debugTable.Columns[Properties.Resources.DebugTable_CarTrackSurfaceMaterial].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        /// <summary>
        /// Initializes the DataGridView properties of the incident table columns.
        /// </summary>
        private void InitializeIncidentsGridView()
		{
            incidentsView.AutoGenerateColumns = true;
            incidentsView.DataSource = incidentsBindingSource;
            incidentsView.SetDoubleBuffered();

            incidentsView.Columns[Properties.Resources.IncidentsTable_HiddenTimeStamp].Visible = false;

            incidentsView.Columns[Properties.Resources.IncidentsTable_LocalTime].HeaderText = "Local Time";
            incidentsView.Columns[Properties.Resources.IncidentsTable_LocalTime].Width = (int)IncidentTableColumnWidths.LocalTimeColumnWidth;
            incidentsView.DisableFilterChecklist(incidentsView.Columns[Properties.Resources.IncidentsTable_LocalTime]);
            incidentsView.DisableFilterCustom(incidentsView.Columns[Properties.Resources.IncidentsTable_LocalTime]);

            incidentsView.Columns[Properties.Resources.IncidentsTable_SessionTime].HeaderText = "Session Time";
            incidentsView.Columns[Properties.Resources.IncidentsTable_SessionTime].Width = (int)IncidentTableColumnWidths.SessionTimeColumnWidth;
            incidentsView.DisableFilterChecklist(incidentsView.Columns[Properties.Resources.IncidentsTable_SessionTime]);
            incidentsView.DisableFilterCustom(incidentsView.Columns[Properties.Resources.IncidentsTable_SessionTime]);

            incidentsView.Columns[Properties.Resources.IncidentsTable_CarClass].Width = (int)IncidentTableColumnWidths.CarClassColumnWidth;
            incidentsView.Columns[Properties.Resources.IncidentsTable_CarClass].HeaderText = "Car Class";

            incidentsView.Columns[Properties.Resources.IncidentsTable_CarNumber].Width = (int)IncidentTableColumnWidths.CarNumberColumnWidth;
            incidentsView.Columns[Properties.Resources.IncidentsTable_CarNumber].HeaderText = "Car #";

            incidentsView.Columns[Properties.Resources.IncidentsTable_TeamName].HeaderText = "Team Name";
            incidentsView.Columns[Properties.Resources.IncidentsTable_TeamName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            incidentsView.Columns[Properties.Resources.IncidentsTable_DriverName].HeaderText = "Driver Name";
            incidentsView.Columns[Properties.Resources.IncidentsTable_DriverName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            incidentsView.Columns[Properties.Resources.IncidentsTable_IncidentValue].Width = (int)IncidentTableColumnWidths.IncidentValueColumnWidth;
            incidentsView.Columns[Properties.Resources.IncidentsTable_IncidentValue].HeaderText = "Incident";

            incidentsView.Columns[Properties.Resources.IncidentsTable_TotalIncidents].Width = (int)IncidentTableColumnWidths.TotalIncidentsColumnWidth;
            incidentsView.Columns[Properties.Resources.IncidentsTable_TotalIncidents].HeaderText = "Total";
            incidentsView.DisableFilterChecklist(incidentsView.Columns[Properties.Resources.IncidentsTable_TotalIncidents]);
            incidentsView.DisableFilterCustom(incidentsView.Columns[Properties.Resources.IncidentsTable_TotalIncidents]);

            incidentsView.Columns[Properties.Resources.IncidentsTable_DriverLapNumber].Width = (int)IncidentTableColumnWidths.DriverLapNumberColumnWidth;
            incidentsView.Columns[Properties.Resources.IncidentsTable_DriverLapNumber].HeaderText = "Lap #";
        }

        /// <summary>
        /// Sets up column properties for the incidents table.
        /// </summary>
        /// <param name="columns"><see cref="DataColumnCollection"/> of the incident columns.</param>
        private void InitializeIncidentsDataTableColumns(DataColumnCollection columns)
		{
            DataColumn hiddenTimeStampColumn = new DataColumn(Properties.Resources.IncidentsTable_HiddenTimeStamp, typeof(DateTime));
            hiddenTimeStampColumn.ReadOnly = true;
            columns.Add(hiddenTimeStampColumn);

            DataColumn localTimeColumn = new DataColumn(Properties.Resources.IncidentsTable_LocalTime, typeof(string));
            localTimeColumn.ReadOnly = true;
            columns.Add(localTimeColumn);

            DataColumn sessionTimeColumn = new DataColumn(Properties.Resources.IncidentsTable_SessionTime, typeof(string));
            sessionTimeColumn.ReadOnly = true;
            columns.Add(sessionTimeColumn);

            DataColumn carClassColumn = new DataColumn(Properties.Resources.IncidentsTable_CarClass, typeof(string));
            carClassColumn.ReadOnly = true;
            columns.Add(carClassColumn);

            DataColumn carNumberColumn = new DataColumn(Properties.Resources.IncidentsTable_CarNumber, typeof(string));
            carNumberColumn.ReadOnly = true;
            columns.Add(carNumberColumn);

            DataColumn teamNameColumn = new DataColumn(Properties.Resources.IncidentsTable_TeamName, typeof(string));
            teamNameColumn.ReadOnly = true;
            columns.Add(teamNameColumn);

            DataColumn driverNameColumn = new DataColumn(Properties.Resources.IncidentsTable_DriverName, typeof(string));
            driverNameColumn.ReadOnly = true;
            columns.Add(driverNameColumn);

            DataColumn incidentValueColumn = new DataColumn(Properties.Resources.IncidentsTable_IncidentValue, typeof(string));
            incidentValueColumn.ReadOnly = true;
            columns.Add(incidentValueColumn);

            DataColumn totalIncidentsColumn = new DataColumn(Properties.Resources.IncidentsTable_TotalIncidents, typeof(string));
            totalIncidentsColumn.ReadOnly = true;
            columns.Add(totalIncidentsColumn);

            DataColumn driverLapNumberColumn = new DataColumn(Properties.Resources.IncidentsTable_DriverLapNumber, typeof(string));
            driverLapNumberColumn.ReadOnly = true;
            columns.Add(driverLapNumberColumn);
		}

        /// <summary>
        /// Called when the session string has been updated by the simulator.
        /// Checks for new drivers that have entered the session and populates/updates list of drivers.
        /// Checks for new cars that have entered the session and populates/updates list of cars.
        /// Checks each driver for a change in incidents, logs new incident to the table if so.
        /// Updates laps completed for each driver.
        /// Updates car team incident counts for each car.
        /// Applies color highlighting to the incidents table.
        /// Updates the incident counts display.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Session string changed event. Contains info from session string that can be queried.</param>
        public void OnSessionInfoUpdated(object sender, SdkWrapper.SessionInfoUpdatedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnSessionInfoUpdated(sender, e)));
                return;
            }

            // Perform some initialization if this is the first time being called in this session...
            if (!sessionInitializationComplete)
            {
                InitializeSession(e);
                sessionInitializationComplete = true;
            }

            AddNewDrivers(e);
            AddNewCars(e);
            UpdateDriverIncidentCounts(e);
            UpdateDriverLapCounts(e);
            UpdateCarTeamIncidentCounts(e);
            UpdateIncidentCountDisplay();
            UpdateVisibleIncidents();
            ApplyIncidentTableColorHighlighting(null);
            ApplyTimeFrameFilter();
            ApplyIncidentsTableTimeFilter(incidentsTimeFilterComboBox.SelectedIndex);

            var resultsOfficial = e.SessionInfo["SessionInfo"]["Sessions"]["SessionNum", sessionNum]["ResultsOfficial"].Value;
            if (raceSession && resultsOfficial == "1")
            {
                ShowIncidents();
                raceSession = false;
                Console.WriteLine("race complete");
            }
        }

        /// <summary>
        /// Called every time the live telemetry gets updates. The poll rate of live telemetry is stored in this.telemetryPollRate and can be changed by the user at runtime.
        /// Checks current session ID to see if new session initialization should take place.
        /// Checks for change in flag state. When session goes green again after a caution the incs since last caution field is reset to zero.
        /// Iterates through all cars in the session and updates their telemetry values.
        /// Set telemetry poll rate by setting wrapper.TelemetryUpdateFrequency(telemetryPollRate)
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
                Console.WriteLine($"id = {sessionUniqueID}, num = {sessionNum}, lapsLeft = {sessionLapsRemain}, timeLeft = {sessionTimeRemain}, flags = {sessionFlags}");
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
            UpdateDebugTable();

            CheckFlagStateChanges(e);

            if (raceSession && Properties.Settings.Default.useTotalIncidentsForCaution)
            {
                CheckIncidentLimit();
            }

            if (raceSession && Properties.Settings.Default.detectTowForCaution)
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

            Console.WriteLine($"initializing session {sessionName} ({sessionType})");

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
            
            // If this is not a team session, hide the team name column.
            if(int.TryParse(e.SessionInfo["WeekendInfo"]["TeamRacing"].Value, out teamRacing))
			{
                if (teamRacing == 0 && incidentsView.Columns.Contains(Properties.Resources.IncidentsTable_TeamName))
                {
                    incidentsView.Columns[Properties.Resources.IncidentsTable_TeamName].Visible = false;
                }
            }
            
            // If this is not a multiclass sesion, hide the car class column.
            if(int.TryParse(e.SessionInfo["WeekendInfo"]["NumCarClasses"].Value, out int numClasses))
			{
                if(numClasses < 2)
				{
                    incidentsView.Columns[Properties.Resources.IncidentsTable_CarClass].Visible = false;
                    debugTable.Columns[Properties.Resources.DebugTable_CarClassShortName].Visible = false;
                    debugTable.Columns[Properties.Resources.DebugTable_CarClassPosition].Visible = false;
                }
			}

            ClearIncidents();
            this.totalIncCount = 0;
            this.totalIncidentCountOfTable = 0;
            this.incCountSinceCaution = 0;

            AddNewDrivers(e);
            AddNewCars(e);
            PopulateDebugTable();
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

            totalIncidentCountLabel.Visible = false;
            totalIncidentCountNum.Visible = false;
            incidentsSinceCautionLabel.Visible = false;
            incidentsSinceCautionNum.Visible = false;
            visibleIncidentsLabel.Visible = false;
            visibleIncidentsNum.Visible = false;
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

            totalIncidentCountLabel.Visible = true;
            totalIncidentCountNum.Visible = true;
            incidentsSinceCautionLabel.Visible = true;
            incidentsSinceCautionNum.Visible = true;
            visibleIncidentsLabel.Visible = true;
            visibleIncidentsNum.Visible = true;
        }

        /// <summary>
        /// Iterates through all drivers in the session and updates their incident counts, logs a new incident if one is detected.
        /// </summary>
        /// <param name="e">SessionInfoUpdated event args.</param>
        private void UpdateDriverIncidentCounts(SdkWrapper.SessionInfoUpdatedEventArgs e)
        {
            int carIdx = 0;
            YamlQuery query;
            for(; carIdx < MAX_CARIDX; carIdx++)
            {
                query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];

                if(!query.TryGetValue(out string name))
				{
                    continue;
				}

                if (name == null || name == "Pace Car")
                {
                    continue;
                }

                if (!drivers.ContainsKey(name))
                {
                    Console.WriteLine($"ERROR: driver {name} not found in session driver list");
                    continue;
                }

                if (teamRacing != 0)
                {
                    drivers[name].TeamIncs = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["TeamIncidentCount"].Value;
                }

                int.TryParse(e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["CurDriverIncidentCount"].Value, out int newIncidentCount);

                // delta can be negative if a driver or the person running the RaceAdmin program 
                // disconnects and then reconnects; overall the negative rows and then the positive
                // rows added back total up to the same amount, so we can just ignore these. The negative
                // rows cause confusion and make the incident count fluctuate unnaturally.
                int delta = newIncidentCount - drivers[name].OldIncs;
                if (delta > 0)
                {
                    drivers[name].NewIncs = newIncidentCount;
                    Incident newInc = new Incident(e.SessionInfo.UpdateTime, DateTime.Now, delta, carIdx);
                    totalIncCount += newInc.Value;
                    totalIncidentCountOfTable += newInc.Value;
                    incCountSinceCaution += newInc.Value;
                    LogNewIncident(newInc);
                    drivers[name].OldIncs = drivers[name].NewIncs;
                    UpdateVisibleRows();
                }
            }
        }

        /// <summary>
        /// Iterates through all drivers in the session and updates their completed laps and current lap number.
        /// </summary>
        /// <param name="e">SessionInfoUpdated event args.</param>
        private void UpdateDriverLapCounts(SdkWrapper.SessionInfoUpdatedEventArgs e)
        {
            YamlQuery query;
            for(int position = 1; position < MAX_CARIDX; position++)
            {
                query = e.SessionInfo["SessionInfo"]["Sessions"]["SessionNum", this.sessionNum]["ResultsPositions"]["Position", position]["CarIdx"];

                if (!query.TryGetValue(out string carIdx))
				{
                    continue;
				}

                query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];

                if (query.TryGetValue(out string userName))
                {
                    if (drivers.TryGetValue(userName, out Driver driver))
                    {
                        query = e.SessionInfo["SessionInfo"]["Sessions"]["SessionNum", this.sessionNum]["ResultsPositions"]["Position", position]["LapsComplete"];
                        query.TryGetValue(out string s_lapsComplete);
						int.TryParse(s_lapsComplete, out int i_lapsComplete);
                        driver.CurrentLap = i_lapsComplete + 1;
                    }
                }
            }
        }

        /// <summary>
        /// Iterates through all cars in the session and updates the team incident count.
        /// </summary>
        /// <param name="e">SessionInfoUpdated event args.</param>
        private void UpdateCarTeamIncidentCounts(SdkWrapper.SessionInfoUpdatedEventArgs e)
		{
            YamlQuery query;
            for(int carIdx = 0; carIdx < MAX_CARIDX; carIdx++)
            {
                query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];

                if (!query.TryGetValue(out string name))
				{
                    continue;
				}

                if (name == null || name == "Pace Car")
                {
                    continue;
                }

                if (!cars.ContainsKey(carIdx))
                {
                    Console.WriteLine($"ERROR: car {carIdx} not found in session driver list");
                    continue;
                }

                cars[carIdx].TeamIncidentCount = SafeInt(e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["TeamIncidentCount"].Value);
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
        /// Iterates through every car in the session and checks if it has towed to pit lane since the last update.
        /// </summary>
        private void CheckForTow()
        {
            if (!raceSession)
            {
                // Only trigger cautions during races.
                return;
            }

            if (sessionFlags.Contains(SessionFlags.Checkered))
            {
                // Don't trigger cautions after the checkered flag is out.
                return;
            }

            if (!Properties.Settings.Default.detectTowForCaution)
            {
                // App not configured to trigger caution on tow.
                return;
            }

            if (cautionState != CautionState.None)
            {
                // Already triggered a caution; nothing to do.
                return;
            }

            if (sessionLapsRemain <= Properties.Settings.Default.lastLaps - 1)
            {
                // No cautions during configured number of last laps of the race if the race
                // distance is measured in laps.
                return;
            }

            if (sessionTimeRemain <= (double)Properties.Settings.Default.lastMinutes * 60.0)
            {
                // No cautions during configured last minutes of the race for timed races.
                return;
            }

            // Iterate over every car in the session and check if they have towed to pit lane since the last update.
            foreach (var car in cars.Values)
            {
                // If car is already "ApproachingPits" when tow occurs then ignore.
                if (car.TrackSurface != TrackSurfaces.AproachingPits)
                {
                    // Pit entry transition has occured.
                    if (car.BetweenPitCones != car.LastBetweenPitCones)
                    {
                        // Car has entered pit lane.
                        if (car.BetweenPitCones)
                        {
                            // Notify caution handlers
                            Console.WriteLine("Caution condition met; notifying caution handlers.");
                            cautionHandlers.Values.ToList().ForEach(h => h.CautionThresholdReached());

                            // Move to next state in caution handling cycle
                            cautionState = CautionState.ThresholdReached;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Runs checks on conditions to determine if a caution threshold has been reached and notifies the caution handlers.
        /// </summary>
        private void CheckIncidentLimit()
        {
            if (!raceSession)
            {
                // Only trigger cautions during races.
                return;
            }

            if (sessionFlags.Contains(SessionFlags.Checkered))
            {
                // Don't trigger cautions after the checkered flag is out.
                return;
            }

            if (!Properties.Settings.Default.useTotalIncidentsForCaution || incsRequiredForCaution == 0 || incCountSinceCaution < incsRequiredForCaution)
            {
                // App not configured to trigger caution or not enough incidents to trigger caution.
                return;
            }

            if (cautionState != CautionState.None)
            {
                // Already triggered a caution; nothing to do.
                return;
            }

            if (sessionLapsRemain <= Properties.Settings.Default.lastLaps - 1)
            {
                // No cautions during configured number of last laps of the race if the race
                // distance is measured in laps.
                return;
            }

            if (sessionTimeRemain <= (double)Properties.Settings.Default.lastMinutes * 60.0)
            {
                // No cautions during configured last minutes of the race for timed races.
                return;
            }

            Console.WriteLine("Caution condition met; notifying caution handlers.");

            // TODO: Find a better way to do this(table contains no rows during unit testing)
            if (incidentsView.Rows.Count > 0)
            {
                // Tag the incident row which triggered the caution with a yellow background in the table.
                ApplyIncidentTableColorHighlighting(incidentsView.Rows[incidentsView.Rows.Count - 1]);
            }

            // Notify caution handlers.
            cautionHandlers.Values.ToList().ForEach(h => h.CautionThresholdReached());

            // Move to next state in caution handling cycle.
            cautionState = CautionState.ThresholdReached;
        }

        /// <summary>
        /// Updates the text incident counters on the main tab.
        /// </summary>
        private void UpdateIncidentCountDisplay()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateIncidentCountDisplay()));
                return;
            }

            totalIncidentCountNum.Text = totalIncCount.ToString();
            incidentsSinceCautionNum.Text = incCountSinceCaution.ToString();
        }

        /// <summary>
        /// Checks for caution state changes. No caution=>Caution. Caution=>Green.
        /// </summary>
        /// <param name="e">Event parameters.</param>
        private void CheckFlagStateChanges(ITelemetryUpdatedEvent e)
        {
            // Has caution flag been deployed?
            if (sessionFlags.Contains(SessionFlags.Caution) && cautionState == CautionState.ThresholdReached)
            {
                // Notify caution handlers than the yellow flag has been thrown
                // and move to next state in caution handling cycle.
                cautionHandlers.Values.ToList().ForEach(h => h.YellowFlagThrown());
                cautionState = CautionState.YellowFlagDeployed;
            }

            // Has green flag been thrown?
            if (sessionFlags.Contains(SessionFlags.Green) && cautionState == CautionState.YellowFlagDeployed)
            {
                // Notify caution handlers than the race has resumed and move back
                // to initial state in caution handling cycle.
                cautionHandlers.Values.ToList().ForEach(h => h.GreenFlagThrown());
                cautionState = CautionState.None;

                // Reset incident count.
                incCountSinceCaution = 0;
            }
        }

        /// <summary>
        /// Clears incident counts from drivers.
        /// Clears all incident rows from main incidents table.
        /// </summary>
        private void ClearIncidents()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ClearIncidents()));
                return;
            }

            incidentsDataTable.Rows.Clear();

            foreach (var driver in drivers.Values)
            {
                driver.NewIncs = 0;
                driver.OldIncs = 0;
                driver.TeamIncs = "0";
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

            debugDataTable.Rows.Clear();

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

            foreach(DataRow row in debugDataTable.Rows)
			{
                row[2] = cars[(int)row[0]].OverallPositionInRace;
                row[3] = cars[(int)row[0]].ClassPositionInRace;
                row[5] = cars[(int)row[0]].CurrentDriver;
                row[6] = (cars[(int)row[0]].PercentAroundTrack * 100).ToString("0.00");
                if (cars[(int)row[0]].BetweenPitCones)
                {
                    row[7] = Properties.Resources.ConeFull;
                }
                else
                {
                    row[7] = Properties.Resources.ConeEmpty;
                }

                row[8] = cars[(int)row[0]].CurrentLap;
                row[9] = cars[(int)row[0]].LapsCompleted;
                row[10] = cars[(int)row[0]].TrackSurface;
                row[11] = cars[(int)row[0]].TrackSurfaceMaterial;
            }

            //debugTable.DataSource = debugBindingSource;
        }

        /// <summary>
        /// Adds a new car row to the debugTable.
        /// </summary>
        /// <param name="newCar">The car to draw values from.</param>
        private void AddNewCarDebugTable(Car newCar)
		{
            if (InvokeRequired)
            {
                Invoke(new Action(() => AddNewCarDebugTable(newCar)));
                return;
            }

            DataRow newRow = debugDataTable.NewRow();
            newRow[0] = newCar.CarIdx;
            newRow[1] = newCar.CarNumber;
            newRow[2] = newCar.OverallPositionInRace;
            newRow[3] = newCar.ClassPositionInRace;
            newRow[4] = newCar.CarClassShortName;
            newRow[5] = newCar.CurrentDriver;
            newRow[6] = newCar.PercentAroundTrack;
            if (newCar.BetweenPitCones)
            {
                newRow[7] = Properties.Resources.ConeFull;
            }
            else
            {
                newRow[7] = Properties.Resources.ConeEmpty;
            }

            newRow[8] = newCar.CurrentLap;
            newRow[9] = newCar.LapsCompleted;
            newRow[10] = newCar.TrackSurface;
            newRow[11] = newCar.TrackSurfaceMaterial;

            debugDataTable.Rows.Add(newRow);
        }

		/// <summary>
		/// Inserts new row into the incident data table.
		/// </summary>
		/// <param name="newInc"><see cref="Incident"/> object containing information about the latest incident.</param>
		private void LogNewIncident(Incident newInc)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => LogNewIncident(newInc)));
                return;
            }

            DataRow newRow = incidentsDataTable.NewRow();
            newRow[Properties.Resources.IncidentsTable_HiddenTimeStamp] = newInc.TimeStamp;
            newRow[Properties.Resources.IncidentsTable_LocalTime] = newInc.TimeStamp.ToLongTimeString();
            newRow[Properties.Resources.IncidentsTable_SessionTime] = MakeTimeString(newInc.SessionTime);
            newRow[Properties.Resources.IncidentsTable_CarClass] = cars[newInc.CarIdx].CarClassShortName;
            newRow[Properties.Resources.IncidentsTable_CarNumber] = cars[newInc.CarIdx].CarNumber;
            if (teamRacing != 0)
            {
                newRow[Properties.Resources.IncidentsTable_TeamName] = cars[newInc.CarIdx].TeamName;
            }
            newRow[Properties.Resources.IncidentsTable_DriverName] = cars[newInc.CarIdx].CurrentDriver;
            newRow[Properties.Resources.IncidentsTable_IncidentValue] = $"{newInc.Value}x";
            string total;
            if (teamRacing != 0)
            {
                // iRacing-style team incidents. (Team count, driver count)
                total = $"{cars[newInc.CarIdx].TeamIncidentCount},{drivers[cars[newInc.CarIdx].CurrentDriver].NewIncs}";
            }
            else
            {
                total = drivers[cars[newInc.CarIdx].CurrentDriver].NewIncs.ToString();
            }
            newRow[Properties.Resources.IncidentsTable_TotalIncidents] = total;
            newRow[Properties.Resources.IncidentsTable_DriverLapNumber] = cars[newInc.CarIdx].CurrentLap;

            incidentsDataTable.Rows.Add(newRow);

            if(incidentsView.RowCount > 0)
			{
                incidentsView.FirstDisplayedScrollingRowIndex = incidentsView.RowCount - 1;
            }

            Console.WriteLine($"{newRow[Properties.Resources.IncidentsTable_IncidentValue]}; driver = {drivers[cars[newInc.CarIdx].CurrentDriver].FullName}");
        }

        /// <summary>
        /// Informs the user of how many rows are currently visible in the incident table due to current filtering out of how many rows total.
        /// </summary>
        private void UpdateVisibleRows()
		{
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateVisibleRows()));
                return;
            }

            int visibleRowCount = incidentsView.Rows.GetRowCount(DataGridViewElementStates.Visible);
            int totalRowCount = incidentsDataTable.Rows.Count;
            visibleRowsNum.Text = $"{visibleRowCount} of {totalRowCount}";
        }

        /// <summary>
        /// Informs the user of how many incident points are currently visible due to current filtering out of how many incident points total.
        /// </summary>
        private void UpdateVisibleIncidents()
		{
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateVisibleIncidents()));
                return;
            }

            int visibleIncidentCount = 0;
            int visibleRowCount = incidentsView.Rows.GetRowCount(DataGridViewElementStates.Visible);

            for (int i = 0; i < visibleRowCount; i++)
			{
                int.TryParse(incidentsView.Rows[i].Cells["incidentValue"].Value.ToString().TrimEnd('x'), out int incidentValue);
                visibleIncidentCount += incidentValue;
			}

            visibleIncidentsNum.Text = $"{visibleIncidentCount} of {totalIncidentCountOfTable}";
        }

        /// <summary>
        /// Applies any color highlighting to the incidents table based on user settings.
        /// </summary>
        /// <param name="cautionRow">The incident that caused a caution. Passed as null for regular incidents.</param>
        internal void ApplyIncidentTableColorHighlighting(DataGridViewRow cautionRow)
		{
            if (InvokeRequired)
            {
                Invoke(new Action(() => ApplyIncidentTableColorHighlighting(cautionRow)));
                return;
            }

            try
			{

                foreach (DataGridViewRow row in incidentsView.Rows)
                {
                    if (row.Index % 2 == 0)
                    {
                        row.DefaultCellStyle.BackColor = incidentsView.DefaultCellStyle.BackColor;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = incidentsView.AlternatingRowsDefaultCellStyle.BackColor;
                    }
                }

                if (Properties.Settings.Default.highlightDriverIfIncidentThreshold)
                {
                    int driverIncidentCount = 0;
                    foreach (DataGridViewRow row in incidentsView.Rows)
                    {
                        if (teamRacing != 0)
                        {
                            var splitString = row.Cells[Properties.Resources.IncidentsTable_TotalIncidents].Value.ToString().Split(',');
                            int.TryParse(splitString.Last(), out driverIncidentCount);
                        }
                        else
                        {
                            int.TryParse(row.Cells[Properties.Resources.IncidentsTable_TotalIncidents].Value.ToString(), out driverIncidentCount);
                        }

                        if (driverIncidentCount >= Properties.Settings.Default.highlightDriverIncidentThreshold)
                        {
                            row.DefaultCellStyle.BackColor = Properties.Settings.Default.driverIncidentThresholdSelectedColor;
                        }
                    }
                }
                
                if (Properties.Settings.Default.highlight4xIncidents)
                {
                    foreach (DataGridViewRow row in incidentsView.Rows)
                    {
                        if (row.Cells[Properties.Resources.IncidentsTable_IncidentValue].Value.ToString() == "4x")
                        {
                            row.DefaultCellStyle.BackColor = Properties.Settings.Default.highlight4xIncidentsSelectedColor;
                        }
                    }
                }
                
                if (Properties.Settings.Default.highlightIncidentThatTriggeredCaution)
                {
                    if (cautionRow != null)
                    {
                        cautionRow.DefaultCellStyle.BackColor = Properties.Settings.Default.highlightCautionIncidentSelectedColor;
                    }
                }
            }
            catch(DataException ex)
			{
                Console.WriteLine($"Data Exception in ApplyIncidentTableColorHighlighting():");
                Console.WriteLine(ex.Message);
                return;
            }
		}

        /// <summary>
        /// Applys filtering to the incidents table based on what the user has set.
        /// </summary>
        /// <param name="selectedIndiex">The selected index number of the incidentsTimeFilterComboBox.</param>
        private void ApplyIncidentsTableTimeFilter(int selectedIndex)
		{
            if (InvokeRequired)
            {
                Invoke(new Action(() => ApplyIncidentsTableTimeFilter(selectedIndex)));
                return;
            }

            DateTime filter;

            switch (selectedIndex)
			{
                case 0:
                    incidentsDataTable.DefaultView.RowFilter = $"";
                    break;

                case 1:
                    filter = DateTime.Now.AddMinutes(-30).ToLocalTime();
                    incidentsDataTable.DefaultView.RowFilter = $"hiddenTimeStamp >= #{filter}#";
                    break;

                case 2:
                    filter = DateTime.Now.AddMinutes(-60).ToLocalTime();
                    incidentsDataTable.DefaultView.RowFilter = $"hiddenTimeStamp >= #{filter}#";
                    break;

                case 3:
                    filter = DateTime.Now.AddMinutes(-90).ToLocalTime();
                    incidentsDataTable.DefaultView.RowFilter = $"hiddenTimeStamp >= #{filter}#";
                    break;

                case 4:
                    filter = DateTime.Now.AddMinutes(-120).ToLocalTime();
                    incidentsDataTable.DefaultView.RowFilter = $"hiddenTimeStamp >= #{filter}#";
                    break;

                case 5:
                    filter = DateTime.Now.AddMinutes(-180).ToLocalTime();
                    incidentsDataTable.DefaultView.RowFilter = $"hiddenTimeStamp >= #{filter}#";
                    break;
            }

            UpdateVisibleRows();
            UpdateVisibleIncidents();
            ApplyIncidentTableColorHighlighting(null);
        }

        /// <summary>
        /// Applies time frame filtering to the incidents table from a starting session time to an ending session time.
        /// </summary>
        private void ApplyTimeFrameFilter()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ApplyTimeFrameFilter()));
                return;
            }

            if (timeFrameFilterBegin == null || timeFrameFilterEnd == null)
			{
                incidentsDataTable.DefaultView.RowFilter = $"";
                ApplyIncidentsTableTimeFilter(incidentsTimeFilterComboBox.SelectedIndex);
                ApplyIncidentTableColorHighlighting(null);
                return;
			}

            string filterBegin = MakeTimeString((double)timeFrameFilterBegin);
            string filterEnd = MakeTimeString((double)timeFrameFilterEnd);
            incidentsDataTable.DefaultView.RowFilter = $"sessionTime >= #{filterBegin}# AND sessionTime <= #{filterEnd}#";

            UpdateVisibleRows();
            UpdateVisibleIncidents();
            ApplyIncidentTableColorHighlighting(null);
        }

        /// <summary>
        /// Calculates the time frame begin and time frame end values to be used for filtering incidents.
        /// </summary>
        private void CalculateTimeFrameDelta()
        {
            double? timeFrameDelta = timeFrameFilterEnd - timeFrameFilterBegin;

            if (timeFrameDelta <= 0)
            {
                timeFrameFilterErrorText.Visible = true;
                timeFrameFilterErrorText.Text = "Negative or zero time frame value";
                timeFrameFilterComboBox1.BackColor = Color.MistyRose;
                timeFrameFilterComboBox2.BackColor = Color.MistyRose;
            }
            else
            {
                timeFrameFilterErrorText.Visible = false;
                timeFrameFilterErrorText.Text = "NONE";
                timeFrameFilterComboBox1.BackColor = Color.White;
                timeFrameFilterComboBox2.BackColor = Color.White;
            }

            ApplyTimeFrameFilter();
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
        /// Exports the currently visible contents of the IncidentsView to the given writer in CSV format.
        /// </summary>
        /// <param name="writer">The TextWriter to which the contents should be written.</param>
        public void ExportIncidentTableToCsv(TextWriter writer)
        {
            // Write the column headers.
            var headers = incidentsView.Columns.Cast<DataGridViewColumn>();
            writer.WriteLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            // Iterate through each row of the incidents table and write.
            foreach (DataGridViewRow row in incidentsView.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                writer.WriteLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }
        }

        /// <summary>
        /// Parses car number strings as integers so the incidents table can be sorted by the car number column.
        /// Currently not used since the table has been replaced.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event args.</param>
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
            YamlQuery query;
            for(int carIdx = 0; carIdx < MAX_CARIDX; carIdx++)
			{
                query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];

                if (!query.TryGetValue(out string fullName))
                {
                    continue;
                }

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
                }
			}
        }

        /// <summary>
        /// Populates a Dictionary<carIdx, Car> of cars in the current session.
        /// </summary>
        /// <param name="e">Session string changed event. Object that conatains info from session string that can be queried.</param>
        private void AddNewCars(SdkWrapper.SessionInfoUpdatedEventArgs e)
		{
            YamlQuery query;
            for(int carIdx = 0; carIdx < MAX_CARIDX; carIdx++)
            {
                query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];

                if(!query.TryGetValue(out string fullName))
				{
                    continue;
				}

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
                            CarScreenName = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["CarScreenName"].Value,
                            CarClassShortName = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["CarClassShortName"].Value,
                        };

                        Console.WriteLine($"Adding car {carIdx}");
                        cars.Add(carIdx, car);
						AddNewCarDebugTable(car);
                    }
                }
            }
        }

        /// <summary>
        /// Sets any internal variables based on user changing settings.
        /// </summary>
        public void SettingsChanged()
        {
            incsRequiredForCaution = Properties.Settings.Default.incidentsRequired;
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
            return int.TryParse(s, out int x) ? x : 0;
        }

        /// <summary>
        /// Sets the public CautionHandlers property.
        /// </summary>
        /// <param name="cautionHandlers"></param>
        public void SetTestCautionHandlers(Dictionary<string, ICautionHandler> cautionHandlers)
        {
            CautionHandlers = cautionHandlers;
        }

        #region EVENT_HANDLERS
        /// <summary>
        /// Performs some intialization of size and position of the main RaceAdmin form.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event args.</param>
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
        /// <param name="e">Event args.</param>
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
        /// <param name="e">Event args.</param>
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
        /// <param name="e">Event args.</param>
        private void ExportButton_Click(object sender, EventArgs e)
        {
            if(incidentsView.RowCount == 0)
			{
                MessageBox.Show("Nothing to Export!", "Empty table");
                return;
			}

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
        /// <param name="e">Event args.</param>
        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            Form settings = new SettingsDialog(this);
            settings.Show();
        }

        /// <summary>
        /// Checks or unchecks the menu item.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event args.</param>
        private void viewIncidentTableMenuItem_Click(object sender, EventArgs e)
        {
            viewIncidentTableMenuItem.Checked = !viewIncidentTableMenuItem.Checked;
        }

        /// <summary>
        /// Checks or unchecks the menu item.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event args.</param>
        private void viewIncidentsCountMenuItem_Click(object sender, EventArgs e)
        {
            viewIncidentsCountMenuItem.Checked = !viewIncidentsCountMenuItem.Checked;
        }

        /// <summary>
        /// Checks or unchecks the menu item.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event args.</param>
		private void viewCautionPanelMenuItem_Click(object sender, EventArgs e)
        {
            viewCautionPanelMenuItem.Checked = !viewCautionPanelMenuItem.Checked;
        }

        /// <summary>
        /// Shows or hides the caution indicator panel based on the checked status.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event args.</param>
		private void viewCautionPanelMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (viewCautionPanelMenuItem.Checked)
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
		private void viewIncidentTableMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (viewIncidentTableMenuItem.Checked)
            {
                incidentsView.Visible = true;
                incidentsTimeFilterComboBox.Visible = true;
                incidentsTimeFilterLabel.Visible = true;
                visibleRowsLabel.Visible = true;
                visibleRowsNum.Visible = true;
                timeFrameFilterLabel1.Visible = true;
                timeFrameFilterLabel2.Visible = true;
                timeFrameFilterComboBox1.Visible = true;
                timeFrameFilterComboBox2.Visible = true;
                visibleIncidentsLabel.Visible = true;
                visibleIncidentsNum.Visible = true;
                addTestRowButton.Visible = true;
            }
            else
            {
                incidentsView.Visible = false;
                incidentsTimeFilterComboBox.Visible = false;
                incidentsTimeFilterLabel.Visible = false;
                visibleRowsLabel.Visible = false;
                visibleRowsNum.Visible = false;
                timeFrameFilterLabel1.Visible = false;
                timeFrameFilterLabel2.Visible = false;
                timeFrameFilterComboBox1.Visible = false;
                timeFrameFilterComboBox2.Visible = false;
                visibleIncidentsLabel.Visible = false;
                visibleIncidentsNum.Visible = false;
                addTestRowButton.Visible = false;
            }
        }

        /// <summary>
        /// Shows or hides the incident counts based on the checked status.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event args.</param>
		private void viewIncidentsCountMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (viewIncidentsCountMenuItem.Checked)
            {
                totalIncidentCountLabel.Visible = true;
                totalIncidentCountNum.Visible = true;
                incidentsSinceCautionLabel.Visible = true;
                incidentsSinceCautionNum.Visible = true;
                resetIncidentsSinceLastCautionButton.Visible = true;
                resetTotalIncidentCountButton.Visible = true;
            }
            else
            {
                totalIncidentCountLabel.Visible = false;
                totalIncidentCountNum.Visible = false;
                incidentsSinceCautionLabel.Visible = false;
                incidentsSinceCautionNum.Visible = false;
                resetIncidentsSinceLastCautionButton.Visible = false;
                resetTotalIncidentCountButton.Visible = false;
            }
        }

        /// <summary>
        /// Change the backColor of the incident count items to match the backColor of caution panel.
        /// This has to be done because Windows Forms doesn't support transparent controls.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event args.</param>
        private void cautionPanel_BackColorChanged(object sender, EventArgs e)
        {
            if(viewCautionPanelMenuItem.Checked)
			{
                totalIncidentCountLabel.BackColor = cautionPanel.BackColor;
                totalIncidentCountNum.BackColor = cautionPanel.BackColor;
                incidentsSinceCautionLabel.BackColor = cautionPanel.BackColor;
                incidentsSinceCautionNum.BackColor = cautionPanel.BackColor;
            }
            else
			{
                totalIncidentCountLabel.BackColor = totalIncidentCountLabel.Parent.BackColor;
                totalIncidentCountNum.BackColor = totalIncidentCountNum.Parent.BackColor;
                incidentsSinceCautionLabel.BackColor = incidentsSinceCautionLabel.Parent.BackColor;
                incidentsSinceCautionNum.BackColor = incidentsSinceCautionNum.Parent.BackColor;
            }
        }

        /// <summary>
        /// Change the backColor of the incident count items to match the backColor of caution panel.
        /// This has to be done because Windows Forms doesn't support transparent controls.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event args.</param>
        private void cautionPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (viewCautionPanelMenuItem.Checked)
            {
                totalIncidentCountLabel.BackColor = cautionPanel.BackColor;
                totalIncidentCountNum.BackColor = cautionPanel.BackColor;
                incidentsSinceCautionLabel.BackColor = cautionPanel.BackColor;
                incidentsSinceCautionNum.BackColor = cautionPanel.BackColor;
            }
            else
            {
                totalIncidentCountLabel.BackColor = totalIncidentCountLabel.Parent.BackColor;
                totalIncidentCountNum.BackColor = totalIncidentCountNum.Parent.BackColor;
                incidentsSinceCautionLabel.BackColor = incidentsSinceCautionLabel.Parent.BackColor;
                incidentsSinceCautionNum.BackColor = incidentsSinceCautionNum.Parent.BackColor;
            }
        }

        /// <summary>
        /// Sets the poll rate of live telemetry after the user changed the value.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event args.</param>
        private void telemetryPollRateTextBox_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(telemetryPollRateTextBox.Text, out int x))
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
        /// <param name="e">Event args.</param>
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
        /// User changed the time filter value.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event args.</param>
        private void incidentsTimeFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (incidentsTimeFilterComboBox.SelectedIndex != 0)
			{
                timeFrameFilterComboBox1.SelectedIndex = 0;
                ApplyIncidentsTableTimeFilter(incidentsTimeFilterComboBox.SelectedIndex);
                ApplyIncidentTableColorHighlighting(null);
            }
        }

        /// <summary>
        /// Parses the time in the time frame filter box back into a double sessionTime and sets the internal timeFrameFilterBegin field.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event args.</param>
        private void timeFrameFilterComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timeFrameFilterErrorText.Visible = false;
            timeFrameFilterErrorText.Text = "NONE";
            timeFrameFilterComboBox1.BackColor = Color.White;

            if(timeFrameFilterComboBox1.SelectedIndex == 0)
			{
                timeFrameFilterBegin = null;
                timeFrameFilterComboBox2.SelectedIndex = 0;
                ApplyTimeFrameFilter();
                return;
			}

            string[] timeStringSplit = timeFrameFilterComboBox1.SelectedItem.ToString().Split(':');

            if (timeStringSplit.Length != 2)
            {
                timeFrameFilterErrorText.Text = "Error while parsing value";
                timeFrameFilterErrorText.Visible = true;
                timeFrameFilterComboBox1.BackColor = Color.MistyRose;
                timeFrameFilterComboBox1.SelectedIndex = 0;
                timeFrameFilterBegin = null;
                return;
            }

            if (!int.TryParse(timeStringSplit[0], out int hours))
            {
                timeFrameFilterErrorText.Text = "Error while parsing value";
                timeFrameFilterErrorText.Visible = true;
                timeFrameFilterComboBox1.BackColor = Color.MistyRose;
                timeFrameFilterComboBox1.SelectedIndex = 0;
                timeFrameFilterBegin = null;
                return;
            }

            if (!int.TryParse(timeStringSplit[1], out int minutes))
            {
                timeFrameFilterErrorText.Text = "Error while parsing value";
                timeFrameFilterErrorText.Visible = true;
                timeFrameFilterComboBox1.BackColor = Color.MistyRose;
                timeFrameFilterComboBox1.SelectedIndex = 0;
                timeFrameFilterBegin = null;
                return;
            }

            timeFrameFilterBegin = (hours * 3600) + (minutes * 60);

            if (timeFrameFilterEnd != null && timeFrameFilterBegin != null)
            {
                incidentsTimeFilterComboBox.SelectedIndex = 0;
                CalculateTimeFrameDelta();
            }
        }

        /// <summary>
        /// Parses the time in the time frame filter box back into a double sessionTime and sets the internal timeFrameFilterEnd field.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event args.</param>
		private void timeFrameFilterComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            timeFrameFilterErrorText.Visible = false;
            timeFrameFilterErrorText.Text = "NONE";
            timeFrameFilterComboBox2.BackColor = Color.White;

            if(timeFrameFilterComboBox2.SelectedIndex == 0)
			{
                timeFrameFilterEnd = null;
                timeFrameFilterComboBox1.SelectedIndex = 0;
                ApplyTimeFrameFilter();
                return;
            }

            string[] timeStringSplit = timeFrameFilterComboBox2.SelectedItem.ToString().Split(':');

            if(timeStringSplit.Length != 2)
			{
                timeFrameFilterErrorText.Text = "Error while parsing value";
                timeFrameFilterErrorText.Visible = true;
                timeFrameFilterComboBox2.BackColor = Color.MistyRose;
                timeFrameFilterComboBox2.SelectedIndex = 0;
                timeFrameFilterEnd = null;
                return;
            }

            if(!int.TryParse(timeStringSplit[0], out int hours))
			{
                timeFrameFilterErrorText.Text = "Error while parsing value";
                timeFrameFilterErrorText.Visible = true;
                timeFrameFilterComboBox2.BackColor = Color.MistyRose;
                timeFrameFilterComboBox2.SelectedIndex = 0;
                timeFrameFilterEnd = null;
                return;
            }

            if (!int.TryParse(timeStringSplit[1], out int minutes))
            {
                timeFrameFilterErrorText.Text = "Error while parsing value";
                timeFrameFilterErrorText.Visible = true;
                timeFrameFilterComboBox2.BackColor = Color.MistyRose;
                timeFrameFilterComboBox2.SelectedIndex = 0;
                timeFrameFilterEnd = null;
                return;
            }

            timeFrameFilterEnd = (hours * 3600) + (minutes * 60);

            if (timeFrameFilterEnd != null && timeFrameFilterBegin != null)
			{
                incidentsTimeFilterComboBox.SelectedIndex = 0;
                CalculateTimeFrameDelta();
            }
        }

        /// <summary>
        /// Filters all drivers currently not in the world out of the debug table.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event args.</param>
        private void filterNotInWorldCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(filterNotInWorldCheckBox.Checked)
			{
                debugDataTable.DefaultView.RowFilter = $"carTrackSurface <> {(int)TrackSurfaces.NotInWorld}";
			}
            else
			{
                debugDataTable.DefaultView.RowFilter = $"";
            }
        }

        /// <summary>
        /// Initializes and shows the About window.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event args.</param>
        private void aboutRaceAdministratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutForm = new About(this);

            string version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
            aboutForm.versionLabel.Text = $"v{version}";

            aboutForm.StartPosition = FormStartPosition.CenterScreen;
            aboutForm.Show();
        }

        /// <summary>
        /// Resets the total and since last caution incident count to 0.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event args.</param>
        private void resetTotalIncidentCountButton_Click(object sender, EventArgs e)
        {
            this.totalIncCount = 0;
            this.incCountSinceCaution = 0;
            UpdateIncidentCountDisplay();
        }

        /// <summary>
        /// Resets the incidents since last caution count to 0.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e"></param>
        private void resetIncidentsSinceLastCautionButton_Click(object sender, EventArgs e)
        {
            this.incCountSinceCaution = 0;
            UpdateIncidentCountDisplay();
        }
        #endregion EVENT_HANDLERS

        #region PUBLIC_PROPERTIES
        /// <summary>
        /// Gets or sets the cautionHandlers field.
        /// </summary>
        public Dictionary<string, ICautionHandler> CautionHandlers { get; set; }
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
        private int testMinutes = 0;
        private double testSessionTime = 0.0;
        private int testCarIdx = 0;
        private string[] testCarClasses =
        {
            "LMP1",
            "LMP2",
            "GTEPro",
            "GTEAm",
        };

        /// <summary>
        /// Simulates the incidents of a test session. Only visible in DEBUG mode and don't use if iRacing is running.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event args.</param>
        private void addTestRowButton_Click(object sender, EventArgs e)
        {
            // If iRacing is runnig then don't do anything.
            if(sessionLabel.Text == "NO SESSION")
			{
                PopulateIncidentsToPresent(-24, -1);
            }
        }

        /// <summary>
        /// Populates the incident table with incidents from a simulated session.
        /// </summary>
        /// <param name="addHours">Number of hours ago to begin the test session. Use a negative value of hours to go back in time. EX: -24 means a session will be simulated starting 24 hours ago, and ending now.</param>
        /// <param name="minuteInterval">The number of simulated minutes between incidents. -1 means a random interval between 1-15 minutes will be used for each incident.</param>
        private void PopulateIncidentsToPresent(int addHours, int minuteInterval)
		{
            var rng = new Random();
            DateTime timeStamp;

            do
            {
                int interval = minuteInterval > 0 ? minuteInterval : rng.Next(1, 16);
                testMinutes += interval;
                testSessionTime += interval * 60.0;
                timeStamp = DateTime.Now.AddHours(addHours).AddMinutes(testMinutes);
                Test_AddIncidentRow(timeStamp, testSessionTime);

            } while (DateTime.Now > timeStamp);
        }

        /// <summary>
        /// Generates a random driver and car and uses them to populate a new row in the incident table.
        /// </summary>
        /// <param name="timeStamp">The <see cref="DateTime"/> timeStamp of the new incident to add.</param>
        /// <param name="sessionTime">The number of seconds into the simulated session the incident occured.</param>
        private void Test_AddIncidentRow(DateTime timeStamp, double sessionTime)
        {
            testCurrentLap = MakeRandomLap();
            testCarIdx++;
            var rng = new Random();
            var newIncidents = (int)Math.Pow(2, rng.Next(3));

            Driver driver = new Driver()
            {
                CarIdx = testCarIdx,
                FullName = MakeRandomName(),
                CarNum = MakeRandomCarNumber(),
                IRating = rng.Next(500, 4501).ToString(),
                OldIncs = 0,
                NewIncs = newIncidents,
                CurrentLap = testCurrentLap
            };

            try
			{
                drivers.Add(driver.FullName, driver);
            }
            catch(Exception ex)
			{
                driver.FullName += testCarIdx.ToString();
                drivers.Add(driver.FullName, driver);
            }
            
            MakeTestCar(testCarIdx, driver.CarNum, driver.FullName, driver.TeamName, driver.CurrentLap);

            Incident newInc = new Incident(sessionTime, timeStamp, driver.NewIncs, driver.CarIdx);
            totalIncCount += newIncidents;
            totalIncidentCountOfTable += newIncidents;
            incCountSinceCaution += newIncidents;
            LogNewIncident(newInc);
            UpdateIncidentCountDisplay();
            UpdateVisibleIncidents();

            ApplyIncidentTableColorHighlighting(null);
        }

        /// <summary>
        /// Generates a new car with random values to use in a new incident row.
        /// </summary>
        /// <param name="carIdx">The carIdx of the new car.</param>
        /// <param name="carNum">The car number of the new car.</param>
        /// <param name="driverName">The name of the driver of the new car.</param>
        /// <param name="teamName">The team name of the new car.</param>
        /// <param name="currentLap">The current lap of the new car.</param>
        private void MakeTestCar(int carIdx, string carNum, string driverName, string teamName, int currentLap)
		{
            var rng = new Random();
            Car car = new Car()
            {
                CarIdx = carIdx,
                CarClassShortName = testCarClasses[rng.Next(4)],
                CarNumber = carNum,
                CurrentDriver = driverName,
                TeamName = teamName,
                CurrentLap = currentLap
            };

            cars.Add(car.CarIdx, car);
		}

        /// <summary>
        /// Creates a random name of a new driver.
        /// </summary>
        /// <returns>A randomly generated driver name.</returns>
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

        /// <summary>
        /// Creates a randomly generated car number.
        /// </summary>
        /// <returns>A randomly generated car number.</returns>
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

        /// <summary>
        /// Creates a random integer number to be used as a lap number.
        /// </summary>
        /// <returns>A randomly generated lap number.</returns>
        private int MakeRandomLap()
        {
            var rng = new Random();
            return testCurrentLap + rng.Next(2);
        }
		#endregion TESTING
		// Code in the region above is used to generate test data or to simulate behavior 
		// for UI testing. To use, create buttons on the form and connect them to the various
		// event handler methods above.
	}
}
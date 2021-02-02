using iRacingSdkWrapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RaceAdmin
{
    using SessionFlags = iRacingSdkWrapper.Bitfields.SessionFlags;

    internal enum CautionState
    {
        None,
        ThresholdReached,
        YellowFlagDeployed
    }

    public partial class RaceAdminMain : Form
    {
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);

        /// <summary>
        /// Flag to indicate whether the incidents since last caution field has been reset to 0.
        /// </summary>
        private bool incsReset = false;

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

        private bool teamRacing;

        /// <summary>
        /// The maximum allowable number of drivers set for this session. Used to iterate through drivers in session string.
        /// </summary>
        private int numStarters = 0;

        /// <summary>
        /// Flag to indicate whether the initialization for the current session has occured.
        /// </summary>
        private bool sessionInitializationComplete = false;

        /// <summary>
        /// The number of incidents required for a caution to be triggeed. Set by user in IncsRequiredForCautionTextBox object.
        /// </summary>
        private int incsRequiredForCaution = 0;

        /// <summary>
        /// The current session number obtained from the live telemetry.
        /// </summary>
        private int liveSessionNum = 0;

        /// <summary>
        /// The current unique session ID number obtained from the live telemetry.
        /// </summary>
        private int liveUniqueSessionID = 1;

        /// <summary>
        /// List of Driver objects used to store data about the current set of drivers in the session.
        /// </summary>
        private Dictionary<string, Driver> drivers = new Dictionary<string, Driver>();

        /// <summary>
        /// ISdkWrapper object.
        /// </summary>
        private ISdkWrapper wrapper;

        /// <summary>
        /// The caution handlers used to notify the user that a caution is advised.
        /// </summary>
        private Dictionary<string, ICautionHandler> cautionHandlers;

        private bool raceSession;

        // these are added for testing only
        public int LiveUniqueSessionID { get => liveUniqueSessionID; }
        public int IncsRequiredForCaution { get => incsRequiredForCaution; set => incsRequiredForCaution = value; }
        public Dictionary<string, Driver> Drivers { get => drivers; }
        public int TotalIncCount { get => totalIncCount; }
        public int IncCountSinceCaution { get => incCountSinceCaution; }


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
            // full course yellow settings
            incidentsRequired.Value = Properties.Settings.Default.incidentsRequired;
            audioNotification.Checked = Properties.Settings.Default.audioNotification;
            autoThrowCaution.Checked = Properties.Settings.Default.autoThrowCaution;
            lastLaps.Value = Properties.Settings.Default.lastLaps;
            lastMinutes.Value = Properties.Settings.Default.lastMinutes;

            // general settings
            hideIncidents.Checked = Properties.Settings.Default.hideIncidents;
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
            UpdateIncidentCounts(e);
            UpdateDriverLapCounts(e);

            var sessionComplete = e.SessionInfo["SessionInfo"]["Sessions"]["SessionNum", liveSessionNum]["ResultsOfficial"].Value;
            if (raceSession && sessionComplete == "1")
            {
                ShowIncidents();
            }
        }

        private void InitializeSession(SdkWrapper.SessionInfoUpdatedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => InitializeSession(e)));
                return;
            }

            var sessionType = e.SessionInfo["SessionInfo"]["Sessions"]["SessionNum", liveSessionNum]["SessionType"].Value;
            var sessionName = e.SessionInfo["SessionInfo"]["Sessions"]["SessionNum", liveSessionNum]["SessionName"].Value;
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

            // Get max # of drivers set for this session...
            query = e.SessionInfo["WeekendInfo"]["WeekendOptions"]["NumStarters"];
            query.TryGetValue(out temp);
            System.Int32.TryParse(temp, out this.numStarters);

            this.totalIncCount = 0;
            this.incCountSinceCaution = 0;
            ClearIncidents();
        }

        private void ObscureIncidents()
        {
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

        private void UpdateIncidentCounts(SdkWrapper.SessionInfoUpdatedEventArgs e)
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
            YamlQuery query = e.SessionInfo["SessionInfo"]["Sessions"]["SessionNum", this.liveSessionNum]["ResultsPositions"]["Position", i]["CarIdx"];
            while (query.TryGetValue(out string s_carIdx))
            {
                query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", s_carIdx]["UserName"];
                if (query.TryGetValue(out string userName))
                {
                    if (drivers.TryGetValue(userName, out Driver driver))
                    {
                        query = e.SessionInfo["SessionInfo"]["Sessions"]["SessionNum", this.liveSessionNum]["ResultsPositions"]["Position", i]["LapsComplete"];
                        query.TryGetValue(out string s_lapsComplete);
                        System.Int32.TryParse(s_lapsComplete, out int i_lapsComplete);
                        driver.CurrentLap = i_lapsComplete + 1;
                    }
                }

                i++;
                query = e.SessionInfo["SessionInfo"]["Sessions"]["SessionNum", this.liveSessionNum]["ResultsPositions"]["Position", i]["CarIdx"];
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

            // Check for incident limit reached for caution.
            // Animate color changes on CautionPanel.
            // Only throw cautions during race sessions.
            if (raceSession && (this.incCountSinceCaution >= this.incsRequiredForCaution) && (this.incsRequiredForCaution != 0))
            {
                if (cautionState == CautionState.None)
                {
                    // tag the incident row which triggered the caution with a yellow background in the table
                    incidentsTableView.Rows[incidentsTableView.Rows.Count - 1].DefaultCellStyle.BackColor =
                        System.Drawing.Color.FromName(Properties.Resources.ColorName_Gold);

                    cautionHandlers.Values.ToList().ForEach(h => h.CautionThresholdReached());
                    cautionState = CautionState.ThresholdReached;
                }
            }

            // Update incident count fields.
            TotalIncidentCountNum.Text = this.totalIncCount.ToString();
            IncidentsSinceCautionNum.Text = this.incCountSinceCaution.ToString();

            // Update Session Identifiers
            // NOTE: Current thinking is that the SessionUniqueID changes even between 
            //       pracice, qualifying, and race during one iRacing session, which does seem
            //       to be the case though it is not exactly clear what the values might be. 
            //       The SessionNum value (I think) iterates from 0, 1, 2, etc. and is an 
            //       index into the SessionInfo:Sessions data in the SessionInfoUpdate YAML.
            //       It is not clear that we need both and once we have full telemetry recording
            //       implemented this may become more clear and allow simplification of the code.
            // ALSO: See comments in the SdkWrapperProxy in the telemetry update recording section
            var sessionUniqueID = e.TelemetryInfo.SessionUniqueID.Value;
            var sessionNum = e.TelemetryInfo.SessionNum.Value;

            if (sessionUniqueID != this.liveUniqueSessionID || sessionNum != liveSessionNum)
            {
                this.liveUniqueSessionID = sessionUniqueID;
                this.liveSessionNum = sessionNum;
                this.sessionInitializationComplete = false;
            }

            // Check for change in flag state.
            var flags = e.TelemetryInfo.SessionFlags.Value;
            if (flags.Contains(SessionFlags.Caution))
            {
                if (cautionState == CautionState.ThresholdReached)
                {
                    cautionHandlers.Values.ToList().ForEach(h => h.YellowFlagThrown());
                    cautionState = CautionState.YellowFlagDeployed;
                }
                this.incsReset = false;
            }
            if (flags.Contains(SessionFlags.Green) && (this.incsReset == false))
            {
                if (cautionState == CautionState.YellowFlagDeployed)
                {
                    cautionHandlers.Values.ToList().ForEach(h => h.GreenFlagThrown());
                    cautionState = CautionState.None;
                }
                this.incCountSinceCaution = 0;
                this.incsReset = true;
            }

            // To get telemetry values not defined in Nick's wrapper...
            //var fictionalObject = wrapper.GetTelemetryValue<int>("VariableName");
            //int fictionalValue = fictionalObject.Value;
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
        }

        public static string MakeTimeString(double time)
        {
            return TimeSpan.FromSeconds(time).ToString(@"hh\:mm\:ss");
        }

        /// <summary>
        /// Populates a List<T> of drivers in the current session. 
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
                            OldIncs = SafeInt(e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["CurDriverIncidentCount"].Value)
                        };

                        Console.WriteLine("adding driver {0}", fullName);
                        drivers.Add(fullName, driver);
                    }

                    carIdx++;
                    query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                }
            }
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

        /// <summary>
        /// Closes the current environment when the X button is clicked.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">FormClosing event.</param>
        private void RaceAdminMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            wrapper.Stop();
            Environment.Exit(0);
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

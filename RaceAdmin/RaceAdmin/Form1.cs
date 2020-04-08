using iRacingSdkWrapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
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
        private int liveUniqueSessionID = 0;

        /// <summary>
        /// List of Driver objects used to store data about the current set of drivers in the session.
        /// </summary>
        private List<Driver> drivers = new List<Driver>();

        /// <summary>
        /// ISdkWrapper object.
        /// </summary>
        private ISdkWrapper wrapper;

        /// <summary>
        /// The caution handlers used to notify the user that a caution is advised.
        /// </summary>
        private Dictionary<string, ICautionHandler> cautionHandlers;

        // these are added for testing only
        public int LiveUniqueSessionID { get => liveUniqueSessionID; }
        public int IncsRequiredForCaution { get => incsRequiredForCaution; set => incsRequiredForCaution = value; }
        public List<Driver> Drivers { get => drivers; }
        public int TotalIncCount { get => totalIncCount; }
        public int IncCountSinceCaution { get => incCountSinceCaution; }


        /// <summary>
        /// Constructor for RaceAdminMain form. Initialization of WinForm, SdkWrapper, start wrapper object.
        /// </summary>
        public RaceAdminMain(ISdkWrapper wrapper)
        {
            // Initialize WinForm
            InitializeComponent();

            this.wrapper = wrapper;
            this.cautionHandlers = new Dictionary<string, ICautionHandler>();
            this.cautionHandlers.Add("default", new DefaultCautionHandler(this.CautionPanel));

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
            if (this.sessionInitializationComplete == false)
            {
                YamlQuery query;  // Yaml query object used to query data from the session string.
                string temp;      // Temporary string used to get string version of data from query before parsing to a number.

                // Get max # of drivers set for this session...
                query = e.SessionInfo["WeekendInfo"]["WeekendOptions"]["NumStarters"];
                query.TryGetValue(out temp);
                System.Int32.TryParse(temp, out this.numStarters);

                drivers.Clear();
                PopulateDriversList(drivers, e);
                this.totalIncCount = 0;
                this.incCountSinceCaution = 0;
                IncidentsTableView.Rows.Clear();

                this.sessionInitializationComplete = true;
            }
            else if (this.sessionInitializationComplete == true)
            {
                int carIdx = 0;     // Used as iterator to iterate through driver ID #'s in session string.
                int numDrivers = 0; // Counter for number of drivers in the current session.
                YamlQuery query;    // Yaml query object used to query data from the session string.
                string temp;        // Temporary string used to get string version of data from query before parsing to a number.
                string name;        // Temporary string used to compare a new name from query with current list of drivers in List<drivers>.

                // Check for new drivers that have entered since session started...
                query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                while (carIdx <= this.numStarters + 1)
                {
                    query.TryGetValue(out temp);
                    if (temp == null)
                    {
                        carIdx++;
                        query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                        continue;
                    }
                    else if (temp == "Pace Car")
                    {
                        carIdx++;
                        query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                        continue;
                    }
                    else
                    {
                        carIdx++;
                        numDrivers++;
                        query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                    }
                }

                if (drivers.Count != numDrivers)
                {
                    drivers.Clear();
                    PopulateDriversList(drivers, e);
                }

                // Every time session info updates check all drivers in List<drivers> for changes in incidents...
                carIdx = 0;
                query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                while (carIdx <= this.numStarters + 1)
                {
                    query.TryGetValue(out name);
                    if (name == null) // Someone who clicked join but never actually launched the simulator.
                    {
                        carIdx++;
                        query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                        continue;
                    }
                    if (name == "Pace Car") // We don't care about the pace car.
                    {
                        carIdx++;
                        query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                        continue;
                    }
                    foreach (var driver in drivers)
                    {
                        if (carIdx == driver.CarIdx)
                        {
                            string s_newIncs;
                            int i_newIncs;
                            query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["CurDriverIncidentCount"];
                            query.TryGetValue(out s_newIncs);
                            System.Int32.TryParse(s_newIncs, out i_newIncs);
                            driver.NewIncs = i_newIncs;
                            if ((driver.NewIncs - driver.OldIncs) != 0)
                            {
                                LogNewIncident(driver, (driver.NewIncs - driver.OldIncs));
                                driver.OldIncs = driver.NewIncs;
                            }
                            break;
                        }
                    }

                    carIdx++;
                    query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                }

                // Update current lap number for all drivers...
                int i = 1;
                string s_lapsComplete;
                string s_carIdx;
                carIdx = 0;
                int i_lapsComplete;
                query = e.SessionInfo["SessionInfo"]["Sessions"]["SessionNum", this.liveSessionNum]["ResultsPositions"]["Position", i]["CarIdx"];
                while (query.TryGetValue(out s_carIdx))
                {
                    System.Int32.TryParse(s_carIdx, out carIdx);
                    foreach (var driver in drivers)
                    {
                        if (carIdx == driver.CarIdx)
                        {
                            query = e.SessionInfo["SessionInfo"]["Sessions"]["SessionNum", this.liveSessionNum]["ResultsPositions"]["Position", i]["LapsComplete"];
                            query.TryGetValue(out s_lapsComplete);
                            System.Int32.TryParse(s_lapsComplete, out i_lapsComplete);
                            driver.CurrentLap = i_lapsComplete + 1;
                        }
                    }

                    i++;
                    query = e.SessionInfo["SessionInfo"]["Sessions"]["SessionNum", this.liveSessionNum]["ResultsPositions"]["Position", i]["CarIdx"];
                }
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
        public void OnTelemetryUpdated(object sender, SdkWrapper.TelemetryUpdatedEventArgs e)
        {
            // Check for incident limit reached for caution.
            // Animate color changes on CautionPanel.
            if ((this.incCountSinceCaution >= this.incsRequiredForCaution) && (this.incsRequiredForCaution != 0))
            {
                if (cautionState == CautionState.None)
                {
                    cautionHandlers.Values.ToList().ForEach(h => h.CautionThresholdReached());
                    cautionState = CautionState.ThresholdReached;
                }
            }

            // Update incident count fields.
            TotalIncidentCountNum.Text = this.totalIncCount.ToString();
            IncidentsSinceCautionNum.Text = this.incCountSinceCaution.ToString();

            // Update SessionUniqueID.
            var tempInt = wrapper.GetTelemetryValue<int>("SessionUniqueID");
            if (tempInt.Value() > this.liveUniqueSessionID)
            {
                this.sessionInitializationComplete = false;
                this.liveUniqueSessionID = tempInt.Value();
            }

            // Check for change in flag state.
            tempInt = wrapper.GetTelemetryValue<int>("SessionFlags");
            int flagField = tempInt.Value();
            if ((flagField & (uint)SessionFlags.Caution) != 0)
            {
                if (cautionState == CautionState.ThresholdReached)
                {
                    cautionHandlers.Values.ToList().ForEach(h => h.YellowFlagThrown());
                    cautionState = CautionState.YellowFlagDeployed;
                }
                this.incsReset = false;
            }
            if ((flagField & (uint)SessionFlags.Green) != 0 && (this.incsReset == false))
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

        /// <summary>
        /// Inserts new row in incident log.
        /// </summary>
        /// <param name="driver">Driver associated with the latest incident.</param>
        /// <param name="delta">The number of incident points gained by this driver on this occasion.</param>
        private void LogNewIncident(Driver driver, int delta)
        {
            StringBuilder sb = new StringBuilder();
            int rowId = IncidentsTableView.Rows.Add();
            DataGridViewRow newRow = IncidentsTableView.Rows[rowId];
            newRow.Cells[Properties.Resources.TableColumn_CarNum].Value = driver.CarNum;
            newRow.Cells[Properties.Resources.TableColumn_DriverName].Value = driver.FullName;
            sb.Append(delta + "x");
            newRow.Cells[Properties.Resources.TableColumn_Incident].Value = sb.ToString();
            newRow.Cells[Properties.Resources.TableColumn_Total].Value = driver.NewIncs.ToString();
            newRow.Cells[Properties.Resources.TableColumn_DriverLapNum].Value = driver.CurrentLap;
            this.totalIncCount += delta;
            this.incCountSinceCaution += delta;
            TotalIncidentCountNum.Text = this.totalIncCount.ToString();
            IncidentsSinceCautionNum.Text = this.incCountSinceCaution.ToString();
            if (delta == 4)
            {
                newRow.DefaultCellStyle.BackColor = System.Drawing.Color.FromName(Properties.Resources.ColorName_IndianRed);
            }
            IncidentsTableView.FirstDisplayedScrollingRowIndex = IncidentsTableView.RowCount - 1;
        }

        /// <summary>
        /// Populates a List<T> of drivers in the current session. 
        /// </summary>
        /// <param name="drivers">List of Driver objects.</param>
        /// <param name="e">Session string changed event. Object that conatains info from session string that can be queried.</param>
        private void PopulateDriversList(List<Driver> drivers, SdkWrapper.SessionInfoUpdatedEventArgs e)
        {
            int carIdx = 0;
            string fullName;
            int incidentCount;
            YamlQuery query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
            while (carIdx <= this.numStarters + 1)
            {
                query.TryGetValue(out fullName);
                if (fullName == null)
                {
                    carIdx++;
                    query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                    continue;
                }
                if (fullName == "Pace Car")
                {
                    carIdx++;
                    query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
                    continue;
                }

                Driver driver = new Driver();

                driver.FullName = fullName;
                driver.CarIdx = carIdx;

                query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["CarNumber"];
                driver.CarNum = query.Value;

                query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["IRating"];
                driver.IRating = query.Value;

                query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["CurDriverIncidentCount"];
                System.Int32.TryParse(query.Value, out incidentCount);
                driver.OldIncs = incidentCount;

                drivers.Add(driver);
                carIdx++;
                query = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["UserName"];
            }
        }

        /// <summary>
        /// Exports the incidents table to a CSV file when the Export... button is clicked.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">EventArgs event.</param>
        private void ExportButton_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".csv";
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream outputStream;
                if ((outputStream = saveFileDialog.OpenFile()) != null)
                {
                    var outputWriter = new StreamWriter(outputStream);
                    ExportIncidentTableToCsv(outputWriter);
                    outputWriter.Close();
                }
            }
        }

        /// <summary>
        /// Exports the contents of the IncidentsTableView to the given writer in CSV format.
        /// </summary>
        /// <param name="writer">The TextWriter to which the contents should be written.</param>
        private void ExportIncidentTableToCsv(TextWriter writer)
        {
            // write the column headers
            var headers = IncidentsTableView.Columns.Cast<DataGridViewColumn>();
            writer.WriteLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            // iterate through each row of the incidents table and write
            foreach (DataGridViewRow row in IncidentsTableView.Rows)
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
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            wrapper.Stop();
            Environment.Exit(0);
        }

        /// <summary>
        /// KeyUp event for IncsRequiredForCautionTextBox.
        /// Captures an "Enter" key pressed event to get new IncsRequiredForCaution value from user.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">KeyEvent event.</param>
        private void IncsRequiredForCautionTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (System.Int32.TryParse(IncsRequiredForCautionTextBox.Text, out this.incsRequiredForCaution) == false)
                {
                    MessageBox.Show(Properties.Resources.ErrorMessage_ValidNumberNotEntered);
                }
            }
        }

        private void AudioNotificationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AudioNotificationCheckBox.Checked)
            {
                var player = new AudioCautionHandler(
                    new SoundPlayerProxy(new SoundPlayer(RaceAdmin.Resources.Caution)))
                {
                    Repeat = 5, // times
                    Interval = 1000 // ms
                };

                cautionHandlers.Add("audio", player);
            }
            else
            {
                cautionHandlers.Remove("audio");
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

        // Code below this comment is used to generate test data or to simulate behavior 
        // for UI testing. To use, create buttons on the form and connect them to the various
        // event handler methods below.

        private int testCurrentLap = 1;

        private void Test_AddIncidentRow_Click(object sender, EventArgs e)
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

            LogNewIncident(driver, newIncidents);
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

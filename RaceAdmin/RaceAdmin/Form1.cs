using iRacingSdkWrapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RaceAdmin
{
    public partial class RaceAdminMain : Form
    {
        /// <summary>
        /// Counter used to animate CautionPanel.
        /// </summary>
        private int count = 0;

        /// <summary>
        /// Flag to indicate whether the incidents since last caution field has been reset to 0.
        /// </summary>
        private bool incsReset = false;

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
        /// Constructor for RaceAdminMain form. Initialization of WinForm, SdkWrapper, start wrapper object.
        /// </summary>
        public RaceAdminMain(ISdkWrapper wrapper)
        {
            this.wrapper = wrapper;

            // Initialize WinForm
            InitializeComponent();

            // Listen to events
            wrapper.AddTelemetryUpdateHandler(OnTelemetryUpdated);
            wrapper.AddSessionInfoUpdateHandler(OnSessionInfoUpdated);

            // Set telemetry update rate.
            wrapper.SetTelemetryUpdateFrequency(4); // Hz

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
        private void OnSessionInfoUpdated(object sender, SdkWrapper.SessionInfoUpdatedEventArgs e)
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
        private void OnTelemetryUpdated(object sender, SdkWrapper.TelemetryUpdatedEventArgs e)
        {
            // Check for incident limit reached for caution.
            // Animate color changes on CautionPanel.
            if ((this.incCountSinceCaution >= this.incsRequiredForCaution) && (this.incsRequiredForCaution != 0))
            {
                if (this.count % 2 == 0)
                {
                    if (CautionPanel.BackColor == System.Drawing.Color.FromName(Properties.Resources.ColorName_Control))
                    {
                        CautionPanel.BackColor = System.Drawing.Color.FromName(Properties.Resources.ColorName_Gold);
                    }
                    else if (CautionPanel.BackColor == System.Drawing.Color.FromName(Properties.Resources.ColorName_Gold))
                    {
                        CautionPanel.BackColor = System.Drawing.Color.FromName(Properties.Resources.ColorName_Control);
                    }
                }

                if (this.count >= 3)
                {
                    this.count = 0;
                }
                else
                {
                    this.count++;
                }
            }
            else
            {
                CautionPanel.BackColor = System.Drawing.Color.FromName(Properties.Resources.ColorName_Control);
            }

            // Update incident count fields.
            TotalIncidentCountNum.Text = this.totalIncCount.ToString();
            IncidentsSinceCautionNum.Text = this.incCountSinceCaution.ToString();

            // Update SessionUniqueID.
            var tempInt = wrapper.GetTelemetryValue<int>("SessionUniqueID");
            if (tempInt.Value > this.liveUniqueSessionID)
            {
                this.sessionInitializationComplete = false;
                this.liveUniqueSessionID = tempInt.Value;
            }

            // Check for change in flag state.
            tempInt = wrapper.GetTelemetryValue<int>("SessionFlags");
            int flagField = tempInt.Value;
            int greenFlag = 0x00000004;   // Bit flag defined as "green" in iRacing sdk.
            int cautionFlag = 0x00004000; // Bit flag defined as "caution" in iRacing sdk.
            if ((flagField & cautionFlag) != 0)
            {
                this.incsReset = false;
            }
            if ((flagField & greenFlag) != 0 && (this.incsReset == false))
            {
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
        /// Exports the contents of the IncidentsTableView to a csv file.
        /// </summary>
        private void ExportIncidentTableToCsv()
        {
            // Check for csv folder, create if it doesn't exist.
            StringBuilder csvPath = new StringBuilder();
            csvPath.Append(Path.GetDirectoryName(Application.ExecutablePath));
            csvPath.Append(@"\csv");
            Directory.CreateDirectory(csvPath.ToString());

            // Set path and filename for the csv file.
            DateTime dateTime = DateTime.Now;
            csvPath.Append(@"\");
            csvPath.Append(dateTime.ToString("yyyy-MM-dd HH-mm-ss"));
            csvPath.Append(@".csv");

            // Iterate through each row of the incident table and build a string to write to the csv file.
            StringBuilder csvString = new StringBuilder();
            var headers = IncidentsTableView.Columns.Cast<DataGridViewColumn>();
            csvString.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            foreach (DataGridViewRow row in IncidentsTableView.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                csvString.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }

            // Write to the csv file.
            File.WriteAllText(csvPath.ToString(), csvString.ToString());
        }

        /// <summary>
        /// Closes the current environment when the X button is clicked.
        /// Checks if user wants to export the incident table to csv.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">FormClosing event.</param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            wrapper.Stop();
            if (ExportToCsvCheckBox.Checked == true)
            {
                ExportIncidentTableToCsv();
            }

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
    }
}

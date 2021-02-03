using iRacingSdkWrapper;
using iRacingSdkWrapper.Bitfields;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RaceAdmin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RaceAdminTests
{
    using SessionFlags = iRacingSdkWrapper.Bitfields.SessionFlags;

    [TestClass]
    public class RaceAdminMainTests
    {
        const int TimedRaceLapRemainDefault = -1; // TODO: determine correct observed value from iRacing
        const double LapRaceTimeRemainDefault = 604800.0; // observed value from iRacing

        private const string SessionInfoUpdate1 = @"
WeekendInfo:
    WeekendOptions:
        NumStarters: 1
DriverInfo:
    Drivers:
        - CarIdx: 0
          UserName: Clark Archer
          TeamName: vApex Racing Group
          CarNumber: 29
          IRating: 3692
          CurDriverIncidentCount: 0
SessionInfo:
    Sessions:
        - SessionNum: 0
          SessionType: Race
          SessionName: RACE
          ResultsOfficial: 0
";
        private const string SessionInfoUpdate2 = @"
WeekendInfo:
    WeekendOptions:
        NumStarters: 2
DriverInfo:
    Drivers:
        - CarIdx: 0
          UserName: Clark Archer
          TeamName: vApex Racing Group
          CarNumber: 29
          IRating: 3692
          CurDriverIncidentCount: 0
        - CarIdx: 1
          UserName: Erich Smith
          TeamName: vApex Racing Group
          CarNumber: 32
          IRating: 3073
          CurDriverIncidentCount: 0
SessionInfo:
    Sessions:
        - SessionNum: 0
          SessionType: Race
          SessionName: RACE
          ResultsOfficial: 0
";
        private const string SessionInfoUpdate3 = @"
WeekendInfo:
    WeekendOptions:
        NumStarters: 2
DriverInfo:
    Drivers:
        - CarIdx: 0
          UserName: Clark Archer
          CarNumber: 29
          IRating: 3692
          CurDriverIncidentCount: 4
        - CarIdx: 1
          UserName: Erich Smith
          CarNumber: 32
          IRating: 3073
          CurDriverIncidentCount: 2
SessionInfo:
    Sessions:
        - SessionNum: 0
          SessionType: Race
          SessionName: RACE
          ResultsOfficial: 0
";

        private Mock<ISdkWrapper> mockWrapper;
        private Mock<ITelemetryUpdatedEvent> mockEvent;
        private Mock<ITelemetryInfo> mockTelemetryInfo;
        private Mock<ICautionHandler> mockCautionHandler;

        private Dictionary<string, ICautionHandler> cautionHandlers;
        private RaceAdminMain ram;

        [TestInitialize]
        public void Before()
        {
            mockWrapper = new Mock<ISdkWrapper>();
            mockEvent = new Mock<ITelemetryUpdatedEvent>();
            mockTelemetryInfo = new Mock<ITelemetryInfo>();
            mockCautionHandler = new Mock<ICautionHandler>();

            cautionHandlers = new Dictionary<string, ICautionHandler>
            {
                { "test", mockCautionHandler.Object }
            };

            ram = new RaceAdminMain(mockWrapper.Object);
            ram.SetTestCautionHandlers(cautionHandlers);
        }

        [TestMethod]
        public void TestIncidentTableView_SortCompare_Assumptions()
        {
            // check that a leading zero does not fail to parse or parse as octal
            Assert.AreEqual(90, Int32.Parse("090"));
            Assert.AreEqual(13, Int32.Parse("013"));
        }

        [TestMethod]
        public void TestIncidentsTableView_SortCompare_IgnoresNonCarNumColumn()
        {
            // create a sort event for a column not named "CarNum"
            var column = new DataGridViewColumn()
            {
                Name = "DriverName"
            };
            var e = new DataGridViewSortCompareEventArgs(column, null, null, 0, 0)
            {
                SortResult = 0,
                Handled = false
            };

            ram.IncidentsTableView_SortCompare(null, e);

            // event should not be handled
            Assert.AreEqual(0, e.SortResult);
            Assert.AreEqual(false, e.Handled);
        }

        [TestMethod]
        public void TestIncidentsTableView_SortCompare_ComparesCarNumColumnValues()
        {
            // create a sort event for the "CarNum" column
            var column = new DataGridViewColumn()
            {
                Name = "CarNum"
            };

            var data = new[] {
                ("1", "2", -1),  // simple numeric less than
                ("2", "1", 1),   // simple numeric greater than
                ("3", "3", 0),   // simple numeric equal
                ("10", "2", 1),  // verify sorting by numeric value
                ("1", "01", -1), // two digit numbers with leading zeros are sorted after single digit numbers
                ("044", "44", 1) // three digit numbers with leading zeros are sorted after two digit numbers
            };

            foreach (var x in data)
            {
                var e = new DataGridViewSortCompareEventArgs(column, x.Item1, x.Item2, 0, 0)
                {
                    SortResult = 0,
                    Handled = false
                };

                ram.IncidentsTableView_SortCompare(null, e);

                // event should be handled with valid sort result
                Assert.IsTrue(x.Item3 == e.SortResult,
                    "expected comparison between {0} and {1} to return {2}",
                    x.Item1, x.Item2, x.Item3);
                Assert.AreEqual(true, e.Handled);
            }
        }

        [TestMethod]
        public void TestExportIncidentTableToCSV()
        {
            // first add a few rows of incident logs
            var drivers = new Driver[]
            {
                new Driver() { FullName = "Clark Archer", CarNum = "29", OldIncs = 0, NewIncs = 2, CurrentLap = 1 },
                new Driver() { FullName = "Erich Smith",  CarNum = "32", OldIncs = 0, NewIncs = 4, CurrentLap = 4 },
                new Driver() { FullName = "Clark Archer", CarNum = "29", OldIncs = 2, NewIncs = 6, CurrentLap = 4 }
            };
            int timestamp = 0;
            Array.ForEach(drivers, d => ram.LogNewIncident(++timestamp, d, d.NewIncs - d.OldIncs));

            // set up a mock TextWriter to capture all arguments passed to the WriteLine() method
            var lines = new List<String>();
            var mockWriter = new Mock<TextWriter>();
            mockWriter.Setup(w => w.WriteLine(Capture.In(lines)));

            // run the export
            ram.ExportIncidentTableToCsv(mockWriter.Object);

            // now assemble the expected lines we want to see in the output CSV
            var expected = new List<String>
            {
                "\"Time\",\"Car #\",\"Team\",\"Driver\",\"Inc.\",\"Total\",\"Car Lap #\""
            };
            timestamp = 0;
            Array.ForEach(drivers, d => expected.Add(MakeDriverCSV(++timestamp, d)));

            // verify that the expected values match what the export method actually wrote
            Assert.IsTrue(expected.SequenceEqual(lines),
                "CSV output did not match!\n\tExpected:\n{0}\n\tActual:\n{1}",
                MakeLines(expected), MakeLines(lines));
        }

        private static string MakeLines(List<String> list)
        {
            return String.Join("\n", list.Select(s => "\t\t" + s).ToArray());
        }

        private static string MakeDriverCSV(double timestamp, Driver driver)
        {
            var fields = new String[] {
                RaceAdminMain.MakeTimeString(timestamp),
                driver.CarNum,
                driver.TeamName,
                driver.FullName,
                MakeIncidents(driver),
                driver.NewIncs.ToString(),
                driver.CurrentLap.ToString() };

            return String.Join(",", fields.Select(f => "\"" + f + "\"").ToArray());
        }

        private static string MakeIncidents(Driver driver)
        {
            var delta = driver.NewIncs - driver.OldIncs;
            return delta.ToString() + "x";
        }

        [TestMethod]
        public void TestOnSessionInfoUpdate_ReadsDriverInfo()
        {
            ram.OnSessionInfoUpdated(null, new SdkWrapper.SessionInfoUpdatedEventArgs(SessionInfoUpdate1, 0.0));

            Assert.AreEqual(1, ram.Drivers.Values.Count);
            var driver = ram.Drivers["Clark Archer"];
            Assert.AreEqual("Clark Archer", driver.FullName);
            Assert.AreEqual("29", driver.CarNum);
            Assert.AreEqual("3692", driver.IRating);
            Assert.AreEqual(0, driver.OldIncs);
        }

        [TestMethod]
        public void TestOnSessionInfoUpdated_DetectsNewDrivers()
        {
            ram.OnSessionInfoUpdated(null, new SdkWrapper.SessionInfoUpdatedEventArgs(SessionInfoUpdate1, 0.0));
            Assert.AreEqual(1, ram.Drivers.Count);
            ram.OnSessionInfoUpdated(null, new SdkWrapper.SessionInfoUpdatedEventArgs(SessionInfoUpdate2, 1.0));
            Assert.AreEqual(2, ram.Drivers.Count);
        }

        [TestMethod]
        public void TestOnSessionInfoUpdated_DetectsNewIncidents()
        {
            ram.OnSessionInfoUpdated(null, new SdkWrapper.SessionInfoUpdatedEventArgs(SessionInfoUpdate2, 0.0));
            Assert.AreEqual(0, ram.TotalIncCount);
            Assert.AreEqual(0, ram.IncCountSinceCaution);

            ram.OnSessionInfoUpdated(null, new SdkWrapper.SessionInfoUpdatedEventArgs(SessionInfoUpdate3, 2.0));
            Assert.AreEqual(6, ram.TotalIncCount);
            Assert.AreEqual(6, ram.IncCountSinceCaution);
        }

        [TestMethod]
        public void TestOnTelemetryUpdated_ReadsSessionId()
        {
            var sessionNum = 0;
            var sessionId = 1;

            mockTelemetryInfo.Setup(e => e.SessionFlags).Returns(new FakeTelemetryValue<SessionFlag>(new SessionFlag(0)));
            mockTelemetryInfo.Setup(e => e.SessionNum).Returns(new FakeTelemetryValue<int>(sessionNum));
            mockTelemetryInfo.Setup(e => e.SessionUniqueID).Returns(new FakeTelemetryValue<int>(sessionId));
            mockEvent.Setup(e => e.TelemetryInfo).Returns(mockTelemetryInfo.Object);

            ram.OnTelemetryUpdated(null, mockEvent.Object);

            Assert.AreEqual(sessionId, ram.SessionUniqueID);
        }

        [TestMethod]
        public void TestOnTelemetryUpdated_CautionHandlerInteraction()
        {
            var sessionFlagsCalls = 0;
            mockTelemetryInfo.Setup(e => e.SessionNum).Returns(new FakeTelemetryValue<int>(0));
            mockTelemetryInfo.Setup(e => e.SessionUniqueID).Returns(new FakeTelemetryValue<int>(0));
            mockTelemetryInfo.Setup(e => e.SessionLapsRemain).Returns(new FakeTelemetryValue<int>(99));
            mockTelemetryInfo.Setup(e => e.SessionTimeRemain).Returns(new FakeTelemetryValue<double>(LapRaceTimeRemainDefault));
            mockTelemetryInfo.Setup(e => e.SessionFlags)
                .Callback(() => sessionFlagsCalls++)
                .Returns(() =>
                {
                    if (sessionFlagsCalls < 3)
                    {
                        return new FakeTelemetryValue<SessionFlag>(new SessionFlag(0));
                    }
                    else if (sessionFlagsCalls < 5)
                    {
                        return new FakeTelemetryValue<SessionFlag>(new SessionFlag((int)SessionFlags.Caution));
                    }
                    else if (sessionFlagsCalls < 7)
                    {
                        return new FakeTelemetryValue<SessionFlag>(new SessionFlag((int)SessionFlags.Green));
                    }
                    else
                    {
                        return new FakeTelemetryValue<SessionFlag>(new SessionFlag(0));
                    }
                });
            mockEvent.Setup(e => e.TelemetryInfo).Returns(mockTelemetryInfo.Object);

            ram.IncsRequiredForCaution = 5;

            // add drivers to the session, then send some incidents to trigger caution flag needed notification
            ram.OnSessionInfoUpdated(null, new SdkWrapper.SessionInfoUpdatedEventArgs(SessionInfoUpdate2, 1.0));
            ram.OnSessionInfoUpdated(null, new SdkWrapper.SessionInfoUpdatedEventArgs(SessionInfoUpdate3, 2.0));

            // on the first two calls to OnTelemetryUpdated, the mock wrapper will detect that a caution is needed
            // and has not yet been thrown
            ram.OnTelemetryUpdated(null, mockEvent.Object);
            ram.OnTelemetryUpdated(null, mockEvent.Object);

            // but we want to notify the caution handler only once
            mockCautionHandler.Verify(handler => handler.CautionThresholdReached(), Times.Once());

            // on the second and third calls, the mock wrapper will return SessionFlags indicating a caution has been thrown
            ram.OnTelemetryUpdated(null, mockEvent.Object);
            ram.OnTelemetryUpdated(null, mockEvent.Object);

            // and again we only want to notify the caution handler once
            mockCautionHandler.Verify(handler => handler.YellowFlagThrown(), Times.Once());

            // finally we are ready to get back to green flag racing, so the mock wrapper will return SessionFlags
            // indicating that the green flag has been thrown
            ram.OnTelemetryUpdated(null, mockEvent.Object);
            ram.OnTelemetryUpdated(null, mockEvent.Object);

            // as before we want the caution handler to be notified the green flag has been thrown exactly once
            mockCautionHandler.Verify(handler => handler.GreenFlagThrown(), Times.Once());
        }

        [TestMethod]
        public void TestOnTelemetryUpdated_NoCautionsDuringLastXLaps_XLapsToGo()
        {
            // no incidents last 5 laps; note that since the iRacing telemetry contains
            // the number of complete laps left for the leader, when the leader comes to 
            // the line, the reported number of laps left will not count the lap the leader
            // is currently on. So, as the leader comes to the line with 5 laps to go, as
            // soon as the car crosses the finish line, iRacing will report 4 laps to go.
            const int IncidentLapCutoff = 5;

            mockTelemetryInfo.Setup(e => e.SessionNum).Returns(new FakeTelemetryValue<int>(RaceAdminMain.DefaultSessionNum));
            mockTelemetryInfo.Setup(e => e.SessionUniqueID).Returns(new FakeTelemetryValue<int>(RaceAdminMain.DefaultSessionUniqueID));
            mockTelemetryInfo.Setup(e => e.SessionLapsRemain).Returns(new FakeTelemetryValue<int>(IncidentLapCutoff - 1));
            mockTelemetryInfo.Setup(e => e.SessionTimeRemain).Returns(new FakeTelemetryValue<double>(LapRaceTimeRemainDefault));
            mockEvent.Setup(e => e.TelemetryInfo).Returns(mockTelemetryInfo.Object);

            ram.RaceSession = true;
            ram.IncsRequiredForCaution = 5;
            ram.IncCountSinceCaution = 5;
            ram.LastLaps = IncidentLapCutoff;

            ram.OnTelemetryUpdated(this, mockEvent.Object);

            // verify that the caution handlers were not triggered even though
            // the incident count equals the required incidents since the incident
            // threshold was exceeded during the last 5 laps of the race
            mockCautionHandler.VerifyNoOtherCalls();
            Assert.IsTrue(ram.CautionState == CautionState.None);
        }
    }
}

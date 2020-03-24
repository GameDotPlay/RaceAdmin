using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceAdmin;
using Moq;
using iRacingSdkWrapper;

namespace RaceAdminTests
{
    [TestClass]
    public class RaceAdminMainTests
    {
        private const string sessionInfoUpdate1 = @"
WeekendInfo:
    WeekendOptions:
        NumStarters: 1
DriverInfo:
    Drivers:
        - CarIdx: 0
          UserName: Clark Archer
          CarNumber: 29
          IRating: 3692
          CurDriverIncidentCount: 0
";
        private const string sessionInfoUpdate2 = @"
WeekendInfo:
    WeekendOptions:
        NumStarters: 2
DriverInfo:
    Drivers:
        - CarIdx: 0
          UserName: Clark Archer
          CarNumber: 29
          IRating: 3692
          CurDriverIncidentCount: 0
        - CarIdx: 1
          UserName: Erich Smith
          CarNumber: 32
          IRating: 3073
          CurDriverIncidentCount: 0
";
        private const string sessionInfoUpdate3 = @"
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
";

        [TestMethod]
        public void TestOnSessionInfoUpdate_ReadsDriverInfo()
        {
            var mock = new Mock<ISdkWrapper>();
            var sessionInfo = new SdkWrapper.SessionInfoUpdatedEventArgs(sessionInfoUpdate1, 0.0);

            RaceAdminMain ram = new RaceAdminMain(mock.Object);
            ram.OnSessionInfoUpdated(null, sessionInfo);

            Assert.AreEqual(1, ram.Drivers.Count);
            Assert.AreEqual("Clark Archer", ram.Drivers[0].FullName);
            Assert.AreEqual("29", ram.Drivers[0].CarNum);
            Assert.AreEqual("3692", ram.Drivers[0].IRating);
            Assert.AreEqual(0, ram.Drivers[0].OldIncs);
        }

        [TestMethod]
        public void TestOnSessionInfoUpdated_DetectsNewDrivers()
        {
            var mock = new Mock<ISdkWrapper>();

            RaceAdminMain ram = new RaceAdminMain(mock.Object);
            ram.OnSessionInfoUpdated(null, new SdkWrapper.SessionInfoUpdatedEventArgs(sessionInfoUpdate1, 0.0));
            Assert.AreEqual(1, ram.Drivers.Count);
            ram.OnSessionInfoUpdated(null, new SdkWrapper.SessionInfoUpdatedEventArgs(sessionInfoUpdate2, 1.0));
            Assert.AreEqual(2, ram.Drivers.Count);
        }

        [TestMethod]
        public void TestOnSessionInfoUpdated_DetectsNewIncidents()
        {
            var mock = new Mock<ISdkWrapper>();

            RaceAdminMain ram = new RaceAdminMain(mock.Object);

            ram.OnSessionInfoUpdated(null, new SdkWrapper.SessionInfoUpdatedEventArgs(sessionInfoUpdate2, 0.0));
            Assert.AreEqual(0, ram.TotalIncCount);
            Assert.AreEqual(0, ram.IncCountSinceCaution);

            ram.OnSessionInfoUpdated(null, new SdkWrapper.SessionInfoUpdatedEventArgs(sessionInfoUpdate3, 2.0));
            Assert.AreEqual(6, ram.TotalIncCount);
            Assert.AreEqual(6, ram.IncCountSinceCaution);
        }

        [TestMethod]
        public void TestOnTelemetryUpdatedReadsSessionId()
        {
            var sessionId = 29;

            var mock = new Mock<ISdkWrapper>();
            mock.Setup(wrapper => wrapper.GetTelemetryValue<int>("SessionUniqueID")).Returns(new FakeTelemetryValue<int>(sessionId));
            mock.Setup(wrapper => wrapper.GetTelemetryValue<int>("SessionFlags")).Returns(new FakeTelemetryValue<int>(0));

            RaceAdminMain ram = new RaceAdminMain(mock.Object);
            ram.OnTelemetryUpdated(null, null);

            Assert.AreEqual(sessionId, ram.LiveUniqueSessionID);
        }
    }
}

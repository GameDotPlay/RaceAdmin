using iRacingSdkWrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RaceAdmin;
using System.Collections.Generic;

namespace RaceAdminTests
{
    using SessionFlags = iRacingSdkWrapper.Bitfields.SessionFlags;

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

        private Mock<ISdkWrapper> mockWrapper;
        private Mock<ICautionHandler> mockCautionHandler;
        private Dictionary<string, ICautionHandler> cautionHandlers;
        private RaceAdminMain ram;

        [TestInitialize]
        public void Before()
        {
            mockWrapper = new Mock<ISdkWrapper>();
            mockCautionHandler = new Mock<ICautionHandler>();
            cautionHandlers = new Dictionary<string, ICautionHandler>();
            cautionHandlers.Add("test", mockCautionHandler.Object);

            ram = new RaceAdminMain(mockWrapper.Object);
            ram.SetTestCautionHandlers(cautionHandlers);
        }

        [TestMethod]
        public void TestOnSessionInfoUpdate_ReadsDriverInfo()
        {
            ram.OnSessionInfoUpdated(null, new SdkWrapper.SessionInfoUpdatedEventArgs(sessionInfoUpdate1, 0.0));

            Assert.AreEqual(1, ram.Drivers.Count);
            Assert.AreEqual("Clark Archer", ram.Drivers[0].FullName);
            Assert.AreEqual("29", ram.Drivers[0].CarNum);
            Assert.AreEqual("3692", ram.Drivers[0].IRating);
            Assert.AreEqual(0, ram.Drivers[0].OldIncs);
        }

        [TestMethod]
        public void TestOnSessionInfoUpdated_DetectsNewDrivers()
        {
            ram.OnSessionInfoUpdated(null, new SdkWrapper.SessionInfoUpdatedEventArgs(sessionInfoUpdate1, 0.0));
            Assert.AreEqual(1, ram.Drivers.Count);
            ram.OnSessionInfoUpdated(null, new SdkWrapper.SessionInfoUpdatedEventArgs(sessionInfoUpdate2, 1.0));
            Assert.AreEqual(2, ram.Drivers.Count);
        }

        [TestMethod]
        public void TestOnSessionInfoUpdated_DetectsNewIncidents()
        {
            ram.OnSessionInfoUpdated(null, new SdkWrapper.SessionInfoUpdatedEventArgs(sessionInfoUpdate2, 0.0));
            Assert.AreEqual(0, ram.TotalIncCount);
            Assert.AreEqual(0, ram.IncCountSinceCaution);

            ram.OnSessionInfoUpdated(null, new SdkWrapper.SessionInfoUpdatedEventArgs(sessionInfoUpdate3, 2.0));
            Assert.AreEqual(6, ram.TotalIncCount);
            Assert.AreEqual(6, ram.IncCountSinceCaution);
        }

        [TestMethod]
        public void TestOnTelemetryUpdated_ReadsSessionId()
        {
            var sessionId = 1;

            mockWrapper.Setup(wrapper => wrapper.GetTelemetryValue<int>("SessionUniqueID")).Returns(new FakeTelemetryValue<int>(sessionId));
            mockWrapper.Setup(wrapper => wrapper.GetTelemetryValue<int>("SessionFlags")).Returns(new FakeTelemetryValue<int>(0));

            ram.OnTelemetryUpdated(null, null);

            Assert.AreEqual(sessionId, ram.LiveUniqueSessionID);
        }

        [TestMethod]
        public void TestOnTelemetryUpdated_CautionHandlerInteraction()
        {
            mockWrapper.Setup(wrapper => wrapper.GetTelemetryValue<int>("SessionUniqueID")).Returns(new FakeTelemetryValue<int>(0));
            var sessionFlagsCalls = 0;
            mockWrapper.Setup(wrapper => wrapper.GetTelemetryValue<int>("SessionFlags"))
                .Callback(() => sessionFlagsCalls++)
                .Returns(() =>
                {
                    if (sessionFlagsCalls < 3)
                    {
                        return new FakeTelemetryValue<int>(0);
                    }
                    else if (sessionFlagsCalls < 5)
                    {
                        return new FakeTelemetryValue<int>((int)SessionFlags.Caution);
                    }
                    else if (sessionFlagsCalls < 7)
                    {
                        return new FakeTelemetryValue<int>((int)SessionFlags.Green);
                    }
                    else
                    {
                        return new FakeTelemetryValue<int>(0);
                    }
                });

            ram.IncsRequiredForCaution = 5;

            // add drivers to the session, then send some incidents to trigger caution flag needed notification
            ram.OnSessionInfoUpdated(null, new SdkWrapper.SessionInfoUpdatedEventArgs(sessionInfoUpdate2, 1.0));
            ram.OnSessionInfoUpdated(null, new SdkWrapper.SessionInfoUpdatedEventArgs(sessionInfoUpdate3, 2.0));

            // on the first two calls to OnTelemetryUpdated, the mock wrapper will detect that a caution is needed
            // and has not yet been thrown
            ram.OnTelemetryUpdated(null, null);
            ram.OnTelemetryUpdated(null, null);

            // but we want to notify the caution handler only once
            mockCautionHandler.Verify(handler => handler.CautionThresholdReached(), Times.Once());

            // on the second and third calls, the mock wrapper will return SessionFlags indicating a caution has been thrown
            ram.OnTelemetryUpdated(null, null);
            ram.OnTelemetryUpdated(null, null);

            // and again we only want to notify the caution handler once
            mockCautionHandler.Verify(handler => handler.YellowFlagThrown(), Times.Once());

            // finally we are ready to get back to green flag racing, so the mock wrapper will return SessionFlags
            // indicating that the green flag has been thrown
            ram.OnTelemetryUpdated(null, null);
            ram.OnTelemetryUpdated(null, null);

            // as before we want the caution handler to be notified the green flag has been thrown exactly once
            mockCautionHandler.Verify(handler => handler.GreenFlagThrown(), Times.Once());
        }
    }
}

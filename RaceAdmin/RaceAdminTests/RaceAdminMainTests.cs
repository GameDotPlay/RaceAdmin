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
        [TestMethod]
        public void TestReadSessionIdFromSdk()
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

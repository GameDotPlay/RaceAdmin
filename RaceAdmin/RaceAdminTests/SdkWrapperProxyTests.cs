using iRacingSdkWrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RaceAdmin;
using System;

namespace RaceAdminTests
{
    [TestClass]
    public class SdkWrapperProxyTests
    {
        private SdkWrapper wrapper;
        private SdkWrapperProxy proxy;

        [TestInitialize]
        public void Before()
        {
            wrapper = new SdkWrapper();
            proxy = new SdkWrapperProxy(wrapper, false);

        }

        [TestMethod]
        public void TestOnSessionInfoUpdate_SupportsMultipleCallbacks()
        {
            var mockHandler1 = new Mock<EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs>>();
            var mockHandler2 = new Mock<EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs>>();

            proxy.AddSessionInfoUpdateHandler(mockHandler1.Object);
            proxy.AddSessionInfoUpdateHandler(mockHandler2.Object);

            proxy.OnSessionInfoUpdate(this, null);

            mockHandler1.Verify(h => h.Invoke(this, It.IsAny<SdkWrapper.SessionInfoUpdatedEventArgs>()), Times.Once());
            mockHandler2.Verify(h => h.Invoke(this, It.IsAny<SdkWrapper.SessionInfoUpdatedEventArgs>()), Times.Once());
        }

        [TestMethod]
        public void TestOnTelemetryUpdate_SupportsMultipleCallbacks()
        {
            var mockHandler1 = new Mock<EventHandler<ITelemetryUpdatedEvent>>();
            var mockHandler2 = new Mock<EventHandler<ITelemetryUpdatedEvent>>();

            proxy.AddTelemetryUpdateHandler(mockHandler1.Object);
            proxy.AddTelemetryUpdateHandler(mockHandler2.Object);

            var info = new TelemetryInfo(wrapper.Sdk);
            var evt = new SdkWrapper.TelemetryUpdatedEventArgs(info, 0.0);
            proxy.OnTelemetryUpdate(this, evt);

            mockHandler1.Verify(h => h.Invoke(this, It.IsAny<ITelemetryUpdatedEvent>()), Times.Once());
            mockHandler2.Verify(h => h.Invoke(this, It.IsAny<ITelemetryUpdatedEvent>()), Times.Once());
        }
    }
}

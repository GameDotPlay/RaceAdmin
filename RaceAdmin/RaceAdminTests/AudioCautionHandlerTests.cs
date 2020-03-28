using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RaceAdmin;
using System;
using System.Threading;

namespace RaceAdminTests
{

    [TestClass]
    public class AudioCautionHandlerTests
    {
        private const int soundRepeatCount = 5;
        private const int soundInterval = 10; // ms

        private Mock<ISoundPlayer> player;
        private AudioCautionHandler handler;

        [TestInitialize]
        public void Before()
        {
            player = new Mock<ISoundPlayer>();
            handler = new AudioCautionHandler(player.Object)
            {
                Repeat = soundRepeatCount,
                Interval = soundInterval
            };
        }

        [TestMethod]
        public void TestCautionThresholdReached_PlaysCautionSound()
        {
            handler.CautionThresholdReached();
            Thread.Sleep(soundInterval * soundRepeatCount * 2);

            // verify sound was played....
            player.Verify(p => p.Play(), Times.Exactly(soundRepeatCount));
        }

        [TestMethod]
        public void TestYellowFlagThrown_StopsCautionSound()
        {
            DateTime playLastCalled = DateTime.MinValue;

            player.Setup(p => p.Play())
                .Callback(() => playLastCalled = DateTime.Now);

            handler.CautionThresholdReached();
            Thread.Sleep(soundInterval * 3);

            var now = DateTime.Now;
            handler.YellowFlagThrown();
            Thread.Sleep(soundInterval * soundRepeatCount * 2);

            // verify sound is stopped
            player.Verify(p => p.Play(), Times.AtLeastOnce());
            Assert.IsTrue(playLastCalled < now,
                "expected playLastCalled {0} to be before {1}",
                DateUtil.ToStringISO(playLastCalled), DateUtil.ToStringISO(now));
        }

    }

}

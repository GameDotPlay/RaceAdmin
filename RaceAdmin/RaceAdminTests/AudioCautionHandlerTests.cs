using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RaceAdmin;

namespace RaceAdminTests
{

    [TestClass]
    public class AudioCautionHandlerTests
    {
        private Mock<ISoundPlayer> player;
        private AudioCautionHandler handler;

        [TestInitialize]
        public void Before()
        {
            player = new Mock<ISoundPlayer>();
            handler = new AudioCautionHandler(player.Object);
        }

        [TestMethod]
        public void TestCautionThresholdReached_PlaysCautionSound()
        {
            handler.CautionThresholdReached();

            // verify sound was played....
            player.Verify(p => p.PlayLooping(), Times.Once());
        }

        [TestMethod]
        public void TestYellowFlagThrown_StopsCautionSound()
        {
            handler.YellowFlagThrown();

            // verify sound is stopped
            player.Verify(p => p.Stop(), Times.Once());
        }

    }

}

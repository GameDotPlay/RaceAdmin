using System.Windows.Forms;

namespace RaceAdmin
{
    public interface ICautionHandler
    {
        void CautionThresholdReached();
        void YellowFlagThrown();
        void GreenFlagThrown();
        Panel CautionPanel { get; set; }
    }
}

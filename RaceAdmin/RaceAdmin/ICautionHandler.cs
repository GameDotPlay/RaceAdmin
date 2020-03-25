using System.Windows.Forms;

namespace RaceAdmin
{
    public interface ICautionHandler
    {
        void YellowFlagNeeded();
        void YellowFlagThrown();
        void GreenFlagThrown();
        Panel CautionPanel { get; set; }
    }
}

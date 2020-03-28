namespace RaceAdmin
{
    public interface ICautionHandler
    {
        void CautionThresholdReached();
        void YellowFlagThrown();
        void GreenFlagThrown();
    }
}

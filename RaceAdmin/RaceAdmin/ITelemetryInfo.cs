using iRacingSdkWrapper.Bitfields;

namespace RaceAdmin
{
    public interface ITelemetryInfo
    {
        ITelemetryValue<SessionFlag> SessionFlags { get; }
        ITelemetryValue<int> SessionUniqueID { get; }

    }

}
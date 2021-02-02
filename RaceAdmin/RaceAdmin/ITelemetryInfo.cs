using iRacingSdkWrapper.Bitfields;

namespace RaceAdmin
{
    public interface ITelemetryInfo
    {
        ITelemetryValue<SessionFlag> SessionFlags { get; }
        ITelemetryValue<int> SessionNum { get; }
        ITelemetryValue<int> SessionUniqueID { get; }

    }

}
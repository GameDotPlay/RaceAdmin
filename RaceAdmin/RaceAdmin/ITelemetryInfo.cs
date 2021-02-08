using iRacingSdkWrapper.Bitfields;

namespace RaceAdmin
{
    public interface ITelemetryInfo
    {
        ITelemetryValue<SessionFlag> SessionFlags { get; }
        ITelemetryValue<int> SessionLapsRemain { get; }
        ITelemetryValue<int> SessionNum { get; }
        ITelemetryValue<double> SessionTimeRemain { get; }
        ITelemetryValue<int> SessionUniqueID { get; }
    }

}
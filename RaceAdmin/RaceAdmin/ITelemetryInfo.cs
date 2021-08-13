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
        ITelemetryValue<float[]> PercentAroundTrack { get; }
        ITelemetryValue<bool[]> BetweenPitCones { get; }
        ITelemetryValue<int[]> CurrentLap { get; }
        ITelemetryValue<int[]> LapsCompleted { get; }
        ITelemetryValue<int[]> OverallPositionInRace { get; }
        ITelemetryValue<int[]> ClassPositionInRace { get; }
    }

}
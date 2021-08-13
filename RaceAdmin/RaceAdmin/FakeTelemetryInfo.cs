using iRacingSdkWrapper.Bitfields;

namespace RaceAdmin
{
    public class FakeTelemetryInfo : ITelemetryInfo
    {
        public ITelemetryValue<SessionFlag> SessionFlags { get; set; }
        public ITelemetryValue<int> SessionLapsRemain { get; set; }
        public ITelemetryValue<int> SessionNum { get; set; }
        public ITelemetryValue<double> SessionTimeRemain { get; set; }
        public ITelemetryValue<int> SessionUniqueID { get; set; }
        public ITelemetryValue<float[]> PercentAroundTrack { get; }
        public ITelemetryValue<bool[]> BetweenPitCones { get; }
        public ITelemetryValue<int[]> CurrentLap { get; }
        public ITelemetryValue<int[]> LapsCompleted { get; }
        public ITelemetryValue<int[]> OverallPositionInRace { get; }
        public ITelemetryValue<int[]> ClassPositionInRace { get; }
    }

}

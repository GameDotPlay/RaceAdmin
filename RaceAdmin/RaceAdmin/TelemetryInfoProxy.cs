using iRacingSdkWrapper;
using iRacingSdkWrapper.Bitfields;

namespace RaceAdmin
{
    internal class TelemetryInfoProxy : ITelemetryInfo
    {
        private readonly SdkWrapper wrapper;
        private readonly TelemetryInfo telemetryInfo;

        public TelemetryInfoProxy(SdkWrapper wrapper, TelemetryInfo telemetryInfo)
        {
            this.wrapper = wrapper;
            this.telemetryInfo = telemetryInfo;
        }

        public ITelemetryValue<SessionFlag> SessionFlags { get => new TelemetryValueProxy<SessionFlag>(telemetryInfo.SessionFlags); }
        public ITelemetryValue<int> SessionLapsRemain { get => new TelemetryValueProxy<int>(wrapper.GetTelemetryValue<int>("SessionLapsRemain")); }
        public ITelemetryValue<int> SessionNum { get => new TelemetryValueProxy<int>(telemetryInfo.SessionNum); }
        public ITelemetryValue<int> SessionUniqueID { get => new TelemetryValueProxy<int>(telemetryInfo.SessionUniqueID); }
        public ITelemetryValue<double> SessionTimeRemain { get => new TelemetryValueProxy<double>(telemetryInfo.SessionTimeRemain); }
        public ITelemetryValue<float[]> PercentAroundTrack { get => new TelemetryValueProxy<float[]>(telemetryInfo.CarIdxLapDistPct); }
        public ITelemetryValue<bool[]> BetweenPitCones { get => new TelemetryValueProxy<bool[]>(telemetryInfo.CarIdxOnPitRoad); }
        public ITelemetryValue<int[]> CurrentLap { get => new TelemetryValueProxy<int[]>(telemetryInfo.CarIdxLap); }
        public ITelemetryValue<int[]> LapsCompleted { get => new TelemetryValueProxy<int[]>(telemetryInfo.CarIdxLapCompleted); }
        public ITelemetryValue<int[]> OverallPositionInRace { get => new TelemetryValueProxy<int[]>(telemetryInfo.CarIdxPosition); }
        public ITelemetryValue<int[]> ClassPositionInRace { get => new TelemetryValueProxy<int[]>(telemetryInfo.CarIdxClassPosition); }

        // NOTE: To get telemetry values not defined in Nick's wrapper...
        //    var fictionalObject = wrapper.GetTelemetryValue<T>("VariableName");
        //    int fictionalValue = fictionalObject.Value;
    }
}

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

        // NOTE: To get telemetry values not defined in Nick's wrapper...
        //    var fictionalObject = wrapper.GetTelemetryValue<int>("VariableName");
        //    int fictionalValue = fictionalObject.Value;
    }
}

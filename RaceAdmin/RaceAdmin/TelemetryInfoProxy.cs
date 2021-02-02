using iRacingSdkWrapper;
using iRacingSdkWrapper.Bitfields;

namespace RaceAdmin
{
    internal class TelemetryInfoProxy : ITelemetryInfo
    {
        private TelemetryInfo telemetryInfo;

        public TelemetryInfoProxy(TelemetryInfo telemetryInfo)
        {
            this.telemetryInfo = telemetryInfo;
        }

        public ITelemetryValue<SessionFlag> SessionFlags { get => new TelemetryValueProxy<SessionFlag>(telemetryInfo.SessionFlags); }

        public ITelemetryValue<int> SessionNum { get => new TelemetryValueProxy<int>(telemetryInfo.SessionNum); }

        public ITelemetryValue<int> SessionUniqueID { get => new TelemetryValueProxy<int>(telemetryInfo.SessionUniqueID); }
    }

}
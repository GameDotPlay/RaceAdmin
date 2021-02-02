using iRacingSdkWrapper.Bitfields;

namespace RaceAdmin
{
    public class FakeTelemetryInfo : ITelemetryInfo
    {
        public ITelemetryValue<SessionFlag> SessionFlags { get; set; }

        public ITelemetryValue<int> SessionNum { get; set; }

        public ITelemetryValue<int> SessionUniqueID { get; set; }

    }

}

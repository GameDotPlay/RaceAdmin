namespace RaceAdmin
{
    public class TelemetryUpdatedEventProxy : ITelemetryUpdatedEvent
    {
        private readonly ITelemetryInfo telemetryInfo;

        public TelemetryUpdatedEventProxy(ITelemetryInfo telemetryInfo)
        {
            this.telemetryInfo = telemetryInfo;
        }

        public ITelemetryInfo TelemetryInfo { get => telemetryInfo; }
    }

}

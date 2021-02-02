namespace RaceAdmin
{
    class FakeTelemetryUpdatedEvent : ITelemetryUpdatedEvent
    {
        private readonly ITelemetryInfo telemetryInfo;
        public FakeTelemetryUpdatedEvent(ITelemetryInfo telemetryInfo)
        {
            this.telemetryInfo = telemetryInfo;
        }

        public ITelemetryInfo TelemetryInfo { get => telemetryInfo; }

    }
}

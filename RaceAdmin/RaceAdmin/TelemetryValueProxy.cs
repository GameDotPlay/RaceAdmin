using iRacingSdkWrapper;

namespace RaceAdmin
{
    internal class TelemetryValueProxy<T> : ITelemetryValue<T>
    {
        private readonly TelemetryValue<T> telemetryValue;

        public TelemetryValueProxy(TelemetryValue<T> telemetryValue)
        {
            this.telemetryValue = telemetryValue;
        }

        public T Value { get => telemetryValue.Value; }
    }
}
using RaceAdmin;

namespace RaceAdminTests
{
    internal class FakeTelemetryValue<T> : ITelemetryValue<T>
    {
        private T value;

        public FakeTelemetryValue(T value)
        {
            this.value = value;
        }

        public T Value()
        {
            return value;
        }
    }
}
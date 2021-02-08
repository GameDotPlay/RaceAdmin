namespace RaceAdmin
{
    public class FakeTelemetryValue<T> : ITelemetryValue<T>
    {
        private readonly T value;

        public FakeTelemetryValue(T value)
        {
            this.value = value;
        }

        public T Value { get => value; }
    }

}
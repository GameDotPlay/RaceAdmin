using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

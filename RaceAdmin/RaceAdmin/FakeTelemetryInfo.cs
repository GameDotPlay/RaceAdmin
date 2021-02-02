using iRacingSdkWrapper.Bitfields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceAdmin
{
    public class FakeTelemetryInfo : ITelemetryInfo
    {
        public ITelemetryValue<SessionFlag> SessionFlags { get; set; }

        public ITelemetryValue<int> SessionNum { get; set; }

        public ITelemetryValue<int> SessionUniqueID { get; set; }

    }

}

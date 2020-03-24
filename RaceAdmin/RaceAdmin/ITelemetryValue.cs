using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceAdmin
{
    public interface ITelemetryValue<T>
    {
        T Value();
    }
}

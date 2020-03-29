using System;
using System.Globalization;

namespace RaceAdmin
{
    public class DateUtil
    {
        /// <summary>
        /// Converts the given DateTime into an ISO 8601 style date-time string.
        /// </summary>
        /// <param name="dt">The DateTime to be converted.</param>
        /// <returns>a string containing the given DateTime in ISO 8601 format</returns>
        public static string ToStringISO(DateTime dt)
        {
            return dt.ToUniversalTime().ToString("o", CultureInfo.InvariantCulture);
        }

    }
}

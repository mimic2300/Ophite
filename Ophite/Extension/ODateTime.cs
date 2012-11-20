using System;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datový typ "DateTime".
    /// </summary>
    public static class ODateTime
    {
        /// <summary>
        /// Převádí datum na unixový čas.
        /// </summary>
        /// <param name="date">Datum pro převod.</param>
        /// <returns>Vrací unixový čas jako long.</returns>
        public static long AsUnixTime(this DateTime date)
        {
            return (long)(date - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
        }
    }
}

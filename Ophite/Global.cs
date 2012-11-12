using System;

namespace Ophite
{
    /// <summary>
    /// Globální instance.
    /// </summary>
    public static class Global
    {
        /// <summary>
        /// Generátor náhodných čísel.
        /// </summary>
        public static readonly Random RAND = new Random((int)DateTime.Now.Ticks);
    }
}

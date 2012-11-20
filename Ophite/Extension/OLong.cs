using System;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datový typ "long".
    /// </summary>
    public static class OLong
    {
        /// <summary>
        /// Převádí long číslo na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <param name="toBigEndian">Má se převést pole byte do BigEndian?</param>
        /// <returns>Vrací long číslo jako pole byte.</returns>
        public static byte[] AsBytes(this long number, bool toBigEndian = true)
        {
            byte[] data = BitConverter.GetBytes(number);

            if (data.IsEmpty())
                return data;

            if (toBigEndian && BitConverter.IsLittleEndian)
                Array.Reverse(data);

            return data;
        }

        /// <summary>
        /// Převádí číslo na HEX hodnotu.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <param name="toUpper">Mají být písmena A-F velká?</param>
        /// <returns>Vrací HEX hodnotu z čísla.</returns>
        public static string AsHex(this long number, bool toUpper = true)
        {
            return number.ToString(toUpper ? "X" : "x");
        }

        /// <summary>
        /// Převádí unixový čas na datum.
        /// </summary>
        /// <param name="unixTime">Unixový čas.</param>
        /// <returns>Vrací novou instanci datumu.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static DateTime AsDateTime(this long unixTime)
        {
            return (new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(unixTime);
        }
    }
}

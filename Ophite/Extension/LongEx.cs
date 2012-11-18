using Ophite.Exceptions;
using System;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datové typy "long" a "ulong".
    /// </summary>
    public static class LongEx
    {
        #region LONG

        /// <summary>
        /// Převádí long číslo na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací long číslo jako pole byte.</returns>
        /// <remarks>Převede LittleEndian na BigEndian.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="RankException"></exception>
        public static byte[] AsBytes(this long number)
        {
            byte[] data = BitConverter.GetBytes(number);

            try
            {
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(data);
            }
            catch (ArgumentNullException ex) { throw new OphiteException(ExceptionType.ArgumentNullException, ex); }
            catch (RankException ex) { throw new OphiteException(ExceptionType.RankException, ex); }

            return data;
        }

        /// <summary>
        /// Převádí číslo na HEX hodnotu.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <param name="upper">Mají být písmena A-F velká?</param>
        /// <returns>Vrací HEX hodnotu z čísla.</returns>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="FormatException"></exception>
        public static string AsHex(this long number, bool upper = true)
        {
            try
            {
                return number.ToString(upper ? "X" : "x");
            }
            catch (FormatException ex) { throw new OphiteException(ExceptionType.FormatException, ex); }
        }

        /// <summary>
        /// Převádí unixový čas na datum.
        /// </summary>
        /// <param name="unixTime">Unixový čas.</param>
        /// <returns>Vrací novou instanci datumu.</returns>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static DateTime FromUnixTime(this long unixTime)
        {
            try
            {
                return (new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(unixTime);
            }
            catch (ArgumentOutOfRangeException ex) { throw new OphiteException(ExceptionType.ArgumentOutOfRangeException, ex); }
        }

        #endregion LONG

        #region ULONG

        /// <summary>
        /// Převádí číslo ulong na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací ulong číslo jako pole byte.</returns>
        /// <remarks>Převede LittleEndian na BigEndian.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="RankException"></exception>
        public static byte[] AsBytes(this ulong number)
        {
            byte[] data = BitConverter.GetBytes(number);

            try
            {
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(data);
            }
            catch (ArgumentNullException ex) { throw new OphiteException(ExceptionType.ArgumentNullException, ex); }
            catch (RankException ex) { throw new OphiteException(ExceptionType.RankException, ex); }

            return data;
        }

        #endregion ULONG
    }
}

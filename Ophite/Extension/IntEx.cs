using Ophite.Exceptions;
using System;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datové typy "int" a "uint".
    /// </summary>
    public static class IntEx
    {
        #region INT

        /// <summary>
        /// Převádí int číslo na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací int číslo jako pole byte.</returns>
        /// <remarks>Převede LittleEndian na BigEndian.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="RankException"></exception>
        public static byte[] AsBytes(this int number)
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

        #endregion INT

        #region UINT

        /// <summary>
        /// Převádí uint číslo na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací uint číslo jako pole byte.</returns>
        /// <remarks>Převede LittleEndian na BigEndian.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="RankException"></exception>
        public static byte[] AsBytes(this uint number)
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

        #endregion UINT
    }
}

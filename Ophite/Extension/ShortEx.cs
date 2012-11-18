using Ophite.Exceptions;
using System;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datové typy "short" a "ushort".
    /// </summary>
    public static class ShortEx
    {
        #region SHORT

        /// <summary>
        /// Převádí short číslo na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací short číslo jako pole byte.</returns>
        /// <remarks>Převede LittleEndian na BigEndian.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="RankException"></exception>
        public static byte[] AsBytes(this short number)
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

        #endregion SHORT

        #region USHORT

        /// <summary>
        /// Převádí ushort číslo na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací ushort číslo jako pole byte.</returns>
        /// <remarks>Převede LittleEndian na BigEndian.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="RankException"></exception>
        public static byte[] AsBytes(this ushort number)
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

        #endregion USHORT
    }
}

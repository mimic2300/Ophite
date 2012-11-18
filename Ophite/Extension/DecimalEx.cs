using Ophite.Exceptions;
using System;
using System.IO;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datové typy "float", "double" a "decimal".
    /// </summary>
    public static class DecimalEx
    {
        #region FLOAT

        /// <summary>
        /// Převádí číslo float na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací float číslo jako pole byte.</returns>
        /// <remarks>Převede LittleEndian na BigEndian.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="RankException"></exception>
        public static byte[] AsBytes(this float number)
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

        #endregion FLOAT

        #region DOUBLE

        /// <summary>
        /// Převádí číslo double na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací double číslo jako pole byte.</returns>
        /// <remarks>Převede LittleEndian na BigEndian.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="RankException"></exception>
        public static byte[] AsBytes(this double number)
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

        #endregion DOUBLE

        #region DECIMAL

        /// <summary>
        /// Převádí číslo decimal na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací decimal číslo jako pole byte.</returns>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static byte[] AsBytes(this decimal number)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    using (BinaryWriter br = new BinaryWriter(ms))
                    {
                        br.Write(number);
                        return ms.ToArray();
                    }
                }
                catch (ArgumentNullException ex) { throw new OphiteException(ExceptionType.ArgumentNullException, ex); }
                catch (ArgumentException ex) { throw new OphiteException(ExceptionType.ArgumentException, ex); }
            }
        }

        #endregion DECIMAL
    }
}

using System;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datový typ "double".
    /// </summary>
    public static class ODouble
    {
        /// <summary>
        /// Převádí číslo double na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <param name="toBigEndian">Má se převést pole byte do BigEndian?</param>
        /// <returns>Vrací double číslo jako pole byte.</returns>
        public static byte[] AsBytes(this double number, bool toBigEndian = true)
        {
            byte[] data = BitConverter.GetBytes(number);

            if (data.IsEmpty())
                return data;

            if (toBigEndian && BitConverter.IsLittleEndian)
                Array.Reverse(data);

            return data;
        }
    }
}

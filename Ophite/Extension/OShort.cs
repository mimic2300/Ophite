using System;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datový typ "short".
    /// </summary>
    public static class OShort
    {
        /// <summary>
        /// Převádí short číslo na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <param name="toBigEndian">Má se převést pole byte do BigEndian?</param>
        /// <returns>Vrací short číslo jako pole byte.</returns>
        public static byte[] AsBytes(this short number, bool toBigEndian = true)
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

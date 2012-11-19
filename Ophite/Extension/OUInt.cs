using System;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datový typ "uint".
    /// </summary>
    public static class OUInt
    {
        /// <summary>
        /// Převádí uint číslo na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <param name="toBigEndian">Má se převést pole byte do BigEndian?</param>
        /// <returns>Vrací uint číslo jako pole byte.</returns>
        public static byte[] AsBytes(this uint number, bool toBigEndian = true)
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

using System;
using System.IO;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datový typ "decimal".
    /// </summary>
    public static class ODecimal
    {
        /// <summary>
        /// Převádí číslo decimal na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <param name="toBigEndian">Má se převést pole byte do BigEndian?</param>
        /// <returns>Vrací decimal číslo jako pole byte.</returns>
        public static byte[] AsBytes(this decimal number, bool toBigEndian = true)
        {
            byte[] data = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryWriter br = new BinaryWriter(ms))
                {
                    br.Write(number);
                    data =  ms.ToArray();
                }
            }

            if (data.IsEmpty())
                return data;

            if (toBigEndian && BitConverter.IsLittleEndian)
                Array.Reverse(data);

            return data;
        }
    }
}

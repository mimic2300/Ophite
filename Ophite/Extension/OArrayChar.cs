using System;
using System.IO;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datový typ "char[]".
    /// </summary>
    public static class OArrayChar
    {
        /// <summary>
        /// Kontroluje, zda velikost pole char není prázdné a není NULL.
        /// </summary>
        /// <param name="array">Vstupní pole char.</param>
        /// <returns>Vrací TRUE, pokud pole je prázdné nebo NULL.</returns>
        public static bool IsEmpty(this char[] array)
        {
            return (array == null || array.Length < 1);
        }

        /// <summary>
        /// Převádí pole znaků na pole byte.
        /// </summary>
        /// <param name="array">Vstupní pole znaků.</param>
        /// <returns>Vrací pole byte.</returns>
        /// <remarks>Pokud pole charů bude NULL, tak vrací NULL.</remarks>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="IOException"></exception>
        public static byte[] AsBytes(this char[] array)
        {
            if (array == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryWriter br = new BinaryWriter(ms))
                {
                    br.Write(array);
                    return ms.ToArray();
                }
            }
        }
    }
}

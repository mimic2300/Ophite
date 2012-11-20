using System.Drawing;
using System.IO;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datový typ "Icon".
    /// </summary>
    public static class OIcon
    {
        /// <summary>
        /// Převádí ikonu do pole byte.
        /// </summary>
        /// <param name="icon">Vstupní ikona.</param>
        /// <returns>Vrací pole byte.</returns>
        /// <remarks>Pokud ikona bude NULL, tak vrací NULL.</remarks>
        public static byte[] AsBytes(this Icon icon)
        {
            if (icon == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            {
                icon.Save(ms);
                return ms.ToArray();
            }
        }
    }
}

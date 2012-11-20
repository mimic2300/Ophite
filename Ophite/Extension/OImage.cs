using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datový typ "Image".
    /// </summary>
    public static class OImage
    {
        /// <summary>
        /// Převádí Image do pole byte.
        /// </summary>
        /// <param name="img">Vstupní image.</param>
        /// <param name="format">Do jakého formátu se má image rozložit.</param>
        /// <returns>Vrací pole byte.</returns>
        /// <remarks>Funguje i na bitmapu. Pokud vstupní parametr bude NULL, tak vrací NULL.</remarks>
        public static byte[] AsBytes(this Image img, ImageFormat format)
        {
            if (img == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, format);
                return ms.ToArray();
            }
        }
    }
}

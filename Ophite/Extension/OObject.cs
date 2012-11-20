using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Security;
using System.Text;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datový typ "object".
    /// </summary>
    public static class OObject
    {
        /// <summary>
        /// Převádí objekt na serializované pole byte.
        /// </summary>
        /// <param name="obj">Vstupní objekt.</param>
        /// <returns>Vrací serializované pole byte.</returns>
        /// <remarks>Pokud vstupní objekt bude třída nebo struktůra, tak musí obsahovat flag [Serializable].
        /// Pokud objekt bude NULL, tak vrací NULL.</remarks>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="SecurityException"></exception>
        public static byte[] AsObjectSerialize(this object obj)
        {
            if (obj == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Převádí objekt na SOAP string v kódování ASCII.
        /// </summary>
        /// <param name="obj">Vstupní objekt.</param>
        /// <returns>Vrací SOAP ASCII string.</returns>
        /// <remarks>Pokud vstupní objekt bude třída nebo struktůra, tak musí obsahovat flag [Serializable].
        /// Pokud objekt bude NULL, tak vrací NULL.</remarks>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="SecurityException"></exception>
        public static string AsSoapStringASCII(this object obj)
        {
            if (obj == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            {
                new SoapFormatter().Serialize(ms, obj);
                ms.Flush();
                return Encoding.ASCII.GetString(ms.GetBuffer(), 0, (int)ms.Position);
            }
        }

        /// <summary>
        /// Převádí objekt na SOAP string v kódování UTF8.
        /// </summary>
        /// <param name="obj">Vstupní objekt.</param>
        /// <returns>Vrací SOAP UTF8 string.</returns>
        /// <remarks>Pokud vstupní objekt bude třída nebo struktůra, tak musí obsahovat flag [Serializable].
        /// Pokud objekt bude NULL, tak vrací NULL.</remarks>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="SecurityException"></exception>
        public static string AsSoapStringUTF8(this object obj)
        {
            if (obj == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            {
                new SoapFormatter().Serialize(ms, obj);
                ms.Flush();
                return UTF8Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Position);
            }
        }
    }
}

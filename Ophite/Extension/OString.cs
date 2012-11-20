using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Xml;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datový typ "string".
    /// </summary>
    public static class OString
    {
        /// <summary>
        /// Kontroluje, zda vstupní text je prázdný nebo NULL.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <returns>Pokud je vstupní text je prázdný nebo NULL, tak vrací TRUE.</returns>
        public static bool IsEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }

        /// <summary>
        /// Převádí text na pole byte v kódování ASCII.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="toBigEndian">Má se převést pole byte do BigEndian?</param>
        /// <returns>Vrací pole byte z ASCII textu.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static byte[] AsBytesASCII(this string text, bool toBigEndian = false)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);

            if (data.IsEmpty())
                return data;

            if (toBigEndian && BitConverter.IsLittleEndian)
                Array.Reverse(data);

            return data;
        }

        /// <summary>
        /// Převádí text na pole byte v kódování UTF8.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="toBigEndian">Má se převést pole byte do BigEndian?</param>
        /// <returns>Vrací pole byte z UTF8 textu.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static byte[] AsBytesUTF8(this string text, bool toBigEndian = false)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);

            if (data.IsEmpty())
                return data;

            if (toBigEndian && BitConverter.IsLittleEndian)
                Array.Reverse(data);

            return data;
        }

        /// <summary>
        /// Převádí text na číslo short.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="ignoreException">Má se ignorovat vyjímka při chybném převodu?</param>
        /// <returns>Vrací číslo short.</returns>
        /// <remarks>Pokud se bude ignorovat vyjímka a převod selže, tak vrací 0.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static short AsShort(this string text, bool ignoreException = false)
        {
            if (ignoreException)
            {
                short value;
                short.TryParse(text, out value);
                return value;
            }
            return short.Parse(text);
        }

        /// <summary>
        /// Převádí text na číslo ushort.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="ignoreException">Má se ignorovat vyjímka při chybném převodu?</param>
        /// <returns>Vrací číslo ushort.</returns>
        /// <remarks>Pokud se bude ignorovat vyjímka a převod selže, tak vrací 0.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static ushort AsUShort(this string text, bool ignoreException = false)
        {
            if (ignoreException)
            {
                ushort value;
                ushort.TryParse(text, out value);
                return value;
            }
            return ushort.Parse(text);
        }

        /// <summary>
        /// Převádí text na číslo int.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="ignoreException">Má se ignorovat vyjímka při chybném převodu?</param>
        /// <returns>Vrací číslo int.</returns>
        /// <remarks>Pokud se bude ignorovat vyjímka a převod selže, tak vrací 0.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static int AsInt(this string text, bool ignoreException = false)
        {
            if (ignoreException)
            {
                int value;
                int.TryParse(text, out value);
                return value;
            }
            return int.Parse(text);
        }

        /// <summary>
        /// Převádí text na číslo uint.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="ignoreException">Má se ignorovat vyjímka při chybném převodu?</param>
        /// <returns>Vrací číslo uint.</returns>
        /// <remarks>Pokud se bude ignorovat vyjímka a převod selže, tak vrací 0.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static uint AsUInt(this string text, bool ignoreException = false)
        {
            if (ignoreException)
            {
                uint value;
                uint.TryParse(text, out value);
                return value;
            }
            return uint.Parse(text);
        }

        /// <summary>
        /// Převádí text na číslo long.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="ignoreException">Má se ignorovat vyjímka při chybném převodu?</param>
        /// <returns>Vrací číslo long.</returns>
        /// <remarks>Pokud se bude ignorovat vyjímka a převod selže, tak vrací 0.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static long AsLong(this string text, bool ignoreException = false)
        {
            if (ignoreException)
            {
                long value;
                long.TryParse(text, out value);
                return value;
            }
            return long.Parse(text);
        }

        /// <summary>
        /// Převádí text na číslo ulong.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="ignoreException">Má se ignorovat vyjímka při chybném převodu?</param>
        /// <returns>Vrací číslo ulong.</returns>
        /// <remarks>Pokud se bude ignorovat vyjímka a převod selže, tak vrací 0.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static ulong AsULong(this string text, bool ignoreException = false)
        {
            if (ignoreException)
            {
                ulong value;
                ulong.TryParse(text, out value);
                return value;
            }
            return ulong.Parse(text);
        }

        /// <summary>
        /// Převádí text na číslo float.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="ignoreException">Má se ignorovat vyjímka při chybném převodu?</param>
        /// <returns>Vrací číslo float.</returns>
        /// <remarks>Pokud se bude ignorovat vyjímka a převod selže, tak vrací 0.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static float AsFloat(this string text, bool ignoreException = false)
        {
            if (ignoreException)
            {
                float value;
                float.TryParse(text, out value);
                return value;
            }
            return float.Parse(text, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Převádí text na číslo double.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="ignoreException">Má se ignorovat vyjímka při chybném převodu?</param>
        /// <returns>Vrací číslo double.</returns>
        /// <remarks>Pokud se bude ignorovat vyjímka a převod selže, tak vrací 0.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static double AsDouble(this string text, bool ignoreException = false)
        {
            if (ignoreException)
            {
                double value;
                double.TryParse(text, out value);
                return value;
            }
            return double.Parse(text, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Převádí text na číslo decimal.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="ignoreException">Má se ignorovat vyjímka při chybném převodu?</param>
        /// <returns>Vrací číslo decimal.</returns>
        /// <remarks>Pokud se bude ignorovat vyjímka a převod selže, tak vrací 0.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static decimal AsDecimal(this string text, bool ignoreException = false)
        {
            if (ignoreException)
            {
                decimal value;
                decimal.TryParse(text, out value);
                return value;
            }
            return decimal.Parse(text, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Převádí HEX hodnotu ze stringu do long čísla.
        /// </summary>
        /// <param name="hex">HEX hodnota v podobě stringu.</param>
        /// <returns>Vrací číslo long.</returns>
        /// <remarks>HEX string musí být maximálně 16 znaků dlouhý (převod do long).</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static long AsHexValue(this string hex)
        {
            return long.Parse(hex, NumberStyles.HexNumber);
        }

        /// <summary>
        /// Čte řetězec tak dlouho, dokud nenarazí na vstupní znak.
        /// </summary>
        /// <param name="text">Vstupní řetězec.</param>
        /// <param name="chr">Znak, který určuje konec čtení.</param>
        /// <param name="withReadChr">Má se přečíst i vstupní znak?</param>
        /// <returns>Vrací přečtený řetězec.</returns>
        /// <remarks>Pokud vstupní text bude prázdný nebo se znak nebude vyskytovat v textu, tak vrácí NULL.</remarks>
        public static string ReadTo(this string text, char chr, bool withReadChr = false)
        {
            if (text.IsEmpty())
                return null;

            int index = text.IndexOf(chr);

            if (index == -1)
                return null;

            return text.Substring(0, index + (withReadChr ? 1 : 0));
        }

        /// <summary>
        /// Čte řetězec do určité délky.
        /// </summary>
        /// <param name="text">Vstupní řetězec.</param>
        /// <param name="count">Kolik znaků se má přečíst.</param>
        /// <returns>Vrací přečtený řetězec.</returns>
        /// <remarks>Pokud vstupní text bude prázdný nebo počet nebude platný, tak vrácí NULL.</remarks>
        public static string ReadTo(this string text, int count)
        {
            if (text.IsEmpty())
                return null;

            if (count < 0 || count > text.Length)
                return null;

            return text.Substring(0, count);
        }

        /// <summary>
        /// Rozdělí text podle slova na pole stringů.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="splitString">Rozdělovací text.</param>
        /// <param name="options">Nastavení rozdělení.</param>
        /// <returns>Vrací pole stringů.</returns>
        /// <remarks>Pokud vstupní text bude NULL nebo rozdělovací text bude NULL, tak vrácí prázdné pole.</remarks>
        public static string[] SplitEx(this string text, string splitString, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            if (text.IsEmpty())
                return new string[] { };

            if (splitString.IsEmpty())
                return new string[] { text };

            return text.Split(new string[] { splitString }, options);
        }

        /// <summary>
        /// Převádí HEX hodnotu ze stringu na pole byte.
        /// </summary>
        /// <param name="hexString">HEX hodnota jako string.</param>
        /// <param name="start">Odebere text, který bude před každou HEX hodnotou (např. 0x).</param>
        /// <param name="end">Odebere text, který bude za každou HEX hodnotou (např. mezera).</param>
        /// <returns>Vrací pole byte.</returns>
        /// <remarks>Pokud hexString bude prázdný nebo NULL, tak vrací prázdné pole.</remarks>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static byte[] AsBytesFromHex(this string hexString, string start = "", string end = "")
        {
            if (hexString.IsEmpty() || hexString.Length < 1)
                return new byte[] { };

            string[] tokens = null;

            if (!start.IsEmpty() && hexString.Contains(start))
                tokens = hexString.SplitEx(start);

            List<byte> buffer = new List<byte>();

            if (!tokens.IsEmpty())
            {
                foreach (string part in tokens)
                {
                    string tmp = part;

                    if (!end.IsEmpty() && part.Contains(end))
                        tmp = part.SplitEx(end)[0];

                    buffer.Add(Convert.ToByte(tmp, 16));
                }
            }
            else
            {
                if (!end.IsEmpty() && hexString.Contains(end))
                    tokens = hexString.SplitEx(end);

                if (!tokens.IsEmpty())
                {
                    foreach (string part in tokens)
                    {
                        buffer.Add(Convert.ToByte(part, 16));
                    }
                }
                else
                {
                    if (hexString.Length % 2 != 0)
                        hexString = "0" + hexString;

                    for (int i = 0, n = 0; i < hexString.Length; i += 2, n++)
                    {
                        buffer.Add(Convert.ToByte(hexString.Substring(i, 2), 16));
                    }
                }
            }
            return buffer.ToArray();
        }

        /// <summary>
        /// Převádí SOAP string na objekt.
        /// </summary>
        /// <param name="soapString">Vstupní SOAP string.</param>
        /// <returns>Vrací původní objekt.</returns>
        /// <remarks>Pokud soapString bude NULL, tak vrací NULL.</remarks>
        /// <exception cref="XmlException"></exception>
        public static object AsObjectFromSoap(this string soapString)
        {
            if (soapString == null)
                return null;

            using (MemoryStream ms = new MemoryStream(soapString.AsBytesUTF8()))
            {
                return new SoapFormatter().Deserialize(ms);
            }
        }

        /// <summary>
        /// Odstraní počáteční nuly.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        public static string RemoveLeadingZeros(this string text)
        {
            if (!text.IsEmpty())
                return text.TrimStart('0');

            return text;
        }

        /// <summary>
        /// Převádí text z base64 zpět na pole byte.
        /// </summary>
        /// <param name="data">Vstupní text v base64.</param>
        /// <returns>Vrací pole byte.</returns>
        /// <remarks>Pokud vstupní text bude NULL, tak vrací prázdní pole byte.</remarks>
        /// <exception cref="FormatException"></exception>
        public static byte[] FromBase64(this string data)
        {
            if (data.IsEmpty())
                return new byte[] { };

            return Convert.FromBase64String(data);
        }
    }
}

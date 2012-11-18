﻿using Ophite.Exceptions;
using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datový typ "string".
    /// </summary>
    public static class StringEx
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
        /// <returns>Vrací pole byte z ASCII textu.</returns>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="EncoderFallbackException"></exception>
        public static byte[] AsBytesASCII(this string text)
        {
            try
            {
                return Encoding.ASCII.GetBytes(text);
            }
            catch (ArgumentNullException ex) { throw new OphiteException(ExceptionType.ArgumentNullException, ex); }
            catch (EncoderFallbackException ex) { throw new OphiteException(ExceptionType.EncoderFallbackException, ex); }
        }

        /// <summary>
        /// Převádí text na pole byte v kódování UTF8.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <returns>Vrací pole byte z UTF8 textu.</returns>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="EncoderFallbackException"></exception>
        public static byte[] AsBytesUTF8(this string text)
        {
            try
            {
                return Encoding.UTF8.GetBytes(text);
            }
            catch (ArgumentNullException ex) { throw new OphiteException(ExceptionType.ArgumentNullException, ex); }
            catch (EncoderFallbackException ex) { throw new OphiteException(ExceptionType.EncoderFallbackException, ex); }
        }

        /// <summary>
        /// Převádí text na číslo short.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="ignoreException">Má se ignorovat vyjímka při chybném převodu?</param>
        /// <returns>Vrací číslo short.</returns>
        /// <remarks>Pokud se bude ignorovat vyjímka a převod selže, tak vrací 0.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static short AsShort(this string text, bool ignoreException = false)
        {
            try
            {
                if (ignoreException)
                {
                    short value;
                    short.TryParse(text, out value);
                    return value;
                }
                return short.Parse(text);
            }
            catch (ArgumentNullException ex) { throw new OphiteException(ExceptionType.ArgumentNullException, ex); }
            catch (FormatException ex) { throw new OphiteException(ExceptionType.FormatException, ex); }
            catch (OverflowException ex) { throw new OphiteException(ExceptionType.OverflowException, ex); }
        }

        /// <summary>
        /// Převádí text na číslo ushort.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="ignoreException">Má se ignorovat vyjímka při chybném převodu?</param>
        /// <returns>Vrací číslo ushort.</returns>
        /// <remarks>Pokud se bude ignorovat vyjímka a převod selže, tak vrací 0.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static ushort AsUShort(this string text, bool ignoreException = false)
        {
            try
            {
                if (ignoreException)
                {
                    ushort value;
                    ushort.TryParse(text, out value);
                    return value;
                }
                return ushort.Parse(text);
            }
            catch (ArgumentNullException ex) { throw new OphiteException(ExceptionType.ArgumentNullException, ex); }
            catch (FormatException ex) { throw new OphiteException(ExceptionType.FormatException, ex); }
            catch (OverflowException ex) { throw new OphiteException(ExceptionType.OverflowException, ex); }
        }

        /// <summary>
        /// Převádí text na číslo int.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="ignoreException">Má se ignorovat vyjímka při chybném převodu?</param>
        /// <returns>Vrací číslo int.</returns>
        /// <remarks>Pokud se bude ignorovat vyjímka a převod selže, tak vrací 0.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static int AsInt(this string text, bool ignoreException = false)
        {
            try
            {
                if (ignoreException)
                {
                    int value;
                    int.TryParse(text, out value);
                    return value;
                }
                return int.Parse(text);
            }
            catch (ArgumentNullException ex) { throw new OphiteException(ExceptionType.ArgumentNullException, ex); }
            catch (FormatException ex) { throw new OphiteException(ExceptionType.FormatException, ex); }
            catch (OverflowException ex) { throw new OphiteException(ExceptionType.OverflowException, ex); }
        }

        /// <summary>
        /// Převádí text na číslo uint.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="ignoreException">Má se ignorovat vyjímka při chybném převodu?</param>
        /// <returns>Vrací číslo uint.</returns>
        /// <remarks>Pokud se bude ignorovat vyjímka a převod selže, tak vrací 0.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static uint AsUInt(this string text, bool ignoreException = false)
        {
            try
            {
                if (ignoreException)
                {
                    uint value;
                    uint.TryParse(text, out value);
                    return value;
                }
                return uint.Parse(text);
            }
            catch (ArgumentNullException ex) { throw new OphiteException(ExceptionType.ArgumentNullException, ex); }
            catch (FormatException ex) { throw new OphiteException(ExceptionType.FormatException, ex); }
            catch (OverflowException ex) { throw new OphiteException(ExceptionType.OverflowException, ex); }
        }

        /// <summary>
        /// Převádí text na číslo long.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="ignoreException">Má se ignorovat vyjímka při chybném převodu?</param>
        /// <returns>Vrací číslo long.</returns>
        /// <remarks>Pokud se bude ignorovat vyjímka a převod selže, tak vrací 0.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static long AsLong(this string text, bool ignoreException = false)
        {
            try
            {
                if (ignoreException)
                {
                    long value;
                    long.TryParse(text, out value);
                    return value;
                }
                return long.Parse(text);
            }
            catch (ArgumentNullException ex) { throw new OphiteException(ExceptionType.ArgumentNullException, ex); }
            catch (FormatException ex) { throw new OphiteException(ExceptionType.FormatException, ex); }
            catch (OverflowException ex) { throw new OphiteException(ExceptionType.OverflowException, ex); }
        }

        /// <summary>
        /// Převádí text na číslo ulong.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="ignoreException">Má se ignorovat vyjímka při chybném převodu?</param>
        /// <returns>Vrací číslo ulong.</returns>
        /// <remarks>Pokud se bude ignorovat vyjímka a převod selže, tak vrací 0.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static ulong AsULong(this string text, bool ignoreException = false)
        {
            try
            {
                if (ignoreException)
                {
                    ulong value;
                    ulong.TryParse(text, out value);
                    return value;
                }
                return ulong.Parse(text);
            }
            catch (ArgumentNullException ex) { throw new OphiteException(ExceptionType.ArgumentNullException, ex); }
            catch (FormatException ex) { throw new OphiteException(ExceptionType.FormatException, ex); }
            catch (OverflowException ex) { throw new OphiteException(ExceptionType.OverflowException, ex); }
        }

        /// <summary>
        /// Převádí text na číslo float.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="ignoreException">Má se ignorovat vyjímka při chybném převodu?</param>
        /// <returns>Vrací číslo float.</returns>
        /// <remarks>Pokud se bude ignorovat vyjímka a převod selže, tak vrací 0.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static float AsFloat(this string text, bool ignoreException = false)
        {
            try
            {
                if (ignoreException)
                {
                    float value;
                    float.TryParse(text, out value);
                    return value;
                }
                return float.Parse(text);
            }
            catch (ArgumentNullException ex) { throw new OphiteException(ExceptionType.ArgumentNullException, ex); }
            catch (FormatException ex) { throw new OphiteException(ExceptionType.FormatException, ex); }
            catch (OverflowException ex) { throw new OphiteException(ExceptionType.OverflowException, ex); }
        }

        /// <summary>
        /// Převádí text na číslo double.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="ignoreException">Má se ignorovat vyjímka při chybném převodu?</param>
        /// <returns>Vrací číslo double.</returns>
        /// <remarks>Pokud se bude ignorovat vyjímka a převod selže, tak vrací 0.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static double AsDouble(this string text, bool ignoreException = false)
        {
            try
            {
                if (ignoreException)
                {
                    double value;
                    double.TryParse(text, out value);
                    return value;
                }
                return double.Parse(text);
            }
            catch (ArgumentNullException ex) { throw new OphiteException(ExceptionType.ArgumentNullException, ex); }
            catch (FormatException ex) { throw new OphiteException(ExceptionType.FormatException, ex); }
            catch (OverflowException ex) { throw new OphiteException(ExceptionType.OverflowException, ex); }
        }

        /// <summary>
        /// Převádí text na číslo decimal.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="ignoreException">Má se ignorovat vyjímka při chybném převodu?</param>
        /// <returns>Vrací číslo decimal.</returns>
        /// <remarks>Pokud se bude ignorovat vyjímka a převod selže, tak vrací 0.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static decimal AsDecimal(this string text, bool ignoreException = false)
        {
            try
            {
                if (ignoreException)
                {
                    decimal value;
                    decimal.TryParse(text, out value);
                    return value;
                }
                return decimal.Parse(text);
            }
            catch (ArgumentNullException ex) { throw new OphiteException(ExceptionType.ArgumentNullException, ex); }
            catch (FormatException ex) { throw new OphiteException(ExceptionType.FormatException, ex); }
            catch (OverflowException ex) { throw new OphiteException(ExceptionType.OverflowException, ex); }
        }

        /// <summary>
        /// Převádí HEX hodnotu ze stringu do long čísla.
        /// </summary>
        /// <param name="hex">HEX hodnota v podobě stringu.</param>
        /// <returns>Vrací číslo long.</returns>
        /// <remarks>HEX string musí být maximálně 16 znaků dlouhý (převod do long).</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static long AsHexValue(this string hex)
        {
            try
            {
                return long.Parse(hex, NumberStyles.HexNumber);
            }
            catch (ArgumentNullException ex) { throw new OphiteException(ExceptionType.ArgumentNullException, ex); }
            catch (ArgumentException ex) { throw new OphiteException(ExceptionType.ArgumentException, ex); }
            catch (FormatException ex) { throw new OphiteException(ExceptionType.FormatException, ex); }
            catch (OverflowException ex) { throw new OphiteException(ExceptionType.OverflowException, ex); }
        }

        /// <summary>
        /// Čte řetězec tak dlouho, dokud nenarazí na vstupní znak nebo do určité délky.
        /// </summary>
        /// <param name="text">Vstupní řetězec.</param>
        /// <param name="endIndex">Do jakého indexu se má řetězec číst (-1 ignoruje délku).</param>
        /// <param name="chr">Znak, který určuje konec čtení.</param>
        /// <returns>Vrací přečtený řetězec.</returns>
        /// <remarks>Pokud vstupní text bude prázdný nebo se znak nebude vyskytovat v textu, tak vrácí NULL.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string ReadTo(this string text, int endIndex, char chr)
        {
            int index = text.IndexOf(chr);

            if (index == -1 || (index > endIndex && endIndex != -1))
                return null;

            try
            {
                return text.Substring(0, index);
            }
            catch (ArgumentOutOfRangeException ex) { throw new OphiteException(ExceptionType.ArgumentOutOfRangeException, ex); }
        }

        /// <summary>
        /// Rozdělí text podle slova na pole stringů.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="splitString">Rozdělovací text.</param>
        /// <param name="options">Nastavení rozdělení.</param>
        /// <returns>Vrací pole stringů.</returns>
        /// <remarks>Pokud vstupní text bude NULL nebo rozdělovací text bude NULL, tak vrácí prázdné pole.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static string[] SplitEx(this string text, string splitString, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            try
            {
                return (!text.IsEmpty() && !splitString.IsEmpty()) ? text.Split(new string[] { splitString }, options) : new string[] { };
            }
            catch (ArgumentException ex) { throw new OphiteException(ExceptionType.ArgumentException, ex); }
        }

        /// <summary>
        /// Převádí HEX hodnotu ze stringu na pole byte.
        /// </summary>
        /// <param name="hexString">HEX hodnota jako string.</param>
        /// <param name="start">Odebere text, který bude před každou HEX hodnotou (např. 0x).</param>
        /// <param name="end">Odebere text, který bude za každou HEX hodnotou (např. mezera).</param>
        /// <returns>Vrací pole byte.</returns>
        /// <remarks>Pokud nastane chyba, tak vrací prázdné pole.</remarks>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static byte[] AsBytesHexa(this string hexString, string start = "", string end = "")
        {
            if (!hexString.IsMatch(RegexMatch.HexValue) || hexString.Length < 2 || hexString.Length % 2 != 0)
                return new byte[] { };

            if (!start.IsEmpty())
                hexString = hexString.Replace(start, "");

            if (!end.IsEmpty())
                hexString = hexString.Replace(end, "");

            byte[] data = new byte[hexString.Length / 2];

            try
            {
                for (int i = 0, n = 0; i < hexString.Length; i += 2, n++)
                {
                    data[n] = Convert.ToByte(hexString.Substring(i, 2), 16);
                }
            }
            catch (FormatException ex) { throw new OphiteException(ExceptionType.FormatException, ex); }
            catch (ArgumentException ex) { throw new OphiteException(ExceptionType.ArgumentException, ex); }
            catch (OverflowException ex) { throw new OphiteException(ExceptionType.OverflowException, ex); }

            return data;
        }

        /// <summary>
        /// Převádí SOAP string na objekt.
        /// </summary>
        /// <param name="soapString">Vstupní SOAP string.</param>
        /// <returns>Vrací původní objekt.</returns>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static object AsObjectFromSoap(this string soapString)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(soapString.AsBytesUTF8()))
                {
                    SoapFormatter sf = new SoapFormatter();
                    return sf.Deserialize(ms);
                }
            }
            catch (ArgumentNullException ex) { throw new OphiteException(ExceptionType.ArgumentNullException, ex); }
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
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        public static byte[] FromBase64(this string data)
        {
            if (data.IsEmpty())
                return new byte[] { };

            try
            {
                return Convert.FromBase64String(data);
            }
            catch (ArgumentNullException ex) { throw new OphiteException(ExceptionType.ArgumentNullException, ex); }
            catch (FormatException ex) { throw new OphiteException(ExceptionType.FormatException, ex); }
        }
    }
}

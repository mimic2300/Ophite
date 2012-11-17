using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;

namespace Ophite.Extension
{
    /// <summary>
    /// Slouží pro převody z jednoho datového typů do jiného.
    /// </summary>
    public static class Converter
    {
        #region short

        /// <summary>
        /// Převádí short číslo na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací short číslo jako pole byte.</returns>
        /// <remarks>Převede LittleEndian na BigEndian.</remarks>
        public static byte[] AsBytes(this short number)
        {
            byte[] data = BitConverter.GetBytes(number);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);

            return data;
        }

        #endregion short

        #region ushort

        /// <summary>
        /// Převádí ushort číslo na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací ushort číslo jako pole byte.</returns>
        /// <remarks>Převede LittleEndian na BigEndian.</remarks>
        public static byte[] AsBytes(this ushort number)
        {
            byte[] data = BitConverter.GetBytes(number);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);

            return data;
        }

        #endregion ushort

        #region int

        /// <summary>
        /// Převádí int číslo na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací int číslo jako pole byte.</returns>
        /// <remarks>Převede LittleEndian na BigEndian.</remarks>
        public static byte[] AsBytes(this int number)
        {
            byte[] data = BitConverter.GetBytes(number);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);

            return data;
        }

        #endregion int

        #region uint

        /// <summary>
        /// Převádí uint číslo na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací uint číslo jako pole byte.</returns>
        /// <remarks>Převede LittleEndian na BigEndian.</remarks>
        public static byte[] AsBytes(this uint number)
        {
            byte[] data = BitConverter.GetBytes(number);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);

            return data;
        }

        #endregion uint

        #region long

        /// <summary>
        /// Převádí long číslo na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací long číslo jako pole byte.</returns>
        /// <remarks>Převede LittleEndian na BigEndian.</remarks>
        public static byte[] AsBytes(this long number)
        {
            byte[] data = BitConverter.GetBytes(number);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);

            return data;
        }

        /// <summary>
        /// Převádí číslo na HEX hodnotu.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <param name="upper">Mají být písmena A-F velká?</param>
        /// <returns>Vrací HEX hodnotu z čísla.</returns>
        public static string AsHex(this long number, bool upper = true)
        {
            return number.ToString(upper ? "X" : "x");
        }

        /// <summary>
        /// Převádí unixový čas na datum.
        /// </summary>
        /// <param name="unixTime">Unixový čas.</param>
        /// <returns>Vrací novou instanci datumu.</returns>
        public static DateTime FromUnixTime(this long unixTime)
        {
            return (new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(unixTime);
        }

        #endregion long

        #region ulong

        /// <summary>
        /// Převádí číslo ulong na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací ulong číslo jako pole byte.</returns>
        /// <remarks>Převede LittleEndian na BigEndian.</remarks>
        public static byte[] AsBytes(this ulong number)
        {
            byte[] data = BitConverter.GetBytes(number);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);

            return data;
        }

        #endregion ulong

        #region float

        /// <summary>
        /// Převádí číslo float na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací float číslo jako pole byte.</returns>
        /// <remarks>Převede LittleEndian na BigEndian.</remarks>
        public static byte[] AsBytes(this float number)
        {
            byte[] data = BitConverter.GetBytes(number);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);

            return data;
        }

        #endregion float

        #region double

        /// <summary>
        /// Převádí číslo double na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací double číslo jako pole byte.</returns>
        /// <remarks>Převede LittleEndian na BigEndian.</remarks>
        public static byte[] AsBytes(this double number)
        {
            byte[] data = BitConverter.GetBytes(number);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);

            return data;
        }

        #endregion double

        #region decimal

        /// <summary>
        /// Převádí číslo decimal na pole byte.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací decimal číslo jako pole byte.</returns>
        public static byte[] AsBytes(this decimal number)
        {
            byte[] data = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryWriter br = new BinaryWriter(ms))
                {
                    br.Write(number);
                    data = ms.ToArray();
                }
            }
            return data;
        }

        #endregion decimal

        #region string

        /// <summary>
        /// Kontroluje, zda vstupní text je prázdný nebo null.
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
        /// <remarks>Pokud text bude prázdný nebo NULL, tak vrací NULL.</remarks>
        public static byte[] AsBytesASCII(this string text)
        {
            if (text.IsEmpty())
                return null;

            return Encoding.ASCII.GetBytes(text);
        }

        /// <summary>
        /// Převádí text na pole byte v kódování UTF8.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <returns>Vrací pole byte z UTF8 textu.</returns>
        /// <remarks>Pokud text bude prázdný nebo NULL, tak vrací NULL.</remarks>
        public static byte[] AsBytesUTF8(this string text)
        {
            if (text.IsEmpty())
                return null;

            return Encoding.UTF8.GetBytes(text);
        }

        /// <summary>
        /// Převádí text na číslo short.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <returns>Vrací číslo short.</returns>
        /// <remarks>Pokud nastane chyba, tak vrácí NULL.</remarks>
        public static short? AsShort(this string text)
        {
            short? result = null;

            try
            {
                result = short.Parse(text);
            }
            catch (Exception) { }

            return result;
        }

        /// <summary>
        /// Převádí text na číslo ushort.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <returns>Vrací číslo ushort.</returns>
        /// <remarks>Pokud nastane chyba, tak vrací NULL.</remarks>
        public static ushort? AsUShort(this string text)
        {
            ushort? result = null;

            try
            {
                result = ushort.Parse(text);
            }
            catch (Exception) { }

            return result;
        }

        /// <summary>
        /// Převádí text na číslo int.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <returns>Vrací číslo int.</returns>
        /// <remarks>Pokud nastane chyba, tak vrací NULL.</remarks>
        public static int? AsInt(this string text)
        {
            int? result = null;

            try
            {
                result = int.Parse(text);
            }
            catch (Exception) { }

            return result;
        }

        /// <summary>
        /// Převádí text na číslo uint.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <returns>Vrací číslo uint.</returns>
        /// <remarks>Pokud nastane chyba, tak vrací NULL.</remarks>
        public static uint? AsUInt(this string text)
        {
            uint? result = null;

            try
            {
                result = uint.Parse(text);
            }
            catch (Exception) { }

            return result;
        }

        /// <summary>
        /// Převádí text na číslo long.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <returns>Vrací číslo long.</returns>
        /// <remarks>Pokud nastane chyba, tak vrací NULL.</remarks>
        public static long? AsLong(this string text)
        {
            long? result = null;

            try
            {
                result = long.Parse(text);
            }
            catch (Exception) { }

            return result;
        }

        /// <summary>
        /// Převádí text na číslo ulong.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <returns>Vrací číslo ulong.</returns>
        /// <remarks>Pokud nastane chyba, tak vrací NULL.</remarks>
        public static ulong? AsULong(this string text)
        {
            ulong? result = null;

            try
            {
                result = ulong.Parse(text);
            }
            catch (Exception) { }

            return result;
        }

        /// <summary>
        /// Převádí text na číslo float.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <returns>Vrací číslo float.</returns>
        /// <remarks>Pokud nastane chyba, tak vrací NULL.</remarks>
        public static float? AsFloat(this string text)
        {
            float? result = null;

            try
            {
                result = float.Parse(text);
            }
            catch (Exception) { }

            return result;
        }

        /// <summary>
        /// Převádí text na číslo double.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <returns>Vrací číslo double.</returns>
        /// <remarks>Pokud nastane chyba, tak vrací NULL.</remarks>
        public static double? AsDouble(this string text)
        {
            double? result = null;

            try
            {
                result = double.Parse(text);
            }
            catch (Exception) { }

            return result;
        }

        /// <summary>
        /// Převádí text na číslo decimal.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <returns>Vrací číslo decimal.</returns>
        /// <remarks>Pokud nastane chyba, tak vrací NULL.</remarks>
        public static decimal? AsDecimal(this string text)
        {
            decimal? result = null;

            try
            {
                result = decimal.Parse(text);
            }
            catch (Exception) { }

            return result;
        }

        /// <summary>
        /// Převádí HEX hodnotu ze stringu do long čísla.
        /// </summary>
        /// <param name="hex">HEX hodnota v podobě stringu.</param>
        /// <returns>Vrací číslo long.</returns>
        /// <remarks>Pokud bude špatný znak na vstupu nebo žádný, tak vrácí 0.
        /// HEX string musí být maximálně 16 znaků dlouhý (převod do long), jinak vrácí 0.</remarks>
        public static long AsHexValue(this string hex)
        {
            if (hex.IsMatch(RegexMatch.HexValue) || hex.Length < 1 || hex.Length > 16)
                return 0;

            return long.Parse(hex, NumberStyles.HexNumber);
        }

        /// <summary>
        /// Čte řetězec tak dlouho, dokud nenarazí na vstupní znak nebo do určité délky.
        /// </summary>
        /// <param name="text">Vstupní řetězec.</param>
        /// <param name="endIndex">Do jakého indexu se má řetězec číst (-1 ignoruje délku).</param>
        /// <param name="chr">Znak, který určuje konec čtení.</param>
        /// <returns>Vrací přečtený řetězec.</returns>
        /// <remarks>Pokud vstupní text bude prázdný nebo se znak nebude vyskytovat v textu, tak vrácí NULL.</remarks>
        public static string ReadTo(this string text, int endIndex, char chr)
        {
            int index = text.IndexOf(chr);

            if (index == -1 || (index > endIndex && endIndex != -1))
                return null;

            return text.Substring(0, index);
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
            return (!text.IsEmpty() && !splitString.IsEmpty()) ? text.Split(new string[] { splitString }, options) : new string[] { };
        }

        /// <summary>
        /// Převádí HEX hodnotu ze stringu na pole byte.
        /// </summary>
        /// <param name="hexString">HEX hodnota jako string.</param>
        /// <param name="start">Odebere text, který bude před každou HEX hodnotou (např. 0x).</param>
        /// <param name="end">Odebere text, který bude za každou HEX hodnotou (např. mezera).</param>
        /// <returns>Vrací pole byte.</returns>
        /// <remarks>Pokud nastane chyba, tak vrací prázdné pole.</remarks>
        public static byte[] AsBytesHexa(this string hexString, string start = "", string end = "")
        {
            if (!hexString.IsMatch(RegexMatch.HexValue) || hexString.Length < 2 || hexString.Length % 2 != 0)
                return new byte[] { };

            if (!start.IsEmpty())
                hexString = hexString.Replace(start, "");

            if (!end.IsEmpty())
                hexString = hexString.Replace(end, "");

            byte[] data = new byte[hexString.Length / 2];

            for (int i = 0, n = 0; i < hexString.Length; i += 2, n++)
            {
                data[n] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return data;
        }

        /// <summary>
        /// Převádí SOAP string na objekt.
        /// </summary>
        /// <param name="soapString">Vstupní SOAP string.</param>
        /// <returns>Vrací původní objekt.</returns>
        /// <remarks>Pokud převod selže, tak vrací NULL.</remarks>
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
            catch(Exception) { return null; }
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

        #endregion string

        #region string[]

        /// <summary>
        /// Zjistí existenci stringu v poli stringů.
        /// </summary>
        /// <param name="strings">V jakém poli stringů se má hledat.</param>
        /// <param name="text">Jaký string hledáme.</param>
        /// <param name="ignoreCase">Má se ignorovat velikost písmen?</param>
        /// <returns>Vrací TRUE, pokud string v poli stringů existuje.</returns>
        public static bool IsExists(this string[] strings, string text, bool ignoreCase = false)
        {
            if (strings.IsEmpty() || text.IsEmpty())
                return false;

            if (ignoreCase)
            {
                return Array.Exists(strings, str => { return str.ToLower() == text.ToLower(); });
            }
            else return Array.Exists(strings, str => { return str == text; });
        }

        /// <summary>
        /// Spojí texty v poli stringů do jednoho stringu.
        /// </summary>
        /// <param name="strings">Vstupní pole stringů.</param>
        /// <param name="delimiter">Znak, který bude oddělovat každý string.</param>
        /// <returns>Vrací spojený string.</returns>
        /// <remarks>Pokud vstupní pole stringů bude NULL nebo prázdné, tak vrácí NULL.</remarks>
        public static string Join(this string[] strings, char delimiter)
        {
            if (strings.IsEmpty())
                return null;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < strings.Length; i++)
            {
                sb.Append(strings[i]);

                if (i < strings.Length - 1)
                    sb.Append(delimiter);
            }
            return sb.ToString();
        }

        #endregion string[]

        #region byte[]

        /// <summary>
        /// Kontroluje, zda pole byte je prázdné nebo je NULL.
        /// </summary>
        /// <param name="data">Vstupní pole byte.</param>
        /// <returns>Vrací TRUE, pokud pole je prázdné nebo NULL.</returns>
        public static bool IsEmpty(this byte[] data)
        {
            return (data == null || data.Length < 1);
        }

        /// <summary>
        /// Převádí pole byte na hodnotu bool.
        /// </summary>
        /// <param name="data">Vstupní pole byte.</param>
        /// <returns>Vrací hodnotu bool z pole byte.</returns>
        /// <remarks>Pokud nastane chyba při převodu, tak vrácí FALSE.</remarks>
        public static bool AsBool(this byte[] data)
        {
            try
            {
                return BitConverter.ToBoolean(data, 0);
            }
            catch (Exception) { return false; }
        }

        /// <summary>
        /// Převádí pole byte na short číslo.
        /// </summary>
        /// <param name="data">Vstupní pole byte.</param>
        /// <returns>Vrací short číslo.</returns>
        /// <remarks>Pokud nastane chyba při převodu, tak vrácí 0.</remarks>
        public static short AsShort(this byte[] data)
        {
            try
            {
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(data);

                return BitConverter.ToInt16(data, 0);
            }
            catch (Exception) { return 0; }
        }

        /// <summary>
        /// Převádí pole byte na ushort číslo.
        /// </summary>
        /// <param name="data">Vstupní pole byte.</param>
        /// <returns>Vrací ushort číslo.</returns>
        /// <remarks>Pokud nastane chyba při převodu, tak vrácí 0.</remarks>
        public static ushort AsUShort(this byte[] data)
        {
            try
            {
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(data);

                return BitConverter.ToUInt16(data, 0);
            }
            catch (Exception) { return 0; }
        }

        /// <summary>
        /// Převádí pole byte na int číslo.
        /// </summary>
        /// <param name="data">Vstupní pole byte.</param>
        /// <returns>Vrací int číslo.</returns>
        /// <remarks>Pokud nastane chyba při převodu, tak vrácí 0.</remarks>
        public static int AsInt(this byte[] data)
        {
            try
            {
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(data);

                return BitConverter.ToInt32(data, 0);
            }
            catch (Exception) { return 0; }
        }

        /// <summary>
        /// Převádí pole byte na uint číslo.
        /// </summary>
        /// <param name="data">Vstupní pole byte.</param>
        /// <returns>Vrací uint číslo.</returns>
        /// <remarks>Pokud nastane chyba při převodu, tak vrácí 0.</remarks>
        public static uint AsUInt(this byte[] data)
        {
            try
            {
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(data);

                return BitConverter.ToUInt32(data, 0);
            }
            catch (Exception) { return 0; }
        }

        /// <summary>
        /// Převádí pole byte na long číslo.
        /// </summary>
        /// <param name="data">Vstupní pole byte.</param>
        /// <returns>Vrací long číslo.</returns>
        /// <remarks>Pokud nastane chyba při převodu, tak vrácí 0.</remarks>
        public static long AsLong(this byte[] data)
        {
            try
            {
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(data);

                return BitConverter.ToInt64(data, 0);
            }
            catch (Exception) { return 0; }
        }

        /// <summary>
        /// Převádí pole byte na ulong číslo.
        /// </summary>
        /// <param name="data">Vstupní pole byte.</param>
        /// <returns>Vrací ulong číslo.</returns>
        /// <remarks>Pokud nastane chyba při převodu, tak vrácí 0.</remarks>
        public static ulong AsULong(this byte[] data)
        {
            try
            {
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(data);

                return BitConverter.ToUInt64(data, 0);
            }
            catch (Exception) { return 0; }
        }

        /// <summary>
        /// Převádí pole byte na float číslo.
        /// </summary>
        /// <param name="data">Vstupní pole byte.</param>
        /// <returns>Vrací float číslo.</returns>
        /// <remarks>Pokud nastane chyba při převodu, tak vrácí 0.</remarks>
        public static float AsFloat(this byte[] data)
        {
            try
            {
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(data);

                return BitConverter.ToSingle(data, 0);
            }
            catch (Exception) { return 0f; }
        }

        /// <summary>
        /// Převádí pole byte na double číslo.
        /// </summary>
        /// <param name="data">Vstupní pole byte.</param>
        /// <returns>Vrací double číslo.</returns>
        /// <remarks>Pokud nastane chyba při převodu, tak vrácí 0.</remarks>
        public static double AsDouble(this byte[] data)
        {
            try
            {
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(data);

                return BitConverter.ToDouble(data, 0);
            }
            catch (Exception) { return 0; }
        }

        /// <summary>
        /// Převádí pole byte na pole znaků v kódování ASCII.
        /// </summary>
        /// <param name="data">Vstupní pole byte.</param>
        /// <returns>Vrací pole ASCII znaků.</returns>
        /// <remarks>Pokud nastane chyba při převodu, tak vrácí NULL.</remarks>
        public static char[] AsCharsASCII(this byte[] data)
        {
            try
            {
                return Encoding.ASCII.GetString(data).ToCharArray();
            }
            catch (Exception) { return null; }
        }

        /// <summary>
        /// Převádí pole byte na pole znaků v kódování UTF8.
        /// </summary>
        /// <param name="data">Vstupní pole byte.</param>
        /// <returns>Vrací pole UTF8 znaků.</returns>
        /// <remarks>Pokud nastane chyba při převodu, tak vrácí NULL.</remarks>
        public static char[] AsCharsUTF8(this byte[] data)
        {
            try
            {
                return Encoding.UTF8.GetString(data).ToCharArray();
            }
            catch (Exception) { return null; }
        }

        /// <summary>
        /// Převádí pole byte na decimální číslo.
        /// </summary>
        /// <param name="data">Vstupní pole byte.</param>
        /// <returns>Vrací decimální číslo.</returns>
        /// <remarks>Pokud nastane chyba při převodu, tak vrácí 0.</remarks>
        public static decimal AsDecimal(this byte[] data)
        {
            if (data.IsEmpty())
                return 0;

            try
            {
                if (data.Length == 1)
                    return decimal.Parse(((char)data[0]).ToString());

                decimal value = 0;

                using (MemoryStream ms = new MemoryStream(data))
                {
                    using (BinaryReader reader = new BinaryReader(ms))
                    {
                        value = reader.ReadDecimal();
                    }
                }
                return value;
            }
            catch (Exception) { return 0; }
        }

        /// <summary>
        /// Převádí pole byte na string.
        /// </summary>
        /// <param name="data">Vstupní byte pole.</param>
        /// <param name="format">Typ formátu textu.</param>
        /// <returns>Vrácí string.</returns>
        /// <remarks>Pokud vstupní pole byte bude NULL, tak vrácí NULL.</remarks>
        public static string AsString(this byte[] data, TextFormat format = TextFormat.UTF8)
        {
            if (data.IsEmpty())
                return null;

            switch (format)
            {
                case TextFormat.ASCII:
                    return Encoding.ASCII.GetString(data);

                case TextFormat.UTF8:
                    return Encoding.UTF8.GetString(data);

                case TextFormat.UTF7:
                    return Encoding.UTF7.GetString(data);

                case TextFormat.UTF32:
                    return Encoding.UTF32.GetString(data);

                case TextFormat.Unicode:
                    return Encoding.Unicode.GetString(data);

                case TextFormat.BigEndianUnicode:
                    return Encoding.BigEndianUnicode.GetString(data);

                default:
                    return Encoding.UTF8.GetString(data);
            }
        }

        /// <summary>
        /// Převádí pole byte na ikonu.
        /// </summary>
        /// <param name="data">Vstupní pole byte.</param>
        /// <returns>Vrací ikonu.</returns>
        /// <remarks>Pokud nastane chyba při převodu, tak vrácí NULL.</remarks>
        public static Icon AsIcon(this byte[] data)
        {
            try
            {
                Icon icon = null;

                using (MemoryStream ms = new MemoryStream(data))
                {
                    Bitmap bitmap = (Bitmap)Image.FromStream(ms);
                    icon = Icon.FromHandle(bitmap.GetHicon());
                }
                return icon;
            }
            catch (Exception) { return null; }
        }

        /// <summary>
        /// Převádí pole byte na Image.
        /// </summary>
        /// <param name="data">Vstupní pole byte.</param>
        /// <returns>Vrací obrázek.</returns>
        /// <remarks>Pokuď nastane chyba při převodu, tak vrací NULL.</remarks>
        public static Image AsImage(this byte[] data)
        {
            try
            {
                Image img = null;

                using (MemoryStream ms = new MemoryStream(data))
                {
                    img = Image.FromStream(ms);
                }
                return img;
            }
            catch (Exception) { return null; }
        }

        /// <summary>
        /// Převádí pole byte na FontFamily.
        /// </summary>
        /// <param name="buffer">Data fontu.</param>
        /// <returns>Vrací FontFamily.</returns>
        /// <remarks>Pouze pro TrueType fonty.
        /// Pokud nastane chyba, tak vrací NULL.</remarks>
        public static FontFamily AsFontFamily(this byte[] buffer)
        {
            if (buffer.IsEmpty())
                return null;

            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            FontFamily family = null;

            try
            {
                IntPtr ptr = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);

                using (PrivateFontCollection pfc = new PrivateFontCollection())
                {
                    pfc.AddMemoryFont(ptr, buffer.Length);
                    family = pfc.Families[0];
                }
            }
            finally
            {
                handle.Free();
            }
            return family;
        }

        /// <summary>
        /// Převádí serializované pole byte zpět na původní objekt.
        /// </summary>
        /// <param name="data">Serializované pole byte.</param>
        /// <returns>Vrací původní objekt.</returns>
        /// <remarks>Pokud nastane chyba při převodu, tak vrácí NULL.</remarks>
        public static object AsObjectDeserialize(this byte[] data)
        {
            try
            {
                object obj = null;

                using (MemoryStream ms = new MemoryStream(data))
                {
                    obj = new BinaryFormatter().Deserialize(ms);
                }
                return obj;
            }
            catch (Exception) { return null; }
        }

        /// <summary>
        /// Převádí pole byte do HEX formátu jako string.
        /// </summary>
        /// <param name="data">Vstupní pole byte.</param>
        /// <param name="before">Text, který bude před každou HEX hodnotou.</param>
        /// <param name="back">Text, který bude za každou HEX hodnotou.</param>
        /// <param name="toLower">Má obsahovat výstup malé znaky?</param>
        /// <returns>Vrací HEX string.</returns>
        /// <remarks>Pokud nastane chyba při převodu, tak vrácí NULL.</remarks>
        public static string AsStringHex(this byte[] data, string before = "", string back = "", bool toLower = true)
        {
            try
            {
                string hexa = BitConverter.ToString(data).Replace("-", "");
                string output = null;

                if (before.IsEmpty() && back.IsEmpty())
                    return (toLower) ? hexa.ToLowerInvariant() : hexa;

                for (int i = 2; i < hexa.Length; i += 2)
                {
                    output += before + ((toLower) ? hexa[i - 2].ToString().ToLowerInvariant() : hexa[i - 2].ToString());
                    output += ((toLower) ? hexa[i - 1].ToString().ToLowerInvariant() : hexa[i - 1].ToString()) + back;
                }
                return output;
            }
            catch (Exception) { return null; }
        }

        /// <summary>
        /// Spojí několik polí byte do jednoho velkého pole byte.
        /// </summary>
        /// <param name="mainBytes">K jakému poli byte se mají ostatní pole byte přidávat.</param>
        /// <param name="byteArr">Pole polí byte.</param>
        /// <returns>Vrací spojené pole byte.</returns>
        /// <remarks>Přeskakuje pole s hodnotou NULL, takže nevadí, pokud hlavní pole byte bude NULL.
        /// Spojuje se vždy do prvního (hlavního) pole.</remarks>
        public static byte[] Join(this byte[] mainBytes, params byte[][] byteArr)
        {
            int size = !mainBytes.IsEmpty() ? mainBytes.Length : 0;
            int offset = size;

            foreach (byte[] b in byteArr)
            {
                if (b == null)
                    continue;

                size += b.Length;
            }

            if (size == 0)
                return null;

            byte[] output = new byte[size];

            if (mainBytes != null)
                mainBytes.CopyTo(output, 0);

            foreach (byte[] b in byteArr)
            {
                if (b == null)
                    continue;

                b.CopyTo(output, offset);
                offset += b.Length;
            }
            return output;
        }

        #endregion byte[]

        #region char[]

        /// <summary>
        /// Kontroluje, zda velikost pole char není 0 nebo není NULL.
        /// </summary>
        /// <param name="data">Vstupní pole char.</param>
        /// <returns>Vrací TRUE, pokud pole je prázdné nebo NULL.</returns>
        public static bool IsEmpty(this char[] data)
        {
            return (data == null || data.Length < 1);
        }

        /// <summary>
        /// Převádí pole znaků na pole byte.
        /// </summary>
        /// <param name="data">Vstupní pole znaků.</param>
        /// <returns>Vrací pole byte.</returns>
        /// <remarks>Pokud při převodu nastane chyba, tak vrácí NULL.</remarks>
        public static byte[] AsBytes(this char[] data)
        {
            try
            {
                byte[] result = null;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (BinaryWriter br = new BinaryWriter(ms))
                    {
                        br.Write(data);
                        result = ms.ToArray();
                    }
                }
                return result;
            }
            catch (Exception) { return null; }
        }

        #endregion char[]

        #region bool

        /// <summary>
        /// Převádí hodnotu bool na pole byte.
        /// </summary>
        /// <param name="value">Vstupní hodnota bool.</param>
        /// <returns>Vrací pole byte.</returns>
        public static byte[] AsBytes(this bool value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        /// Převádí bool hodnotu do textu s vlastním názvem.
        /// </summary>
        /// <param name="value">Bool hodnota.</param>
        /// <param name="yes">Název pro TRUE.</param>
        /// <param name="no">Název pro FALSE.</param>
        /// <returns>Vrací string.</returns>
        /// <remarks>Pokud nebude nastaven template pro hodnotu, tak vrácí bool hodnotu jako string.</remarks>
        public static string AsString(this bool value, string yes = "Yes", string no = "No")
        {
            string boolStr = value.ToString();

            if (value && yes.IsEmpty())
                yes = boolStr;

            if (!value && no.IsEmpty())
                no = boolStr;

            return (boolStr.ToLower() == "true") ? yes : no;
        }

        #endregion bool

        #region Icon

        /// <summary>
        /// Převádí ikonu do pole byte.
        /// </summary>
        /// <param name="icon">Vstupní ikona.</param>
        /// <returns>Vrací pole byte.</returns>
        public static byte[] AsBytes(this Icon icon)
        {
            if (icon == null)
                return null;

            byte[] data = null;

            using (MemoryStream ms = new MemoryStream())
            {
                icon.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }

        #endregion Icon

        #region Image / Bitmap.

        /// <summary>
        /// Převádí Image do pole byte.
        /// </summary>
        /// <param name="img">Vstupní image.</param>
        /// <param name="format">Do jakého formátu se má image rozložit.</param>
        /// <returns>Vrací pole byte.</returns>
        /// <remarks>Funguje i na bitmapu.</remarks>
        public static byte[] AsBytes(this Image img, ImageFormat format)
        {
            if (img == null)
                return null;

            byte[] data = null;

            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, format);
                data = ms.ToArray();
            }
            return data;
        }

        #endregion Image / Bitmap.

        #region object

        /// <summary>
        /// Převádí objekt na serializované pole byte.
        /// </summary>
        /// <param name="obj">Vstupní objekt.</param>
        /// <returns>Vrací serializované pole byte.</returns>
        /// <remarks>Pokud vstupní objekt bude třída nebo struktůra, tak musí obsahovat flag [Serializable], jinak vrací NULL!</remarks>
        public static byte[] AsObjectSerialize(this object obj)
        {
            try
            {
                byte[] data = null;

                using (MemoryStream ms = new MemoryStream())
                {
                    new BinaryFormatter().Serialize(ms, obj);
                    data = ms.ToArray();
                }
                return data;
            }
            catch (Exception) { return null; }
        }

        /// <summary>
        /// Převádí objekt na SOAP string v kódování ASCII.
        /// </summary>
        /// <param name="obj">Vstupní objekt.</param>
        /// <returns>Vrací SOAP ASCII string.</returns>
        /// <remarks>Pokud nastane chyba, tak vrací NULL.</remarks>
        public static string AsSoapStringASCII(this object obj)
        {
            try
            {
                string result = null;

                using (MemoryStream ms = new MemoryStream())
                {
                    SoapFormatter sf = new SoapFormatter();
                    sf.Serialize(ms, obj);
                    ms.Flush();
                    result = Encoding.ASCII.GetString(ms.GetBuffer(), 0, (int)ms.Position);
                }
                return result;
            }
            catch { return null; }
        }

        /// <summary>
        /// Převádí objekt na SOAP string v kódování UTF8.
        /// </summary>
        /// <param name="obj">Vstupní objekt.</param>
        /// <returns>Vrací SOAP UTF8 string.</returns>
        /// <remarks>Pokud nastane chyba, tak vrací NULL.</remarks>
        public static string AsSoapStringUTF8(this object obj)
        {
            try
            {
                string result = null;

                using (MemoryStream ms = new MemoryStream())
                {
                    SoapFormatter sf = new SoapFormatter();
                    sf.Serialize(ms, obj);
                    ms.Flush();
                    result = UTF8Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Position);
                }
                return result;
            }
            catch { return null; }
        }

        #endregion object

        #region object[]

        /// <summary>
        /// Kontroluje, zda vstupní pole objektů je prázdné nebo NULL.
        /// </summary>
        /// <param name="objs">Vstupní pole objektů.</param>
        /// <returns>Vrací true, pokuď pole objektů je prázdné nebo NULL.</returns>
        public static bool IsEmpty(this object[] objs)
        {
            return (objs == null || objs.Length < 1);
        }

        #endregion object[]

        #region DateTime

        /// <summary>
        /// Převádí datum na unixový čas.
        /// </summary>
        /// <param name="date">Datum pro převod.</param>
        /// <returns>Vrací unixový čas jako long.</returns>
        /// <remarks>Pokud datum bude NULL, tak vrácí 0.</remarks>
        public static long AsUnixTime(this DateTime date)
        {
            if (date == null)
                return 0;

            return (long)(date - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
        }

        #endregion DateTime
    }
}

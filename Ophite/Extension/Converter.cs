using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Ophite.Extension
{
    /// <summary>
    /// Slouží pro převody z jednoho datového typů do jiného.
    /// </summary>
    public static class Converter
    {
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
                return System.Array.Exists(strings, str => { return str.ToLower() == text.ToLower(); });
            }
            else return System.Array.Exists(strings, str => { return str == text; });
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
                    System.Array.Reverse(data);

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
                    System.Array.Reverse(data);

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
                    System.Array.Reverse(data);

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
                    System.Array.Reverse(data);

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
                    System.Array.Reverse(data);

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
                    System.Array.Reverse(data);

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
                    System.Array.Reverse(data);

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
                    System.Array.Reverse(data);

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
        /// <param name="after">Text, který bude za každou HEX hodnotou.</param>
        /// <param name="toLower">Má obsahovat výstup malé znaky?</param>
        /// <returns>Vrací HEX string.</returns>
        /// <remarks>Pokud nastane chyba při převodu, tak vrácí NULL.</remarks>
        public static string AsStringHex(this byte[] data, string before = "", string after = "", bool toLower = true)
        {
            try
            {
                string hexa = BitConverter.ToString(data).Replace("-", "");
                string output = null;

                if (before.IsEmpty() && after.IsEmpty())
                    return (toLower) ? hexa.ToLowerInvariant() : hexa;

                for (int i = 2; i < hexa.Length; i += 2)
                {
                    output += before + ((toLower) ? hexa[i - 2].ToString().ToLowerInvariant() : hexa[i - 2].ToString());
                    output += ((toLower) ? hexa[i - 1].ToString().ToLowerInvariant() : hexa[i - 1].ToString()) + after;
                }
                return output;
            }
            catch (Exception) { return null; }
        }

        /// <summary>
        /// Převádí pole byte do DEC formátu jako string.
        /// </summary>
        /// <param name="data">Vstupní pole byte.</param>
        /// <param name="before">Text, který bude před každou DEC hodnotou.</param>
        /// <param name="after">Text, který bude za každou DEC hodnotou.</param>
        /// <returns>Vrací DEC string.</returns>
        /// <remarks>Pokud vstupní data jsou NULL nebo prázdné, tak vrací NULL.</remarks>
        public static string AsStringDec(this byte[] data, string before = "", string after = "")
        {
            if (data.IsEmpty())
                return string.Empty;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(before).Append(data[i]).Append(after);
            }
            return sb.ToString();
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

        /// <summary>
        /// Převádí byte pole do base64.
        /// </summary>
        /// <param name="data">Vstupní byte pole.</param>
        /// <returns>Vrací text v base64.</returns>
        /// <remarks>Pokud vstup bude NULL, tak vrací NULL.</remarks>
        public static string ToBase64(this byte[] data)
        {
            if (data.IsEmpty())
                return null;

            return Convert.ToBase64String(data);
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

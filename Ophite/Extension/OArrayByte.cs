using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Text;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datový typ "byte[]".
    /// </summary>
    public static class OArrayByte
    {
        /// <summary>
        /// Kontroluje, zda pole byte je prázdné nebo je NULL.
        /// </summary>
        /// <param name="array">Vstupní pole byte.</param>
        /// <returns>Vrací TRUE, pokud pole je prázdné nebo NULL.</returns>
        public static bool IsEmpty(this byte[] array)
        {
            return (array == null || array.Length < 1);
        }

        /// <summary>
        /// Převádí pole byte na hodnotu bool.
        /// </summary>
        /// <param name="array">Vstupní pole byte.</param>
        /// <returns>Vrací hodnotu bool z pole byte.</returns>
        /// <remarks>Pokud pole bude prázdné nebo NULL, tak brací FALSE.</remarks>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool AsBool(this byte[] array)
        {
            if (array.IsEmpty())
                return false;

            return BitConverter.ToBoolean(array, 0);
        }

        /// <summary>
        /// Převádí pole byte na short číslo.
        /// </summary>
        /// <param name="array">Vstupní pole byte.</param>
        /// <returns>Vrací short číslo.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="RankException"></exception>
        public static short AsShort(this byte[] array)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(array);

            return BitConverter.ToInt16(array, 0);
        }

        /// <summary>
        /// Převádí pole byte na ushort číslo.
        /// </summary>
        /// <param name="array">Vstupní pole byte.</param>
        /// <returns>Vrací ushort číslo.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="RankException"></exception>
        public static ushort AsUShort(this byte[] array)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(array);

            return BitConverter.ToUInt16(array, 0);
        }

        /// <summary>
        /// Převádí pole byte na int číslo.
        /// </summary>
        /// <param name="array">Vstupní pole byte.</param>
        /// <returns>Vrací int číslo.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="RankException"></exception>
        public static int AsInt(this byte[] array)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(array);

            return BitConverter.ToInt32(array, 0);
        }

        /// <summary>
        /// Převádí pole byte na uint číslo.
        /// </summary>
        /// <param name="array">Vstupní pole byte.</param>
        /// <returns>Vrací uint číslo.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="RankException"></exception>
        public static uint AsUInt(this byte[] array)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(array);

            return BitConverter.ToUInt32(array, 0);
        }

        /// <summary>
        /// Převádí pole byte na long číslo.
        /// </summary>
        /// <param name="array">Vstupní pole byte.</param>
        /// <returns>Vrací long číslo.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="RankException"></exception>
        public static long AsLong(this byte[] array)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(array);

            return BitConverter.ToInt64(array, 0);
        }

        /// <summary>
        /// Převádí pole byte na ulong číslo.
        /// </summary>
        /// <param name="array">Vstupní pole byte.</param>
        /// <returns>Vrací ulong číslo.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="RankException"></exception>
        public static ulong AsULong(this byte[] array)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(array);

            return BitConverter.ToUInt64(array, 0);
        }

        /// <summary>
        /// Převádí pole byte na float číslo.
        /// </summary>
        /// <param name="array">Vstupní pole byte.</param>
        /// <returns>Vrací float číslo.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="RankException"></exception>
        public static float AsFloat(this byte[] array)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(array);

            return BitConverter.ToSingle(array, 0);
        }

        /// <summary>
        /// Převádí pole byte na double číslo.
        /// </summary>
        /// <param name="array">Vstupní pole byte.</param>
        /// <returns>Vrací double číslo.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="RankException"></exception>
        public static double AsDouble(this byte[] array)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(array);

            return BitConverter.ToDouble(array, 0);
        }

        /// <summary>
        /// Převádí pole byte na decimální číslo.
        /// </summary>
        /// <param name="array">Vstupní pole byte.</param>
        /// <returns>Vrací decimální číslo.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="RankException"></exception>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="IOException"></exception>
        public static decimal AsDecimal(this byte[] array)
        {
            if (array.Length == 1)
                return decimal.Parse(((char)array[0]).ToString());

            using (MemoryStream ms = new MemoryStream(array))
            {
                using (BinaryReader reader = new BinaryReader(ms))
                {
                    return reader.ReadDecimal();
                }
            }
        }

        /// <summary>
        /// Převádí pole byte na pole znaků v kódování ASCII.
        /// </summary>
        /// <param name="array">Vstupní pole byte.</param>
        /// <returns>Vrací pole ASCII znaků.</returns>
        /// <remarks>Pokud pole bude prázdné nebo NULL, tak vrací prázdné pole char.</remarks>
        public static char[] AsCharsASCII(this byte[] array)
        {
            if (array.IsEmpty())
                return new char[] { };

            return Encoding.ASCII.GetString(array).ToCharArray();
        }

        /// <summary>
        /// Převádí pole byte na pole znaků v kódování UTF8.
        /// </summary>
        /// <param name="array">Vstupní pole byte.</param>
        /// <returns>Vrací pole UTF8 znaků.</returns>
        /// <remarks>Pokud pole bude prázdné nebo NULL, tak vrací prázdné pole char.</remarks>
        public static char[] AsCharsUTF8(this byte[] array)
        {
            if (array.IsEmpty())
                return new char[] { };

            return Encoding.UTF8.GetString(array).ToCharArray();
        }

        /// <summary>
        /// Převádí pole byte na string.
        /// </summary>
        /// <param name="array">Vstupní byte pole.</param>
        /// <param name="encoding">Kódování textu.</param>
        /// <returns>Vrácí string.</returns>
        /// <remarks>Pokud vstupní pole bude prázdné nebo nějaký parametr bude NULL, tak vrací NULL.</remarks>
        public static string AsString(this byte[] array, Encoding encoding)
        {
            if (array.IsEmpty() || encoding == null)
                return null;

            return encoding.GetString(array);
        }

        /// <summary>
        /// Převádí pole byte na ikonu.
        /// </summary>
        /// <param name="array">Vstupní pole byte.</param>
        /// <returns>Vrací ikonu.</returns>
        /// <remarks>Pokud pole bude prázdné nebo NULL, tak vrací NULL.</remarks>
        /// <exception cref="Exception"></exception>
        public static Icon AsIcon(this byte[] array)
        {
            if (array.IsEmpty())
                return null;

            using (MemoryStream ms = new MemoryStream(array))
            {
                Bitmap bitmap = (Bitmap)Image.FromStream(ms);
                return Icon.FromHandle(bitmap.GetHicon());
            }
        }

        /// <summary>
        /// Převádí pole byte na Image.
        /// </summary>
        /// <param name="array">Vstupní pole byte.</param>
        /// <returns>Vrací obrázek.</returns>
        /// <remarks>Pokud pole bude prázdné nebo NULL, tak vrací NULL.</remarks>
        public static Image AsImage(this byte[] array)
        {
            if (array.IsEmpty())
                return null;

            using (MemoryStream ms = new MemoryStream(array))
            {
                return Image.FromStream(ms);
            }
        }

        /// <summary>
        /// Převádí pole byte na FontFamily.
        /// </summary>
        /// <param name="array">Pole byte fontu.</param>
        /// <returns>Vrací FontFamily.</returns>
        /// <remarks>Pouze pro TrueType fonty.
        /// Pokud pole bude prázdné nebo NULL, tak vrací NULL.
        /// Pokud nastane chyba při získání FontFamily, tak vrací NULL.</remarks>
        public static FontFamily AsFontFamily(this byte[] array)
        {
            if (array.IsEmpty())
                return null;

            GCHandle handle = GCHandle.Alloc(array, GCHandleType.Pinned);
            FontFamily family = null;

            try
            {
                IntPtr ptr = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);

                using (PrivateFontCollection pfc = new PrivateFontCollection())
                {
                    pfc.AddMemoryFont(ptr, array.Length);
                    family = pfc.Families[0];
                }
            }
            catch (OverflowException) { }
            finally
            {
                if (handle.IsAllocated)
                    handle.Free();
            }
            return family;
        }

        /// <summary>
        /// Převádí serializované pole byte zpět na původní objekt.
        /// </summary>
        /// <param name="array">Serializované pole byte.</param>
        /// <returns>Vrací původní objekt.</returns>
        /// <remarks>Pokud pole bude prázdné nebo NULL, tak vrací NULL.</remarks>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="SecurityException"></exception>
        public static object AsObjectDeserialize(this byte[] array)
        {
            if (array.IsEmpty())
                return null;

            using (MemoryStream ms = new MemoryStream(array))
            {
                return new BinaryFormatter().Deserialize(ms);
            }
        }

        /// <summary>
        /// Převádí pole byte do HEX formátu jako string.
        /// </summary>
        /// <param name="array">Vstupní pole byte.</param>
        /// <param name="before">Text, který bude před každou HEX hodnotou.</param>
        /// <param name="after">Text, který bude za každou HEX hodnotou.</param>
        /// <param name="toLower">Má obsahovat výstup malé znaky?</param>
        /// <returns>Vrací HEX string.</returns>
        /// <remarks>Pokud nastane jakákoliv chyba, tak vrácí NULL.</remarks>
        public static string AsStringHex(this byte[] array, string before = "", string after = "", bool toLower = true)
        {
            try
            {
                string hexa = BitConverter.ToString(array).Replace("-", "");
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
        /// <param name="array">Vstupní pole byte.</param>
        /// <param name="before">Text, který bude před každou DEC hodnotou.</param>
        /// <param name="after">Text, který bude za každou DEC hodnotou.</param>
        /// <returns>Vrací DEC string.</returns>
        /// <remarks>Pokud pole je prázdné nebo NULL, tak vrací NULL.</remarks>
        public static string AsStringDec(this byte[] array, string before = "", string after = "")
        {
            if (array.IsEmpty())
                return string.Empty;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
            {
                sb.Append(before).Append(array[i]).Append(after);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Spojí několik polí byte do jednoho velkého pole byte.
        /// </summary>
        /// <param name="mainArray">K jakému poli byte se mají ostatní pole byte přidávat.</param>
        /// <param name="array">Pole polí byte.</param>
        /// <returns>Vrací spojené pole byte.</returns>
        /// <remarks>Přeskakuje pole s hodnotou NULL, takže nevadí, pokud hlavní pole bude NULL.
        /// Spojuje se vždy do prvního (hlavního) pole.</remarks>
        public static byte[] Join(this byte[] mainArray, params byte[][] array)
        {
            int size = !mainArray.IsEmpty() ? mainArray.Length : 0;
            int offset = size;

            foreach (byte[] b in array)
            {
                if (b == null)
                    continue;

                size += b.Length;
            }

            if (size == 0)
                return null;

            byte[] output = new byte[size];

            if (mainArray != null)
                mainArray.CopyTo(output, 0);

            foreach (byte[] b in array)
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
        /// <param name="array">Vstupní byte pole.</param>
        /// <returns>Vrací text v base64.</returns>
        /// <remarks>Pokud pole bude prázdné nebo NULL, tak vrací NULL.</remarks>
        public static string ToBase64(this byte[] array)
        {
            if (array.IsEmpty())
                return null;

            return Convert.ToBase64String(array);
        }
    }
}

using System;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datový typ "bool".
    /// </summary>
    public static class OBool
    {
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
    }
}

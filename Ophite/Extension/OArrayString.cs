using System.Text;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datový typ "string[]".
    /// </summary>
    public static class OArrayString
    {
        /// <summary>
        /// Zjistí existenci stringu v poli stringů.
        /// </summary>
        /// <param name="strings">V jakém poli stringů se má hledat.</param>
        /// <param name="searchText">Jaký string hledáme.</param>
        /// <param name="ignoreCase">Má se ignorovat velikost písmen?</param>
        /// <returns>Vrací TRUE, pokud string v poli stringů existuje.</returns>
        /// <remarks>Pokud nebude existovat pole stringů nebo hledaný text, tak vrací FALSE.</remarks>
        public static bool IsExists(this string[] strings, string searchText, bool ignoreCase = false)
        {
            if (strings.IsEmpty() || searchText.IsEmpty())
                return false;

            if (ignoreCase)
            {
                return System.Array.Exists(strings, str => { return str.ToLower() == searchText.ToLower(); });
            }
            else return System.Array.Exists(strings, str => { return str == searchText; });
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
    }
}

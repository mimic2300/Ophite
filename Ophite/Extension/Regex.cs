using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje typy o bezpečtnostní prvky.
    /// </summary>
    public static class Regex
    {
        /// <summary>
        /// Kontroluje text přes regex výraz.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="template">Volba regexu.</param>
        /// <param name="options">Speciální nastavení regexu.</param>
        /// <returns>Vrací true, pokud vstupní text projde kontrolou.</returns>
        public static bool IsMatch(this string text, RegexMatch template, RegexOptions options = RegexOptions.None)
        {
            string pattern = null;

            switch (template)
            {
                // kompletní ochrana IP (délka, znaky i formát)
                case RegexMatch.IP:
                    pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
                    break;

                // kompletní ochrana portu (délka i znaky)
                case RegexMatch.Port:
                    pattern = @"(^(6553[0-5]|655[0-2][0-9]|65[0-4][0-9][0-9]|6[0-4][0-9][0-9][0-9]|[1-9][0-9][0-9][0-9]|[1-9][0-9][0-9]|[1-9][0-9]|[1-9])$)";
                    break;

                // kontrola názvu databaáe (třeba v MySQL)
                case RegexMatch.DatabaseName:
                    pattern = @"^([a-zA-Z0-9_]{1,30})$";
                    break;

                // znaky, které nesmí obsahovat název souboru
                case RegexMatch.FileNameInvalidChars:
                    pattern = @"^[^<>|:?*\\/""]*$";
                    break;

                // kontrola velmi silného hesla (musí obsahovat od každého znaku něco a mít délku minimálně 8 znaků)
                case RegexMatch.ExtraStrongPassword:
                    pattern = @"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,})$";
                    break;

                // ochrana validního URL pro (http, https, ftp) + dotazování
                case RegexMatch.URL:
                    pattern = @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";
                    break;

                // kompletní ochrana emailu i spravný formát a znaky
                case RegexMatch.Email:
                    pattern = @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$";
                    break;

                // pouze znaky [a-z], [A-Z] a speciální znaky [' -] + maximální délka 40 znaků
                case RegexMatch.UsernameForUSA:
                    pattern = @"^[a-zA-Z''-'\s]{1,40}$";
                    break;

                // pouze znaky [a-z] a [A-Z]
                case RegexMatch.OnlyLetters:
                    pattern = @"^[a-zA-Z]*$";
                    break;

                // pouze znaky [a-z]
                case RegexMatch.OnlyLowerLetters:
                    pattern = @"^[a-z]*$";
                    break;

                // pouze znaky [A-Z]
                case RegexMatch.OnlyUpperLetters:
                    pattern = @"^[A-Z]*$";
                    break;

                // pouze čísla [0-9]
                case RegexMatch.OnlyNumbers:
                    pattern = @"^[0-9]*$";
                    break;

                // pouze čísla [0-9] a tečky
                case RegexMatch.NumberWithDots:
                    pattern = @"^[0-9\.]*$";
                    break;

                // pouze speciální znaky
                case RegexMatch.OnlySpecialChars:
                    pattern = @"^[^a-z^A-Z^0-9]*$";
                    break;

                // bez speciálních znaků a pouze [a-z], [A-Z] a [0-9]
                case RegexMatch.WithoutSpecialChars:
                    pattern = @"^[a-zA-Z0-9]*$";
                    break;

                // pouze HEX znaky
                case RegexMatch.HexValue:
                    pattern = @"^[A-Fa-f0-9]*$";
                    break;

                // římské čísla
                case RegexMatch.RomanNumbers:
                    pattern = @"^m*(d?c{0,3}|c[dm])" + "(l?x{0,3}|x[lc])(v?i{0,3}|i[vx])$";
                    break;
            }
            return System.Text.RegularExpressions.Regex.IsMatch(text, pattern, options);
        }

        /// <summary>
        /// Odstraňuje z textu určité prvky.
        /// </summary>
        /// <param name="input">Vstupní text.</param>
        /// <param name="template">Typ modifikace.</param>
        /// <returns>Vrací upravený text.</returns>
        /// <remarks>Pokud vstupní text bude prázdný, tak vrácí NULL.</remarks>
        public static string Modify(this string input, RegexModify template)
        {
            if (input.IsEmpty())
                return null;

            // \000 null
            // \010 backspace
            // \011 horizontal tab
            // \012 new line
            // \015 carriage return
            // \032 substitute
            // \042 double quote
            // \047 single quote
            // \134 backslash
            // \140 grave accent

            switch (template)
            {
                // přidá do vstupního textu před všechny potencionálně nebezpečné znaky zpětné lomítko
                case RegexModify.AddSlashes:
                    return System.Text.RegularExpressions.Regex.Replace(
                        input, @"[\000\010\011\012\015\032\042\047\134\140]", "\\$0");

                // odebere ze vstupního textu zpětná lomítka před potencionálně nebezpečnými znaky
                case RegexModify.RemoveSlashes:
                    return System.Text.RegularExpressions.Regex.Replace(
                        input, @"(\\)([\000\010\011\012\015\032\042\047\134\140])", "$2");

                // odebere všechny tabulátory
                case RegexModify.RemoveTabs:
                    return System.Text.RegularExpressions.Regex.Replace(
                        input, @"[\t]", "");

                // odebere všechny CR (carriage return)
                case RegexModify.RemoveCarriageReturn:
                    return System.Text.RegularExpressions.Regex.Replace(
                        input, @"[\n]", "");

                // odebere všechny LF (line feed)
                case RegexModify.RemoveLineFeed:
                    return System.Text.RegularExpressions.Regex.Replace(
                        input, @"[\r]", "");

                // odebere všechny nové řádky (ve windows)
                case RegexModify.RemoveWindowsNewLine:
                    return System.Text.RegularExpressions.Regex.Replace(
                        input, @"[\n\r]", "");

                // odebere všechny HTML tagy (vše mezi <...>)
                case RegexModify.RemoveHTMLTags:
                    return System.Text.RegularExpressions.Regex.Replace(
                        input, "<.*?>", "");

                // spojí víceřádkové stringy do jednoho
                case RegexModify.JoinMultilineStrings:
                    return System.Text.RegularExpressions.Regex.Replace(
                        input, @"\s*\r?\n\s*", " ");

                default: return input;
            }
        }

        /// <summary>
        /// Parsuje text podle přednastaveného paternu.
        /// </summary>
        /// <param name="input">Vstupní text.</param>
        /// <param name="template">Jak se má parsovat.</param>
        /// <returns>Vrací pole stringů s výsledky.</returns>
        /// <remarks>Pokud vstupní text bude prázdný nebo nebude co parsovat, tak vrácí NULL.</remarks>
        public static string[] Parse(this string input, RegexParse template)
        {
            if (input.IsEmpty())
                return null;

            List<string> data = new List<string>();
            MatchCollection parsed = null;

            switch (template)
            {
                // vybere z textu všechny binarní hodnoty o délce 8 bitů
                case RegexParse.ByteInBinary:
                    parsed = System.Text.RegularExpressions.Regex.Matches(
                        input, "[01]{8}", RegexOptions.Multiline);
                    break;

                // vybere z textu všechny youtube ID videa
                case RegexParse.YouTubeVideoID:
                    parsed = System.Text.RegularExpressions.Regex.Matches(
                        input, @"(?<=v(\=|\/))([-a-zA-Z0-9_]+)|(?<=youtu\.be\/)([-a-zA-Z0-9_]+)", RegexOptions.Multiline);
                    break;

                // vybere všechna velká slova
                case RegexParse.FindAllCapsWords:
                    parsed = System.Text.RegularExpressions.Regex.Matches(
                        input, @"(\b[^\Wa-z0-9_]+\b)", RegexOptions.Multiline);
                    break;

                // vybere všechna malá slova
                case RegexParse.FindAllLowercaseWords:
                    parsed = System.Text.RegularExpressions.Regex.Matches(
                        input, @"(\b[^\WA-Z0-9_]+\b)", RegexOptions.Multiline);
                    break;

                // vybere všechna slova, která začínají velkým písmenem
                case RegexParse.FindAllInitialCaps:
                    parsed = System.Text.RegularExpressions.Regex.Matches(
                        input, @"(\b[^\Wa-z0-9_][^\WA-Z0-9_]*\b)", RegexOptions.Multiline);
                    break;

                // vybere všechna čísla
                case RegexParse.FindAllNumbers:
                    parsed = System.Text.RegularExpressions.Regex.Matches(
                        input, @"(\d+\.?\d*|\.\d+)", RegexOptions.Multiline);
                    break;
            }

            if (parsed == null || parsed.Count == 0)
                return null;

            foreach (Match s in parsed)
            {
                data.Add(s.ToString());
            }
            return data.ToArray();
        }

        /// <summary>
        /// Parsuje text podle vlastního paternu.
        /// </summary>
        /// <param name="input">Vstupní text.</param>
        /// <param name="patern">Patern, podle kterého se má parsovat.</param>
        /// <param name="option">Nastavení parseru.</param>
        /// <returns>Vrací pole stringů s výsledky.</returns>
        /// <remarks>Pokud vstupní text bude prázdný nebo nebude co parsovat, tak vrácí NULL.</remarks>
        public static string[] Parse(this string input, string patern, RegexOptions option = RegexOptions.Multiline)
        {
            if (input.IsEmpty())
                return null;

            List<string> data = new List<string>();
            MatchCollection parsed = null;

            try
            {
                parsed = System.Text.RegularExpressions.Regex.Matches(input, patern, option);
            }
            catch (Exception) { }

            if (parsed == null || parsed.Count == 0)
                return null;

            foreach (Match s in parsed)
            {
                data.Add(s.ToString());
            }
            return data.ToArray();
        }
    }
}

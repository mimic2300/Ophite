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
    }
}

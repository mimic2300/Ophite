namespace Ophite.Security
{
    /// <summary>
    /// Typy regex výrazů pro kontrolou vstupu.
    /// </summary>
    public enum RegexMatch
    {
        /// <summary>
        /// IP adresa.
        /// </summary>
        IP,

        /// <summary>
        /// Port.
        /// </summary>
        Port,

        /// <summary>
        /// Název databáze (třeba Mysql).
        /// </summary>
        DatabaseName,

        /// <summary>
        /// Znaky, které nesmí obsahovat název souboru.
        /// </summary>
        FileNameInvalidChars,

        /// <summary>
        /// Silné heslo, kde musí obsahovat číslo, písmeno i speciální znak a
        /// mít délku minimálně 8 znaků.
        /// </summary>
        ExtraStrongPassword,

        /// <summary>
        /// Web URL.
        /// </summary>
        URL,

        /// <summary>
        /// Email.
        /// </summary>
        Email,

        /// <summary>
        /// Uživatelské jméno pro USA, kde může obsahovat apostrof a pomlčku.
        /// </summary>
        UsernameForUSA,

        /// <summary>
        /// Pouze písmena.
        /// </summary>
        OnlyLetters,

        /// <summary>
        /// Pouze malá písmena.
        /// </summary>
        OnlyLowerLetters,

        /// <summary>
        /// Pouze velká písmena.
        /// </summary>
        OnlyUpperLetters,

        /// <summary>
        /// Pouze čísla.
        /// </summary>
        OnlyNumbers,

        /// <summary>
        /// Pouze speciální znaky.
        /// </summary>
        OnlySpecialChars,

        /// <summary>
        /// Pouze číslo + tečky.
        /// </summary>
        NumberWithDots,

        /// <summary>
        /// Nesmí obsahovat speciální znaky.
        /// </summary>
        WithoutSpecialChars,

        /// <summary>
        /// HEXa hodnota.
        /// </summary>
        HexValue,

        /// <summary>
        /// Římská čísla.
        /// </summary>
        RomanNumbers
    }
}

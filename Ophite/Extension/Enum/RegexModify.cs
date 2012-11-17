namespace Ophite.Extension
{
    /// <summary>
    /// Typ modifikace pro změnu vstupu u regexu.
    /// </summary>
    public enum RegexModify : int
    {
        /// <summary>
        /// Přidá do vstupního textu před všechny potencionálně nebezpečné znaky zpětné lomítko.
        /// </summary>
        AddSlashes,

        /// <summary>
        /// Odebere ze vstupního textu zpětná lomítka před potencionálně nebezpečnými znaky.
        /// </summary>
        RemoveSlashes,

        /// <summary>
        /// Odebere všechny tabulátory (\t).
        /// </summary>
        RemoveTabs,

        /// <summary>
        /// Odebere všechny CR (carriage return (\r)).
        /// </summary>
        RemoveLineFeed,

        /// <summary>
        /// odebere všechny LF (line feed (\n)).
        /// </summary>
        RemoveCarriageReturn,

        /// <summary>
        /// Odebere všechny nové řádky ve windows (\n\r).
        /// </summary>
        RemoveWindowsNewLine,

        /// <summary>
        /// Odebere všechny HTML tagy (vše mezi špičatými závorkami).
        /// </summary>
        RemoveHTMLTags,

        /// <summary>
        /// Spojí víceřádkové stringy do jednoho.
        /// </summary>
        JoinMultilineStrings
    }
}

namespace Ophite.Extension
{
    /// <summary>
    /// Typ parsování textu pro regex.
    /// </summary>
    public enum RegexParse : int
    {
        /// <summary>
        /// Vybere z textu všechny binarní hodnoty o délce 8 bitů.
        /// </summary>
        ByteInBinary,

        /// <summary>
        /// Vybere z textu všechny youtube videa ID.
        /// </summary>
        YouTubeVideoID,

        /// <summary>
        /// Vybere všechna slova, která jsou napsána velkými písmeny.
        /// </summary>
        FindAllCapsWords,

        /// <summary>
        /// Vybere všechna slova, která jsou napsána malými písmeny.
        /// </summary>
        FindAllLowercaseWords,

        /// <summary>
        /// Vybere všechna slova, která začínají velkým písmenem.
        /// </summary>
        FindAllInitialCaps,

        /// <summary>
        /// Vybere všechna čísla.
        /// </summary>
        FindAllNumbers
    }
}

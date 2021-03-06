﻿namespace Ophite.Exceptions
{
    /// <summary>
    /// Různé typy vyjímek, které mohou nastat v tomto API.
    /// </summary>
    public enum ExceptionType : uint
    {
        /// <summary>
        /// Typ není nastaven.
        /// </summary>
        None = 0,

        /// <summary>
        /// Jeden z argumentů v uvedené metodě má hodnotu NULL.
        /// </summary>
        ArgumentNullException,

        /// <summary>
        /// Hodnota argumentu je mimo povolený rozsah hodnot.
        /// </summary>
        ArgumentOutOfRangeException,

        /// <summary>
        /// Požadovaná metoda nebo operace není implementována.
        /// </summary>
        NotImplementedException,

        /// <summary>
        /// Metoda není podporována nebo při pokusu o čtení, hledání nebo zápisu do proudu, který nepodporuje metodu.
        /// </summary>
        NotSupportedException,

        /// <summary>
        /// Soubor nelze načíst.
        /// </summary>
        FileLoadException,

        /// <summary>
        /// Pokud se nezdaří pokus o přístup k souboru na disku nebo neexistuje.
        /// </summary>
        FileNotFoundException,

        /// <summary>
        /// Neplatný soubor obrazu dynamické knihovny (DLL) nebo spustitelného programu.
        /// </summary>
        BadImageFormatException,

        /// <summary>
        /// Není dostatek paměti.
        /// </summary>
        OutOfMemoryException,

        /// <summary>
        /// Objekt se vyřadil (zlikvidoval) a nelze s ním dále pracovat.
        /// </summary>
        ObjectDisposedException,

        /// <summary>
        /// Pokud je volání metody v aktuálním stavu objektu neplatné.
        /// </summary>
        InvalidOperationException,

        /// <summary>
        /// Metodu nelze spustit na určité platformě.
        /// </summary>
        PlatformNotSupportedException,

        /// <summary>
        /// Pokud se nezdaří pokus o přístup členské třídy (objektu).
        /// </summary>
        MemberAccessException,

        /// <summary>
        /// Neplatný pokus o přístup k metodě, jako je přístup k soukromé metodě z částečně důvěryhodného kódu.
        /// </summary>
        MethodAccessException,

        /// <summary>
        /// Metoda vyvolaná prostřednictvím reflexe.
        /// </summary>
        TargetInvocationException,

        /// <summary>
        /// Zjištěna chyba zabezpečení.
        /// </summary>
        SecurityException,

        /// <summary>
        /// Metodě je předán nesprávný počet rozměrů pole.
        /// </summary>
        RankException,

        /// <summary>
        /// Formát argument nesplňuje specifikace parametru metody.
        /// </summary>
        FormatException,

        /// <summary>
        /// Selhání kodéru.
        /// </summary>
        EncoderFallbackException,

        /// <summary>
        /// Chyba při aritmetický operaci nebo převodu, který způsobí přetečení.
        /// </summary>
        OverflowException,

        /// <summary>
        /// Doba spouštění metody a porovnávání regulárního výrazu přesáhne jeho časový limit.
        /// </summary>
        RegexMatchTimeoutException,

        /// <summary>
        /// Počet parametrů vyvolání neodpovídá očekávanému počtu.
        /// </summary>
        TargetParameterCountException,

        /// <summary>
        /// Jeden z argumentů v uvedené metodě není platný.
        /// </summary>
        ArgumentException = 0x1000,

        /// <summary>
        /// Všeobecný kód chyby pro Win32.
        /// </summary>
        Win32Exception = 0x2000,

        /// <summary>
        /// Všeobecná chyba pro operace zápisu a čtení.
        /// </summary>
        IOException = 0x4000,

        /// <summary>
        /// Globální chyba.
        /// </summary>
        Exception = 0x8000
    }
}

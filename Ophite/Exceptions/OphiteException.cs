using System;

namespace Ophite.Exceptions
{
    /// <summary>
    /// Obsluhuje všechny vyjímky, které mohou nastat v tomto API.
    /// </summary>
    public sealed class OphiteException : Exception
    {
        private ExceptionType type = ExceptionType.None;
        private DateTime time = DateTime.Now;

        #region Konstruktory

        /// <summary>
        /// Konstruktor pro předání instance OphiteException.
        /// </summary>
        /// <param name="exception">Instance vyjímky OphiteException.</param>
        public OphiteException(OphiteException exception)
            // TODO: Není ošetřen vstupní parametr jako NULL.
            : base(exception.Message, exception.InnerException)
        {
            this.type = exception.type;
            this.time = exception.time;
        }

        /// <summary>
        /// Hlavní konstruktor.
        /// </summary>
        /// <param name="type">Typ vyjímky.</param>
        public OphiteException(ExceptionType type)
            : base()
        {
            this.type = type;
        }

        /// <summary>
        /// Konstruktor pro nastavení vlastní zprávy.
        /// </summary>
        /// <param name="type">Typ vyjímky.</param>
        /// <param name="message">Vlastní zpráva.</param>
        public OphiteException(ExceptionType type, string message)
            : base(message)
        {
            this.type = type;
        }

        /// <summary>
        /// Rozšířený konstruktor.
        /// </summary>
        /// <param name="type">Typ vyjímky.</param>
        /// <param name="innerException">Vyhozená vyjímka.</param>
        public OphiteException(ExceptionType type, Exception innerException)
            : base(innerException.Message, innerException)
        {
            this.type = type;
        }

        /// <summary>
        /// Rozšířený konstruktor.
        /// </summary>
        /// <param name="type">Typ vyjímky.</param>
        /// <param name="message">Vlastní zpráva.></param>
        /// <param name="innerException">Vyhozená vyjímka.</param>
        public OphiteException(ExceptionType type, string message, Exception innerException)
            : base(message, innerException)
        {
            this.type = type;
        }

        #endregion Konstruktory

        /// <summary>
        /// Vrací typ vyjímky.
        /// </summary>
        public ExceptionType Type { get { return type; } }

        /// <summary>
        /// Vrací čas vyvolání vyjímky.
        /// </summary>
        public DateTime Time { get { return time; } }
    }
}

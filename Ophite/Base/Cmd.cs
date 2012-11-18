using Ophite.Exceptions;
using Ophite.Extension;
using System;
using System.IO;

namespace Ophite.Base
{
    /// <summary>
    /// Pracuje s konzolí.
    /// </summary>
    public static class Cmd
    {
        /// <summary>
        /// Přečte double hodnotu z konzole a vrátí ji.
        /// </summary>
        /// <param name="question">Pod jakou otázkou, bude konzole požadovat double číslo.</param>
        /// <returns>Vrací double číslo.</returns>
        /// <remarks>Pokud vstup z konzole bude špatný, tak vrácí vyjímku.</remarks>
        /// <exception cref="OphiteException"></exception>
        public static double ReadDouble(string question = null)
        {
            if (!question.IsEmpty())
                Console.Write(question);

            return Console.ReadLine().AsDouble();
        }

        /// <summary>
        /// Bude číst z konzole text tak dlouho, dokud se nebude jednat o double.
        /// </summary>
        /// <param name="question">Pod jakou otázkou, bude konzole požadovat double číslo.</param>
        /// <returns>Vrací číslo double.</returns>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="IOException"></exception>
        public static double ReadDoubleLoop(string question = null)
        {
            while (true)
            {
                try
                {
                    if (!question.IsEmpty())
                        Console.Write(question);

                    string text = Console.ReadLine();
                    return text.AsDouble();
                }
                catch (IOException ex) { throw new OphiteException(ExceptionType.IOException, ex); }
            }
        }

        /// <summary>
        /// Přečte int hodnotu z konzole a vrátí ji.
        /// </summary>
        /// <param name="question">Pod jakou otázkou, bude konzole požadovat int číslo.</param>
        /// <returns>Vrací int číslo.</returns>
        /// <remarks>Když vstup z konzole bude špatný, tak vrácí vyjímku.</remarks>
        /// <exception cref="OphiteException"></exception>
        public static int ReadInt(string question = null)
        {
            if (!question.IsEmpty())
                Console.Write(question);

            return Console.ReadLine().AsInt();
        }

        /// <summary>
        /// Bude číst z konzole text tak dlouho, dokud se nebude jednat o int.
        /// </summary>
        /// <param name="question">Pod jakou otázkou, bude konzole požadovat int číslo.</param>
        /// <returns>Vrací číslo int.</returns>
        /// <exception cref="OphiteException"></exception>
        /// <exception cref="IOException"></exception>
        public static int ReadIntLoop(string question = null)
        {
            while (true)
            {
                try
                {
                    if (!question.IsEmpty())
                        Console.Write(question);

                    string text = Console.ReadLine();
                    return text.AsInt();
                }
                catch (IOException ex) { throw new OphiteException(ExceptionType.IOException, ex); }
            }
        }

        /// <summary>
        /// Přečte string hodnotu z konzole a vrátí ji.
        /// </summary>
        /// <param name="question">Pod jakou otázkou, bude konzole požadovat string hodnotu.</param>
        /// <returns>Vrací string hodnotu.</returns>
        public static string ReadString(string question = null)
        {
            if (!question.IsEmpty())
                Console.Write(question);

            return Console.ReadLine();
        }

        /// <summary>
        /// Napíše do konzole barevný text.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <param name="foreground">Barva textu.</param>
        /// <param name="background">Barva pozadí za textem.</param>
        public static void Color(string text, ConsoleColor foreground = ConsoleColor.Gray, ConsoleColor background = ConsoleColor.Black)
        {
            if (text.IsEmpty())
                return;

            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}

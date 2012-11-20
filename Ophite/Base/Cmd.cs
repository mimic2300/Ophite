using Ophite.Extension;
using System;

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
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
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
        public static double ReadDoubleLoop(string question = null)
        {
            while (true)
            {
                if (!question.IsEmpty())
                    Console.Write(question);

                try
                {
                    return Console.ReadLine().AsDouble();
                }
                catch (ArgumentException) { }
                catch (FormatException) { }
                catch (OverflowException) { }
            }
        }

        /// <summary>
        /// Přečte int hodnotu z konzole a vrátí ji.
        /// </summary>
        /// <param name="question">Pod jakou otázkou, bude konzole požadovat int číslo.</param>
        /// <returns>Vrací int číslo.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
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
        public static int ReadIntLoop(string question = null)
        {
            while (true)
            {
                if (!question.IsEmpty())
                    Console.Write(question);

                try
                {
                    return Console.ReadLine().AsInt();
                }
                catch (ArgumentException) { }
                catch (FormatException) { }
                catch (OverflowException) { }
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

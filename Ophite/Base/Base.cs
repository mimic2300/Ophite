using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Ophite.Base
{
    /// <summary>
    /// Práce se systémem a API.
    /// </summary>
    public static class Base
    {
        /// <summary>
        /// Vynuceně ukončí tento process.
        /// </summary>
        /// <returns>Vrací TRUE, pokud se aktuální proces ukončil.</returns>
        public static bool ForceTerminate()
        {
            return ProcessKill(Process.GetCurrentProcess().Id);
        }

        /// <summary>
        /// Ukončuje všechny procesy, který mají stejný název.
        /// </summary>
        /// <param name="processName">Název procesu.</param>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static void ProcessKill(string processName)
        {
            Process[] proc = Process.GetProcessesByName(processName);

            foreach (Process p in proc)
            {
                p.Kill();
            }
        }

        /// <summary>
        /// Ukončuje proces podle ID.
        /// </summary>
        /// <param name="processID">ID procesu.</param>
        /// <returns>Vrací TRUE, pokud se proces ukončil.</returns>
        public static bool ProcessKill(int processID)
        {
            try
            {
                Process.GetProcessById(processID).Kill();
                return true;
            }
            catch (Win32Exception) { }
            catch (NotSupportedException) { }
            catch (ArgumentException) { }
            catch (InvalidOperationException) { }

            return false;
        }

        /// <summary>
        /// Vrací pole byte ze zdroje (Resources).
        /// </summary>
        /// <param name="namespaceDir">Název jmenného prostoru (až do adresáře se zdrojem).</param>
        /// <param name="file">Název souboru (z adresáře zdroje).</param>
        /// <returns>Vrací pole byte souboru zdroje.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="FileLoadException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="BadImageFormatException"></exception>
        /// <exception cref="OutOfMemoryException"></exception>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="IOException"></exception>
        public static byte[] BytesFromResources(string namespaceDir, string file)
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(namespaceDir + "." + file))
            {
                IntPtr data = Marshal.AllocCoTaskMem((int)stream.Length);
                byte[] byteData = new byte[stream.Length];

                stream.Read(byteData, 0, (int)stream.Length);
                Marshal.Copy(byteData, 0, data, (int)stream.Length);
                Marshal.FreeCoTaskMem(data);

                return byteData;
            }
        }

        /// <summary>
        /// Vrací ukazatel na soubor ze zdroje (Resource).
        /// </summary>
        /// <param name="namespaceDir">Název jmenného prostoru (až do adresáře se zdrojem).</param>
        /// <param name="file">Název souboru (z adresáře zdroje).</param>
        /// <returns>Vrací ukazatel na soubor.</returns>
        /// <remarks>Nutno poté uvolnit ukazatel, aby nevznikl memory leak!</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="FileLoadException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="BadImageFormatException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        /// <exception cref="OutOfMemoryException"></exception>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public static IntPtr HandleFromResources(string namespaceDir, string file)
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(namespaceDir + "." + file))
            {
                return Marshal.AllocCoTaskMem((int)stream.Length);
            }
        }

        /// <summary>
        /// Získá aktuální čas v sekundách.
        /// </summary>
        /// <returns>Vrací sekundy.</returns>
        public static long ActualTimeInSeconds()
        {
            return (long)new TimeSpan(DateTime.Now.Ticks).TotalSeconds;
        }

        /// <summary>
        /// Získá aktuální unixtime.
        /// </summary>
        /// <returns>Vrací unixtime.</returns>
        public static long UnixTime()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}

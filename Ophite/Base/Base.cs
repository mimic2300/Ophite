using System;
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
        public static void ForceTerminate()
        {
            Process.GetCurrentProcess().Kill();
        }

        /// <summary>
        /// Ukončuje všechny procesy, který mají stejný název.
        /// </summary>
        /// <param name="processName">Název procesu.</param>
        public static void ProcessKill(string processName)
        {
            Process[] proc = Process.GetProcessesByName(processName);

            foreach (Process p in proc)
            {
                try
                {
                    p.Kill();
                }
                catch (Exception) { }
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
            catch (Exception) { return false; }
        }

        /// <summary>
        /// Vrací pole byte ze zdroje (Resources).
        /// </summary>
        /// <param name="namespaceDir">Název jmenného prostoru až do adresáře se zdrojem.</param>
        /// <param name="file">Název souboru z adresáře zdroje.</param>
        /// <returns>Vrací pole byte souboru zdroje.</returns>
        /// <remarks>Pokud se zadá špatná cesta k souboru do zdroje, tak vrací NULL.</remarks>
        public static byte[] BytesFromResources(string namespaceDir, string file)
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(namespaceDir + "." + file))
            {
                if (stream == null)
                    return null;

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
        /// <param name="namespaceDir">Název jmenného prostoru až do adresáře se zdrojem.</param>
        /// <param name="file">Název souboru z adresáře zdroje.</param>
        /// <returns>Vrací ukazatel na soubor.</returns>
        /// <remarks>Pokud se zadá špatná cesta k souboru do zdroje, tak vrací 0.
        /// Nutno poté uvolnit pointer, aby nevznikl memory leak!</remarks>
        public static IntPtr HandleFromResources(string namespaceDir, string file)
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(namespaceDir + "." + file))
            {
                if (stream == null)
                    return IntPtr.Zero;

                return Marshal.AllocCoTaskMem((int)stream.Length);
            }
        }

        /// <summary>
        /// Získá aktuální čas v sekundách.
        /// </summary>
        /// <returns>Vrací sekundy.</returns>
        public static double ActualTime()
        {
            return new TimeSpan(DateTime.Now.Ticks).TotalSeconds;
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

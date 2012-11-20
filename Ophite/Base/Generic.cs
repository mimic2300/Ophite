using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

namespace Ophite.Base
{
    /// <summary>
    /// Pracuje s generickým typem.
    /// </summary>
    public static class Generic
    {
        /// <summary>
        /// Porovnává dva generické typy.
        /// </summary>
        /// <typeparam name="GenericType">Vstupní generický typ.</typeparam>
        /// <typeparam name="Comparer">Jaký typ by to měl být.</typeparam>
        /// <returns>Vrací TRUE, pokud jsou typy stejné.</returns>
        public static bool Equals<GenericType, Comparer>()
        {
            Type type = typeof(GenericType);
            return type.Equals(typeof(Comparer));
        }

        /// <summary>
        /// Porovnává generický typ s objektem.
        /// </summary>
        /// <typeparam name="GenericType">Vstupní generický typ.</typeparam>
        /// <param name="obj">Vstupní objekt, který by měl být stejného typu jako generický.</param>
        /// <returns>Vrací TRUE, pokud objekt obsahuje stejný typ jako je generický.</returns>
        /// <remarks>Pokud vstupní parametr bude NULL, tak vrací FALSE.</remarks>
        public static bool Equals<GenericType>(object obj)
        {
            if (obj == null)
                return false;

            Type type = typeof(GenericType);
            Type input = obj.GetType();

            return type.Equals(input);
        }

        /// <summary>
        /// Vytvoří instanci z generického typu o určitých parametrech.
        /// </summary>
        /// <typeparam name="T">Generický typ třídy nebo struktůry.</typeparam>
        /// <param name="types">Seznam typů parametrů.</param>
        /// <param name="args">Hodnoty parametrů.</param>
        /// <returns>Vrací novou instanci objektu.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MethodAccessException"></exception>
        /// <exception cref="MemberAccessException"></exception>
        /// <exception cref="TargetInvocationException"></exception>
        /// <exception cref="TargetParameterCountException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="SecurityException"></exception>
        public static T CallConstructor<T>(Type[] types, params object[] args) where T : new()
        {
            return (T)new T().GetType().GetConstructor(types).Invoke(args);
        }

        /// <summary>
        /// Vytvoří instanci z generického typu o určitým parametru.
        /// </summary>
        /// <typeparam name="T">Generický typ třídy nebo struktůry.</typeparam>
        /// <param name="type">Typ vstupního parametru.</param>
        /// <param name="arg">Hodnota parametru.</param>
        /// <returns>Vrací novou instanci objektu.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MethodAccessException"></exception>
        /// <exception cref="MemberAccessException"></exception>
        /// <exception cref="TargetInvocationException"></exception>
        /// <exception cref="TargetParameterCountException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="SecurityException"></exception>
        public static T CallConstructor<T>(Type type, object arg) where T : new()
        {
            Type[] types = new Type[] { type };
            object[] args = new object[] { arg };

            return (T)new T().GetType().GetConstructor(types).Invoke(args);
        }

        /// <summary>
        /// Převádí pole byte do struktůry dle generického typu.
        /// </summary>
        /// <typeparam name="T">Vstupní typ strukůry.</typeparam>
        /// <param name="bytes">Data pro převod.</param>
        /// <returns>Vrací struktůru podle generického typu.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static T ToStructure<T>(byte[] bytes) where T : struct
        {
            GCHandle gch = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            IntPtr ptr = gch.AddrOfPinnedObject();
            T result = (T)Marshal.PtrToStructure(ptr, typeof(T));

            gch.Free();
            return result;
        }
    }
}

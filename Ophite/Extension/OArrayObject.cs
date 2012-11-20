namespace Ophite.Extension
{
    /// <summary>
    /// Rozšiřuje původní datový typ "object[]".
    /// </summary>
    public static class OArrayObject
    {
        /// <summary>
        /// Kontroluje, zda vstupní pole objektů je prázdné nebo NULL.
        /// </summary>
        /// <param name="objs">Vstupní pole objektů.</param>
        /// <returns>Vrací TRUE, pokuď pole objektů je prázdné nebo NULL.</returns>
        public static bool IsEmpty(this object[] objs)
        {
            return (objs == null || objs.Length < 1);
        }

        /// <summary>
        /// Náhodně promíchá prvky v poli.
        /// </summary>
        /// <param name="array">Pole prvků.</param>
        public static void Shuffle(this object[] array)
        {
            if (array == null)
                return;

            for (int i = array.Length - 1; i > 0; i--)
            {
                int index = Global.RAND.Next(i);

                object tmp = array[index];
                array[index] = array[i];
                array[i] = tmp;
            }
        }
    }
}

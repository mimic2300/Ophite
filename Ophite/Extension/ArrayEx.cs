namespace Ophite.Extension
{
    /// <summary>
    /// Pracuje s polem.
    /// </summary>
    public static class ArrayEx
    {
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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ophite.Extension;

namespace OphiteTests.Extension
{
    [TestClass]
    public class OShort
    {
        [TestMethod]
        public void AsBytes()
        {
            // kladná hodnota (bigEndian)
            CollectionAssert.AreEqual(
                new byte[] { 0, 100 },
                ((short)100).AsBytes());

            // záporná hodnota (bigEndian)
            CollectionAssert.AreEqual(
                new byte[] { 255, 156 },
                ((short)-100).AsBytes());

            // kladná hodnota (littleEndian)
            CollectionAssert.AreEqual(
                new byte[] { 100, 0 },
                ((short)100).AsBytes(false));

            // záporná hodnota (littleEndian)
            CollectionAssert.AreEqual(
                new byte[] { 156, 255 },
                ((short)-100).AsBytes(false));
        }
    }
}

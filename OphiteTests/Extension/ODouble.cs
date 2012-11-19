using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ophite.Extension;

namespace OphiteTests.Extension
{
    [TestClass]
    public class ODouble
    {
        [TestMethod]
        public void AsBytes()
        {
            // kladná hodnota (bigEndian)
            CollectionAssert.AreEqual(
                new byte[] { 64, 89, 0, 0, 0, 0, 0, 0 },
                ((double)100.0).AsBytes());

            // záporná hodnota (bigEndian)
            CollectionAssert.AreEqual(
                new byte[] { 192, 89, 0, 0, 0, 0, 0, 0 },
                ((double)-100.0).AsBytes());

            // kladná hodnota (littleEndian)
            CollectionAssert.AreEqual(
                new byte[] { 0, 0, 0, 0, 0, 0, 89, 64 },
                ((double)100.0).AsBytes(false));

            // záporná hodnota (littleEndian)
            CollectionAssert.AreEqual(
                new byte[] { 0, 0, 0, 0, 0, 0, 89, 192 },
                ((double)-100.0).AsBytes(false));
        }
    }
}

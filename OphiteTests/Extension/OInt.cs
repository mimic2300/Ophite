using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ophite.Extension;

namespace OphiteTests.Extension
{
    [TestClass]
    public class OInt
    {
        [TestMethod]
        public void AsBytes()
        {
            // kladná hodnota (bigEndian)
            CollectionAssert.AreEqual(
                new byte[] { 0, 0, 0, 100 },
                ((int)100).AsBytes());

            // záporná hodnota (bigEndian)
            CollectionAssert.AreEqual(
                new byte[] { 255, 255, 255, 156 },
                ((int)-100).AsBytes());

            // kladná hodnota (littleEndian)
            CollectionAssert.AreEqual(
                new byte[] { 100, 0, 0, 0 },
                ((int)100).AsBytes(false));

            // záporná hodnota (littleEndian)
            CollectionAssert.AreEqual(
                new byte[] { 156, 255, 255, 255 },
                ((int)-100).AsBytes(false));
        }
    }
}

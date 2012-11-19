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
            byte[] result = ((int)100).AsBytes();

            CollectionAssert.AreEqual(new byte[] { 0, 0, 0, 100 }, result);

            // záporná hodnota (bigEndian)
            result = ((int)-100).AsBytes();

            CollectionAssert.AreEqual(new byte[] { 255, 255, 255, 156 }, result);

            // kladná hodnota (littleEndian)
            result = ((int)100).AsBytes(false);

            CollectionAssert.AreEqual(new byte[] { 100, 0, 0, 0 }, result);

            // záporná hodnota (littleEndian)
            result = ((int)-100).AsBytes(false);

            CollectionAssert.AreEqual(new byte[] { 156, 255, 255, 255 }, result);
        }
    }
}

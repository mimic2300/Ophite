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
            byte[] result = ((double)100.0).AsBytes();

            CollectionAssert.AreEqual(new byte[] { 64, 89, 0, 0, 0, 0, 0, 0 }, result);

            // záporná hodnota (bigEndian)
            result = ((double)-100.0).AsBytes();

            CollectionAssert.AreEqual(new byte[] { 192, 89, 0, 0, 0, 0, 0, 0 }, result);

            // kladná hodnota (littleEndian)
            result = ((double)100.0).AsBytes(false);

            CollectionAssert.AreEqual(new byte[] { 0, 0, 0, 0, 0, 0, 89, 64 }, result);

            // záporná hodnota (littleEndian)
            result = ((double)-100.0).AsBytes(false);

            CollectionAssert.AreEqual(new byte[] { 0, 0, 0, 0, 0, 0, 89, 192 }, result);
        }
    }
}

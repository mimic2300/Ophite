using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ophite.Extension;

namespace OphiteTests.Extension
{
    [TestClass]
    public class OFloat
    {
        [TestMethod]
        public void AsBytes()
        {
            // kladná hodnota (bigEndian)
            byte[] result = ((float)100.0f).AsBytes();

            CollectionAssert.AreEqual(new byte[] { 66, 200, 0, 0 }, result);

            // záporná hodnota (bigEndian)
            result = ((float)-100.0f).AsBytes();

            CollectionAssert.AreEqual(new byte[] { 194, 200, 0, 0 }, result);

            // kladná hodnota (littleEndian)
            result = ((float)100.0f).AsBytes(false);

            CollectionAssert.AreEqual(new byte[] { 0, 0, 200, 66 }, result);

            // záporná hodnota (littleEndian)
            result = ((float)-100.0f).AsBytes(false);

            CollectionAssert.AreEqual(new byte[] { 0, 0, 200, 194 }, result);
        }
    }
}

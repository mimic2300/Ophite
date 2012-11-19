using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ophite.Extension;

namespace OphiteTests.Extension
{
    [TestClass]
    public class ODecimal
    {
        [TestMethod]
        public void AsBytes()
        {
            // kladná hodnota (bigEndian)
            byte[] result = ((decimal)100.0).AsBytes();

            CollectionAssert.AreEqual(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100 }, result);

            // záporná hodnota (bigEndian)
            result = ((decimal)-100.0).AsBytes();

            CollectionAssert.AreEqual(new byte[] { 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100 }, result);

            // kladná hodnota (littleEndian)
            result = ((decimal)100.0).AsBytes(false);

            CollectionAssert.AreEqual(new byte[] { 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, result);

            // záporná hodnota (littleEndian)
            result = ((decimal)-100.0).AsBytes(false);

            CollectionAssert.AreEqual(new byte[] { 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 128 }, result);
        }
    }
}

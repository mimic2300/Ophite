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
            CollectionAssert.AreEqual(
                new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100 },
                ((decimal)100.0).AsBytes());

            // záporná hodnota (bigEndian)
            CollectionAssert.AreEqual(
                new byte[] { 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100 },
                ((decimal)-100.0).AsBytes());

            // kladná hodnota (littleEndian)
            CollectionAssert.AreEqual(
                new byte[] { 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                ((decimal)100.0).AsBytes(false));

            // záporná hodnota (littleEndian)
            CollectionAssert.AreEqual(
                new byte[] { 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 128 },
                ((decimal)-100.0).AsBytes(false));
        }
    }
}

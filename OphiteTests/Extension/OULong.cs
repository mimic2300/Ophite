using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ophite.Extension;

namespace OphiteTests.Extension
{
    [TestClass]
    public class OULong
    {
        [TestMethod]
        public void AsBytes()
        {
            // kladná hodnota (bigEndian)
            CollectionAssert.AreEqual(
                new byte[] { 0, 0, 0, 0, 0, 0, 0, 100 },
                ((ulong)100).AsBytes());

            // kladná hodnota (littleEndian)
            CollectionAssert.AreEqual(
                new byte[] { 100, 0, 0, 0, 0, 0, 0, 0 },
                ((ulong)100).AsBytes(false));
        }
    }
}

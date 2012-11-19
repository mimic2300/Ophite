using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ophite.Extension;

namespace OphiteTests.Extension
{
    [TestClass]
    public class OUShort
    {
        [TestMethod]
        public void AsBytes()
        {
            // kladná hodnota (bigEndian)
            CollectionAssert.AreEqual(
                new byte[] { 0, 100 },
                ((ushort)100).AsBytes());

            // kladná hodnota (littleEndian)
            CollectionAssert.AreEqual(
                new byte[] { 100, 0 },
                ((ushort)100).AsBytes(false));
        }
    }
}

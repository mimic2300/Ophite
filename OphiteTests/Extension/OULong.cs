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
            byte[] result = ((ulong)100).AsBytes();

            CollectionAssert.AreEqual(new byte[] { 0, 0, 0, 0, 0, 0, 0, 100 }, result);

            // kladná hodnota (littleEndian)
            result = ((ulong)100).AsBytes(false);

            CollectionAssert.AreEqual(new byte[] { 100, 0, 0, 0, 0, 0, 0, 0 }, result);
        }
    }
}

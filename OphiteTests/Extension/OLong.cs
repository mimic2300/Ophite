using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ophite.Extension;
using System;

namespace OphiteTests.Extension
{
    [TestClass]
    public class OLong
    {
        [TestMethod]
        public void AsBytes()
        {
            // kladná hodnota (bigEndian)
            byte[] result = ((long)100).AsBytes();

            CollectionAssert.AreEqual(new byte[] { 0, 0, 0, 0, 0, 0, 0, 100 }, result);

            // záporná hodnota (bigEndian)
            result = ((long)-100).AsBytes();

            CollectionAssert.AreEqual(new byte[] { 255, 255, 255, 255, 255, 255, 255, 156 }, result);

            // kladná hodnota (littleEndian)
            result = ((long)100).AsBytes(false);

            CollectionAssert.AreEqual(new byte[] { 100, 0, 0, 0, 0, 0, 0, 0 }, result);

            // záporná hodnota (littleEndian)
            result = ((long)-100).AsBytes(false);

            CollectionAssert.AreEqual(new byte[] { 156, 255, 255, 255, 255, 255, 255, 255 }, result);
        }

        [TestMethod]
        public void AsHex()
        {
            // kladná hodnota
            Assert.AreEqual("7A69", ((long)31337).AsHex());
            Assert.AreEqual("7a69", ((long)31337).AsHex(false));

            // záporná hodnota
            Assert.AreEqual("FFFFFFFFFFFF8597", ((long)-31337).AsHex());
            Assert.AreEqual("ffffffffffff8597", ((long)-31337).AsHex(false));

            // nula
            Assert.AreEqual("0", ((long)0).AsHex());
        }

        [TestMethod]
        public void FromUnixTime()
        {
            DateTime result = new DateTime(2012, 11, 19, 18, 23, 22);

            Assert.AreEqual(result, ((long)1353349402).AsDateTime());
        }
    }
}

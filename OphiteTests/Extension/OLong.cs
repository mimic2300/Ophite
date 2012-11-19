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
            CollectionAssert.AreEqual(
                new byte[] { 0, 0, 0, 0, 0, 0, 0, 100 },
                ((long)100).AsBytes());

            // záporná hodnota (bigEndian)
            CollectionAssert.AreEqual(
                new byte[] { 255, 255, 255, 255, 255, 255, 255, 156 },
                ((long)-100).AsBytes());

            // kladná hodnota (littleEndian)
            CollectionAssert.AreEqual(
                new byte[] { 100, 0, 0, 0, 0, 0, 0, 0 },
                ((long)100).AsBytes(false));

            // záporná hodnota (littleEndian)
            CollectionAssert.AreEqual(
                new byte[] { 156, 255, 255, 255, 255, 255, 255, 255 },
                ((long)-100).AsBytes(false));
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
            Assert.AreEqual(
                new DateTime(2012, 11, 19, 18, 23, 22),
                ((long)1353349402).AsDateTime());
        }
    }
}

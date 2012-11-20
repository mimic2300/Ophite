using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ophite.Extension;
using System;
using System.Runtime.Serialization;

namespace OphiteTests.Extension
{
    [TestClass]
    public class OObject
    {
        private struct Person
        {
            public byte Age;
        }

        [Serializable]
        private struct Person_Serializable
        {
            public byte Age;
        }

        [TestMethod]
        public void AsObjectSerialize()
        {
            // neplatný objekt pro serializaci
            Person person = new Person() { Age = 30 };

            // platný objekt pro serializaci
            Person_Serializable person_serializable = new Person_Serializable() { Age = 30 };

            byte[] expected = person_serializable.AsObjectSerialize();

            // serializuje objekt, který není označený jako [Serializable]
            try
            {
                CollectionAssert.AreEqual(expected, person.AsObjectSerialize());
                Assert.Fail();
            }
            catch (SerializationException) { }

            // hodnota NULL
            CollectionAssert.AreEqual(null, ((object)null).AsObjectSerialize());
        }

        [TestMethod]
        public void AsSoapStringASCII()
        {
            // neplatný objekt pro serializaci
            Person person = new Person() { Age = 30 };

            // platný objekt pro serializaci
            Person_Serializable person_serializable = new Person_Serializable() { Age = 30 };

            string expected = person_serializable.AsSoapStringASCII();

            // serializuje objekt, který není označený jako [Serializable]
            try
            {
                Assert.AreEqual(expected, person.AsSoapStringASCII());
                Assert.Fail();
            }
            catch (SerializationException) { }

            // hodnota NULL
            Assert.AreEqual(null, ((object)null).AsSoapStringASCII());
        }

        [TestMethod]
        public void AsSoapStringUTF8()
        {
            // neplatný objekt pro serializaci
            Person person = new Person() { Age = 30 };

            // platný objekt pro serializaci
            Person_Serializable person_serializable = new Person_Serializable() { Age = 30 };

            string expected = person_serializable.AsSoapStringUTF8();

            // serializuje objekt, který není označený jako [Serializable]
            try
            {
                Assert.AreEqual(expected, person.AsSoapStringUTF8());
                Assert.Fail();
            }
            catch (SerializationException) { }

            // hodnota NULL
            Assert.AreEqual(null, ((object)null).AsSoapStringUTF8());
        }
    }
}

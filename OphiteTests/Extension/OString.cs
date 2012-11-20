using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ophite.Extension;
using System;
using System.Xml;

namespace OphiteTests.Extension
{
    [TestClass]
    public class OString
    {
        [Serializable]
        private struct Person
        {
            public byte Age;
        }

        [TestMethod]
        public void IsEmpty()
        {
            // prázdný vstup
            Assert.AreEqual(true, "".IsEmpty());

            // hodnota NULL
            Assert.AreEqual(true, ((string)null).IsEmpty());

            // textový vstup
            Assert.AreEqual(false, "world".IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsBytesASCII()
        {
            // textový vstup (jako littleEndian)
            CollectionAssert.AreEqual(new byte[] { 63, 97, 117 }, "čau".AsBytesASCII());

            // textový vstup (jako bigEndian)
            CollectionAssert.AreEqual(new byte[] { 117, 97, 63 }, "čau".AsBytesASCII(true));

            // prázdný vstup
            CollectionAssert.AreEqual(new byte[] { }, "".AsBytesASCII());

            // hodnota NULL - vyhodí vyjímku "ArgumentNullException"
            CollectionAssert.AreEqual(new byte[] { }, ((string)null).AsBytesASCII());
        }

        [TestMethod]
        public void AsBytesUTF8()
        {
            // textový vstup (jako littleEndian)
            CollectionAssert.AreEqual(new byte[] { 196, 141, 97, 117 }, "čau".AsBytesUTF8());

            // textový vstup (jako bigEndian)
            CollectionAssert.AreEqual(new byte[] { 117, 97, 141, 196 }, "čau".AsBytesUTF8(true));

            // prázdný vstup
            CollectionAssert.AreEqual(new byte[] { }, "".AsBytesASCII());

            // hodnota NULL
            try
            {
                CollectionAssert.AreEqual(new byte[] { }, ((string)null).AsBytesASCII());
                CollectionAssert.AreEqual(null, ((string)null).AsBytesASCII());
                Assert.Fail();
            }
            catch (ArgumentNullException) { }
        }

        [TestMethod]
        public void AsShort()
        {
            // číselný text
            Assert.AreEqual((short)100, "100".AsShort());

            // záporný číselný text
            Assert.AreEqual((short)-100, "-100".AsShort());

            // písmeno nebo znak v textu
            try
            {
                Assert.AreEqual((short)0, "1.00".AsShort());
                Assert.AreEqual((short)1, "1.00".AsShort());
                Assert.Fail();
            }
            catch (FormatException) { }

            // prázdný text
            try
            {
                Assert.AreEqual((short)0, "".AsShort());
                Assert.Fail();
            }
            catch (FormatException) { }

            // hodnota NULL
            try
            {
                Assert.AreEqual((short)0, ((string)null).AsShort());
                Assert.Fail();
            }
            catch (ArgumentNullException) { }

            // příliš velké číslo
            try
            {
                Assert.AreEqual((short)0, "10000000".AsShort());
                Assert.AreEqual((short)short.MaxValue, "10000000".AsShort());
                Assert.Fail();
            }
            catch (OverflowException) { }

            // písmeno nebo znak v textu
            Assert.AreEqual((short)0, "1.00".AsShort(true));

            // prázdný text
            Assert.AreEqual((short)0, "".AsShort(true));

            // hodnota NULL
            Assert.AreEqual((short)0, ((string)null).AsShort(true));

            // příliš velké číslo
            Assert.AreEqual((short)0, "10000000".AsShort(true));
        }

        [TestMethod]
        public void AsUShort()
        {
            // číselný text
            Assert.AreEqual((ushort)100, "100".AsUShort());

            // písmeno nebo znak v textu
            try
            {
                Assert.AreEqual((ushort)0, "1.00".AsUShort());
                Assert.AreEqual((ushort)1, "1.00".AsUShort());
                Assert.Fail();
            }
            catch (FormatException) { }

            // prázdný text
            try
            {
                Assert.AreEqual((ushort)0, "".AsUShort());
                Assert.Fail();
            }
            catch (FormatException) { }

            // hodnota NULL
            try
            {
                Assert.AreEqual((ushort)0, ((string)null).AsUShort());
                Assert.Fail();
            }
            catch (ArgumentNullException) { }

            // příliš velké číslo
            try
            {
                Assert.AreEqual((ushort)0, "10000000".AsUShort());
                Assert.AreEqual((ushort)ushort.MaxValue, "10000000".AsUShort());
                Assert.Fail();
            }
            catch (OverflowException) { }

            // písmeno nebo znak v textu
            Assert.AreEqual((ushort)0, "1.00".AsUShort(true));

            // prázdný text
            Assert.AreEqual((ushort)0, "".AsUShort(true));

            // hodnota NULL
            Assert.AreEqual((ushort)0, ((string)null).AsUShort(true));

            // příliš velké číslo
            Assert.AreEqual((ushort)0, "10000000".AsUShort(true));
        }

        [TestMethod]
        public void AsInt()
        {
            // číselný text
            Assert.AreEqual((int)100, "100".AsInt());

            // záporný číselný text
            Assert.AreEqual((int)-100, "-100".AsInt());

            // písmeno nebo znak v textu
            try
            {
                Assert.AreEqual((int)0, "1.00".AsInt());
                Assert.AreEqual((int)1, "1.00".AsInt());
                Assert.Fail();
            }
            catch (FormatException) { }

            // prázdný text
            try
            {
                Assert.AreEqual((int)0, "".AsInt());
                Assert.Fail();
            }
            catch (FormatException) { }

            // hodnota NULL
            try
            {
                Assert.AreEqual((int)0, ((string)null).AsInt());
                Assert.Fail();
            }
            catch (ArgumentNullException) { }

            // příliš velké číslo
            try
            {
                Assert.AreEqual((int)0, "10000000000".AsInt());
                Assert.AreEqual((int)int.MaxValue, "10000000000".AsInt());
                Assert.Fail();
            }
            catch (OverflowException) { }

            // písmeno nebo znak v textu
            Assert.AreEqual((int)0, "1.00".AsInt(true));

            // prázdný text
            Assert.AreEqual((int)0, "".AsInt(true));

            // hodnota NULL
            Assert.AreEqual((int)0, ((string)null).AsInt(true));

            // příliš velké číslo
            Assert.AreEqual((int)0, "10000000000".AsInt(true));
        }

        [TestMethod]
        public void AsUInt()
        {
            // číselný text
            Assert.AreEqual((uint)100, "100".AsUInt());

            // písmeno nebo znak v textu
            try
            {
                Assert.AreEqual((uint)0, "1.00".AsUInt());
                Assert.AreEqual((uint)1, "1.00".AsUInt());
                Assert.Fail();
            }
            catch (FormatException) { }

            // prázdný text
            try
            {
                Assert.AreEqual((uint)0, "".AsUInt());
                Assert.Fail();
            }
            catch (FormatException) { }

            // hodnota NULL
            try
            {
                Assert.AreEqual((uint)0, ((string)null).AsUInt());
                Assert.Fail();
            }
            catch (ArgumentNullException) { }

            // příliš velké číslo
            try
            {
                Assert.AreEqual((uint)0, "10000000000".AsUInt());
                Assert.AreEqual((uint)uint.MaxValue, "10000000000".AsUInt());
                Assert.Fail();
            }
            catch (OverflowException) { }

            // písmeno nebo znak v textu
            Assert.AreEqual((uint)0, "1.00".AsUInt(true));

            // prázdný text
            Assert.AreEqual((uint)0, "".AsUInt(true));

            // hodnota NULL
            Assert.AreEqual((uint)0, ((string)null).AsUInt(true));

            // příliš velké číslo
            Assert.AreEqual((uint)0, "10000000000".AsUInt(true));
        }

        [TestMethod]
        public void AsLong()
        {
            // číselný text
            Assert.AreEqual((long)100, "100".AsLong());

            // záporný číselný text
            Assert.AreEqual((long)-100, "-100".AsLong());

            // písmeno nebo znak v textu
            try
            {
                Assert.AreEqual((long)0, "1.00".AsLong());
                Assert.AreEqual((long)1, "1.00".AsLong());
                Assert.Fail();
            }
            catch (FormatException) { }

            // prázdný text
            try
            {
                Assert.AreEqual((long)0, "".AsLong());
                Assert.Fail();
            }
            catch (FormatException) { }

            // hodnota NULL
            try
            {
                Assert.AreEqual((long)0, ((string)null).AsLong());
                Assert.Fail();
            }
            catch (ArgumentNullException) { }

            // příliš velké číslo
            try
            {
                Assert.AreEqual((long)0, "10000000000000000000".AsLong());
                Assert.AreEqual((long)long.MaxValue, "10000000000000000000".AsLong());
                Assert.Fail();
            }
            catch (OverflowException) { }

            // písmeno nebo znak v textu
            Assert.AreEqual((long)0, "1.00".AsLong(true));

            // prázdný text
            Assert.AreEqual((long)0, "".AsLong(true));

            // hodnota NULL
            Assert.AreEqual((long)0, ((string)null).AsLong(true));

            // příliš velké číslo
            Assert.AreEqual((long)0, "10000000000000000000".AsLong(true));
        }

        [TestMethod]
        public void AsULong()
        {
            // číselný text
            Assert.AreEqual((ulong)100, "100".AsULong());

            // písmeno nebo znak v textu
            try
            {
                Assert.AreEqual((ulong)0, "1.00".AsULong());
                Assert.AreEqual((ulong)1, "1.00".AsULong());
                Assert.Fail();
            }
            catch (FormatException) { }

            // prázdný text
            try
            {
                Assert.AreEqual((ulong)0, "".AsULong());
                Assert.Fail();
            }
            catch (FormatException) { }

            // hodnota NULL
            try
            {
                Assert.AreEqual((ulong)0, ((string)null).AsULong());
                Assert.Fail();
            }
            catch (ArgumentNullException) { }

            // příliš velké číslo
            try
            {
                Assert.AreEqual((ulong)0, "100000000000000000000".AsULong());
                Assert.AreEqual((ulong)ulong.MaxValue, "100000000000000000000".AsULong());
                Assert.Fail();
            }
            catch (OverflowException) { }

            // písmeno nebo znak v textu
            Assert.AreEqual((ulong)0, "1.00".AsULong(true));

            // prázdný text
            Assert.AreEqual((ulong)0, "".AsULong(true));

            // hodnota NULL
            Assert.AreEqual((ulong)0, ((string)null).AsULong(true));

            // příliš velké číslo
            Assert.AreEqual((ulong)0, "100000000000000000000".AsULong(true));
        }

        [TestMethod]
        public void AsFloat()
        {
            // číselný text
            Assert.AreEqual((float)100.0f, "100".AsFloat());

            // číselný text s tečkou
            Assert.AreEqual((float)1.00f, "1.00".AsFloat());

            // záporný číselný text
            Assert.AreEqual((float)-100.0f, "-100".AsFloat());

            // prázdný text
            try
            {
                Assert.AreEqual((float)0.0f, "".AsFloat());
                Assert.Fail();
            }
            catch (FormatException) { }

            // hodnota NULL
            try
            {
                Assert.AreEqual((float)0.0f, ((string)null).AsFloat());
                Assert.Fail();
            }
            catch (ArgumentNullException) { }

            // příliš velké číslo
            try
            {
                Assert.AreEqual((float)0.0f, (float.MaxValue + 1).ToString().AsFloat());
                Assert.AreEqual((float)float.MaxValue, (float.MaxValue + 1).ToString().AsFloat());
                Assert.Fail();
            }
            catch (OverflowException) { }

            // písmeno nebo znak v textu
            Assert.AreEqual((float)0.0f, "1.00".AsFloat(true));

            // prázdný text
            Assert.AreEqual((float)0.0f, "".AsFloat(true));

            // hodnota NULL
            Assert.AreEqual((float)0.0f, ((string)null).AsFloat(true));

            // příliš velké číslo
            Assert.AreEqual((float)3.402823E+38f, (float.MaxValue + 1).ToString().AsFloat(true));
        }

        [TestMethod]
        public void AsDouble()
        {
            // číselný text
            Assert.AreEqual((double)100.0, "100".AsDouble());

            // číselný text s tečkou
            Assert.AreEqual((double)1.00, "1.00".AsDouble());

            // záporný číselný text
            Assert.AreEqual((double)-100.0, "-100".AsDouble());

            // prázdný text
            try
            {
                Assert.AreEqual((double)0.0, "".AsDouble());
                Assert.Fail();
            }
            catch (FormatException) { }

            // hodnota NULL
            try
            {
                Assert.AreEqual((double)0.0, ((string)null).AsDouble());
                Assert.Fail();
            }
            catch (ArgumentNullException) { }

            // příliš velké číslo
            try
            {
                Assert.AreEqual((double)0.0, (double.MaxValue + 1).ToString().AsDouble());
                Assert.AreEqual((double)double.MaxValue, (double.MaxValue + 1).ToString().AsDouble());
                Assert.Fail();
            }
            catch (OverflowException) { }

            // písmeno nebo znak v textu
            Assert.AreEqual((double)0.0, "1.00".AsDouble(true));

            // prázdný text
            Assert.AreEqual((double)0.0, "".AsDouble(true));

            // hodnota NULL
            Assert.AreEqual((double)0.0, ((string)null).AsDouble(true));

            // příliš velké číslo
            Assert.AreEqual((double)0.0, (double.MaxValue + 1).ToString().AsDouble(true));
        }

        [TestMethod]
        public void AsDecimal()
        {
            // číselný text
            Assert.AreEqual((decimal)100.0, "100".AsDecimal());

            // číselný text s tečkou
            Assert.AreEqual((decimal)1.00, "1.00".AsDecimal());

            // záporný číselný text
            Assert.AreEqual((decimal)-100.0, "-100".AsDecimal());

            // prázdný text
            try
            {
                Assert.AreEqual((decimal)0.0, "".AsDecimal());
                Assert.Fail();
            }
            catch (FormatException) { }

            // hodnota NULL
            try
            {
                Assert.AreEqual((decimal)0.0, ((string)null).AsDecimal());
                Assert.Fail();
            }
            catch (ArgumentNullException) { }

            // příliš velké číslo
            try
            {
                Assert.AreEqual((decimal)0.0, "79228162514264337593543950336".AsDecimal());
                Assert.AreEqual((decimal)decimal.MaxValue, "79228162514264337593543950336".AsDecimal());
                Assert.Fail();
            }
            catch (OverflowException) { }

            // písmeno nebo znak v textu
            Assert.AreEqual((decimal)0.0, "1.00".AsDecimal(true));

            // prázdný text
            Assert.AreEqual((decimal)0.0, "".AsDecimal(true));

            // hodnota NULL
            Assert.AreEqual((decimal)0.0, ((string)null).AsDecimal(true));

            // příliš velké číslo
            Assert.AreEqual((decimal)0.0, "79228162514264337593543950336".AsDecimal(true));
        }

        [TestMethod]
        public void AsHexValue()
        {
            // HEX text
            Assert.AreEqual((long)11259375, "ABCDEF".AsHexValue());

            // text obsahuje prilis velkou hodnotu pro převod do long
            Assert.AreEqual((long)-1, "FFFFFFFFFFFFFFFF".AsHexValue());

            // text obsahuje jiný znak nez A-F
            try
            {
                Assert.AreEqual((long)0, "ABCDEFG".AsHexValue());
                Assert.AreEqual((long)11259375, "ABCDEFG".AsHexValue());
                Assert.Fail();
            }
            catch (FormatException) { }

            // text je prázdný
            try
            {
                Assert.AreEqual((long)0, "".AsHexValue());
                Assert.Fail();
            }
            catch (FormatException) { }

            // hodnota NULL
            try
            {
                Assert.AreEqual((long)0, ((string)null).AsHexValue());
                Assert.Fail();
            }
            catch (ArgumentNullException) { }
        }

        [TestMethod]
        public void ReadTo()
        {
            // přečte text do první čárky
            Assert.AreEqual(
                "Text je cokoliv",
                "Text je cokoliv, co je uloženo v textovém formátu.".ReadTo(','));

            // přečte text do první čárky + čárku
            Assert.AreEqual(
                "Text je cokoliv,",
                "Text je cokoliv, co je uloženo v textovém formátu.".ReadTo(',', true));

            // znak, který v textu neexistuje
            Assert.AreEqual(
                null,
                "Text je cokoliv, co je uloženo v textovém formátu.".ReadTo('w'));

            // přečte prvních 10 znaků
            Assert.AreEqual(
                "Text je co",
                "Text je cokoliv, co je uloženo v textovém formátu.".ReadTo(10));

            // počet znaků bude mimo rozmezí délky textu
            Assert.AreEqual(
                null,
                "Text je cokoliv, co je uloženo v textovém formátu.".ReadTo(100));

            // počet znaků bude mimo rozmezí délky textu
            Assert.AreEqual(
                null,
                "Text je cokoliv, co je uloženo v textovém formátu.".ReadTo(-100));
        }

        [TestMethod]
        public void SplitEx()
        {
            // rozdělení podle  " : "
            CollectionAssert.AreEqual(
                new string[] { "a", "b", "c" },
                "a : b : c".SplitEx(" : "));

            // rozdělení posle znaku, který v textu neexistuje
            CollectionAssert.AreEqual(
                new string[] { "a : b : c" },
                "a : b : c".SplitEx("x"));

            // hodnota NULL
            CollectionAssert.AreEqual(
                new string[] { },
                ((string)null).SplitEx("x"));

            // rozdělovací text nebude existovat
            CollectionAssert.AreEqual(
                new string[] { "a : b : c" },
                "a : b : c".SplitEx(""));

            // rozdělovací text bude NULL
            CollectionAssert.AreEqual(
                new string[] { "a : b : c" },
                "a : b : c".SplitEx(null));
        }

        [TestMethod]
        public void AsBytesFromHex()
        {
            // text v HEX
            CollectionAssert.AreEqual(new byte[] { 255, 80, 170 }, "FF50AA".AsBytesFromHex());

            // pokud bude lichý počet, tak na začátek přidá 0 (FF50A -> 0FF50A)
            CollectionAssert.AreEqual(new byte[] { 15, 245, 10 }, "FF50A".AsBytesFromHex());

            // pokud bude lichý počet a velikost bude vetší jak 0, tak opět přidá 0 (F -> 0F)
            CollectionAssert.AreEqual(new byte[] { 15 }, "F".AsBytesFromHex());

            // prázdný text
            CollectionAssert.AreEqual(new byte[] { }, "".AsBytesFromHex());

            // hodnota NULL
            CollectionAssert.AreEqual(new byte[] { }, ((string)null).AsBytesFromHex());

            // neplatný vstup pro HEX hodnotu
            try
            {
                CollectionAssert.AreEqual(new byte[] { 15 }, "FG".AsBytesFromHex());
                CollectionAssert.AreEqual(new byte[] { }, "FG".AsBytesFromHex());
                Assert.Fail();
            }
            catch (FormatException) { }

            // za každou HEX hodnotou je mezera
            CollectionAssert.AreEqual(new byte[] { 255, 80, 170 }, "FF 50 AA".AsBytesFromHex("", " "));

            // před každou HEX hodnotou je mezera
            CollectionAssert.AreEqual(new byte[] { 255, 80, 170 }, " FF 50 AA".AsBytesFromHex(" "));

            // před i za každou HEX hodnotou je nějaký znak
            CollectionAssert.AreEqual(new byte[] { 255, 80, 170 }, "0xFF 0x50 0xAA".AsBytesFromHex("0x", " "));

            // před i za každou HEX hodnotou je nějaký znak a zároveň HEX hodnota je zjednodušená
            CollectionAssert.AreEqual(new byte[] { 15, 80, 10 }, "0xF 0x50 0xA".AsBytesFromHex("0x", " "));

            // špatný formát (mezi HEX hodnotami je ještě mezera)
            try
            {
                CollectionAssert.AreEqual(new byte[] { 15, 80, 10 }, "0xF 0x50 0xA".AsBytesFromHex("0x"));
                CollectionAssert.AreEqual(new byte[] { }, "0xF 0x50 0xA".AsBytesFromHex("0x"));
                Assert.Fail();
            }
            catch (FormatException) { }

            // v pořádku, protože HEX hodnota může začínat "0x", ale nesmí obsahovat mezeru
            CollectionAssert.AreEqual(new byte[] { 15, 80, 10 }, "0xF 0x50 0xA".AsBytesFromHex("", " "));

            // špatný formát (před HEX hodnotami je ještě "x")
            try
            {
                CollectionAssert.AreEqual(new byte[] { 15, 80, 10 }, "xF x50 xA".AsBytesFromHex("", " "));
                CollectionAssert.AreEqual(new byte[] { }, "xF x50 xA".AsBytesFromHex("", " "));
                Assert.Fail();
            }
            catch (FormatException) { }
        }

        [TestMethod]
        public void AsObjectFromSoap()
        {
            Person person = new Person() { Age = 30 };
            string soap = person.AsSoapStringASCII();

            // soap string Person na objekt Person
            Assert.AreEqual(person, soap.AsObjectFromSoap());

            // špatný formát soap stringu
            try
            {
                Assert.AreEqual(" ", " ".AsObjectFromSoap());
                Assert.Fail();
            }
            catch (XmlException) { }

            // hodnota NULL
            Assert.AreEqual(null, ((string)null).AsObjectFromSoap());
        }

        [TestMethod]
        public void RemoveLeadingZeros()
        {
            // odebere první nuly
            Assert.AreEqual("123", "000123".RemoveLeadingZeros());

            // prázdný text
            Assert.AreEqual("", "".RemoveLeadingZeros());

            // hodnota NULL
            Assert.AreEqual(null, ((string)null).RemoveLeadingZeros());
        }

        [TestMethod]
        public void FromBase64()
        {
            // převod platného base64
            CollectionAssert.AreEqual(new byte[] { 111, 112, 104, 105, 116, 101 }, "b3BoaXRl".FromBase64());

            // prázdný string
            CollectionAssert.AreEqual(new byte[] { }, "".FromBase64());

            // hodnota NULL
            CollectionAssert.AreEqual(new byte[] { }, ((string)null).FromBase64());

            // neplatný string nebo znak ve stringu
            try
            {
                CollectionAssert.AreEqual(new byte[] { 111, 112, 104, 105, 116, 101 }, "b3BoaXRl!".FromBase64());
                CollectionAssert.AreEqual(new byte[] { }, "b3BoaXRl!".FromBase64());
            }
            catch (FormatException) { }
        }
    }
}

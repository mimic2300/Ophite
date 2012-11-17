using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OphiteTests
{
    [TestClass]
    public class LogicTests
    {
        [TestMethod]
        public void Fibbonaci_ZeroNumber()
        {
            ulong zero = Ophite.Base.Logic.Fibonacci(0);

            Assert.AreEqual((ulong)0, zero);
        }

        [TestMethod]
        public void Fibbonaci_FirstNumber()
        {
            ulong first = Ophite.Base.Logic.Fibonacci(1);

            Assert.AreEqual((ulong)1, first);
        }

        [TestMethod]
        public void Fibbonaci_SecondNumber()
        {
            ulong second = Ophite.Base.Logic.Fibonacci(2);

            Assert.AreEqual((ulong)1, second);
        }

        [TestMethod]
        public void Fibbonaci_TenthNumber()
        {
            ulong tenth = Ophite.Base.Logic.Fibonacci(10);

            Assert.AreEqual((ulong)55, tenth);
        }

        [TestMethod]
        public void Faktorial_TenFactorial()
        {
            ulong tenFactorial = Ophite.Base.Logic.Factorial(10);

            Assert.AreEqual((ulong)3628800, tenFactorial);
        }
    }
}

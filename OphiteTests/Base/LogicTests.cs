using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ophite.Base;
using System.Drawing;

namespace OphiteTests.Base
{
    [TestClass]
    public class LogicTests
    {
        [TestMethod]
        public void QuadraticRoot()
        {
            double[] result = Logic.QuadraticRoot(5, 8, -2);

            Assert.AreEqual(0.219803902, result[0], 1e-9);
            Assert.AreEqual(-1.819803902, result[1], 1e-9);
        }

        [TestMethod]
        public void GpsDistance_Km()
        {
            double distance = Logic.GpsDistance(10, 50, -10, -50);

            Assert.AreEqual(11280.527224170, distance, 1e-9);
        }

        [TestMethod]
        public void GpsDistance_Mil()
        {
            double distance = Logic.GpsDistance(10, 50, -10, -50, 'M');

            Assert.AreEqual(6086.958314362, distance, 1e-9);
        }

        [TestMethod]
        public void PointDistance()
        {
            double distance = Logic.PointDistance(new Point(10, 10), new Point(50, 50));

            Assert.AreEqual(56.568542494, distance, 1e-9);
        }

        [TestMethod]
        public void DegreesToPoint()
        {
            PointF point = Logic.DegreesToPoint(45.0, 20.0, Point.Empty);

            Assert.AreEqual(new PointF(14.1421356f, -14.1421356f), point);
        }

        [TestMethod]
        public void AngleToDegrees()
        {
            double result = Logic.AngleToDegrees(new Point(10, 10), new Point(25, 25));

            Assert.AreEqual(135.0, result);
        }

        [TestMethod]
        public void Fibbonaci_ZeroNumber()
        {
            ulong zero = Logic.Fibonacci(0);

            Assert.AreEqual(0UL, zero);
        }

        [TestMethod]
        public void Fibbonaci_FirstNumber()
        {
            ulong first = Logic.Fibonacci(1);

            Assert.AreEqual(1UL, first);
        }

        [TestMethod]
        public void Fibbonaci_SecondNumber()
        {
            ulong second = Logic.Fibonacci(2);

            Assert.AreEqual(1UL, second);
        }

        [TestMethod]
        public void Fibbonaci_TenthNumber()
        {
            ulong tenth = Logic.Fibonacci(10);

            Assert.AreEqual(55UL, tenth);
        }

        [TestMethod]
        public void Faktorial_TenFactorial()
        {
            ulong tenFactorial = Logic.Factorial(10);

            Assert.AreEqual(3628800UL, tenFactorial);
        }

        [TestMethod]
        public void ToRadian()
        {
            double result = Logic.ToRadian(12.25);

            Assert.AreEqual(0.213802833, result, 1e-9);
        }

        [TestMethod]
        public void ToDegree()
        {
            double result = Logic.ToDegree(12.25);

            Assert.AreEqual(701.873299, result, 1e-6);
        }

        [TestMethod]
        public void IsPerfectNumber()
        {
            bool value = Logic.IsPerfectNumber(8128);

            Assert.AreEqual(true, value);
        }

        [TestMethod]
        public void Gcd()
        {
            int result = Logic.Gcd(9, 15);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Lcm()
        {
            int result = Logic.Lcm(9, 15);

            Assert.AreEqual(45, result);
        }
    }
}

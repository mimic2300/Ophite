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

            Assert.AreEqual(0.219803902, result[0], 1e-9);  // první kořen
            Assert.AreEqual(-1.819803902, result[1], 1e-9); // druhý kořen
        }

        [TestMethod]
        public void GpsDistance()
        {
            // námořní míle
            double result = Logic.GpsDistance(10, 50, -10, -50, 'N');

            Assert.AreEqual(7004.852109005, result, 1e-9);

            // míle
            result = Logic.GpsDistance(10, 50, -10, -50, 'M');

            Assert.AreEqual(6083.013571460, result, 1e-9);

            // kilometry
            result = Logic.GpsDistance(10, 50, -10, -50, 'K');

            Assert.AreEqual(11273.216712515, result, 1e-9);
        }

        [TestMethod]
        public void PointDistance()
        {
            double result = Logic.PointDistance(new Point(10, 10), new Point(50, 50));

            Assert.AreEqual(56.568542494, result, 1e-9);
        }

        [TestMethod]
        public void DegreesToPoint()
        {
            PointF result = Logic.DegreesToPoint(45.0, 20.0, Point.Empty);

            Assert.AreEqual(new PointF(14.1421356f, -14.1421356f), result);
        }

        [TestMethod]
        public void AngleToDegrees()
        {
            double result = Logic.AngleToDegrees(new Point(10, 10), new Point(25, 25));

            Assert.AreEqual(135.0, result);
        }

        [TestMethod]
        public void Fibbonaci()
        {
            // vstup 0
            ulong result = Logic.Fibonacci(0);

            Assert.AreEqual(0UL, result);

            // vstup 1
            result = Logic.Fibonacci(1);

            Assert.AreEqual(1UL, result);

            // vstup 2
            result = Logic.Fibonacci(2);

            Assert.AreEqual(1UL, result);

            // vstup 10
            result = Logic.Fibonacci(10);

            Assert.AreEqual(55UL, result);
        }

        [TestMethod]
        public void Faktorial()
        {
            ulong result = Logic.Factorial(10);

            Assert.AreEqual(3628800UL, result);
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
            bool result = Logic.IsPerfectNumber(8128);

            Assert.AreEqual(true, result);

            result = Logic.IsPerfectNumber(8129);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsPrimeNumber()
        {
            bool result = Logic.IsPrimeNumber(503);

            Assert.AreEqual(result, true);

            result = Logic.IsPrimeNumber(500);

            Assert.AreEqual(result, false);
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

        [TestMethod]
        public void Factorization()
        {
            bool isPrimeNumber;
            ulong[] result = Logic.Factorization(100, out isPrimeNumber);

            Assert.IsFalse(isPrimeNumber);
            CollectionAssert.AreEqual(new ulong[] { 2, 2, 5, 5 }, result);

            result = Logic.Factorization(503, out isPrimeNumber);

            Assert.IsTrue(isPrimeNumber);
            CollectionAssert.AreEqual(new ulong[] { }, result);
        }
    }
}

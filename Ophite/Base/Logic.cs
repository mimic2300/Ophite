using Ophite.Extension;
using System;
using System.Drawing;

namespace Ophite.Base
{
    /// <summary>
    /// Pracuje s matematikou.
    /// </summary>
    public static class Logic
    {
        #region Konstanty

        /// <summary>
        /// Číslo PI.
        /// </summary>
        public const double PI = 3.141592653589;

        /// <summary>
        /// Druhá mocnina PI.
        /// </summary>
        public const double PI2 = 9.86960440108;

        /// <summary>
        /// Gravitace (hodnota gravitačního zrychlení).
        /// </summary>
        public const double GRAVITY = 9.80665;

        /// <summary>
        /// Konstanta omegy.
        /// </summary>
        public const double OMEGA = 0.567143290409;

        /// <summary>
        /// Reciproční Fibonacciho konstanta.
        /// </summary>
        public const double FIBONACCI = 3.359885666243;

        /// <summary>
        /// Eulerova konstanta.
        /// </summary>
        public const double EULER = 0.577215664901;

        /// <summary>
        /// Matematická konstanta "e".
        /// </summary>
        public const double E = 2.718281828459;

        /// <summary>
        /// Druhá odmocnina ze 2.
        /// </summary>
        public const double ROOT2 = 1.414213562373;

        #endregion Konstanty

        /// <summary>
        /// Vypočte kořen kvadratické rovnice.
        /// </summary>
        /// <param name="a">Koeficient A.</param>
        /// <param name="b">Koeficient B.</param>
        /// <param name="c">Koeficient C.</param>
        /// <param name="isFirst">Pokud bude TRUE, tak se vypočte první kořen a pokud bude FALSE, tak druhý.</param>
        /// <returns>Vrací hodnotu kořene.</returns>
        public static double QuadraticRoot(double a, double b, double c, bool isFirst)
        {
            if (a == 0)
                return -c / b;

            double dis = b * b - 4 * a * c;

            if (isFirst)
                return (-b + Math.Sqrt(dis)) / (2 * a);

            return (-b - Math.Sqrt(dis)) / (2 * a);
        }

        /// <summary>
        /// Vypočte vzdálenost, mezi dvěma GPS.
        /// </summary>
        /// <param name="latit1">GPS 1: latit.</param>
        /// <param name="longit1">GPS 1: longit.</param>
        /// <param name="latit2">GPS 2: latit.</param>
        /// <param name="longit2">GPS 2: longit.</param>
        /// <param name="unit">Do jakých jednotek se má vzdálenost převést (K - km, M - míle).</param>
        /// <returns>Vrací vzdálenost, mezi dvěma GPS.</returns>
        public static double GpsDistance(double latit1, double longit1, double latit2, double longit2, char unit = 'K')
        {
            double theta = longit1 - longit2;
            double dist = Math.Sin(ToRadian(latit1)) * Math.Sin(ToRadian(latit2)) +
                          Math.Cos(ToRadian(latit1)) * Math.Cos(ToRadian(latit2)) *
                          Math.Cos(ToRadian(theta));

            dist = Math.Acos(dist);
            dist = ToDegree(dist);
            dist = dist * 60 * 1.1515;

            switch (unit)
            {
                case 'K': return dist * 1.609344; // km
                case 'M': return dist * 0.8684;   // míle
                default: return dist;
            }
        }

        /// <summary>
        /// Vypočte vzdálenost, mezi dvěma body.
        /// </summary>
        /// <param name="point1">První bod.</param>
        /// <param name="point2">Druhý bod.</param>
        /// <returns>Vrací vzdálenost, mezi prvním a druhým bodem.</returns>
        public static double PointDistance(Point point1, Point point2)
        {
            double a = (double)(point2.X - point1.X);
            double b = (double)(point2.Y - point1.Y);

            return Math.Sqrt(a * a + b * b);
        }

        /// <summary>
        /// Vypočítá bod, který je v úhlu od originálního (0 je vpravo).
        /// </summary>
        /// <param name="degrees">Stupeň.</param>
        /// <param name="radius">Poloměr.</param>
        /// <param name="origin">Originání bod.</param>
        /// <returns>Vrací nový bod, který je pod určitým úhlem.</returns>
        /// <remarks>Pokud originální bod bude NULL, tak vrácí instanci nového bodu [0,0].</remarks>
        public static PointF DegreesToPoint(double degrees, double radius, Point origin)
        {
            PointF newPoint = new PointF();

            if (origin == null)
                return newPoint;

            double radians = ToRadian(degrees);

            newPoint.X = (float)(Math.Cos(radians) * radius + origin.X);
            newPoint.Y = (float)(Math.Sin(-radians) * radius + origin.Y);

            return newPoint;
        }

        /// <summary>
        /// Vypočte úhel bodu od originálního.
        /// </summary>
        /// <param name="angle">Bod, od kterého se má spočítat úhel.</param>
        /// <param name="origin">Originální bod.</param>
        /// <returns>Vrací úhel.</returns>
        /// <remarks>Pokud nějaký vstupní bod bude NULL, tak vrácí 0.</remarks>
        public static double AngleToDegrees(Point angle, Point origin)
        {
            if (angle == null || origin == null)
                return 0;

            int deltaX = origin.X - angle.X;
            int deltaY = origin.Y - angle.Y;

            double radAngle = Math.Atan2(deltaY, deltaX);
            double degreeAngle = radAngle * 180.0 / Math.PI;

            return 180.0 - degreeAngle;
        }

        /// <summary>
        /// Vypočte faktoriál čísla.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací faktorál vstupního čísla.</returns>
        /// <remarks> Vstupní číslo musí být větší než 0, jinak vrácí 1.</remarks>
        public static ulong Factorial(uint number)
        {
            if (number <= 1)
                return 1;

            ulong val = 1;

            for (int i = 2; i <= number; i++)
            {
                val *= (ulong)i;
            }

            return val;
        }

        /// <summary>
        /// Vypočte Fibonacciho posloupnost.
        /// </summary>
        /// <param name="number">Vstupní číslo.</param>
        /// <returns>Vrací Fibonacciho posloupnost.</returns>
        /// <remarks>Vstupní číslo musí být větší než 1, jinak vrácí vstupní číslo.</remarks>
        public static ulong Fibonacci(uint number)
        {
            ulong first = 0;
            ulong second = 1;

            for (int i = 0; i < number; i++)
            {
                ulong temp = first;
                first = second;
                second = temp + second;
            }

            return first;
        }

        /// <summary>
        /// Převádí desetinné stupně na radiány.
        /// </summary>
        /// <param name="degree">Desetinné stupně.</param>
        /// <returns>Vrací radiány.</returns>
        public static double ToRadian(double degree)
        {
            return (degree * Math.PI / 180.0);
        }

        /// <summary>
        /// Převádí radiány na desetinné stupně.
        /// </summary>
        /// <param name="radian">Radiány.</param>
        /// <returns>Vrací desetinné stupně.</returns>
        public static double ToDegree(double radian)
        {
            return (radian / Math.PI * 180.0);
        }
    }
}

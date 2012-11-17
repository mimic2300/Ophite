using System;
using System.Drawing;

namespace Ophite.Base
{
    /// <summary>
    /// Pracuje s matematikou a logikou.
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
        /// Vypočte kořen kvadratické rovnice o jedné neznámé.
        /// </summary>
        /// <param name="a">Koeficient A.</param>
        /// <param name="b">Koeficient B.</param>
        /// <param name="c">Koeficient C.</param>
        /// <returns>Vrací kořeny kvadratické rovnice.</returns>
        /// <remarks>Pokud orvnice nemá řešení, tak vrací prázdné pole.</remarks>
        public static double[] QuadraticRoot(double a, double b, double c)
        {
            double dis = b * b - 4 * a * c;

            // rovnice nemá řešení
            if (dis < 0)
                return new double[] { };

            if (dis == 0)
                return new double[] { -b / 2 * a };

            return new double[]
            {
                (-b + Math.Sqrt(dis)) / (2 * a),
                (-b - Math.Sqrt(dis)) / (2 * a)
            };
        }

        /// <summary>
        /// Vypočte vzdálenost, mezi dvěma GPS.
        /// </summary>
        /// <param name="latit1">GPS 1: latit.</param>
        /// <param name="longit1">GPS 1: longit.</param>
        /// <param name="latit2">GPS 2: latit.</param>
        /// <param name="longit2">GPS 2: longit.</param>
        /// <param name="unit">Do jakých jednotek se má vzdálenost převést (K - km, M - míle).</param>
        /// <returns>Vrací vzdálenost mezi dvěma GPS.</returns>
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
        public static PointF DegreesToPoint(double degrees, double radius, Point origin)
        {
            PointF newPoint = new PointF();
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
        public static double AngleToDegrees(Point angle, Point origin)
        {
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
            if (number < 2)
                return 1;

            ulong value = 1;

            for (int i = 2; i <= number; i++)
            {
                value *= (ulong)i;
            }
            return value;
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
            return (degree * PI / 180.0);
        }

        /// <summary>
        /// Převádí radiány na desetinné stupně.
        /// </summary>
        /// <param name="radian">Radiány.</param>
        /// <returns>Vrací desetinné stupně.</returns>
        public static double ToDegree(double radian)
        {
            return (radian / PI * 180.0);
        }

        /// <summary>
        /// Zjišťuje, zda se jedná o dokonalé číslo.
        /// </summary>
        /// <param name="number">Testované číslo.</param>
        /// <returns>Vrací TRUE, pokud se jedná o dokonalé číslo.</returns>
        public static bool IsPerfectNumber(ulong number)
        {
            if (number % 2 == 1)
                return false;

            ulong result = 1;
            ulong i = 2;

            while (i <= Math.Sqrt(number))
            {
                if (number % i == 0)
                {
                    result += i;
                    result += number / i;
                }
                i++;
            }

            if (Math.Pow(i, 2) == number)
                result -= i;

            return result == number;
        }

        /// <summary>
        /// Zjišťuje největšího společného dělitele.
        /// </summary>
        /// <param name="a">První číslo.</param>
        /// <param name="b">Druhé číslo.</param>
        /// <returns>Vrací největší společný dělitel.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static int Gcd(int a, int b)
        {
            if (a < 1 || b < 1)
                throw new ArgumentException("Žádný parametr nesmí být menší než 1.");

            while (b != 0)
            {
                int tmp = a;
                a = b;
                b = tmp % b;
            }
            return a;
        }

        /// <summary>
        /// Nejmenší společný násobek.
        /// </summary>
        /// <param name="a">První číslo.</param>
        /// <param name="b">Druhé číslo.</param>
        /// <returns>Vrací nejmenší společný násobek.</returns>
        public static int Lcm(int a, int b)
        {
            if (a == 0 || b == 0)
                return 0;

            return (a * b) / Gcd(a, b);
        }
    }
}

using System;

namespace Зад2
{
    class Program
    {   
        class Rational
        {
            private int m, n;

            private static int nod(int a, int b)
            {
                a = Math.Abs(a); b = Math.Abs(b);
                while (a != 0 && b != 0)
                {
                    if (a > b) a %= b;
                    else b %= a;
                }
                return a + b;
            }
            public Rational(int a, int b)
            {
                if (b == 0)
                {
                    this.m = 0;
                    this.n = 1;
                }
                else
                {
                    if (a < 0 && b < 0) { a = Math.Abs(a); b = Math.Abs(b); }
                    if (b < 0) { b *= -1; a *= -1; }
                    int c = nod(a, b);
                    this.m = a/c;
                    this.n = b/c;

                }
            }
            public override string ToString() {
                return m + "/" + n;
            }

            public void PrintRational()
            {
                Console.WriteLine("{0}/{1}", m, n);
            }
            public Rational Plus(Rational a)
            {
                int b, c;
                b = m * a.n + n * a.m;
                c = n * a.n;
                int d = nod(b, c);
                return (new Rational(b / d, c / d));
            }
            public static Rational operator +(Rational a, Rational b)
            {
                return (a.Plus(b));
            }

            public Rational Minus(Rational a)
            {
                int b, c;
                b = m * a.n - n * a.m;
                c = n * a.n;
                int d = nod(b, c);
                return (new Rational(b/d, c/d));
            }
            public static Rational operator -(Rational a, Rational b)
            {
                return (a.Minus(b));
            }

            public Rational Mult(Rational a)
            {
                int b, c;
                b = m * a.m;
                c = n * a.n;
                int d = nod(b, c);
                return (new Rational(b / d, c / d));
            }
            public static Rational operator *(Rational a, Rational b)
            {
                return (a.Mult(b));
            }

            public Rational Divide(Rational a)
            {
                int b, c;
                b = m * a.n;
                c = n * a.m;
                int d = nod(b, c);
                return (new Rational(b / d, c / d));
            }
            public static Rational operator /(Rational a, Rational b)
            {
                return (a.Divide(b));
            }
            private Rational(int a, int b, string t)
            {
                m = a; n = b;
            }
            public static readonly Rational Zero, One;
            static Rational()
            {
                Zero = new Rational(0, 1, "private");
                One = new Rational(1, 1, "private");
            }
            public static bool operator ==(Rational a, Rational b)
            {
                return ((a.m == b.m) && (a.n == b.n));
            }
            public static bool operator !=(Rational a, Rational b)
            {
                return ((a.m != b.m) || (a.n != b.n));
            }
            public static bool operator >(Rational a, Rational b)
            {
                return ((a.m * b.n) > (a.n * b.m));
            }
            public static bool operator <(Rational a, Rational b)
            {
                return ((a.m * b.n) < (a.n * b.m));
            }
            public static bool operator <(Rational a, double b)
            {
                return ((double)a.m / a.n < b);
            }
            public static bool operator >(Rational a, double b)
            {
                return ((double)a.m / a.n > b);
            }
        }

        static void Main()
        {
            Rational c = new Rational(-1, -4);
            Rational c1 = new Rational(5, 0);
            Rational c2 = new Rational(1, -7);
            Rational c3 = new Rational(5, 10);
            Rational c4 = new Rational(3, 8);
            Console.WriteLine(c.ToString());
            c2.PrintRational();
            c3.PrintRational();
            c1 = c + c4;
            c1.PrintRational();
            c1 = c - c4;
            c1.PrintRational();
            c1 = c * c4;
            c1.PrintRational();
            c1 = c / c4;
            c1.PrintRational();

        }
    }
}

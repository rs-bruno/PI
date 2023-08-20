namespace Functions
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public double Mod()
        {
            return Math.Sqrt(X*X + Y*Y);
        }
        public Point Middle(Point b)
        {
            return new Point((X + b.X) / 2, (Y + b.Y) / 2);
        }
        public static Point operator+(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
        public static Point operator-(Point a)
        {
            return new Point(-a.X, -a.Y);
        }
        public static Point operator-(Point a, Point b)
        {
            return a + (-b);
        }
        public static Point operator*(double x, Point a)
        {
            return new Point(x * a.X, x * a.Y);
        }
        public static Point operator/(Point a, double x)
        {
            return new Point(a.X / x, a.Y / x);
        }
    }
    static class FunctionsClass
    {
        static double Iter(long numIters, Point a, Point b)
        {
            if (numIters < 1)
                return 0;
            var middlePoint = a.Middle(b);
            var triangleVert = middlePoint / middlePoint.Mod();
            var triangleArea = (b - a).Mod() * (triangleVert - middlePoint).Mod() / 2;
            return triangleArea + Iter(numIters - 1, a, triangleVert) + Iter(numIters - 1, triangleVert, b);
        }
        public static double PIExtTriRec(long numIters)
        {
            var a = new Point(0, 1);
            var b = new Point(1, 0);
            return 2 + 4 * Iter(numIters, a, b);
        }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("First 48 decimal digits of PI = 3.141592653589793238462643383279502884197169399375");
            Console.WriteLine($"Math.PI = {Math.PI:G100}");
            long i = 1;
            while (true)
            {
                Console.WriteLine($"{i} recursive iterations triangle extenuation = {FunctionsClass.PIExtTriRec(i):G100}");
                ++i;
            }
        }
    }
}
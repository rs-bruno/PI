Random r1 = new Random((int)DateTime.Now.Ticks);
Random r2 = new Random((int)DateTime.Now.Ticks);
long insideUnit = 0;
long total = 1;
double mod(double x, double y)
{
    return Math.Sqrt(x * x + y * y);
}
Thread printer = new Thread(() =>
{
    Console.WriteLine("First 48 decimal digits of PI = 3.141592653589793238462643383279502884197169399375");
    Console.WriteLine($"Math.PI = {Math.PI:G100}");
    while (true)
    {
        Thread.Sleep(1000);
        var insideSnap = insideUnit;
        var totalSnap = total;
        var estimation = 4d * ((double)insideSnap / totalSnap);
        Console.WriteLine($"Current estimation: {estimation}");
    }
});
printer.Start();
while (true)
{
    ++total;
    if (mod(r1.NextDouble(), r2.NextDouble()) <= 1)
        ++insideUnit;
}
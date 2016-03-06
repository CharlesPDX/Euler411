namespace Euler411
{
    using System;
    using System.Diagnostics;
    using System.Numerics;

    class Program
    {
        static void Main(string[] args)
        {
            BigInteger sumOfPathLengths = 0;
            
            // note odd for end condition, need to run 1-30 inclusive
            for (var k = 1; k < 31; k++)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                var n = (int)Math.Pow(k, 5);
                
                var domain = new StationDomain(n);
                var currentPathLength = domain.CalculateValidPathLength();
                stopwatch.Stop();
                sumOfPathLengths = sumOfPathLengths + currentPathLength;
                Console.WriteLine("S({0}^5)= {1} in {2}h {3}m {4}.{5}s",
                    k,
                    currentPathLength,
                    stopwatch.Elapsed.Hours,
                    stopwatch.Elapsed.Minutes,
                    stopwatch.Elapsed.Seconds,
                    stopwatch.ElapsedMilliseconds);
            }

            Console.WriteLine("Sum of path lengths: {0}", sumOfPathLengths);
            Console.WriteLine("Complete, press enter to exit.");
            Console.ReadLine();
        }
    }
}
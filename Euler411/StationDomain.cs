namespace Euler411
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class StationDomain
    {
        private readonly Station[] _yOrderedStations;

        private readonly int maxDegreeOfParallelism = Environment.ProcessorCount - 1;

        public StationDomain(int n)
        {
            var stations = GetStations(n);
            _yOrderedStations = stations.OrderBy(p => p.Y).ThenBy(q => q.X).ToArray();
        }

        public int CalculateValidPathLength()
        {
            var maxStations = _yOrderedStations.Length;
            var interval = GetInterval(maxStations);

            for (var stationIndex = 0; stationIndex < maxStations; stationIndex++)
            {
                var currentPoint = _yOrderedStations[stationIndex];
                var nextLength = currentPoint.Length + 1;

                var currentX = currentPoint.X;
                var rollingMax = Math.Min(stationIndex + interval, maxStations);
                
                Parallel.For(stationIndex + 1, rollingMax, new ParallelOptions { MaxDegreeOfParallelism = maxDegreeOfParallelism }, i =>
                {
                    if (_yOrderedStations[i].X >= currentX)
                    {
                        if (_yOrderedStations[i].Length < nextLength)
                        {
                            _yOrderedStations[i].Length = nextLength;
                        }
                    }
                }
                );
            }

            return _yOrderedStations.Last().Length;
        }

        private static int GetInterval(int maxStations)
        {
            if (maxStations < 20000000)
            {
                return maxStations;
            }

            // ReSharper disable once PossibleLossOfFraction
            return (int)Math.Round((decimal)(maxStations / 100), MidpointRounding.AwayFromZero);
        }

        private static IEnumerable<Station> GetStations(int numberOfStationsToGenerate)
        {
            var stations = new HashSet<Station>();

            for (var i = 0; i < numberOfStationsToGenerate; i++)
            {
                var newPoint = new Station(ModPow(2, i, numberOfStationsToGenerate), ModPow(3, i, numberOfStationsToGenerate));
                stations.Add(newPoint);
            }

            var endPoint = new Station(numberOfStationsToGenerate, numberOfStationsToGenerate);

            stations.Add(endPoint);
            return stations;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int ModPow(int value, int exp, int modulus)
        {
            return (int)BigInteger.ModPow(value, exp, modulus);
        }
    }
}
﻿using System;
using System.Threading;

namespace NMetrics.Support
{
    class ThreadLocalRandom
    {
        private static readonly System.Random Seeder = new System.Random();
        private static readonly ThreadLocal<int> Seed;

        private static ThreadLocal<System.Random> _random;

        static ThreadLocalRandom()
        {
            lock (Seeder)
            {
                Seed = new ThreadLocal<int>(() => Seeder.Next());
            }
        }

        public static double NextNonzeroDouble()
        {
            EnsureInitialized();
            var r = _random.Value.NextDouble();
            return Math.Max(r, Double.Epsilon);
        }

        private static void EnsureInitialized()
        {
            if (_random == null)
            {
                _random = new ThreadLocal<System.Random>(() => new System.Random(Seed.Value));
            }
        }
    }
}

﻿using NMetrics.Support;

namespace NMetrics.Core
{
    /// <summary>
    /// A metric which calculates the distribution of a value
    /// <see href="http://www.johndcook.com/standard_deviation.html">Accurately computing running variance</see>
    /// </summary>
    public class Histogram : IMetric, ICounted
    {
        private readonly Reservoir reservoir;
        private readonly AtomicLong count;

        /// <summary>
        /// Creates a new <see cref="Histogram" /> with the given sample type
        /// </summary>
        /// <param name="reservoir">the reservoir to create a histogram from</param>
        public Histogram(Reservoir reservoir)
        {
            this.reservoir = reservoir;
            this.count = new AtomicLong(0);
        }
        /// <summary>
        /// Adds a recorded value
        /// </summary>
        /// <param name="value">the length of the value</param>
        public void Update(int value)
        {
            Update((long)value);
        }

        /// <summary>
        /// Adds a recorded value
        /// </summary>
        /// <param name="value">the length of the value</param>
        public void Update(long value)
        {
            count.IncrementAndGet();
            reservoir.Update(value);
        }

        /// <summary>
        /// Returns the number of values recorded
        /// </summary>
        public long Count { get { return count.Get(); } }

        /// <summary>
        /// Returns a snapshot of the reservoir's value
        /// </summary>
        public Snapshot Snapshot
        {
            get { return reservoir.Snapshot; }
        }
    }
}

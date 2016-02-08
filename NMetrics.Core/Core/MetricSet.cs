using System.Collections.Generic;

namespace NMetrics.Core
{
    /// <summary>
    /// A set of named metrics.
    /// <para />
    /// Used with <see cref="MetricRegistry.RegisterAll(MetricName, MetricSet)"/>
    /// </summary>
    public interface MetricSet : IMetric
    {
        /// <summary>
        /// A dictionary of metric names to metrics
        /// </summary>
        IDictionary<MetricName, IMetric> Metrics { get; }
    }
}

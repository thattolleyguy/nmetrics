namespace NMetrics.Core
{
    /// <summary>
    /// An object which samples values
    /// </summary>
    public interface ISampling
    {
        /// <summary>
        /// Returns a snapshot of the values
        /// </summary>
        Snapshot Snapshot { get; }
    }
}

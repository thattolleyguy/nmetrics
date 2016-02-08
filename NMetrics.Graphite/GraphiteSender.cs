using System;

namespace NMetrics.Reporting.Graphite
{
    public interface GraphiteSender : IDisposable
    {
        void Connect();

        void Send(string name, string value, long timestamp);

        void Flush();
        bool IsConnected { get; }
        int FailureCount { get; }

    }
}

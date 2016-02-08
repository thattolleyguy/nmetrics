using Ninject.Extensions.Interception.Request;
using NMetrics.Core;

namespace NMetrics.Ninject
{
    public static class Utils
    {
        public static MetricName BuildName(IProxyRequest request, string Name, bool Absolute)
        {
            MetricName metricName = null;
            if (Absolute)
                metricName = new MetricName(Name);
            else
                metricName = new MetricName(request.Target.GetType().FullName + "." + Name);
            return metricName;
        }
    }
}

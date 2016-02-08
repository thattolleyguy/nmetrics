using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Attributes;
using Ninject.Extensions.Interception.Request;
using NMetrics.Core;

namespace NMetrics.Ninject
{
    public class MeteredAttribute : InterceptAttribute
    {
        public string Name { get; set; }
        public string[] Tags { get; set; }
        public bool Absolute { get; set; }

        private Meter meter = null;

        public override IInterceptor CreateInterceptor(IProxyRequest request)
        {
            if (meter == null)
            {
                MetricName metricName = Utils.BuildName(request, Name, Absolute);
                MetricRegistry registry = request.Context.Kernel.Get<MetricRegistry>();
                meter = registry.Meter(metricName);
            }
            return new MeteringInterceptor(meter);
        }
    }

    public class MeteringInterceptor : IInterceptor
    {
        private readonly Meter meter;

        public MeteringInterceptor(Meter meter)
        {
            this.meter = meter;
        }

        public void Intercept(IInvocation invocation)
        {
            this.meter.Mark();
            invocation.Proceed();
        }
    }
}

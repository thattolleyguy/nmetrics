using NMetrics.Core;
using NUnit.Framework;

namespace NMetrics.Tests.Core
{
    class DerivativeGaugeTests
    {
        [Test]
        public void Can_derive()
        {
            int sum = 0;
            Gauge<int> baseGauge = new Gauge<int>(() => 1);
            DerivativeGauge<int, int> derivativeGauge = new DerivativeGauge<int, int>(baseGauge,
                (x) =>
                { sum += x; return sum; }
                );
            Assert.AreEqual(1, derivativeGauge.Value);
            Assert.AreEqual(2, derivativeGauge.Value);
            Assert.AreEqual(3, derivativeGauge.Value);
            Assert.AreEqual(4, derivativeGauge.Value);
            Assert.AreEqual(4, sum);

        }
    }
}

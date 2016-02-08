﻿using NMetrics.Core;
using NUnit.Framework;
using System.Collections.Generic;

namespace NMetrics.Tests.Core
{
    [TestFixture]
    public class GaugeTests : MetricTestBase
    {
        [Test]
        public void Can_gauge_scalar_value()
        {
            var queue = new Queue<int>();
            var gauge = new Gauge<int>(() => queue.Count);

            queue.Enqueue(5);
            Assert.AreEqual(1, gauge.Value);

            queue.Enqueue(6);
            queue.Dequeue();
            Assert.AreEqual(1, gauge.Value);

            queue.Dequeue();
            Assert.AreEqual(0, gauge.Value);
        }

        [Test]
        public static void Can_use_gauge_metric()
        {
            var queue = new Queue<int>();
            var metrics = new MetricRegistry();
            var gauge = metrics.Gauge("GaugeTests", () => queue.Count);
            queue.Enqueue(5);
            Assert.AreEqual(1, gauge.Value);
        }
    }
}

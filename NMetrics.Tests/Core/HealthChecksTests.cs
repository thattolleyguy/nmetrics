﻿using NMetrics.Health;
using NUnit.Framework;

namespace NMetrics.Tests.Core
{
    [TestFixture]
    public class HealthChecksTests
    {
        [Test]
        public void Correctly_Report_When_There_Are_HealthChecks()
        {
            HealthCheckRegistry registry = new HealthCheckRegistry();
            registry.Register("test-health-check", new HealthCheck(() => HealthCheck.Result.Healthy()));
            Assert.That(registry.HasHealthChecks, Is.True);
        }
    }
}

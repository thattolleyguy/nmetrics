﻿using NMetrics.Core;
using System;
using System.Collections.Generic;

namespace NMetrics.Util
{
    public static class Serializer
    {
        public static Func<IEnumerable<CLRProfiler.ThreadInfo>, string> SerializeThreads = o => o.ToString();

       /* public static Func<IDictionary<MetricName, IMetric>, string> Serialize = metrics =>
        {
            var sb = new StringBuilder("[");

            foreach (var metric in metrics)
            {
                sb.Append("{\"name\":\"");
                sb.Append(metric.Key.Key).Append("\",\"metric\":");
                metric.Value.LogJson(sb);
                sb.Append("},");
            }

            if (metrics.Count > 0)
                sb.Remove(sb.Length - 1, 1);

            sb.Append("]");

            return sb.ToString();
        };*/

    }
}
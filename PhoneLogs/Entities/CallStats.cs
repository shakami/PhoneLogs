using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneLogs
{
    public class CallStats
    {
        public TimeSpan Duration { get; set; }
        public int TotalCalls { get; set; }

        public static CallStats GetStats(IEnumerable<Call> calls)
        {
            return new CallStats()
            {
                TotalCalls = calls.Count(),
                Duration = calls
                    .Aggregate(TimeSpan.Zero,
                                (runningSum, next) => runningSum + next.CallLength),
            };
        }
    }
}

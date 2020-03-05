using System.Collections.Generic;

namespace PhoneLogs
{
    public class CallLog
    {
        public List<Call> CallsFrom { get; set; } = new List<Call>();
        public List<Call> CallsTo { get; set; } = new List<Call>();
        public CallStats Stats { get { return GetStats(); } }

        private CallStats GetStats()
        {
            var fromStats = CallStats.GetStats(CallsFrom);
            var toStats = CallStats.GetStats(CallsTo);
            return new CallStats()
            {
                Duration = toStats.Duration + fromStats.Duration,
                TotalCalls = toStats.TotalCalls + fromStats.TotalCalls
            };
        }
    }
}

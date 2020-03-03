using System;
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
            int totalCalls = 0;
            TimeSpan duration = TimeSpan.Zero;
            foreach (var call in CallsFrom)
            {
                totalCalls++;
                var values = call.CallLength.Split(':');
                if (values.Length == 3)
                {
                    int hr = int.Parse(values[0]);
                    int min = int.Parse(values[1]);
                    int sec = int.Parse(values[2]);

                    duration += new TimeSpan(hr, min, sec);
                }
            }
            foreach (var call in CallsTo)
            {
                totalCalls++;
                var values = call.CallLength.Split(':');
                if (values.Length == 3)
                {
                    int hr = int.Parse(values[0]);
                    int min = int.Parse(values[1]);
                    int sec = int.Parse(values[2]);

                    duration += new TimeSpan(hr, min, sec);
                }
            }

            return new CallStats()
            {
                Duration = duration,
                TotalCalls = totalCalls
            };
        }
    }
}

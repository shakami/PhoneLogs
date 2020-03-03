using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneLogs
{
    public class CallProcessingService
    {
        private readonly IEnumerable<Call> _calls;

        public CallProcessingService(List<Call> calls)
        {
            _calls = calls ?? throw new ArgumentNullException(nameof(calls));
        }

        public Dictionary<string, CallLog> GetCallsPerPerson()
        {
            return GetCallsPerPerson(null);
        }

        public Dictionary<string, CallLog> GetCallsPerPerson(List<String> employees)
        {
            var result = new Dictionary<string, CallLog>();

            var callsFrom = _calls
                .GroupBy(c => c.FromName)
                .Select(group => new { Employee = group.Key, CallsFrom = group.ToList() });

            var callsTo = _calls
                .GroupBy(c => c.ToName)
                .Select(group => new { Employee = group.Key, CallsTo = group.ToList() });

            if (employees != null)
            {
                callsFrom = callsFrom.Where(c => employees.Contains(c.Employee, StringComparer.OrdinalIgnoreCase));
                callsTo = callsTo.Where(c => employees.Contains(c.Employee, StringComparer.OrdinalIgnoreCase));
            }

            foreach (var item in callsFrom)
            {
                result.Add(item.Employee, new CallLog() { CallsFrom = item.CallsFrom });
            }

            foreach (var item in callsTo)
            {
                result.TryGetValue(item.Employee, out CallLog log);
                if (log == null)
                {
                    result.Add(item.Employee, new CallLog() { CallsTo = item.CallsTo });
                } else
                {
                    log.CallsTo = item.CallsTo;
                }
            }

            return result;
        }
    }
}

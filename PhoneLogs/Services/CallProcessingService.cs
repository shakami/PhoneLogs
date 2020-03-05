using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneLogs.Services
{
    public class CallProcessingService
    {
        private readonly IEnumerable<Call> _calls;

        public CallProcessingService(List<Call> calls)
        {
            _calls = calls ?? throw new ArgumentNullException(nameof(calls));
        }

        public Dictionary<string, CallStats> GetTotalStats(List<string> employees)
        {
            var filteredCalls = _calls;
            if (employees.Any())
            {
                filteredCalls = _calls
                    .Where(c => employees.Contains(c.ToName, StringComparer.OrdinalIgnoreCase) ||
                                employees.Contains(c.FromName, StringComparer.OrdinalIgnoreCase));
            }

            var queues = filteredCalls
                .Where(c => c.CallQueue != string.Empty)
                .GroupBy(c => c.CallQueue)
                .ToDictionary(q => q.Key, q => CallStats.GetStats(q));

            var result = queues;

            var totalStats = CallStats.GetStats(filteredCalls);
            result.Add("Total", totalStats);
            
            return result;
        }

        public Dictionary<string, CallLog> GetCallsPerPerson(List<string> employees)
        {
            var logs = new Dictionary<string, CallLog>(StringComparer.OrdinalIgnoreCase);

            if (employees.Any())
            {
                foreach (var employee in employees)
                {
                    logs.Add(employee, new CallLog());
                }
            }
            else
            {
                logs = _calls
                    .Select(c => c.FromName)
                    .Union(_calls.Select(c => c.ToName))
                    .Where(c => c != string.Empty)
                    .ToDictionary(x => x, x => new CallLog());
            }

            _calls
                .Where(c => logs.Keys.Contains(c.FromName, StringComparer.OrdinalIgnoreCase))
                .GroupBy(c => c.FromName)
                .Select(group => logs[group.Key].CallsFrom = group.OrderBy(c => c.StartTime).ToList()).ToList();

            _calls
                .Where(c => logs.Keys.Contains(c.ToName, StringComparer.OrdinalIgnoreCase))
                .GroupBy(c => c.ToName)
                .Select(group => logs[group.Key].CallsTo = group.OrderBy(c => c.StartTime).ToList()).ToList();

            var result = logs.OrderByDescending(x => x.Value.Stats.TotalCalls).ToDictionary(x => x.Key, x => x.Value);

            return result;
        }
    }
}

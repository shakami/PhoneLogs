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


        //public Dictionary<string, CallLog> GetCallsPerPerson(List<String> employees)
        //{
        //    var result = new Dictionary<string, CallLog>();

        //    var callsFrom = _calls
        //        .Where(c => !string.IsNullOrWhiteSpace(c.FromName))
        //        .GroupBy(c => c.FromName)
        //        .Select(group => new { Employee = group.Key, CallsFrom = group.OrderBy(c => c.StartTime) });

        //    var callsTo = _calls
        //        .Where(c => !string.IsNullOrWhiteSpace(c.ToName))
        //        .GroupBy(c => c.ToName)
        //        .Select(group => new { Employee = group.Key, CallsTo = group.OrderBy(c => c.StartTime) });

        //    if (employees.Any())
        //    {
        //        callsFrom = callsFrom.Where(c => employees.Contains(c.Employee, StringComparer.OrdinalIgnoreCase));
        //        callsTo = callsTo.Where(c => employees.Contains(c.Employee, StringComparer.OrdinalIgnoreCase));
        //    }

        //    foreach (var item in callsFrom)
        //    {
        //        result.Add(item.Employee, new CallLog() { CallsFrom = item.CallsFrom.ToList() });
        //    }

        //    foreach (var item in callsTo)
        //    {
        //        result.TryGetValue(item.Employee, out CallLog log);
        //        if (log == null)
        //        {
        //            result.Add(item.Employee, new CallLog() { CallsTo = item.CallsTo.ToList() });
        //        } else
        //        {
        //            log.CallsTo = item.CallsTo.ToList();
        //        }
        //    }

        //    return result;
        //}
    }
}

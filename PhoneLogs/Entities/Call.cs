using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneLogs
{
    public class Call
    {
        public Call(string sessionId,
                    string fromName,
                    string fromNumber,
                    string toName,
                    string toNumber,
                    string callResult,
                    string callLength,
                    string handleTime,
                    DateTime startTime,
                    string callDirection,
                    string callQueue)
        {
            SessionId = sessionId ?? throw new ArgumentNullException(nameof(sessionId));
            FromName = fromName ?? throw new ArgumentNullException(nameof(fromName));
            FromNumber = fromNumber ?? throw new ArgumentNullException(nameof(fromNumber));
            ToName = toName ?? throw new ArgumentNullException(nameof(toName));
            ToNumber = toNumber ?? throw new ArgumentNullException(nameof(toNumber));
            CallResult = callResult ?? throw new ArgumentNullException(nameof(callResult));
            CallLength = callLength ?? throw new ArgumentNullException(nameof(callLength));
            HandleTime = handleTime ?? throw new ArgumentNullException(nameof(handleTime));
            StartTime = startTime;
            CallDirection = callDirection ?? throw new ArgumentNullException(nameof(callDirection));
            CallQueue = callQueue ?? throw new ArgumentNullException(nameof(callQueue));
        }

        public string SessionId { get; }
        public string FromName { get; }
        public string FromNumber { get; }
        public string ToName { get; }
        public string ToNumber { get; }
        public string CallResult { get; }
        public string CallLength { get; }
        public string HandleTime { get; }
        public DateTime StartTime { get; }
        public string CallDirection { get; }
        public string CallQueue { get; }

        public override string ToString()
        {
            var output = "";
            output += "Session Id: " + SessionId + "\t";
            output += "Call From: " + FromName + "\t";
            output += "From Number: " + FromNumber + "\t";
            output += "Call To: " + ToName + "\t";
            output += "To Number: " + ToNumber + "\t";
            output += "Result: " + CallResult + "\t";
            output += "Call Length: " + CallLength + "\t";
            output += "Handle Time: " + HandleTime + "\t";
            output += "Start Time: " + StartTime + "\t";
            output += "Direction: " + CallDirection + "\t";
            output += "Queue: " + CallQueue + "\t";

            return output;
        }
    }
}

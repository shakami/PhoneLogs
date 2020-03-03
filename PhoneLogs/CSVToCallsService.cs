using System.Collections.Generic;
using System.IO;

namespace PhoneLogs
{
    public class CSVToCallsService
    {
        private readonly int _session_id_index;
        private readonly int _from_name_index;
        private readonly int _from_number_index;
        private readonly int _to_name_index;
        private readonly int _to_number_index;
        private readonly int _call_result_index;
        private readonly int _call_length_index;
        private readonly int _handle_time_index;
        private readonly int _start_time_index;
        private readonly int _call_direction_index;
        private readonly int _call_queue_index;

        public CSVToCallsService(int sessionIdColumn,
                                  int fromNameColumn,
                                  int fromNumberColumn,
                                  int toNameColumn,
                                  int toNumberColumn,
                                  int callResultColumn,
                                  int callLengthColumn,
                                  int handleTimeColumn,
                                  int startTimeColumn,
                                  int callDirectionColumn,
                                  int callQueueColumn)
        {
            _session_id_index = sessionIdColumn - 1;
            _from_name_index = fromNameColumn - 1;
            _from_number_index = fromNumberColumn - 1;
            _to_name_index = toNameColumn - 1;
            _to_number_index = toNumberColumn - 1;
            _call_result_index = callResultColumn - 1;
            _call_length_index = callLengthColumn - 1;
            _handle_time_index = handleTimeColumn - 1;
            _start_time_index = startTimeColumn - 1;
            _call_direction_index = callDirectionColumn - 1;
            _call_queue_index = callQueueColumn - 1;
        }

        public List<Call> ParseCSV(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);

            var calls = new List<Call>();

            // skip the header
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var values = line.Split(',');

                var call = new Call(values[_session_id_index],
                                    values[_from_name_index],
                                    values[_from_number_index],
                                    values[_to_name_index],
                                    values[_to_number_index],
                                    values[_call_result_index],
                                    values[_call_length_index],
                                    values[_handle_time_index],
                                    values[_start_time_index],
                                    values[_call_direction_index],
                                    values[_call_queue_index]);

                calls.Add(call);
            }
            return calls;
        }
    }
}

﻿using System.Collections.Generic;
using System.Collections.Specialized;

namespace Client
{
    public class ProtoBufReportService : Abstraction.IReportService
    {
        public List<T> Report<T>(string reportName, NameValueCollection reportParams)
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var result = ProtobufWebClient.Instance.Report(reportName, reportParams);
            sw.Stop();
            var msg = string.Format("report {0} {1:N0} ms {2:N0} bytes", reportName, sw.ElapsedMilliseconds, result.Length);
            System.Console.WriteLine(msg);
            return ProtobufWebClient.Instance.FromBytes<List<T>>(result);
        }
    }
}

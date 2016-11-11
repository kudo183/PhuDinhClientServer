using System.Collections.Generic;
using System.Collections.Specialized;

namespace Client
{
    public class ProtoBufReportService : Abstraction.IReportService
    {
        public List<T> Report<T>(string reportName, NameValueCollection reportParams)
        {
            var result = ProtobufWebClient.Instance.Report(reportName, reportParams);
            return ProtobufWebClient.Instance.FromBytes<List<T>>(result);
        }
    }
}

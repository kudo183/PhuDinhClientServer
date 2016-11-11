using System.Collections.Generic;
using System.Collections.Specialized;

namespace Client.Abstraction
{
    public interface IReportService
    {
        List<T> Report<T>(string reportName, NameValueCollection reportParams);
    }
}

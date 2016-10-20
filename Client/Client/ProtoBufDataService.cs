using System.Collections.Generic;
using DTO;
using QueryBuilder;
using Client.Abstraction;

namespace Client
{
    public class ProtoBufDataService<T> : IDataService<T> where T : DTO.IDto
    {
        private static long VersionNumber = -1;
        private static byte[] Data;

        private string _controller;

        public ProtoBufDataService()
        {
            _controller = NameManager.Instance.GetControllerName<T>();
        }

        public PagingResultDto<T> Get(QueryExpression qe)
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            string isChanged = "";
            qe.VersionNumber = VersionNumber;
            var bytesResult = ProtobufWebClient.Instance.Post<T>(_controller, "get", qe);
            var result = ProtobufWebClient.Instance.FromBytes<PagingResultDto<T>>(bytesResult);

            if (VersionNumber != result.VersionNumber)
            {
                VersionNumber = result.VersionNumber;
                Data = bytesResult;
                isChanged = "changed ";
            }

            var pagingResult = ProtobufWebClient.Instance.FromBytes<PagingResultDto<T>>(Data);
            foreach (var item in pagingResult.Items)
            {
                item.SetCurrentValueAsOriginalValue();
            }
            sw.Stop();
            var msg = string.Format("{0} get {1} ms {2}{3}", _controller, sw.ElapsedMilliseconds, isChanged, VersionNumber);
            System.Console.WriteLine(msg);
            return pagingResult;
        }

        public string Save(List<ChangedItem<T>> changedItems)
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var result = ProtobufWebClient.Instance.Save(_controller, "save", changedItems);
            System.Console.WriteLine(_controller + " " + "save " + sw.ElapsedMilliseconds + "ms");
            return result;
        }
    }
}

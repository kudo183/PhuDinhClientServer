using System.Collections.Generic;
using DTO;
using QueryBuilder;
using Client.Abstraction;

namespace Client
{
    public class ProtoBufDataService<T> : IDataService<T> where T : DTO.IDto
    {
        class CacheData
        {
            //use this VersionNumber instead of QueryExpression.VersionNumber because QueryExpression.VersionNumver will change
            public long VersionNumber = 0;
            public byte[] Data;
        }

        private static Dictionary<QueryExpression, CacheData> _cache = new Dictionary<QueryExpression, CacheData>();

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

            CacheData cache = null;
            qe.VersionNumber = 0;//keep qe.VersionNumber always 0 for equality
            if (_cache.TryGetValue(qe, out cache) == false)
            {
                cache = new CacheData();
                _cache.Add(qe, cache);
            }

            qe.VersionNumber = cache.VersionNumber;
            var bytesResult = ProtobufWebClient.Instance.Post<T>(_controller, "get", qe);
            qe.VersionNumber = 0;//keep qe.VersionNumber always 0

            var result = ProtobufWebClient.Instance.FromBytes<PagingResultDto<T>>(bytesResult);

            if (cache.VersionNumber != result.VersionNumber)
            {
                cache.VersionNumber = result.VersionNumber;
                cache.Data = bytesResult;
                isChanged = "*******changed";
            }
            else
            {
                result = ProtobufWebClient.Instance.FromBytes<PagingResultDto<T>>(cache.Data);
            }

            if (string.IsNullOrEmpty(result.ErrorMsg) == false)
            {
                System.Console.WriteLine(string.Format("Error get: ({0}) {1} ", _controller, result.ErrorMsg));
            }

            foreach (var item in result.Items)
            {
                item.SetCurrentValueAsOriginalValue();
            }
            sw.Stop();
            var msg = string.Format("{0} get {1:N0} ms {2:N0} bytes {3} {4}", _controller, sw.ElapsedMilliseconds, cache.Data.Length, cache.VersionNumber, isChanged);
            System.Console.WriteLine(msg);
            return result;
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

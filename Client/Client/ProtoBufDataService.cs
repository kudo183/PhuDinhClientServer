using System.Collections.Generic;
using DTO;
using QueryBuilder;
using Client.Abstraction;

namespace Client
{
    public class ProtoBufDataService<T> : IDataService<T> where T : DTO.IDto
    {
        private string _controller;

        public ProtoBufDataService()
        {
            _controller = NameManager.Instance.GetControllerName<T>();
        }

        public PagingResultDto<T> Get(QueryExpression qe)
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            
            var bytesResult = ProtobufWebClient.Instance.Post<T>(_controller, "get", qe);
            
            var result = ProtobufWebClient.Instance.FromBytes<PagingResultDto<T>>(bytesResult);
            
            if (string.IsNullOrEmpty(result.ErrorMsg) == false)
            {
                Logger.Instance.Error(string.Format("Error get: ({0}) {1} ", _controller, result.ErrorMsg), Logger.Categories.Data);
            }

            foreach (var item in result.Items)
            {
                item.SetCurrentValueAsOriginalValue();
            }
            sw.Stop();
            return result;
        }

        public string Save(List<ChangedItem<T>> changedItems)
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var result = ProtobufWebClient.Instance.Save(_controller, "save", changedItems);
            Logger.Instance.Info(_controller + " " + "save " + sw.ElapsedMilliseconds + "ms", Logger.Categories.Data);
            return result;
        }
    }
}

using System.Collections.Generic;
using DTO;
using QueryBuilder;

namespace Client
{
    public class ProtoBufDataService<T> : Abstraction.IDataService<T> where T : DTO.IDto
    {
        private string _controller;
        public ProtoBufDataService(string controller)
        {
            _controller = controller;
        }

        public PagingResultDto<T> Get(QueryExpression qe)
        {
            return ProtobufWebClient.Instance.Post<T>(_controller, "get", qe);
        }

        public string Save(List<ChangedItem<T>> changedItems)
        {
            return ProtobufWebClient.Instance.Save(_controller, "save", changedItems);
        }
    }
}

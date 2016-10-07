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
            System.Console.WriteLine(_controller + " " + "get");
            return ProtobufWebClient.Instance.Post<T>(_controller, "get", qe);
        }

        public string Save(List<ChangedItem<T>> changedItems)
        {
            System.Console.WriteLine(_controller + " " + "save");
            return ProtobufWebClient.Instance.Save(_controller, "save", changedItems);
        }
    }
}

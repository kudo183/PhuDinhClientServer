using System.Collections.Generic;

namespace Client.Abstraction
{
    public interface IDataService<T> where T : DTO.IDto
    {
        DTO.PagingResultDto<T> Get(QueryBuilder.QueryExpression qe);
        string Save(List<DTO.ChangedItem<T>> changedItems);
    }
}

using SimpleDataGrid;
using System.Collections.Generic;

namespace Client.Abstraction
{
    public sealed class ReferenceDataManager<T> where T : DTO.IDto
    {
        private static readonly ReferenceDataManager<T> _instance = new ReferenceDataManager<T>();

        public static ReferenceDataManager<T> Instance
        {
            get { return _instance; }
        }

        private IDataService<T> _dataService = ServiceLocator.Instance.GetInstance<IDataService<T>>();
        public IDataService<T> DataService
        {
            get
            {
                return _dataService;
            }
            private set { }
        }

        private readonly ObservableCollectionEx<T> _datas
            = new ObservableCollectionEx<T>();

        public void Load()
        {
            var qe = new QueryBuilder.QueryExpression();
            qe.PageIndex = 0;

            _datas.Reset(DataService.Get(qe).Items);
        }

        public ObservableCollectionEx<T> Get(bool forceReload = false)
        {
            if (forceReload)
            {
                Load();
            }
            return _datas;
        }

        public void Reset(IEnumerable<T> data)
        {
            _datas.Reset(data);
        }
    }
}

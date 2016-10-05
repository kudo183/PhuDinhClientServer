using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SimpleDataGrid.ViewModel;
using System.Linq;

namespace Client.Abstraction
{
    public abstract class BaseViewModel<T> : IBaseViewModel<T> where T : class, DTO.IDto
    {
        protected string _debugName;

        protected readonly List<T> _originalEntities = new List<T>();

        private IDataService<T> _dataService { get; set; }

        public BaseViewModel(string debugName, IDataService<T> dataService)
        {
            _debugName = debugName;
            _dataService = dataService;

            Entities = new ObservableCollection<T>();
            HeaderFilters = new List<HeaderFilterBaseModel>();
            PagerViewModel = new PagerViewModel()
            {
                IsEnablePaging = true,
                CurrentPageIndex = 0,
                ItemCount = 0,
                PageCount = 0
            };

            PagerViewModel.ActionCurrentPageIndexChanged = Load;
            PagerViewModel.ActionIsEnablePagingChanged = Load;
        }

        protected virtual void ProcessDtoBeforeAddToEntities(T dto)
        {

        }

        protected virtual void ProcessNewAddedDto(T dto)
        {

        }

        #region IBaseViewModel interface
        public bool IsValid { get; set; }

        public ObservableCollection<T> Entities { get; set; }

        public List<HeaderFilterBaseModel> HeaderFilters { get; set; }

        public PagerViewModel PagerViewModel { get; set; }

        public void Load()
        {
            Entities.Clear();
            Entities.CollectionChanged -= Entities_CollectionChanged;
            _originalEntities.Clear();

            DTO.PagingResultDto<T> result;

            var qe = new QueryBuilder.QueryExpression();
            qe.PageIndex = PagerViewModel.IsEnablePaging ? PagerViewModel.CurrentPageIndex : 0;

            qe.WhereOptions = FromHeaderFilter(HeaderFilters);

            qe.OrderOptions.Add(new QueryBuilder.OrderByExpression.OrderOption()
            {
                IsAscending = true,
                PropertyPath = "Ma"
            });

            result = _dataService.Get(qe);

            foreach (var dto in result.Items)
            {
                ProcessDtoBeforeAddToEntities(dto);
                Entities.Add(dto);
                _originalEntities.Add(dto);
            }

            PagerViewModel.ItemCount = Entities.Count;
            PagerViewModel.PageCount = result.PageCount;

            Entities.CollectionChanged += Entities_CollectionChanged;
        }

        private void Entities_CollectionChanged(
            object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                ProcessNewAddedDto(e.NewItems[0] as T);
            }
        }

        public void Save()
        {
            var changedItems = new List<DTO.ChangedItem<T>>();

            foreach (var entity in _originalEntities)
            {
                if (Entities.Any(p => p.Ma == entity.Ma) == false)
                {
                    changedItems.Add(new DTO.ChangedItem<T>()
                    {
                        State = DTO.ChangeState.Delete,
                        Data = entity
                    });
                }
            }

            foreach (var entity in Entities)
            {
                if (entity.Ma == 0)
                {
                    changedItems.Add(new DTO.ChangedItem<T>()
                    {
                        State = DTO.ChangeState.Add,
                        Data = entity
                    });
                }
                else if (entity.HasChange())
                {
                    changedItems.Add(new DTO.ChangedItem<T>()
                    {
                        State = DTO.ChangeState.Update,
                        Data = entity
                    });
                }
            }

            var response = _dataService.Save(changedItems);

            Load();
        }
        #endregion

        private List<QueryBuilder.WhereExpression.WhereOption> FromHeaderFilter(
            List<HeaderFilterBaseModel> headerFilters)
        {
            var result = new List<QueryBuilder.WhereExpression.WhereOption>();

            foreach (var filter in headerFilters)
            {
                if (filter.IsUsed == true && filter.FilterValue != null)
                {
                    if (filter.PropertyType == typeof(string))
                    {
                        result.Add(new QueryBuilder.WhereExpression.WhereOptionString()
                        {
                            Predicate = "=",
                            PropertyPath = filter.PropertyName,
                            Value = (string)filter.FilterValue
                        });
                    }
                    else if (filter.PropertyType == typeof(int))
                    {
                        result.Add(new QueryBuilder.WhereExpression.WhereOptionInt()
                        {
                            Predicate = "=",
                            PropertyPath = filter.PropertyName,
                            Value = int.Parse(filter.FilterValue.ToString())
                        });
                    }
                    else if (filter.PropertyType == typeof(bool))
                    {
                        result.Add(new QueryBuilder.WhereExpression.WhereOptionBool()
                        {
                            Predicate = "=",
                            PropertyPath = filter.PropertyName,
                            Value = (bool)filter.FilterValue
                        });
                    }
                }
            }

            return result;
        }
    }
}

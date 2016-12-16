using System;
using System.Collections.Generic;
using SimpleDataGrid.ViewModel;
using System.Linq;
using System.Windows;
using SimpleDataGrid;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.Abstraction
{
    public abstract class BaseViewModel<T> : IBaseViewModel, IEditableGridViewModel<T> where T : class, DTO.IDto
    {
        protected string _debugName;

        protected readonly List<T> _originalEntities = new List<T>();

        private IDataService<T> _dataService;
        public IDataService<T> DataService
        {
            get
            {
                if (_dataService == null)
                {
                    _dataService = ServiceLocator.Instance.GetInstance<IDataService<T>>();
                }
                return _dataService;
            }
            private set { }
        }

        public BaseViewModel()
        {
            _debugName = NameManager.Instance.GetViewModelName<T>();

            LoadReferenceData();

            OrderOptions = new List<QueryBuilder.OrderByExpression.OrderOption>();
            Entities = new ObservableCollectionEx<T>();
            Entities.CollectionChanged += Entities_CollectionChanged;
            HeaderFilters = new List<HeaderFilterBaseModel>();
            PagerViewModel = new PagerViewModel()
            {
                IsEnablePaging = true,
                CurrentPageIndex = 1,
                ItemCount = 0,
                PageCount = 0
            };

            PagerViewModel.ActionCurrentPageIndexChanged = Load;
            PagerViewModel.ActionIsEnablePagingChanged = Load;

            SelectedValuePath = nameof(DTO.IDto.ID);
        }

        protected void AddHeaderFilter(HeaderFilterBaseModel filter)
        {
            HeaderFilters.Add(filter);
            filter.ActionFilterValueChanged = Load;
            filter.ActionIsUsedChanged = Load;
        }

        protected virtual void ProccessHeaderAddCommand(object view, string title, Action AfterCloseDialogAction)
        {
            var w = new Window()
            {
                Title = title,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Content = view
            };
            w.ShowDialog();

            if (AfterCloseDialogAction != null)
            {
                AfterCloseDialogAction();
            }
        }

        protected virtual void ProcessDtoBeforeAddToEntities(T dto)
        {

        }

        protected virtual void ProcessNewAddedDto(T dto)
        {

        }

        protected virtual void BeforeLoad()
        {

        }

        protected virtual void AfterLoad()
        {

        }

        #region IBaseViewModel interface
        public bool IsValid { get; set; }

        public ObservableCollectionEx<T> Entities { get; set; }

        public object ParentItem { get; set; }

        private string msg;

        public string Msg
        {
            get { return msg; }
            set
            {
                if (msg == value)
                    return;

                msg = value;
                OnPropertyChanged();
            }
        }


        public string SelectedValuePath { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private object _selectedValue;

        public object SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                if (_selectedValue == value)
                {
                    return;
                }

                _selectedValue = value;

                ActionSelectedValueChanged?.Invoke(_selectedValue);
            }
        }

        private object _selectedItem;

        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem == value)
                {
                    return;
                }

                _selectedItem = value;
            }
        }

        public Action<object> ActionSelectedValueChanged { get; set; }

        public List<HeaderFilterBaseModel> HeaderFilters { get; set; }

        public PagerViewModel PagerViewModel { get; set; }

        public List<QueryBuilder.OrderByExpression.OrderOption> OrderOptions { get; set; }

        public SimpleCommand LoadCommand { get; set; }

        public SimpleCommand SaveCommand { get; set; }

        public void Load()
        {
            Console.WriteLine(_debugName + " BaseViewModel Load");

            BeforeLoad();

            DTO.PagingResultDto<T> result;

            var qe = new QueryBuilder.QueryExpression();
            qe.PageIndex = PagerViewModel.IsEnablePaging ? PagerViewModel.CurrentPageIndex : 0;

            qe.WhereOptions = FromHeaderFilter(HeaderFilters);
            qe.OrderOptions = OrderOptions;
            if (qe.OrderOptions.Count == 0)
            {
                qe.AddOrderByOption("Ma", true);
            }
            result = DataService.Get(qe);

            _originalEntities.Clear();

            foreach (var dto in result.Items)
            {
                ProcessDtoBeforeAddToEntities(dto);
                _originalEntities.Add(dto);
            }

            Entities.Reset(result.Items);

            PagerViewModel.ItemCount = Entities.Count;
            PagerViewModel.PageCount = result.PageCount;

            AfterLoad();
        }

        public void Save()
        {
            var changedItems = new List<DTO.ChangedItem<T>>();

            foreach (var entity in _originalEntities)
            {
                if (Entities.Any(p => p.ID == entity.ID) == false)
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
                if (entity.ID == 0)
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

            if (changedItems.Count == 0)
            {
                return;
            }

            var response = DataService.Save(changedItems);

            Load();
        }

        public virtual void LoadReferenceData()
        {
        }

        private void Entities_CollectionChanged(
            object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                ProcessNewAddedDto(e.NewItems[0] as T);
            }
        }
        #endregion

        private List<QueryBuilder.WhereExpression.IWhereOption> FromHeaderFilter(
            List<HeaderFilterBaseModel> headerFilters)
        {
            var result = new List<QueryBuilder.WhereExpression.IWhereOption>();

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
                    else if (filter.PropertyType == typeof(int?))
                    {
                        result.Add(new QueryBuilder.WhereExpression.WhereOptionNullableInt()
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
                    else if (filter.PropertyType == typeof(bool?))
                    {
                        result.Add(new QueryBuilder.WhereExpression.WhereOptionNullableBool()
                        {
                            Predicate = "=",
                            PropertyPath = filter.PropertyName,
                            Value = (bool?)filter.FilterValue
                        });
                    }
                    else if (filter.PropertyType == typeof(DateTime))
                    {
                        result.Add(new QueryBuilder.WhereExpression.WhereOptionDate()
                        {
                            Predicate = "=",
                            PropertyPath = filter.PropertyName,
                            Value = (DateTime)filter.FilterValue
                        });
                    }
                    else if (filter.PropertyType == typeof(DateTime?))
                    {
                        result.Add(new QueryBuilder.WhereExpression.WhereOptionNullableDate()
                        {
                            Predicate = "=",
                            PropertyPath = filter.PropertyName,
                            Value = (DateTime?)filter.FilterValue
                        });
                    }
                    else if (filter.PropertyType == typeof(TimeSpan))
                    {
                        result.Add(new QueryBuilder.WhereExpression.WhereOptionTime()
                        {
                            Predicate = "=",
                            PropertyPath = filter.PropertyName,
                            Value = (TimeSpan)filter.FilterValue
                        });
                    }
                    else if (filter.PropertyType == typeof(TimeSpan?))
                    {
                        result.Add(new QueryBuilder.WhereExpression.WhereOptionNullableTime()
                        {
                            Predicate = "=",
                            PropertyPath = filter.PropertyName,
                            Value = (TimeSpan?)filter.FilterValue
                        });
                    }
                }
            }

            return result;
        }
    }
}

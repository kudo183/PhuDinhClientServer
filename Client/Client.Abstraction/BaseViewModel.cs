using System;
using System.Collections.Generic;
using SimpleDataGrid.ViewModel;
using System.Linq;
using System.Windows;
using SimpleDataGrid;
using System.ComponentModel;

namespace Client.Abstraction
{
    public abstract class BaseViewModel<T> : IBaseViewModel, IEditableGridViewModel<T>, INotifyPropertyChanged where T : class, DTO.IDto
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

            Entities = new ObservableCollectionEx<T>();
            Entities.CollectionChanged += Entities_CollectionChanged;
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

            SelectedValuePath = nameof(DTO.IDto.Ma);
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

        protected virtual void LoadedData(DTO.PagingResultDto<T> data)
        {

        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        #region IBaseViewModel interface
        public bool IsValid { get; set; }

        public ObservableCollectionEx<T> Entities { get; set; }

        private int _selectedIndex = -1;

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (_selectedIndex == value)
                {
                    return;
                }

                _selectedIndex = value;

                if (ActionSelectedIndexChanged != null && Entities.IsResetting == false)
                {
                    ActionSelectedIndexChanged(_selectedIndex);
                }

                OnPropertyChanged(nameof(SelectedIndex));
            }
        }

        public Action<int> ActionSelectedIndexChanged { get; set; }

        public List<HeaderFilterBaseModel> HeaderFilters { get; set; }

        public PagerViewModel PagerViewModel { get; set; }

        public string SelectedValuePath { get; set; }

        public SimpleCommand LoadCommand { get; set; }

        public SimpleCommand SaveCommand { get; set; }

        public void Load()
        {
            Console.WriteLine(_debugName + " BaseViewModel Load");

            DTO.PagingResultDto<T> result;

            var qe = new QueryBuilder.QueryExpression();
            qe.PageIndex = PagerViewModel.IsEnablePaging ? PagerViewModel.CurrentPageIndex : 0;

            qe.WhereOptions = FromHeaderFilter(HeaderFilters);

            qe.OrderOptions.Add(new QueryBuilder.OrderByExpression.OrderOption()
            {
                IsAscending = true,
                PropertyPath = "Ma"
            });

            result = DataService.Get(qe);
            LoadedData(result);

            _originalEntities.Clear();

            foreach (var dto in result.Items)
            {
                ProcessDtoBeforeAddToEntities(dto);
                _originalEntities.Add(dto);
            }

            var selectedIndex = SelectedIndex;
            Entities.Reset(result.Items);
            SelectedIndex = selectedIndex;

            PagerViewModel.ItemCount = Entities.Count;
            PagerViewModel.PageCount = result.PageCount;
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

            if (changedItems.Count == 0)
            {
                return;
            }

            var response = DataService.Save(changedItems);

            Load();
        }

        public IReadOnlyList<T1> GetEntities<T1>()
        {
            return Entities as IReadOnlyList<T1>;
        }

        private void Entities_CollectionChanged(
            object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Entities.IsResetting == true)
            {
                return;
            }

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                ProcessNewAddedDto(e.NewItems[0] as T);
            }
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
                    else if (filter.PropertyType == typeof(DateTime))
                    {
                        result.Add(new QueryBuilder.WhereExpression.WhereOptionDate()
                        {
                            Predicate = "=",
                            PropertyPath = filter.PropertyName,
                            Value = (DateTime)filter.FilterValue
                        });
                    }
                }
            }

            return result;
        }
    }
}

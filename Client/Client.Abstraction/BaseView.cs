using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Client.Abstraction
{
    public class BaseView<T> : UserControl, IBaseView where T : class, DTO.IDto
    {
        protected string _debugName;
        
        public Action ActionAfterSave { get; set; }
        public Action ActionAfterLoad { get; set; }
        public Action ActionMoveFocusToNextView { get; set; }

        public EditableGridView GridView { get; set; }
        public IEditableGridViewModel ViewModel { get; set; }

        private IViewModelFactory _viewModelFactory;
        public IViewModelFactory ViewModelFactory
        {
            get
            {
                if (_viewModelFactory == null)
                {
                    _viewModelFactory = ServiceLocator.Instance.GetInstance<IViewModelFactory>();
                }
                return _viewModelFactory;
            }
            private set { }
        }

        private bool _isDesignTime;
        public BaseView()
        {
            _debugName = NameManager.Instance.GetViewName<T>();
            _isDesignTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());
            if (_isDesignTime == true)
            {
                return;
            }

            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        public void InitView()
        {
            if (_isDesignTime == true)
            {
                return;
            }

            GridView = Content as EditableGridView;
            var viewModelObject = ViewModelFactory.CreateViewModel<T>();
            ViewModel = viewModelObject as IEditableGridViewModel<T>;

            ViewModel.SaveCommand = new SimpleCommand("SaveCommand", () =>
            {
                Logger.Instance.Info(_debugName + " Save", Logger.Categories.Data);
                GridView.dataGrid.CommitEdit(DataGridEditingUnit.Row, true);
                ViewModel.Save();
                ActionAfterSave?.Invoke();
            });

            ViewModel.LoadCommand = new SimpleCommand("LoadCommand", () =>
            {
                Logger.Instance.Info(_debugName + " Load", Logger.Categories.Data);
                GridView.dataGrid.CommitEdit(DataGridEditingUnit.Row, true);
                ViewModel.Load();
                ActionAfterLoad?.Invoke();
            });

            DataContext = ViewModel;

            for (int i = 0; i < ViewModel.HeaderFilters.Count; i++)
            {
                foreach (var column in GridView.Columns)
                {
                    if (column.Header.ToString() == ViewModel.HeaderFilters[i].PropertyName)
                    {
                        column.Header = ViewModel.HeaderFilters[i];
                        break;
                    }
                }
            }
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F3:
                    ViewModel.SaveCommand.Execute(null);
                    break;
                case Key.F4:
                    ViewModel.SaveCommand.Execute(null);
                    ActionMoveFocusToNextView?.Invoke();
                    break;
                case Key.F5:
                    ViewModel.LoadCommand.Execute(null);
                    break;
                default:
                    base.OnPreviewKeyDown(e);
                    break;
            }
        }

        protected override void OnInitialized(EventArgs e)
        {
            Logger.Instance.Debug(_debugName + " OnInitialized", Logger.Categories.UI);
            InitView();
            base.OnInitialized(e);
        }

        public virtual void OnUnloaded(object sender, RoutedEventArgs e)
        {
            Logger.Instance.Debug(_debugName + " Unloaded", Logger.Categories.UI);
        }

        public virtual void OnLoaded(object sender, RoutedEventArgs e)
        {
            Logger.Instance.Debug(_debugName + " Loaded", Logger.Categories.UI);

            ViewModel.Load();
        }
    }
}

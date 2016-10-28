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

        public IBaseViewModel ViewModel { get; set; }

        public event EventHandler AfterSave;
        public event EventHandler AfterCancel;
        public Action ActionMoveFocusToNextView { get; set; }

        public EditableGridView GridView { get; set; }
        private IEditableGridViewModel<T> _viewModel;

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
            _viewModel = viewModelObject as IEditableGridViewModel<T>;
            ViewModel = viewModelObject as IBaseViewModel;

            _viewModel.SaveCommand = new SimpleCommand("SaveCommand", () =>
            {
                Console.WriteLine(_debugName + "Save");
                GridView.dataGrid.CommitEdit(DataGridEditingUnit.Row, true);
                ViewModel.Save();
                if (AfterSave != null)
                {
                    AfterSave(this, null);
                }
            });

            _viewModel.LoadCommand = new SimpleCommand("LoadCommand", () =>
            {
                Console.WriteLine(_debugName + "Load");
                GridView.dataGrid.CommitEdit(DataGridEditingUnit.Row, true);
                ViewModel.Load();
                ViewModel.LoadReferenceData();
                if (AfterCancel != null)
                {
                    AfterCancel(this, null);
                }
            });

            DataContext = ViewModel;

            for (int i = 0; i < ViewModel.HeaderFilters.Count; i++)
            {
                foreach (var column in GridView.Columns)
                {
                    if(column.Header.ToString() == ViewModel.HeaderFilters[i].PropertyName)
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
                    _viewModel.SaveCommand.Execute(null);
                    break;
                case Key.F4:
                    _viewModel.SaveCommand.Execute(null);
                    if (ActionMoveFocusToNextView != null)
                    {
                        ActionMoveFocusToNextView();
                    }
                    break;
                case Key.F5:
                    _viewModel.LoadCommand.Execute(null);
                    break;
                default:
                    base.OnPreviewKeyDown(e);
                    break;
            }
        }

        protected override void OnInitialized(EventArgs e)
        {
            Console.WriteLine(_debugName + " OnInitialized");
            InitView();
            base.OnInitialized(e);
        }

        public virtual void OnUnloaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(_debugName + " Unloaded");
        }

        public virtual void OnLoaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(_debugName + " Loaded");

            ViewModel.Load();
        }
    }
}

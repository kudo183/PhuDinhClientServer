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
        private object _viewModel;

        public BaseView()
        {
            _debugName = NameManager.Instance.GetViewName<T>();
            var designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());
            if (designTime == true)
            {
                return;
            }

            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        public void InitView(BaseViewModel<T> viewModel, EditableGridView gridView)
        {
            GridView = gridView;
            _viewModel = viewModel;
            ViewModel = viewModel;

            viewModel.SaveCommand = new SimpleCommand("SaveCommand", () =>
            {
                Console.WriteLine(_debugName + "Save");
                GridView.dataGrid.CommitEdit(DataGridEditingUnit.Row, true);
                viewModel.Save();
                if (AfterSave != null)
                {
                    AfterSave(this, null);
                }
            });

            viewModel.LoadCommand = new SimpleCommand("LoadCommand", () =>
            {
                Console.WriteLine(_debugName + "Load");
                GridView.dataGrid.CommitEdit(DataGridEditingUnit.Row, true);
                viewModel.Load();
                if (AfterCancel != null)
                {
                    AfterCancel(this, null);
                }
            });

            DataContext = ViewModel;

            for (int i = 0; i < ViewModel.HeaderFilters.Count; i++)
            {
                GridView.Columns[i].Header = ViewModel.HeaderFilters[i];
            }
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F3:
                    (_viewModel as IEditableGridViewModel<T>).SaveCommand.Execute(null);
                    break;
                case Key.F4:
                    (_viewModel as IEditableGridViewModel<T>).SaveCommand.Execute(null);
                    if (ActionMoveFocusToNextView != null)
                    {
                        ActionMoveFocusToNextView();
                    }
                    break;
                case Key.F5:
                    (_viewModel as IEditableGridViewModel<T>).LoadCommand.Execute(null);
                    break;
                default:
                    base.OnPreviewKeyDown(e);
                    break;
            }
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

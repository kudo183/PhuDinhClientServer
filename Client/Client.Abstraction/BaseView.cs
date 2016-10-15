using SimpleDataGrid;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Client.Abstraction
{
    public class BaseView<T> : UserControl, IBaseView where T : class, DTO.IDto
    {
        protected string _debugName;

        public BaseViewModel<T> ViewModel { get; set; }
        protected EditableGridView _gridView;

        public event EventHandler AfterSave;
        public event EventHandler AfterCancel;
        public event EventHandler MoveFocusToNextView;
        public event SelectionChangedEventHandler SelectionChanged;

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
            _gridView = gridView;

            ViewModel = viewModel;

            ViewModel.SaveCommand = new SimpleCommand("SaveCommand", () =>
            {
                Console.WriteLine(_debugName + "Save");
                _gridView.dataGrid.CommitEdit(DataGridEditingUnit.Row, true);
                viewModel.Save();
                if (AfterSave != null)
                {
                    AfterSave(this, null);
                }
            });

            ViewModel.LoadCommand = new SimpleCommand("LoadCommand", () =>
            {
                Console.WriteLine(_debugName + "Load");
                _gridView.dataGrid.CommitEdit(DataGridEditingUnit.Row, true);
                viewModel.Load();
                if (AfterCancel != null)
                {
                    AfterCancel(this, null);
                }
            });

            InputBindings.Add(new KeyBinding(ViewModel.SaveCommand, new KeyGesture(Key.F3)));
            InputBindings.Add(new KeyBinding(ViewModel.LoadCommand, new KeyGesture(Key.F5)));

            DataContext = ViewModel;

            for (int i = 0; i < ViewModel.HeaderFilters.Count; i++)
            {
                _gridView.Columns[i].Header = ViewModel.HeaderFilters[i];
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

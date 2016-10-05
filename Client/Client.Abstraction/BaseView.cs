using SimpleDataGrid;
using System;
using System.Windows;
using System.Windows.Controls;

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

        public BaseView(string debugName)
        {
            _debugName = debugName;
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

            DataContext = ViewModel;

            for (int i = 0; i < ViewModel.HeaderFilters.Count; i++)
            {
                _gridView.Columns[i].Header = ViewModel.HeaderFilters[i];
            }
        }

        public void ProcessMenuButtonClick(object sender, RoutedEventArgs e)
        {
            var button = e.OriginalSource as Button;
            if (button == null)
                return;

            if (button.Tag == null)
                return;

            var buttonName = button.Tag.ToString();
            switch (buttonName)
            {
                case "btnSave":
                    Console.WriteLine(_debugName + "Save");
                    ViewModel.Save();
                    if (AfterSave != null)
                    {
                        AfterSave(this, null);
                    }
                    break;
                case "btnCancel":
                    Console.WriteLine(_debugName + "Cancel");
                    ViewModel.Load();
                    if (AfterCancel != null)
                    {
                        AfterCancel(this, null);
                    }
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

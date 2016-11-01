using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Client.Abstraction
{
    public abstract class BaseComplexView : UserControl
    {
        public static int GetViewLevel(DependencyObject obj)
        {
            return (int)obj.GetValue(ViewLevelProperty);
        }

        public static void SetViewLevel(DependencyObject obj, int value)
        {
            obj.SetValue(ViewLevelProperty, value);
        }

        // Using a DependencyProperty as the backing store for ViewLevel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewLevelProperty =
            DependencyProperty.RegisterAttached("ViewLevel", typeof(int), typeof(BaseComplexView), new PropertyMetadata(0));

        private readonly Dictionary<int, IBaseView> _views = new Dictionary<int, IBaseView>();

        private bool _isDesignTime = true;

        public BaseComplexView()
        {
            _isDesignTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());
        }
        protected override void OnInitialized(EventArgs e)
        {
            Console.WriteLine("BaseComplexView OnInitialized");
            InitView();
            base.OnInitialized(e);
        }

        private void InitView()
        {
            if (_isDesignTime == true)
            {
                return;
            }

            var panel = Content as Panel;
            foreach (UIElement item in panel.Children)
            {
                var level = BaseComplexView.GetViewLevel(item);
                var view = item as IBaseView;
                if (view != null && _views.ContainsKey(level) == false)
                {
                    _views.Add(level, view);
                }
            }

            for (int i = 0; i < _views.Count - 1; i++)
            {
                InitSelectedIndexChangedAction(_views[i], _views[i + 1]);
                InitMoveFocusAction(_views[i], _views[i + 1]);
            }

            InitMoveFocusAction(_views[_views.Count - 1], _views[0]);
        }

        private void InitSelectedIndexChangedAction(IBaseView parent, IBaseView child)
        {
            var viewModel = parent.ViewModel;
            var childViewModel = child.ViewModel;
            viewModel.ActionSelectedValueChanged = (selectedValue) =>
            {
                if (selectedValue == null)
                {
                    childViewModel.HeaderFilters[1].FilterValue = 0;
                }
                else
                {
                    childViewModel.HeaderFilters[1].FilterValue = selectedValue;
                }
            };
            childViewModel.HeaderFilters[1].DisableChangedAction(p => { p.IsUsed = true; p.FilterValue = 0; });
        }

        private void InitMoveFocusAction(IBaseView current, IBaseView next)
        {
            var nextDataGrid = next.GridView.dataGrid;
            current.ActionMoveFocusToNextView = () =>
            {
                nextDataGrid.FocusCell(
                    nextDataGrid.Items.Count - 1,
                    nextDataGrid.FindFirstEditableColumnIndex(0, nextDataGrid));
            };
        }
    }
}

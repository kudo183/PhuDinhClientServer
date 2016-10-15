using System.Windows;
using System.Windows.Controls;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for complexDonHangView.xaml
    /// </summary>
    public partial class complexDonHangView : UserControl
    {
        public complexDonHangView()
        {
            InitializeComponent();

            var designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());
            if (designTime == true)
            {
                return;
            }

            tDonHang.ViewModel.ActionSelectedIndexChanged = ProcessSelectedIndexChanged;
            tChiTietDonHang.ViewModel.HeaderFilters[1].DisableChangedAction(p => { p.IsUsed = true; p.FilterValue = 0; });
        }

        private void ProcessSelectedIndexChanged(int index)
        {
            if (index < 0 || index >= tDonHang.ViewModel.Entities.Count)
            {
                tChiTietDonHang.ViewModel.HeaderFilters[1].FilterValue = 0;
            }
            else
            {
                tChiTietDonHang.ViewModel.HeaderFilters[1].FilterValue = tDonHang.ViewModel.Entities[index].Ma;
            }
        }
    }
}

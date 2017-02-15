using Client.Abstraction;
using Client.ViewModel;
using System.Windows.Controls;

namespace Client.View
{
    public partial class TTonKhoView : BaseView<DTO.TTonKhoDto>
    {
        partial void InitUIPartial()
        {
            GridView.Columns[3].DisplayIndex = 1;

            (GridView.Columns[4] as SimpleDataGrid.DataGridTextColumnExt).SetStyleAsRightAlignIntegerNumber();
            GridView.Columns[5].Visibility = System.Windows.Visibility.Collapsed;

            var btnTonHangNhap = new Button()
            {
                Content = "Copy Ton Hang Nhap",
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                Margin = new System.Windows.Thickness(5)
            };
            btnTonHangNhap.Click += BtnTonHangNhap_Click;
            GridView.CustomMenuItems.Add(btnTonHangNhap);


            var btnTonHangNha = new Button()
            {
                Content = "Copy Ton Hang Nha",
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                Margin = new System.Windows.Thickness(5)
            };
            btnTonHangNha.Click += BtnTonHangNha_Click;
            GridView.CustomMenuItems.Add(btnTonHangNha);
        }

        private void BtnTonHangNhap_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var vm = ViewModel as TTonKhoViewModel;
            vm.CopyTonKhoToClipboard(false);
        }

        private void BtnTonHangNha_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var vm = ViewModel as TTonKhoViewModel;
            vm.CopyTonKhoToClipboard(true);
        }
    }
}

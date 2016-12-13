using Client.Abstraction;
using System.Windows.Controls;
using System.Windows.Media;

namespace Client.View
{
    public partial class TChiTietNhapHangView : BaseView<DTO.TChiTietNhapHangDto>
    {
        partial void InitUIPartial()
        {
            GridView.dataGrid.Columns[2] = new SimpleDataGrid.DataGridTextColumnExt()
            {
                Width = 250,
                IsReadOnly = true,
                Header = GridView.dataGrid.Columns[2].Header,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(nameof(DTO.TChiTietNhapHangDto.TNhapHang) + "." + nameof(DTO.TNhapHangDto.TenHienThi)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            };

            GridView.Columns[1].DisplayIndex = 2;

            var tb = new TextBlock()
            {
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                FontSize = 14,
                Foreground = Brushes.Blue
            };
            tb.SetBinding(TextBlock.TextProperty, "Msg");
            GridView.CustomMenuItems.Add(tb);
        }
    }
}

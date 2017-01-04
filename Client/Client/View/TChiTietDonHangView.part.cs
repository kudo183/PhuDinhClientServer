using Client.Abstraction;
using System.Windows.Controls;
using System.Windows.Media;

namespace Client.View
{
    public partial class TChiTietDonHangView : BaseView<DTO.TChiTietDonHangDto>
    {
        partial void InitUIPartial()
        {
            GridView.dataGrid.Columns[1] = new SimpleDataGrid.DataGridTextColumnExt()
            {
                Width = 250,
                IsReadOnly = true,
                Header = GridView.dataGrid.Columns[1].Header,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(nameof(DTO.TChiTietDonHangDto.TDonHang) + "." + nameof(DTO.TDonHangDto.TenHienThi)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            };
            
            (GridView.dataGrid.Columns[3] as SimpleDataGrid.DataGridTextColumnExt).SetStyleAsRightAlignIntegerNumber();

            GridView.dataGrid.Columns[4].IsReadOnly = true;
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

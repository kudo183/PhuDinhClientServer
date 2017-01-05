using Client.Abstraction;
using System.Windows.Controls;
using System.Windows.Media;

namespace Client.View
{
    public partial class TChiTietChuyenKhoView : BaseView<DTO.TChiTietChuyenKhoDto>
    {
        partial void InitUIPartial()
        {
            GridView.Columns[1] = new SimpleDataGrid.DataGridTextColumnExt()
            {
                Width = 250,
                IsReadOnly = true,
                Header = GridView.dataGrid.Columns[1].Header,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(nameof(DTO.TChiTietChuyenKhoDto.TChuyenKho) + "." + nameof(DTO.TChuyenKhoDto.TenHienThi)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            };

            (GridView.Columns[3] as SimpleDataGrid.DataGridTextColumnExt).SetStyleAsRightAlignIntegerNumber();

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

using Client.Abstraction;

namespace Client.View
{
    public partial class TChuyenHangDonHangView : BaseView<DTO.TChuyenHangDonHangDto>
    {
        partial void InitUIPartial()
        {
            GridView.Columns[1] = new SimpleDataGrid.DataGridTextColumnExt()
            {
                Width = 250,
                IsReadOnly = true,
                Header = GridView.Columns[1].Header,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(nameof(DTO.TChuyenHangDonHangDto.TChuyenHang) + "." + nameof(DTO.TChuyenHangDto.TenHienThi)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            };

            GridView.Columns[2].Width = 250;

            GridView.Columns[3].IsReadOnly = true;
            (GridView.Columns[3] as SimpleDataGrid.DataGridTextColumnExt).SetStyleAsRightAlignIntegerNumber();
            GridView.dataGrid.Columns[4].IsReadOnly = true;
            (GridView.Columns[4] as SimpleDataGrid.DataGridTextColumnExt).SetStyleAsRightAlignIntegerNumber();

            GridView.Columns.Add(new SimpleDataGrid.DataGridCheckBoxColumnExt()
            {
                Width = 150,
                IsReadOnly = true,
                Header = TextManager.TDonHang_Xong,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(string.Format("{0}.{1}",nameof(DTO.TChuyenHangDonHangDto.TDonHang), nameof(DTO.TDonHangDto.Xong))),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            });
        }
    }
}

using Client.Abstraction;

namespace Client.View
{
    public partial class TChiTietChuyenHangDonHangView : BaseView<DTO.TChiTietChuyenHangDonHangDto>
    {
        partial void InitUIPartial()
        {
            GridView.Columns[2] = new SimpleDataGrid.DataGridTextColumnExt()
            {
                Width = 200,
                IsReadOnly = true,
                Header = GridView.Columns[2].Header,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(nameof(DTO.TChiTietChuyenHangDonHangDto.TChuyenHangDonHang) + "." + nameof(DTO.TChuyenHangDonHangDto.TenHienThi)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            };

            GridView.Columns[1].Width = 400;
            GridView.Columns[1].DisplayIndex = 2;

            GridView.Columns[3].Width = 80;
            (GridView.Columns[3] as SimpleDataGrid.DataGridTextColumnExt).SetStyleAsRightAlignIntegerNumber();

            GridView.Columns[4].Width = 80;
            GridView.Columns[4].IsReadOnly = true;
            (GridView.Columns[4] as SimpleDataGrid.DataGridTextColumnExt).SetStyleAsRightAlignIntegerNumber();

            GridView.Columns.Add(new SimpleDataGrid.DataGridCheckBoxColumnExt()
            {
                Width = 150,
                IsReadOnly = true,
                Header = TextManager.TChiTietDonHang_Xong,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(string.Format("{0}.{1}", nameof(DTO.TChiTietChuyenHangDonHangDto.TChiTietDonHang), nameof(DTO.TChiTietDonHangDto.Xong))),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            });
        }
    }
}

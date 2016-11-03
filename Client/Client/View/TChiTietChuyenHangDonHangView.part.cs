using Client.Abstraction;

namespace Client.View
{
    public partial class TChiTietChuyenHangDonHangView : BaseView<DTO.TChiTietChuyenHangDonHangDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;
            datagrid.dataGrid.Columns[2] = new SimpleDataGrid.DataGridTextColumnExt()
            {
                Width = 200,
                IsReadOnly = true,
                Header = datagrid.dataGrid.Columns[2].Header,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(nameof(DTO.TChiTietChuyenHangDonHangDto.TChuyenHangDonHang) + "." + nameof(DTO.TChuyenHangDonHangDto.TenHienThi)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            };

            datagrid.Columns[1].Width = 400;
            datagrid.Columns[1].DisplayIndex = 2;

            datagrid.Columns[3].Width = 80;

            datagrid.Columns[4].Width = 80;
            datagrid.Columns[4].IsReadOnly = true;
        }
    }
}

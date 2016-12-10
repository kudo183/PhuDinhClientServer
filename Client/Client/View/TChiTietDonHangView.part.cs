using Client.Abstraction;

namespace Client.View
{
    public partial class TChiTietDonHangView : BaseView<DTO.TChiTietDonHangDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;

            datagrid.dataGrid.Columns[1] = new SimpleDataGrid.DataGridTextColumnExt()
            {
                Width = 250,
                IsReadOnly = true,
                Header = datagrid.dataGrid.Columns[1].Header,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(nameof(DTO.TChiTietDonHangDto.TDonHang) + "." + nameof(DTO.TDonHangDto.TenHienThi)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            };

            datagrid.dataGrid.Columns[4].IsReadOnly = true;
        }
    }
}

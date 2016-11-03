using Client.Abstraction;

namespace Client.View
{
    public partial class TChiTietToaHangView : BaseView<DTO.TChiTietToaHangDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;

            datagrid.dataGrid.Columns[3] = new SimpleDataGrid.DataGridTextColumnExt()
            {
                Width = 250,
                IsReadOnly = true,
                Header = datagrid.dataGrid.Columns[3].Header,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(nameof(DTO.TChiTietToaHangDto.TToaHang) + "." + nameof(DTO.TToaHangDto.TenHienThi)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            };

            datagrid.Columns[1].DisplayIndex = 3;
            datagrid.Columns[3].DisplayIndex = 1;
        }
    }
}

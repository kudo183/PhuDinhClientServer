using Client.Abstraction;

namespace Client.View
{
    public partial class TChiTietChuyenKhoView : BaseView<DTO.TChiTietChuyenKhoDto>
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
                    Path = new System.Windows.PropertyPath(nameof(DTO.TChiTietChuyenKhoDto.TChuyenKho) + "." + nameof(DTO.TChuyenKhoDto.TenHienThi)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            };
        }
    }
}

using Client.Abstraction;

namespace Client.View
{
    public partial class TToaHangView : BaseView<DTO.TToaHangDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;
            datagrid.Columns[1].DisplayIndex = 2;
            datagrid.Columns.Add(new SimpleDataGrid.DataGridTextColumnExt()
            {
                Width = 150,
                IsReadOnly = true,
                Header = TextManager.TToaHang_ThanhTien,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(nameof(DTO.TToaHangDto.ThanhTien)),
                    Mode = System.Windows.Data.BindingMode.OneWay,
                    StringFormat = "{0:N0}"
                }
            });
        }
    }
}

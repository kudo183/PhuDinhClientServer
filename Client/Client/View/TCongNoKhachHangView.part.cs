using Client.Abstraction;

namespace Client.View
{
    public partial class TCongNoKhachHangView : BaseView<DTO.TCongNoKhachHangDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;
            datagrid.Columns[1].DisplayIndex = 2;
        }
    }
}

using Client.Abstraction;

namespace Client.View
{
    public partial class TToaHangView : BaseView<DTO.TToaHangDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;
            datagrid.Columns[1].DisplayIndex = 2;
        }
    }
}

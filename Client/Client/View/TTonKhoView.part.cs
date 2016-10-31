using Client.Abstraction;

namespace Client.View
{
    public partial class TTonKhoView : BaseView<DTO.TTonKhoDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;
            datagrid.Columns[3].DisplayIndex = 1;
        }
    }
}

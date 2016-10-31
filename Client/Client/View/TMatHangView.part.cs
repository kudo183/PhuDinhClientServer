using Client.Abstraction;

namespace Client.View
{
    public partial class TMatHangView : BaseView<DTO.TMatHangDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;
            datagrid.Columns[3].DisplayIndex = 6;
            datagrid.Columns[2].DisplayIndex = 5;
        }
    }
}

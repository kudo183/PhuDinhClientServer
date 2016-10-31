using Client.Abstraction;

namespace Client.View
{
    public partial class TDonHangView : BaseView<DTO.TDonHangDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;
            datagrid.Columns[4].DisplayIndex = 1;
            datagrid.Columns[1].DisplayIndex = 4;
        }
    }
}

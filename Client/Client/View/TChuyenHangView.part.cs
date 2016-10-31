using Client.Abstraction;

namespace Client.View
{
    public partial class TChuyenHangView : BaseView<DTO.TChuyenHangDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;
            datagrid.Columns[3].DisplayIndex = 1;
        }
    }
}

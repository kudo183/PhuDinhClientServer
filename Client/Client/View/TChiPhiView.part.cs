using Client.Abstraction;

namespace Client.View
{
    public partial class TChiPhiView : BaseView<DTO.TChiPhiDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;
            datagrid.Columns[1].DisplayIndex = 5;
            datagrid.Columns[4].DisplayIndex = 1;
        }
    }
}

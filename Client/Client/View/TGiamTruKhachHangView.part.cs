using Client.Abstraction;

namespace Client.View
{
    public partial class TGiamTruKhachHangView : BaseView<DTO.TGiamTruKhachHangDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;
            datagrid.Columns[1].DisplayIndex = 4;
            datagrid.Columns[3].DisplayIndex = 1;
        }
    }
}

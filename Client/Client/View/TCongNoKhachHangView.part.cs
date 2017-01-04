using Client.Abstraction;

namespace Client.View
{
    public partial class TCongNoKhachHangView : BaseView<DTO.TCongNoKhachHangDto>
    {
        partial void InitUIPartial()
        {
            GridView.Columns[1].DisplayIndex = 2;

            (GridView.Columns[3] as SimpleDataGrid.DataGridTextColumnExt).SetStyleAsRightAlignIntegerNumber();
        }
    }
}

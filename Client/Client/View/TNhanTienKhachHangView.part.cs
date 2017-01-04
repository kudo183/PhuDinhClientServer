using Client.Abstraction;

namespace Client.View
{
    public partial class TNhanTienKhachHangView : BaseView<DTO.TNhanTienKhachHangDto>
    {
        partial void InitUIPartial()
        {
            GridView.Columns[1].DisplayIndex = 2;

            (GridView.Columns[3] as SimpleDataGrid.DataGridTextColumnExt).SetStyleAsRightAlignIntegerNumber();
        }
    }
}

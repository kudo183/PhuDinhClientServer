using Client.Abstraction;

namespace Client.View
{
    public partial class TNhapHangView : BaseView<DTO.TNhapHangDto>
    {
        partial void InitUIPartial()
        {
            GridView.Columns[4].DisplayIndex = 1;
            GridView.Columns[3].DisplayIndex = 2;
            GridView.Columns[2].DisplayIndex = 3;

            GridView.dataGrid.SkippedColumnIndex.Add(1);
        }
    }
}

using Client.Abstraction;

namespace Client.View
{
    public partial class TTonKhoView : BaseView<DTO.TTonKhoDto>
    {
        partial void InitUIPartial()
        {
            GridView.Columns[3].DisplayIndex = 1;

            (GridView.Columns[4] as SimpleDataGrid.DataGridTextColumnExt).SetStyleAsRightAlignIntegerNumber();
            GridView.Columns[5].Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}

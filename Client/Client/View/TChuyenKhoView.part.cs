using Client.Abstraction;

namespace Client.View
{
    public partial class TChuyenKhoView : BaseView<DTO.TChuyenKhoDto>
    {
        partial void InitUIPartial()
        {
            GridView.Columns[4].DisplayIndex = 1;
            GridView.Columns[3].DisplayIndex = 2;
            GridView.Columns[2].DisplayIndex = 3;

            GridView.dataGrid.SkippedColumnIndex.Add(1);

            var columnTongSoLuong = new SimpleDataGrid.DataGridTextColumnExt()
            {
                Width = 150,
                IsReadOnly = true,
                Header = TextManager.TChuyenKho_TongSoLuong,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(nameof(DTO.TChuyenKhoDto.TongSoLuong)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            };
            columnTongSoLuong.SetStyleAsRightAlignIntegerNumber();
            GridView.Columns.Add(columnTongSoLuong);
        }
    }
}

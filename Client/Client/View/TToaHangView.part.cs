using Client.Abstraction;

namespace Client.View
{
    public partial class TToaHangView : BaseView<DTO.TToaHangDto>
    {
        partial void InitUIPartial()
        {
            GridView.Columns[1].DisplayIndex = 2;
            GridView.Columns.Add(new SimpleDataGrid.DataGridTextColumnExt()
            {
                Width = 150,
                IsReadOnly = true,
                Header = TextManager.TToaHang_ThanhTien,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(nameof(DTO.TToaHangDto.ThanhTien)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            });
            
            (GridView.Columns[3] as SimpleDataGrid.DataGridTextColumnExt).SetStyleAsRightAlignIntegerNumber();
        }
    }
}

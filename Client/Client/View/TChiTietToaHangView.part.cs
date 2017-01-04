using Client.Abstraction;

namespace Client.View
{
    public partial class TChiTietToaHangView : BaseView<DTO.TChiTietToaHangDto>
    {
        partial void InitUIPartial()
        {
            GridView.Columns[3] = new SimpleDataGrid.DataGridTextColumnExt()
            {
                Width = 250,
                IsReadOnly = true,
                Header = GridView.Columns[3].Header,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(nameof(DTO.TChiTietToaHangDto.TToaHang) + "." + nameof(DTO.TToaHangDto.TenHienThi)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            };
            
            foreach (var column in GridView.Columns)
            {
                var header = column.Header as SimpleDataGrid.ViewModel.HeaderFilterBaseModel;
                switch (header.PropertyName)
                {
                    case nameof(DTO.TChiTietToaHangDto.ID):
                        column.DisplayIndex = 0;
                        break;
                    case nameof(DTO.TChiTietToaHangDto.MaToaHang):
                        column.DisplayIndex = 1;
                        break;
                    case nameof(DTO.TChiTietToaHangDto.MaChiTietDonHang):
                        column.DisplayIndex = 2;
                        break;
                    case nameof(DTO.TChiTietToaHangDto.GiaTien):
                        column.DisplayIndex = 3;
                        (column as SimpleDataGrid.DataGridTextColumnExt).SetStyleAsRightAlignIntegerNumber();
                        break;
                }
            }

            GridView.Columns.Add(new SimpleDataGrid.DataGridTextColumnExt()
            {
                Width = 150,
                IsReadOnly = true,
                Header = TextManager.TChiTietToaHang_ThanhTien,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(nameof(DTO.TChiTietToaHangDto.ThanhTien)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            });
            (GridView.Columns[4] as SimpleDataGrid.DataGridTextColumnExt).SetStyleAsRightAlignIntegerNumber();
        }
    }
}

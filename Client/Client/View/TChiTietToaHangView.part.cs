using Client.Abstraction;

namespace Client.View
{
    public partial class TChiTietToaHangView : BaseView<DTO.TChiTietToaHangDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;

            datagrid.dataGrid.Columns[3] = new SimpleDataGrid.DataGridTextColumnExt()
            {
                Width = 250,
                IsReadOnly = true,
                Header = datagrid.dataGrid.Columns[3].Header,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(nameof(DTO.TChiTietToaHangDto.TToaHang) + "." + nameof(DTO.TToaHangDto.TenHienThi)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            };
            
            foreach (var column in datagrid.Columns)
            {
                var header = column.Header as SimpleDataGrid.ViewModel.HeaderFilterBaseModel;
                switch (header.PropertyName)
                {
                    case nameof(DTO.TChiTietToaHangDto.Ma):
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
                        break;
                }
            }
        }
    }
}

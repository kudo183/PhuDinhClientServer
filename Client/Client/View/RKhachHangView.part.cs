using Client.Abstraction;

namespace Client.View
{
    public partial class RKhachHangView : BaseView<DTO.RKhachHangDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;

            foreach (var column in datagrid.Columns)
            {
                var header = column.Header as SimpleDataGrid.ViewModel.HeaderFilterBaseModel;
                switch (header.PropertyName)
                {
                    case nameof(DTO.RKhachHangDto.ID):
                        column.DisplayIndex = 0;
                        break;
                    case nameof(DTO.RKhachHangDto.MaDiaDiem):
                        column.DisplayIndex = 1;
                        break;
                    case nameof(DTO.RKhachHangDto.TenKhachHang):
                        column.DisplayIndex = 2;
                        break;
                    case nameof(DTO.RKhachHangDto.KhachRieng):
                        column.DisplayIndex = 3;
                        break;
                }
            }
        }
    }
}

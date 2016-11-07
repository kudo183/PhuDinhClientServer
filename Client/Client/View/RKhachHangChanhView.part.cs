using Client.Abstraction;

namespace Client.View
{
    public partial class RKhachHangChanhView : BaseView<DTO.RKhachHangChanhDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;

            foreach (var column in datagrid.Columns)
            {
                var header = column.Header as SimpleDataGrid.ViewModel.HeaderFilterBaseModel;
                switch (header.PropertyName)
                {
                    case nameof(DTO.RKhachHangChanhDto.Ma):
                        column.DisplayIndex = 0;
                        break;
                    case nameof(DTO.RKhachHangChanhDto.MaKhachHang):
                        column.DisplayIndex = 1;
                        break;
                    case nameof(DTO.RKhachHangChanhDto.MaChanh):
                        column.DisplayIndex = 2;
                        break;
                    case nameof(DTO.RKhachHangChanhDto.LaMacDinh):
                        column.DisplayIndex = 3;
                        break;
                }
            }
        }
    }
}

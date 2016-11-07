using Client.Abstraction;

namespace Client.View
{
    public partial class RLoaiHangView : BaseView<DTO.RLoaiHangDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;
            
            foreach (var column in datagrid.Columns)
            {
                var header = column.Header as SimpleDataGrid.ViewModel.HeaderFilterBaseModel;
                switch (header.PropertyName)
                {
                    case nameof(DTO.RLoaiHangDto.Ma):
                        column.DisplayIndex = 0;
                        break;
                    case nameof(DTO.RLoaiHangDto.TenLoai):
                        column.DisplayIndex = 1;
                        break;
                    case nameof(DTO.RLoaiHangDto.HangNhaLam):
                        column.DisplayIndex = 2;
                        break;
                }
            }
        }
    }
}

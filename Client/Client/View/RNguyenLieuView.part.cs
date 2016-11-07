using Client.Abstraction;

namespace Client.View
{
    public partial class RNguyenLieuView : BaseView<DTO.RNguyenLieuDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;

            foreach (var column in datagrid.Columns)
            {
                var header = column.Header as SimpleDataGrid.ViewModel.HeaderFilterBaseModel;
                switch (header.PropertyName)
                {
                    case nameof(DTO.RNguyenLieuDto.Ma):
                        column.DisplayIndex = 0;
                        break;
                    case nameof(DTO.RNguyenLieuDto.MaLoaiNguyenLieu):
                        column.DisplayIndex = 1;
                        break;
                    case nameof(DTO.RNguyenLieuDto.DuongKinh):
                        column.DisplayIndex = 2;
                        break;
                }
            }
        }
    }
}

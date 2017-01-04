using Client.Abstraction;

namespace Client.View
{
    public partial class TPhuThuKhachHangView : BaseView<DTO.TPhuThuKhachHangDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;

            foreach (var column in datagrid.Columns)
            {
                var header = column.Header as SimpleDataGrid.ViewModel.HeaderFilterBaseModel;
                switch (header.PropertyName)
                {
                    case nameof(DTO.TPhuThuKhachHangDto.ID):
                        column.DisplayIndex = 0;
                        break;
                    case nameof(DTO.TPhuThuKhachHangDto.Ngay):
                        column.DisplayIndex = 1;
                        break;
                    case nameof(DTO.TPhuThuKhachHangDto.MaKhachHang):
                        column.DisplayIndex = 2;
                        break;
                    case nameof(DTO.TPhuThuKhachHangDto.SoTien):
                        column.DisplayIndex = 3;
                        (column as SimpleDataGrid.DataGridTextColumnExt).SetStyleAsRightAlignIntegerNumber();
                        break;
                    case nameof(DTO.TPhuThuKhachHangDto.GhiChu):
                        column.DisplayIndex = 4;
                        break;
                }
            }
        }
    }
}

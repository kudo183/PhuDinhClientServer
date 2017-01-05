using Client.Abstraction;

namespace Client.View
{
    public partial class TGiamTruKhachHangView : BaseView<DTO.TGiamTruKhachHangDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;

            foreach (var column in datagrid.Columns)
            {
                var header = column.Header as SimpleDataGrid.ViewModel.HeaderFilterBaseModel;
                switch (header.PropertyName)
                {
                    case nameof(DTO.TGiamTruKhachHangDto.ID):
                        column.DisplayIndex = 0;
                        break;
                    case nameof(DTO.TGiamTruKhachHangDto.Ngay):
                        column.DisplayIndex = 1;
                        break;
                    case nameof(DTO.TGiamTruKhachHangDto.MaKhachHang):
                        column.DisplayIndex = 2;
                        break;
                    case nameof(DTO.TGiamTruKhachHangDto.SoTien):
                        column.DisplayIndex = 3;
                        (column as SimpleDataGrid.DataGridTextColumnExt).SetStyleAsRightAlignIntegerNumber();
                        break;
                    case nameof(DTO.TGiamTruKhachHangDto.GhiChu):
                        column.DisplayIndex = 4;
                        break;
                }
            }
        }
    }
}

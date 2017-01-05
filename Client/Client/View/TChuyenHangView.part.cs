using Client.Abstraction;

namespace Client.View
{
    public partial class TChuyenHangView : BaseView<DTO.TChuyenHangDto>
    {
        partial void InitUIPartial()
        {
            foreach (var column in GridView.Columns)
            {
                var header = column.Header as SimpleDataGrid.ViewModel.HeaderFilterBaseModel;
                switch (header.PropertyName)
                {
                    case nameof(DTO.TChuyenHangDto.ID):
                        column.DisplayIndex = 0;
                        break;
                    case nameof(DTO.TChuyenHangDto.Ngay):
                        column.DisplayIndex = 1;
                        break;
                    case nameof(DTO.TChuyenHangDto.Gio):
                        column.DisplayIndex = 2;
                        break;
                    case nameof(DTO.TChuyenHangDto.MaNhanVienGiaoHang):
                        column.DisplayIndex = 3;
                        break;
                    case nameof(DTO.TChuyenHangDto.TongDonHang):
                        column.DisplayIndex = 4;
                        column.IsReadOnly = true;
                        (column as SimpleDataGrid.DataGridTextColumnExt).SetStyleAsRightAlignIntegerNumber();
                        break;
                    case nameof(DTO.TChuyenHangDto.TongSoLuongTheoDonHang):
                        column.DisplayIndex = 5;
                        column.IsReadOnly = true;
                        (column as SimpleDataGrid.DataGridTextColumnExt).SetStyleAsRightAlignIntegerNumber();
                        break;
                    case nameof(DTO.TChuyenHangDto.TongSoLuongThucTe):
                        column.DisplayIndex = 6;
                        column.IsReadOnly = true;
                        (column as SimpleDataGrid.DataGridTextColumnExt).SetStyleAsRightAlignIntegerNumber();
                        break;
                }
            }

            GridView.dataGrid.SkippedColumnIndex.Add(1);
        }
    }
}

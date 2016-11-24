using Client.Abstraction;

namespace Client.View
{
    public partial class TChiPhiView : BaseView<DTO.TChiPhiDto>
    {
        partial void InitUIPartial()
        {
            var datagrid = Content as SimpleDataGrid.EditableGridView;

            foreach (var column in datagrid.Columns)
            {
                var header = column.Header as SimpleDataGrid.ViewModel.HeaderFilterBaseModel;
                switch (header.PropertyName)
                {
                    case nameof(DTO.TChiPhiDto.ID):
                        column.DisplayIndex = 0;
                        break;
                    case nameof(DTO.TChiPhiDto.Ngay):
                        column.DisplayIndex = 1;
                        break;
                    case nameof(DTO.TChiPhiDto.MaLoaiChiPhi):
                        column.DisplayIndex = 2;
                        break;
                    case nameof(DTO.TChiPhiDto.MaNhanVienGiaoHang):
                        column.DisplayIndex = 3;
                        break;
                    case nameof(DTO.TChiPhiDto.SoTien):
                        column.DisplayIndex = 4;
                        break;
                    case nameof(DTO.TChiPhiDto.GhiChu):
                        column.DisplayIndex = 5;
                        break;
                }
            }
        }
    }
}

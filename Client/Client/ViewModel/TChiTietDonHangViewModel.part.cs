using System;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TChiTietDonHangViewModel : BaseViewModel<TChiTietDonHangDto>
    {
        partial void InitFilterPartial()
        {
            _MaDonHangFilter = new HeaderTextFilterModel(TextManager.TChiTietDonHang_MaDonHang, nameof(TChiTietDonHangDto.MaDonHang), typeof(int));
        }

        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<RKhoHangDto>.Instance.Load();
            ReferenceDataManager<RKhachHangDto>.Instance.Load();
        }

        partial void ProcessDtoBeforeAddToEntitiesPartial(TChiTietDonHangDto dto)
        {
            if (dto.TDonHang != null)
            {
                dto.TDonHang.RKhoHang = ReferenceDataManager<RKhoHangDto>.Instance.GetList().Find(p => p.ID == dto.TDonHang.MaKhoHang);
                dto.TDonHang.RKhachHang = ReferenceDataManager<RKhachHangDto>.Instance.GetList().Find(p => p.ID == dto.TDonHang.MaKhachHang);
            }
        }

        partial void ProcessNewAddedDtoPartial(TChiTietDonHangDto dto)
        {
            dto.Xong = false;
        }
    }
}

using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TChuyenHangController : SwaEntityBaseController<PhuDinhServerContext, TChuyenHang, TChuyenHangDto>
    {
        partial void ConvertToDtoPartial(ref TChuyenHangDto dto, TChuyenHang entity);
        partial void ConvertToEntityPartial(ref TChuyenHang entity, TChuyenHangDto dto);

        public override TChuyenHangDto ConvertToDto(TChuyenHang entity)
        {
            var dto = new TChuyenHangDto();
            dto.Gio = entity.Gio;
            dto.GroupID = entity.GroupID;
            dto.Ma = entity.Ma;
            dto.MaNhanVienGiaoHang = entity.MaNhanVienGiaoHang;
            dto.Ngay = entity.Ngay;
            dto.TongDonHang = entity.TongDonHang;
            dto.TongSoLuongTheoDonHang = entity.TongSoLuongTheoDonHang;
            dto.TongSoLuongThucTe = entity.TongSoLuongThucTe;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override TChuyenHang ConvertToEntity(TChuyenHangDto dto)
        {
            var entity = new TChuyenHang();
            entity.Gio = dto.Gio;
            entity.GroupID = dto.GroupID;
            entity.Ma = dto.Ma;
            entity.MaNhanVienGiaoHang = dto.MaNhanVienGiaoHang;
            entity.Ngay = dto.Ngay;
            entity.TongDonHang = dto.TongDonHang;
            entity.TongSoLuongTheoDonHang = dto.TongSoLuongTheoDonHang;
            entity.TongSoLuongThucTe = dto.TongSoLuongThucTe;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

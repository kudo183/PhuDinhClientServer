using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TChuyenHangDonHangController : SwaEntityBaseController<PhuDinhServerContext, TChuyenHangDonHang, TChuyenHangDonHangDto>
    {
        partial void ConvertToDtoPartial(ref TChuyenHangDonHangDto dto, TChuyenHangDonHang entity);
        partial void ConvertToEntityPartial(ref TChuyenHangDonHang entity, TChuyenHangDonHangDto dto);

        public override TChuyenHangDonHangDto ConvertToDto(TChuyenHangDonHang entity)
        {
            var dto = new TChuyenHangDonHangDto();
            dto.GroupID = entity.GroupID;
            dto.Ma = entity.Ma;
            dto.MaChuyenHang = entity.MaChuyenHang;
            dto.MaDonHang = entity.MaDonHang;
            dto.TongSoLuongTheoDonHang = entity.TongSoLuongTheoDonHang;
            dto.TongSoLuongThucTe = entity.TongSoLuongThucTe;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override TChuyenHangDonHang ConvertToEntity(TChuyenHangDonHangDto dto)
        {
            var entity = new TChuyenHangDonHang();
            entity.GroupID = dto.GroupID;
            entity.Ma = dto.Ma;
            entity.MaChuyenHang = dto.MaChuyenHang;
            entity.MaDonHang = dto.MaDonHang;
            entity.TongSoLuongTheoDonHang = dto.TongSoLuongTheoDonHang;
            entity.TongSoLuongThucTe = dto.TongSoLuongThucTe;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

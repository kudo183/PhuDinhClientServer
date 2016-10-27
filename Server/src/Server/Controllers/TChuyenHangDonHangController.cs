using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public class TChuyenHangDonHangController : SwaEntityBaseController<PhuDinhServerContext, TChuyenHangDonHang, TChuyenHangDonHangDto>
    {
        public override TChuyenHangDonHangDto ConvertToDto(TChuyenHangDonHang entity)
        {
            var dto = new TChuyenHangDonHangDto();
            dto.Ma = entity.Ma;
            dto.MaChuyenHang = entity.MaChuyenHang;
            dto.MaDonHang = entity.MaDonHang;
            dto.TongSoLuongTheoDonHang = entity.TongSoLuongTheoDonHang;
            dto.TongSoLuongThucTe = entity.TongSoLuongThucTe;
            return dto;
        }

        public override TChuyenHangDonHang ConvertToEntity(TChuyenHangDonHangDto dto)
        {
            var entity = new TChuyenHangDonHang();
            entity.Ma = dto.Ma;
            entity.MaChuyenHang = dto.MaChuyenHang;
            entity.MaDonHang = dto.MaDonHang;
            entity.TongSoLuongTheoDonHang = dto.TongSoLuongTheoDonHang;
            entity.TongSoLuongThucTe = dto.TongSoLuongThucTe;
            return entity;
        }
    }
}

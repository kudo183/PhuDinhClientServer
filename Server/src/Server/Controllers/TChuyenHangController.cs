using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public class TChuyenHangController : SwaEntityBaseController<PhuDinhServerContext, TChuyenHang, TChuyenHangDto>
    {
        public override TChuyenHangDto ConvertToDto(TChuyenHang entity)
        {
            var dto = new TChuyenHangDto();
            dto.Ma = entity.Ma;
            dto.Gio = entity.Gio;
            dto.MaNhanVienGiaoHang = entity.MaNhanVienGiaoHang;
            dto.Ngay = entity.Ngay;
            dto.TongDonHang = entity.TongDonHang;
            dto.TongSoLuongTheoDonHang = entity.TongSoLuongTheoDonHang;
            dto.TongSoLuongThucTe = entity.TongSoLuongThucTe;
            return dto;
        }

        public override TChuyenHang ConvertToEntity(TChuyenHangDto dto)
        {
            var entity = new TChuyenHang();
            entity.Ma = dto.Ma;
            entity.Gio = dto.Gio;
            entity.MaNhanVienGiaoHang = dto.MaNhanVienGiaoHang;
            entity.Ngay = dto.Ngay;
            entity.TongDonHang = dto.TongDonHang;
            entity.TongSoLuongTheoDonHang = dto.TongSoLuongTheoDonHang;
            entity.TongSoLuongThucTe = dto.TongSoLuongThucTe;
            return entity;
        }
    }
}

using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TChiTietChuyenHangDonHangController : SwaEntityBaseController<PhuDinhServerContext, TChiTietChuyenHangDonHang, TChiTietChuyenHangDonHangDto>
    {
        public override TChiTietChuyenHangDonHangDto ConvertToDto(TChiTietChuyenHangDonHang entity)
        {
            var dto = new TChiTietChuyenHangDonHangDto();
            dto.Ma = entity.Ma;
            dto.MaChiTietDonHang = entity.MaChiTietDonHang;
            dto.MaChuyenHangDonHang = entity.MaChuyenHangDonHang;
            dto.SoLuong = entity.SoLuong;
            dto.SoLuongTheoDonHang = entity.SoLuongTheoDonHang;
            return dto;
        }

        public override TChiTietChuyenHangDonHang ConvertToEntity(TChiTietChuyenHangDonHangDto dto)
        {
            var entity = new TChiTietChuyenHangDonHang();
            entity.Ma = dto.Ma;
            entity.MaChiTietDonHang = dto.MaChiTietDonHang;
            entity.MaChuyenHangDonHang = dto.MaChuyenHangDonHang;
            entity.SoLuong = dto.SoLuong;
            entity.SoLuongTheoDonHang = dto.SoLuongTheoDonHang;
            return entity;
        }
    }
}

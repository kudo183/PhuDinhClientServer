using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public class TChiTietNhapHangController : SwaEntityBaseController<PhuDinhServerContext, TChiTietNhapHang, TChiTietNhapHangDto>
    {
        public override TChiTietNhapHangDto ConvertToDto(TChiTietNhapHang entity)
        {
            var dto = new TChiTietNhapHangDto();
            dto.Ma = entity.Ma;
            dto.MaMatHang = entity.MaMatHang;
            dto.MaNhapHang = entity.MaNhapHang;
            dto.SoLuong = entity.SoLuong;
            return dto;
        }

        public override TChiTietNhapHang ConvertToEntity(TChiTietNhapHangDto dto)
        {
            var entity = new TChiTietNhapHang();
            entity.Ma = dto.Ma;
            entity.MaMatHang = dto.MaMatHang;
            entity.MaNhapHang = dto.MaNhapHang;
            entity.SoLuong = dto.SoLuong;
            return entity;
        }
    }
}

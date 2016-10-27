using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public class TChiTietToaHangController : SwaEntityBaseController<PhuDinhServerContext, TChiTietToaHang, TChiTietToaHangDto>
    {
        public override TChiTietToaHangDto ConvertToDto(TChiTietToaHang entity)
        {
            var dto = new TChiTietToaHangDto();
            dto.Ma = entity.Ma;
            dto.GiaTien = entity.GiaTien;
            dto.MaChiTietDonHang = entity.MaChiTietDonHang;
            dto.MaToaHang = entity.MaToaHang;
            return dto;
        }

        public override TChiTietToaHang ConvertToEntity(TChiTietToaHangDto dto)
        {
            var entity = new TChiTietToaHang();
            entity.Ma = dto.Ma;
            entity.GiaTien = dto.GiaTien;
            entity.MaChiTietDonHang = dto.MaChiTietDonHang;
            entity.MaToaHang = dto.MaToaHang;
            return entity;
        }
    }
}

using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public class TNhanTienKhachHangController : SwaEntityBaseController<PhuDinhServerContext, TNhanTienKhachHang, TNhanTienKhachHangDto>
    {
        public override TNhanTienKhachHangDto ConvertToDto(TNhanTienKhachHang entity)
        {
            var dto = new TNhanTienKhachHangDto();
            dto.Ma = entity.Ma;
            dto.MaKhachHang = entity.MaKhachHang;
            dto.Ngay = entity.Ngay;
            dto.SoTien = entity.SoTien;
            return dto;
        }

        public override TNhanTienKhachHang ConvertToEntity(TNhanTienKhachHangDto dto)
        {
            var entity = new TNhanTienKhachHang();
            entity.Ma = dto.Ma;
            entity.MaKhachHang = dto.MaKhachHang;
            entity.Ngay = dto.Ngay;
            entity.SoTien = dto.SoTien;
            return entity;
        }
    }
}

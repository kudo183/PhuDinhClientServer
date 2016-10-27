using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public class TToaHangController : SwaEntityBaseController<PhuDinhServerContext, TToaHang, TToaHangDto>
    {
        public override TToaHangDto ConvertToDto(TToaHang entity)
        {
            var dto = new TToaHangDto();
            dto.Ma = entity.Ma;
            dto.MaKhachHang = entity.MaKhachHang;
            dto.Ngay = entity.Ngay;
            return dto;
        }

        public override TToaHang ConvertToEntity(TToaHangDto dto)
        {
            var entity = new TToaHang();
            entity.Ma = dto.Ma;
            entity.MaKhachHang = dto.MaKhachHang;
            entity.Ngay = dto.Ngay;
            return entity;
        }
    }
}

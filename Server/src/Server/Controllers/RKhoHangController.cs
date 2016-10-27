using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public class RKhoHangController : SwaEntityBaseController<PhuDinhServerContext, RKhoHang, RKhoHangDto>
    {
        public override RKhoHangDto ConvertToDto(RKhoHang entity)
        {
            var dto = new RKhoHangDto();
            dto.Ma = entity.Ma;
            dto.TenKho = entity.TenKho;
            dto.TrangThai = entity.TrangThai;
            return dto;
        }

        public override RKhoHang ConvertToEntity(RKhoHangDto dto)
        {
            var entity = new RKhoHang();
            entity.Ma = dto.Ma;
            entity.TenKho = dto.TenKho;
            entity.TrangThai = dto.TrangThai;
            return entity;
        }
    }
}

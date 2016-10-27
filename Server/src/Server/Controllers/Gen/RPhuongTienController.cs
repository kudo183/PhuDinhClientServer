using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RPhuongTienController : SwaEntityBaseController<PhuDinhServerContext, RPhuongTien, RPhuongTienDto>
    {
        public override RPhuongTienDto ConvertToDto(RPhuongTien entity)
        {
            var dto = new RPhuongTienDto();
            dto.Ma = entity.Ma;
            dto.TenPhuongTien = entity.TenPhuongTien;
            return dto;
        }

        public override RPhuongTien ConvertToEntity(RPhuongTienDto dto)
        {
            var entity = new RPhuongTien();
            entity.Ma = dto.Ma;
            entity.TenPhuongTien = dto.TenPhuongTien;
            return entity;
        }
    }
}

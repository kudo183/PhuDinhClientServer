using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RPhuongTienController : SwaEntityBaseController<PhuDinhServerContext, RPhuongTien, RPhuongTienDto>
    {
        partial void ConvertToDtoPartial(ref RPhuongTienDto dto, RPhuongTien entity);
        partial void ConvertToEntityPartial(ref RPhuongTien entity, RPhuongTienDto dto);

        public override RPhuongTienDto ConvertToDto(RPhuongTien entity)
        {
            var dto = new RPhuongTienDto();
            dto.GroupID = entity.GroupID;
            dto.ID = entity.ID;
            dto.TenPhuongTien = entity.TenPhuongTien;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override RPhuongTien ConvertToEntity(RPhuongTienDto dto)
        {
            var entity = new RPhuongTien();
            entity.GroupID = dto.GroupID;
            entity.ID = dto.ID;
            entity.TenPhuongTien = dto.TenPhuongTien;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

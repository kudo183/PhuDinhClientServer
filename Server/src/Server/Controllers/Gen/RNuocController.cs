using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RNuocController : SwaEntityBaseController<PhuDinhServerContext, RNuoc, RNuocDto>
    {
        partial void ConvertToDtoPartial(ref RNuocDto dto, RNuoc entity);
        partial void ConvertToEntityPartial(ref RNuoc entity, RNuocDto dto);

        public override RNuocDto ConvertToDto(RNuoc entity)
        {
            var dto = new RNuocDto();
            dto.GroupID = entity.GroupID;
            dto.Ma = entity.Ma;
            dto.TenNuoc = entity.TenNuoc;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override RNuoc ConvertToEntity(RNuocDto dto)
        {
            var entity = new RNuoc();
            entity.GroupID = dto.GroupID;
            entity.Ma = dto.Ma;
            entity.TenNuoc = dto.TenNuoc;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

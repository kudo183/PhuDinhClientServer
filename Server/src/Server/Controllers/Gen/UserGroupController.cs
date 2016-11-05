using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class UserGroupController : SwaEntityBaseController<PhuDinhServerContext, UserGroup, UserGroupDto>
    {
        partial void ConvertToDtoPartial(ref UserGroupDto dto, UserGroup entity);
        partial void ConvertToEntityPartial(ref UserGroup entity, UserGroupDto dto);

        public override UserGroupDto ConvertToDto(UserGroup entity)
        {
            var dto = new UserGroupDto();
            dto.LaChuGroup = entity.LaChuGroup;
            dto.Ma = entity.Ma;
            dto.MaGroup = entity.MaGroup;
            dto.MaUser = entity.MaUser;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override UserGroup ConvertToEntity(UserGroupDto dto)
        {
            var entity = new UserGroup();
            entity.LaChuGroup = dto.LaChuGroup;
            entity.Ma = dto.Ma;
            entity.MaGroup = dto.MaGroup;
            entity.MaUser = dto.MaUser;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

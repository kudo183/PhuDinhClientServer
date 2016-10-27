using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public class UserGroupController : SwaEntityBaseController<PhuDinhServerContext, UserGroup, UserGroupDto>
    {
        public override UserGroupDto ConvertToDto(UserGroup entity)
        {
            var dto = new UserGroupDto();
            dto.Ma = entity.Ma;
            dto.LaChuGroup = entity.LaChuGroup;
            dto.MaGroup = entity.MaGroup;
            dto.MaUser = entity.MaUser;
            return dto;
        }

        public override UserGroup ConvertToEntity(UserGroupDto dto)
        {
            var entity = new UserGroup();
            entity.Ma = dto.Ma;
            entity.LaChuGroup = dto.LaChuGroup;
            entity.MaGroup = dto.MaGroup;
            entity.MaUser = dto.MaUser;
            return entity;
        }
    }
}

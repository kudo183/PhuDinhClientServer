using huypq.SwaMiddleware;
using DTO;
using Server.Entities;

namespace Server.Controllers
{
    public class GroupController : SwaEntityBaseController<PhuDinhServerContext, Group, GroupDto>
    {
        public override GroupDto ConvertToDto(Group entity)
        {
            var dto = new GroupDto();
            dto.Ma = entity.Ma;
            dto.TenGroup = entity.TenGroup;
            dto.NgayTao = entity.NgayTao;
            return dto;
        }

        public override Group ConvertToEntity(GroupDto dto)
        {
            var entity = new Group();
            entity.Ma = dto.Ma;
            entity.TenGroup = dto.TenGroup;
            entity.NgayTao = dto.NgayTao;
            return entity;
        }
    }
}

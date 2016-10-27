using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class GroupController : SwaEntityBaseController<PhuDinhServerContext, Group, GroupDto>
    {
        public override GroupDto ConvertToDto(Group entity)
        {
            var dto = new GroupDto();
            dto.Ma = entity.Ma;
            dto.NgayTao = entity.NgayTao;
            dto.TenGroup = entity.TenGroup;
            return dto;
        }

        public override Group ConvertToEntity(GroupDto dto)
        {
            var entity = new Group();
            entity.Ma = dto.Ma;
            entity.NgayTao = dto.NgayTao;
            entity.TenGroup = dto.TenGroup;
            return entity;
        }
    }
}

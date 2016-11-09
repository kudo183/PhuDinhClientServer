using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    //public partial class GroupController : SwaEntityBaseController<PhuDinhServerContext, Group, GroupDto>
    //{
    //    partial void ConvertToDtoPartial(ref GroupDto dto, Group entity);
    //    partial void ConvertToEntityPartial(ref Group entity, GroupDto dto);

    //    public override GroupDto ConvertToDto(Group entity)
    //    {
    //        var dto = new GroupDto();
    //        dto.Ma = entity.Ma;
    //        dto.NgayTao = entity.NgayTao;
    //        dto.TenGroup = entity.TenGroup;

    //        ConvertToDtoPartial(ref dto, entity);

    //        return dto;
    //    }

    //    public override Group ConvertToEntity(GroupDto dto)
    //    {
    //        var entity = new Group();
    //        entity.Ma = dto.Ma;
    //        entity.NgayTao = dto.NgayTao;
    //        entity.TenGroup = dto.TenGroup;

    //        ConvertToEntityPartial(ref entity, dto);

    //        return entity;
    //    }
    //}
}

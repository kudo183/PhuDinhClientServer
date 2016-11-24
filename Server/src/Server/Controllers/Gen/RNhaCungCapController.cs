using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RNhaCungCapController : SwaEntityBaseController<PhuDinhServerContext, RNhaCungCap, RNhaCungCapDto>
    {
        partial void ConvertToDtoPartial(ref RNhaCungCapDto dto, RNhaCungCap entity);
        partial void ConvertToEntityPartial(ref RNhaCungCap entity, RNhaCungCapDto dto);

        public override RNhaCungCapDto ConvertToDto(RNhaCungCap entity)
        {
            var dto = new RNhaCungCapDto();
            dto.GroupID = entity.GroupID;
            dto.ID = entity.ID;
            dto.TenNhaCungCap = entity.TenNhaCungCap;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override RNhaCungCap ConvertToEntity(RNhaCungCapDto dto)
        {
            var entity = new RNhaCungCap();
            entity.GroupID = dto.GroupID;
            entity.ID = dto.ID;
            entity.TenNhaCungCap = dto.TenNhaCungCap;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

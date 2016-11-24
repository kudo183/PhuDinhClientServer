using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RChanhController : SwaEntityBaseController<PhuDinhServerContext, RChanh, RChanhDto>
    {
        partial void ConvertToDtoPartial(ref RChanhDto dto, RChanh entity);
        partial void ConvertToEntityPartial(ref RChanh entity, RChanhDto dto);

        public override RChanhDto ConvertToDto(RChanh entity)
        {
            var dto = new RChanhDto();
            dto.GroupID = entity.GroupID;
            dto.ID = entity.ID;
            dto.MaBaiXe = entity.MaBaiXe;
            dto.TenChanh = entity.TenChanh;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override RChanh ConvertToEntity(RChanhDto dto)
        {
            var entity = new RChanh();
            entity.GroupID = dto.GroupID;
            entity.ID = dto.ID;
            entity.MaBaiXe = dto.MaBaiXe;
            entity.TenChanh = dto.TenChanh;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

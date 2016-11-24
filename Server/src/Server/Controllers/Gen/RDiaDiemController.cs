using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RDiaDiemController : SwaEntityBaseController<PhuDinhServerContext, RDiaDiem, RDiaDiemDto>
    {
        partial void ConvertToDtoPartial(ref RDiaDiemDto dto, RDiaDiem entity);
        partial void ConvertToEntityPartial(ref RDiaDiem entity, RDiaDiemDto dto);

        public override RDiaDiemDto ConvertToDto(RDiaDiem entity)
        {
            var dto = new RDiaDiemDto();
            dto.GroupID = entity.GroupID;
            dto.ID = entity.ID;
            dto.MaNuoc = entity.MaNuoc;
            dto.Tinh = entity.Tinh;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override RDiaDiem ConvertToEntity(RDiaDiemDto dto)
        {
            var entity = new RDiaDiem();
            entity.GroupID = dto.GroupID;
            entity.ID = dto.ID;
            entity.MaNuoc = dto.MaNuoc;
            entity.Tinh = dto.Tinh;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

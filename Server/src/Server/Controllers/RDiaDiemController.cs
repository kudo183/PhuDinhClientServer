using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public class RDiaDiemController : SwaEntityBaseController<PhuDinhServerContext, RDiaDiem, RDiaDiemDto>
    {
        public override RDiaDiemDto ConvertToDto(RDiaDiem entity)
        {
            var dto = new RDiaDiemDto();
            dto.Ma = entity.Ma;
            dto.MaNuoc = entity.MaNuoc;
            dto.Tinh = entity.Tinh;
            return dto;
        }

        public override RDiaDiem ConvertToEntity(RDiaDiemDto dto)
        {
            var entity = new RDiaDiem();
            entity.Ma = dto.Ma;
            entity.MaNuoc = dto.MaNuoc;
            entity.Tinh = dto.Tinh;
            return entity;
        }
    }
}

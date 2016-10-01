using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public class RChanhController : SwaEntityBaseController<PhuDinhServerContext, RChanh, RChanhDto>
    {
        public override RChanhDto ConvertToDto(RChanh entity)
        {
            var dto = new RChanhDto();
            dto.Ma = entity.Ma;
            dto.MaBaiXe = entity.MaBaiXe;
            dto.TenChanh = entity.TenChanh;
            return dto;
        }

        public override RChanh ConvertToEntity(RChanhDto dto)
        {
            var entity = new RChanh();
            entity.Ma = dto.Ma;
            entity.MaBaiXe = dto.MaBaiXe;
            entity.TenChanh = dto.TenChanh;
            return entity;
        }
    }
}

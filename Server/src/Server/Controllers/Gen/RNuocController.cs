using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RNuocController : SwaEntityBaseController<PhuDinhServerContext, RNuoc, RNuocDto>
    {
        public override RNuocDto ConvertToDto(RNuoc entity)
        {
            var dto = new RNuocDto();
            dto.Ma = entity.Ma;
            dto.TenNuoc = entity.TenNuoc;
            return dto;
        }

        public override RNuoc ConvertToEntity(RNuocDto dto)
        {
            var entity = new RNuoc();
            entity.Ma = dto.Ma;
            entity.TenNuoc = dto.TenNuoc;
            return entity;
        }
    }
}

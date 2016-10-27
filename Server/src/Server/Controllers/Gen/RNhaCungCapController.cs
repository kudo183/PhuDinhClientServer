using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RNhaCungCapController : SwaEntityBaseController<PhuDinhServerContext, RNhaCungCap, RNhaCungCapDto>
    {
        public override RNhaCungCapDto ConvertToDto(RNhaCungCap entity)
        {
            var dto = new RNhaCungCapDto();
            dto.Ma = entity.Ma;
            dto.TenNhaCungCap = entity.TenNhaCungCap;
            return dto;
        }

        public override RNhaCungCap ConvertToEntity(RNhaCungCapDto dto)
        {
            var entity = new RNhaCungCap();
            entity.Ma = dto.Ma;
            entity.TenNhaCungCap = dto.TenNhaCungCap;
            return entity;
        }
    }
}

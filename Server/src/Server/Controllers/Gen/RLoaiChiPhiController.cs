using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RLoaiChiPhiController : SwaEntityBaseController<PhuDinhServerContext, RLoaiChiPhi, RLoaiChiPhiDto>
    {
        public override RLoaiChiPhiDto ConvertToDto(RLoaiChiPhi entity)
        {
            var dto = new RLoaiChiPhiDto();
            dto.Ma = entity.Ma;
            dto.TenLoaiChiPhi = entity.TenLoaiChiPhi;
            return dto;
        }

        public override RLoaiChiPhi ConvertToEntity(RLoaiChiPhiDto dto)
        {
            var entity = new RLoaiChiPhi();
            entity.Ma = dto.Ma;
            entity.TenLoaiChiPhi = dto.TenLoaiChiPhi;
            return entity;
        }
    }
}

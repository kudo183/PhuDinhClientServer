using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RLoaiChiPhiController : SwaEntityBaseController<PhuDinhServerContext, RLoaiChiPhi, RLoaiChiPhiDto>
    {
        partial void ConvertToDtoPartial(ref RLoaiChiPhiDto dto, RLoaiChiPhi entity);
        partial void ConvertToEntityPartial(ref RLoaiChiPhi entity, RLoaiChiPhiDto dto);

        public override RLoaiChiPhiDto ConvertToDto(RLoaiChiPhi entity)
        {
            var dto = new RLoaiChiPhiDto();
            dto.GroupID = entity.GroupID;
            dto.Ma = entity.Ma;
            dto.TenLoaiChiPhi = entity.TenLoaiChiPhi;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override RLoaiChiPhi ConvertToEntity(RLoaiChiPhiDto dto)
        {
            var entity = new RLoaiChiPhi();
            entity.GroupID = dto.GroupID;
            entity.Ma = dto.Ma;
            entity.TenLoaiChiPhi = dto.TenLoaiChiPhi;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

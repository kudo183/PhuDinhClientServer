using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RKhoHangController : SwaEntityBaseController<PhuDinhServerContext, RKhoHang, RKhoHangDto>
    {
        partial void ConvertToDtoPartial(ref RKhoHangDto dto, RKhoHang entity);
        partial void ConvertToEntityPartial(ref RKhoHang entity, RKhoHangDto dto);

        public override RKhoHangDto ConvertToDto(RKhoHang entity)
        {
            var dto = new RKhoHangDto();
            dto.GroupID = entity.GroupID;
            dto.ID = entity.ID;
            dto.TenKho = entity.TenKho;
            dto.TrangThai = entity.TrangThai;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override RKhoHang ConvertToEntity(RKhoHangDto dto)
        {
            var entity = new RKhoHang();
            entity.GroupID = dto.GroupID;
            entity.ID = dto.ID;
            entity.TenKho = dto.TenKho;
            entity.TrangThai = dto.TrangThai;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

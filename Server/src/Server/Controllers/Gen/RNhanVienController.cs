using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RNhanVienController : SwaEntityBaseController<PhuDinhServerContext, RNhanVien, RNhanVienDto>
    {
        partial void ConvertToDtoPartial(ref RNhanVienDto dto, RNhanVien entity);
        partial void ConvertToEntityPartial(ref RNhanVien entity, RNhanVienDto dto);

        public override RNhanVienDto ConvertToDto(RNhanVien entity)
        {
            var dto = new RNhanVienDto();
            dto.Ma = entity.Ma;
            dto.MaPhuongTien = entity.MaPhuongTien;
            dto.TenNhanVien = entity.TenNhanVien;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override RNhanVien ConvertToEntity(RNhanVienDto dto)
        {
            var entity = new RNhanVien();
            entity.Ma = dto.Ma;
            entity.MaPhuongTien = dto.MaPhuongTien;
            entity.TenNhanVien = dto.TenNhanVien;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

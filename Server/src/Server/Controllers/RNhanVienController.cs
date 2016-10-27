using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public class RNhanVienController : SwaEntityBaseController<PhuDinhServerContext, RNhanVien, RNhanVienDto>
    {
        public override RNhanVienDto ConvertToDto(RNhanVien entity)
        {
            var dto = new RNhanVienDto();
            dto.Ma = entity.Ma;
            dto.MaPhuongTien = entity.MaPhuongTien;
            dto.TenNhanVien = entity.TenNhanVien;
            return dto;
        }

        public override RNhanVien ConvertToEntity(RNhanVienDto dto)
        {
            var entity = new RNhanVien();
            entity.Ma = dto.Ma;
            entity.MaPhuongTien = dto.MaPhuongTien;
            entity.TenNhanVien = dto.TenNhanVien;
            return entity;
        }
    }
}

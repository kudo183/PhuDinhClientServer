using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TCongNoKhachHangController : SwaEntityBaseController<PhuDinhServerContext, TCongNoKhachHang, TCongNoKhachHangDto>
    {
        partial void ConvertToDtoPartial(ref TCongNoKhachHangDto dto, TCongNoKhachHang entity);
        partial void ConvertToEntityPartial(ref TCongNoKhachHang entity, TCongNoKhachHangDto dto);

        public override TCongNoKhachHangDto ConvertToDto(TCongNoKhachHang entity)
        {
            var dto = new TCongNoKhachHangDto();
            dto.Ma = entity.Ma;
            dto.MaKhachHang = entity.MaKhachHang;
            dto.Ngay = entity.Ngay;
            dto.SoTien = entity.SoTien;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override TCongNoKhachHang ConvertToEntity(TCongNoKhachHangDto dto)
        {
            var entity = new TCongNoKhachHang();
            entity.Ma = dto.Ma;
            entity.MaKhachHang = dto.MaKhachHang;
            entity.Ngay = dto.Ngay;
            entity.SoTien = dto.SoTien;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

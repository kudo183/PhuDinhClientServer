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
            dto.GroupID = entity.GroupID;
            dto.ID = entity.ID;
            dto.MaKhachHang = entity.MaKhachHang;
            dto.Ngay = entity.Ngay;
            dto.SoTien = entity.SoTien;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override TCongNoKhachHang ConvertToEntity(TCongNoKhachHangDto dto)
        {
            var entity = new TCongNoKhachHang();
            entity.GroupID = dto.GroupID;
            entity.ID = dto.ID;
            entity.MaKhachHang = dto.MaKhachHang;
            entity.Ngay = dto.Ngay;
            entity.SoTien = dto.SoTien;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

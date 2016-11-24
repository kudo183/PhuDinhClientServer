using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TNhanTienKhachHangController : SwaEntityBaseController<PhuDinhServerContext, TNhanTienKhachHang, TNhanTienKhachHangDto>
    {
        partial void ConvertToDtoPartial(ref TNhanTienKhachHangDto dto, TNhanTienKhachHang entity);
        partial void ConvertToEntityPartial(ref TNhanTienKhachHang entity, TNhanTienKhachHangDto dto);

        public override TNhanTienKhachHangDto ConvertToDto(TNhanTienKhachHang entity)
        {
            var dto = new TNhanTienKhachHangDto();
            dto.GroupID = entity.GroupID;
            dto.ID = entity.ID;
            dto.MaKhachHang = entity.MaKhachHang;
            dto.Ngay = entity.Ngay;
            dto.SoTien = entity.SoTien;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override TNhanTienKhachHang ConvertToEntity(TNhanTienKhachHangDto dto)
        {
            var entity = new TNhanTienKhachHang();
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

using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TToaHangController : SwaEntityBaseController<PhuDinhServerContext, TToaHang, TToaHangDto>
    {
        partial void ConvertToDtoPartial(ref TToaHangDto dto, TToaHang entity);
        partial void ConvertToEntityPartial(ref TToaHang entity, TToaHangDto dto);

        public override TToaHangDto ConvertToDto(TToaHang entity)
        {
            var dto = new TToaHangDto();
            dto.GroupID = entity.GroupID;
            dto.Ma = entity.Ma;
            dto.MaKhachHang = entity.MaKhachHang;
            dto.Ngay = entity.Ngay;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override TToaHang ConvertToEntity(TToaHangDto dto)
        {
            var entity = new TToaHang();
            entity.GroupID = dto.GroupID;
            entity.Ma = dto.Ma;
            entity.MaKhachHang = dto.MaKhachHang;
            entity.Ngay = dto.Ngay;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

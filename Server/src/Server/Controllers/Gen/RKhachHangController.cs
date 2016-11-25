using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RKhachHangController : SwaEntityBaseController<PhuDinhServerContext, RKhachHang, RKhachHangDto>
    {
        partial void ConvertToDtoPartial(ref RKhachHangDto dto, RKhachHang entity);
        partial void ConvertToEntityPartial(ref RKhachHang entity, RKhachHangDto dto);

        public override RKhachHangDto ConvertToDto(RKhachHang entity)
        {
            var dto = new RKhachHangDto();
            dto.GroupID = entity.GroupID;
            dto.KhachRieng = entity.KhachRieng;
            dto.Ma = entity.Ma;
            dto.MaDiaDiem = entity.MaDiaDiem;
            dto.TenKhachHang = entity.TenKhachHang;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override RKhachHang ConvertToEntity(RKhachHangDto dto)
        {
            var entity = new RKhachHang();
            entity.GroupID = dto.GroupID;
            entity.KhachRieng = dto.KhachRieng;
            entity.Ma = dto.Ma;
            entity.MaDiaDiem = dto.MaDiaDiem;
            entity.TenKhachHang = dto.TenKhachHang;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

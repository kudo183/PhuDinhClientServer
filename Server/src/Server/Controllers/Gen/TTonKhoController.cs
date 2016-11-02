using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TTonKhoController : SwaEntityBaseController<PhuDinhServerContext, TTonKho, TTonKhoDto>
    {
        partial void ConvertToDtoPartial(ref TTonKhoDto dto, TTonKho entity);
        partial void ConvertToEntityPartial(ref TTonKho entity, TTonKhoDto dto);

        public override TTonKhoDto ConvertToDto(TTonKho entity)
        {
            var dto = new TTonKhoDto();
            dto.Ma = entity.Ma;
            dto.MaKhoHang = entity.MaKhoHang;
            dto.MaMatHang = entity.MaMatHang;
            dto.Ngay = entity.Ngay;
            dto.SoLuong = entity.SoLuong;
            dto.SoLuongCu = entity.SoLuongCu;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override TTonKho ConvertToEntity(TTonKhoDto dto)
        {
            var entity = new TTonKho();
            entity.Ma = dto.Ma;
            entity.MaKhoHang = dto.MaKhoHang;
            entity.MaMatHang = dto.MaMatHang;
            entity.Ngay = dto.Ngay;
            entity.SoLuong = dto.SoLuong;
            entity.SoLuongCu = dto.SoLuongCu;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

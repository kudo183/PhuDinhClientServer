using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RKhachHangChanhController : SwaEntityBaseController<PhuDinhServerContext, RKhachHangChanh, RKhachHangChanhDto>
    {
        partial void ConvertToDtoPartial(ref RKhachHangChanhDto dto, RKhachHangChanh entity);
        partial void ConvertToEntityPartial(ref RKhachHangChanh entity, RKhachHangChanhDto dto);

        public override RKhachHangChanhDto ConvertToDto(RKhachHangChanh entity)
        {
            var dto = new RKhachHangChanhDto();
            dto.Ma = entity.Ma;
            dto.LaMacDinh = entity.LaMacDinh;
            dto.MaChanh = entity.MaChanh;
            dto.MaKhachHang = entity.MaKhachHang;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override RKhachHangChanh ConvertToEntity(RKhachHangChanhDto dto)
        {
            var entity = new RKhachHangChanh();
            entity.Ma = dto.Ma;
            entity.LaMacDinh = dto.LaMacDinh;
            entity.MaChanh = dto.MaChanh;
            entity.MaKhachHang = dto.MaKhachHang;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

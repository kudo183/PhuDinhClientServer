using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public class RKhachHangChanhController 
        : SwaEntityBaseController<PhuDinhServerContext, RKhachHangChanh, RKhachHangChanhDto>
    {
        public override RKhachHangChanhDto ConvertToDto(RKhachHangChanh entity)
        {
            var dto = new RKhachHangChanhDto();
            dto.Ma = entity.Ma;
            dto.LaMacDinh = entity.LaMacDinh;
            dto.MaChanh = entity.MaChanh;
            dto.MaKhachHang = entity.MaKhachHang;
            return dto;
        }

        public override RKhachHangChanh ConvertToEntity(RKhachHangChanhDto dto)
        {
            var entity = new RKhachHangChanh();
            entity.Ma = dto.Ma;
            entity.LaMacDinh = dto.LaMacDinh;
            entity.MaChanh = dto.MaChanh;
            entity.MaKhachHang = dto.MaKhachHang;
            return entity;
        }
    }
}

using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RNguyenLieuController : SwaEntityBaseController<PhuDinhServerContext, RNguyenLieu, RNguyenLieuDto>
    {
        public override RNguyenLieuDto ConvertToDto(RNguyenLieu entity)
        {
            var dto = new RNguyenLieuDto();
            dto.Ma = entity.Ma;
            dto.DuongKinh = entity.DuongKinh;
            dto.MaLoaiNguyenLieu = entity.MaLoaiNguyenLieu;
            return dto;
        }

        public override RNguyenLieu ConvertToEntity(RNguyenLieuDto dto)
        {
            var entity = new RNguyenLieu();
            entity.Ma = dto.Ma;
            entity.DuongKinh = dto.DuongKinh;
            entity.MaLoaiNguyenLieu = dto.MaLoaiNguyenLieu;
            return entity;
        }
    }
}

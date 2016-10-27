using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public class RMatHangNguyenLieuController : SwaEntityBaseController<PhuDinhServerContext, RMatHangNguyenLieu, RMatHangNguyenLieuDto>
    {
        public override RMatHangNguyenLieuDto ConvertToDto(RMatHangNguyenLieu entity)
        {
            var dto = new RMatHangNguyenLieuDto();
            dto.Ma = entity.Ma;
            dto.MaMatHang = entity.MaMatHang;
            dto.MaNguyenLieu = entity.MaNguyenLieu;
            return dto;
        }

        public override RMatHangNguyenLieu ConvertToEntity(RMatHangNguyenLieuDto dto)
        {
            var entity = new RMatHangNguyenLieu();
            entity.Ma = dto.Ma;
            entity.MaMatHang = dto.MaMatHang;
            entity.MaNguyenLieu = dto.MaNguyenLieu;
            return entity;
        }
    }
}

using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RMatHangNguyenLieuController : SwaEntityBaseController<PhuDinhServerContext, RMatHangNguyenLieu, RMatHangNguyenLieuDto>
    {
        partial void ConvertToDtoPartial(ref RMatHangNguyenLieuDto dto, RMatHangNguyenLieu entity);
        partial void ConvertToEntityPartial(ref RMatHangNguyenLieu entity, RMatHangNguyenLieuDto dto);

        public override RMatHangNguyenLieuDto ConvertToDto(RMatHangNguyenLieu entity)
        {
            var dto = new RMatHangNguyenLieuDto();
            dto.GroupID = entity.GroupID;
            dto.Ma = entity.Ma;
            dto.MaMatHang = entity.MaMatHang;
            dto.MaNguyenLieu = entity.MaNguyenLieu;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override RMatHangNguyenLieu ConvertToEntity(RMatHangNguyenLieuDto dto)
        {
            var entity = new RMatHangNguyenLieu();
            entity.GroupID = dto.GroupID;
            entity.Ma = dto.Ma;
            entity.MaMatHang = dto.MaMatHang;
            entity.MaNguyenLieu = dto.MaNguyenLieu;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

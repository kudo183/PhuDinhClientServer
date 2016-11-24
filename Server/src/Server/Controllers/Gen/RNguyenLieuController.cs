using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RNguyenLieuController : SwaEntityBaseController<PhuDinhServerContext, RNguyenLieu, RNguyenLieuDto>
    {
        partial void ConvertToDtoPartial(ref RNguyenLieuDto dto, RNguyenLieu entity);
        partial void ConvertToEntityPartial(ref RNguyenLieu entity, RNguyenLieuDto dto);

        public override RNguyenLieuDto ConvertToDto(RNguyenLieu entity)
        {
            var dto = new RNguyenLieuDto();
            dto.DuongKinh = entity.DuongKinh;
            dto.GroupID = entity.GroupID;
            dto.ID = entity.ID;
            dto.MaLoaiNguyenLieu = entity.MaLoaiNguyenLieu;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override RNguyenLieu ConvertToEntity(RNguyenLieuDto dto)
        {
            var entity = new RNguyenLieu();
            entity.DuongKinh = dto.DuongKinh;
            entity.GroupID = dto.GroupID;
            entity.ID = dto.ID;
            entity.MaLoaiNguyenLieu = dto.MaLoaiNguyenLieu;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

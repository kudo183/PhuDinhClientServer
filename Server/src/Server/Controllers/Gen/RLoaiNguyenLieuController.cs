using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RLoaiNguyenLieuController : SwaEntityBaseController<PhuDinhServerContext, RLoaiNguyenLieu, RLoaiNguyenLieuDto>
    {
        partial void ConvertToDtoPartial(ref RLoaiNguyenLieuDto dto, RLoaiNguyenLieu entity);
        partial void ConvertToEntityPartial(ref RLoaiNguyenLieu entity, RLoaiNguyenLieuDto dto);

        public override RLoaiNguyenLieuDto ConvertToDto(RLoaiNguyenLieu entity)
        {
            var dto = new RLoaiNguyenLieuDto();
            dto.GroupID = entity.GroupID;
            dto.Ma = entity.Ma;
            dto.TenLoai = entity.TenLoai;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override RLoaiNguyenLieu ConvertToEntity(RLoaiNguyenLieuDto dto)
        {
            var entity = new RLoaiNguyenLieu();
            entity.GroupID = dto.GroupID;
            entity.Ma = dto.Ma;
            entity.TenLoai = dto.TenLoai;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

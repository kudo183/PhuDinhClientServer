using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TNhapNguyenLieuController : SwaEntityBaseController<PhuDinhServerContext, TNhapNguyenLieu, TNhapNguyenLieuDto>
    {
        partial void ConvertToDtoPartial(ref TNhapNguyenLieuDto dto, TNhapNguyenLieu entity);
        partial void ConvertToEntityPartial(ref TNhapNguyenLieu entity, TNhapNguyenLieuDto dto);

        public override TNhapNguyenLieuDto ConvertToDto(TNhapNguyenLieu entity)
        {
            var dto = new TNhapNguyenLieuDto();
            dto.GroupID = entity.GroupID;
            dto.Ma = entity.Ma;
            dto.MaNguyenLieu = entity.MaNguyenLieu;
            dto.MaNhaCungCap = entity.MaNhaCungCap;
            dto.Ngay = entity.Ngay;
            dto.SoLuong = entity.SoLuong;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override TNhapNguyenLieu ConvertToEntity(TNhapNguyenLieuDto dto)
        {
            var entity = new TNhapNguyenLieu();
            entity.GroupID = dto.GroupID;
            entity.Ma = dto.Ma;
            entity.MaNguyenLieu = dto.MaNguyenLieu;
            entity.MaNhaCungCap = dto.MaNhaCungCap;
            entity.Ngay = dto.Ngay;
            entity.SoLuong = dto.SoLuong;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

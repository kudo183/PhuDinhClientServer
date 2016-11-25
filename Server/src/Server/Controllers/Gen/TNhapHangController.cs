using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TNhapHangController : SwaEntityBaseController<PhuDinhServerContext, TNhapHang, TNhapHangDto>
    {
        partial void ConvertToDtoPartial(ref TNhapHangDto dto, TNhapHang entity);
        partial void ConvertToEntityPartial(ref TNhapHang entity, TNhapHangDto dto);

        public override TNhapHangDto ConvertToDto(TNhapHang entity)
        {
            var dto = new TNhapHangDto();
            dto.GroupID = entity.GroupID;
            dto.Ma = entity.Ma;
            dto.MaKhoHang = entity.MaKhoHang;
            dto.MaNhaCungCap = entity.MaNhaCungCap;
            dto.MaNhanVien = entity.MaNhanVien;
            dto.Ngay = entity.Ngay;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override TNhapHang ConvertToEntity(TNhapHangDto dto)
        {
            var entity = new TNhapHang();
            entity.GroupID = dto.GroupID;
            entity.Ma = dto.Ma;
            entity.MaKhoHang = dto.MaKhoHang;
            entity.MaNhaCungCap = dto.MaNhaCungCap;
            entity.MaNhanVien = dto.MaNhanVien;
            entity.Ngay = dto.Ngay;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

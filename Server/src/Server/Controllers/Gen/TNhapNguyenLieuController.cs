using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TNhapNguyenLieuController : SwaEntityBaseController<PhuDinhServerContext, TNhapNguyenLieu, TNhapNguyenLieuDto>
    {
        public override TNhapNguyenLieuDto ConvertToDto(TNhapNguyenLieu entity)
        {
            var dto = new TNhapNguyenLieuDto();
            dto.Ma = entity.Ma;
            dto.MaNguyenLieu = entity.MaNguyenLieu;
            dto.MaNhaCungCap = entity.MaNhaCungCap;
            dto.Ngay = entity.Ngay;
            dto.SoLuong = entity.SoLuong;
            return dto;
        }

        public override TNhapNguyenLieu ConvertToEntity(TNhapNguyenLieuDto dto)
        {
            var entity = new TNhapNguyenLieu();
            entity.Ma = dto.Ma;
            entity.MaNguyenLieu = dto.MaNguyenLieu;
            entity.MaNhaCungCap = dto.MaNhaCungCap;
            entity.Ngay = dto.Ngay;
            entity.SoLuong = dto.SoLuong;
            return entity;
        }
    }
}

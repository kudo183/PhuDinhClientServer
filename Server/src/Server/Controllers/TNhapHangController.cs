using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public class TNhapHangController : SwaEntityBaseController<PhuDinhServerContext, TNhapHang, TNhapHangDto>
    {
        public override TNhapHangDto ConvertToDto(TNhapHang entity)
        {
            var dto = new TNhapHangDto();
            dto.Ma = entity.Ma;
            dto.MaKhoHang = entity.MaKhoHang;
            dto.MaNhaCungCap = entity.MaNhaCungCap;
            dto.MaNhanVien = entity.MaNhanVien;
            dto.Ngay = entity.Ngay;
            return dto;
        }

        public override TNhapHang ConvertToEntity(TNhapHangDto dto)
        {
            var entity = new TNhapHang();
            entity.Ma = dto.Ma;
            entity.MaKhoHang = dto.MaKhoHang;
            entity.MaNhaCungCap = dto.MaNhaCungCap;
            entity.MaNhanVien = dto.MaNhanVien;
            entity.Ngay = dto.Ngay;
            return entity;
        }
    }
}

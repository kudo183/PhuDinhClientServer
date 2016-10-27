using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TChuyenKhoController : SwaEntityBaseController<PhuDinhServerContext, TChuyenKho, TChuyenKhoDto>
    {
        public override TChuyenKhoDto ConvertToDto(TChuyenKho entity)
        {
            var dto = new TChuyenKhoDto();
            dto.Ma = entity.Ma;
            dto.MaKhoHangNhap = entity.MaKhoHangNhap;
            dto.MaKhoHangXuat = entity.MaKhoHangXuat;
            dto.MaNhanVien = entity.MaNhanVien;
            dto.Ngay = entity.Ngay;
            return dto;
        }

        public override TChuyenKho ConvertToEntity(TChuyenKhoDto dto)
        {
            var entity = new TChuyenKho();
            entity.Ma = dto.Ma;
            entity.MaKhoHangNhap = dto.MaKhoHangNhap;
            entity.MaKhoHangXuat = dto.MaKhoHangXuat;
            entity.MaNhanVien = dto.MaNhanVien;
            entity.Ngay = dto.Ngay;
            return entity;
        }
    }
}

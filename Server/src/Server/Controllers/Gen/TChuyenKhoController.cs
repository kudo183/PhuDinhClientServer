using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TChuyenKhoController : SwaEntityBaseController<PhuDinhServerContext, TChuyenKho, TChuyenKhoDto>
    {
        partial void ConvertToDtoPartial(ref TChuyenKhoDto dto, TChuyenKho entity);
        partial void ConvertToEntityPartial(ref TChuyenKho entity, TChuyenKhoDto dto);

        public override TChuyenKhoDto ConvertToDto(TChuyenKho entity)
        {
            var dto = new TChuyenKhoDto();
            dto.Ma = entity.Ma;
            dto.MaKhoHangNhap = entity.MaKhoHangNhap;
            dto.MaKhoHangXuat = entity.MaKhoHangXuat;
            dto.MaNhanVien = entity.MaNhanVien;
            dto.Ngay = entity.Ngay;

            ConvertToDtoPartial(ref dto, entity);

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

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TChiTietChuyenKhoController : SwaEntityBaseController<PhuDinhServerContext, TChiTietChuyenKho, TChiTietChuyenKhoDto>
    {
        partial void ConvertToDtoPartial(ref TChiTietChuyenKhoDto dto, TChiTietChuyenKho entity);
        partial void ConvertToEntityPartial(ref TChiTietChuyenKho entity, TChiTietChuyenKhoDto dto);

        public override TChiTietChuyenKhoDto ConvertToDto(TChiTietChuyenKho entity)
        {
            var dto = new TChiTietChuyenKhoDto();
            dto.Ma = entity.Ma;
            dto.MaChuyenKho = entity.MaChuyenKho;
            dto.MaMatHang = entity.MaMatHang;
            dto.SoLuong = entity.SoLuong;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override TChiTietChuyenKho ConvertToEntity(TChiTietChuyenKhoDto dto)
        {
            var entity = new TChiTietChuyenKho();
            entity.Ma = dto.Ma;
            entity.MaChuyenKho = dto.MaChuyenKho;
            entity.MaMatHang = dto.MaMatHang;
            entity.SoLuong = dto.SoLuong;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

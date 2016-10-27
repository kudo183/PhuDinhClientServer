using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public class TChiTietChuyenKhoController : SwaEntityBaseController<PhuDinhServerContext, TChiTietChuyenKho, TChiTietChuyenKhoDto>
    {
        public override TChiTietChuyenKhoDto ConvertToDto(TChiTietChuyenKho entity)
        {
            var dto = new TChiTietChuyenKhoDto();
            dto.Ma = entity.Ma;
            dto.MaChuyenKho = entity.MaChuyenKho;
            dto.MaMatHang = entity.MaMatHang;
            dto.SoLuong = entity.SoLuong;
            return dto;
        }

        public override TChiTietChuyenKho ConvertToEntity(TChiTietChuyenKhoDto dto)
        {
            var entity = new TChiTietChuyenKho();
            entity.Ma = dto.Ma;
            entity.MaChuyenKho = dto.MaChuyenKho;
            entity.MaMatHang = dto.MaMatHang;
            entity.SoLuong = dto.SoLuong;
            return entity;
        }
    }
}

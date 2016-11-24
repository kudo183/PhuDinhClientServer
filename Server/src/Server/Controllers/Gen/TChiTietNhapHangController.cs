using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TChiTietNhapHangController : SwaEntityBaseController<PhuDinhServerContext, TChiTietNhapHang, TChiTietNhapHangDto>
    {
        partial void ConvertToDtoPartial(ref TChiTietNhapHangDto dto, TChiTietNhapHang entity);
        partial void ConvertToEntityPartial(ref TChiTietNhapHang entity, TChiTietNhapHangDto dto);

        public override TChiTietNhapHangDto ConvertToDto(TChiTietNhapHang entity)
        {
            var dto = new TChiTietNhapHangDto();
            dto.GroupID = entity.GroupID;
            dto.ID = entity.ID;
            dto.MaMatHang = entity.MaMatHang;
            dto.MaNhapHang = entity.MaNhapHang;
            dto.SoLuong = entity.SoLuong;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override TChiTietNhapHang ConvertToEntity(TChiTietNhapHangDto dto)
        {
            var entity = new TChiTietNhapHang();
            entity.GroupID = dto.GroupID;
            entity.ID = dto.ID;
            entity.MaMatHang = dto.MaMatHang;
            entity.MaNhapHang = dto.MaNhapHang;
            entity.SoLuong = dto.SoLuong;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

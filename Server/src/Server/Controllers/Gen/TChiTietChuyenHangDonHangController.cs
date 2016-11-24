using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TChiTietChuyenHangDonHangController : SwaEntityBaseController<PhuDinhServerContext, TChiTietChuyenHangDonHang, TChiTietChuyenHangDonHangDto>
    {
        partial void ConvertToDtoPartial(ref TChiTietChuyenHangDonHangDto dto, TChiTietChuyenHangDonHang entity);
        partial void ConvertToEntityPartial(ref TChiTietChuyenHangDonHang entity, TChiTietChuyenHangDonHangDto dto);

        public override TChiTietChuyenHangDonHangDto ConvertToDto(TChiTietChuyenHangDonHang entity)
        {
            var dto = new TChiTietChuyenHangDonHangDto();
            dto.GroupID = entity.GroupID;
            dto.ID = entity.ID;
            dto.MaChiTietDonHang = entity.MaChiTietDonHang;
            dto.MaChuyenHangDonHang = entity.MaChuyenHangDonHang;
            dto.SoLuong = entity.SoLuong;
            dto.SoLuongTheoDonHang = entity.SoLuongTheoDonHang;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override TChiTietChuyenHangDonHang ConvertToEntity(TChiTietChuyenHangDonHangDto dto)
        {
            var entity = new TChiTietChuyenHangDonHang();
            entity.GroupID = dto.GroupID;
            entity.ID = dto.ID;
            entity.MaChiTietDonHang = dto.MaChiTietDonHang;
            entity.MaChuyenHangDonHang = dto.MaChuyenHangDonHang;
            entity.SoLuong = dto.SoLuong;
            entity.SoLuongTheoDonHang = dto.SoLuongTheoDonHang;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

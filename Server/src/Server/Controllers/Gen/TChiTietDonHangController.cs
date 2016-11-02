using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TChiTietDonHangController : SwaEntityBaseController<PhuDinhServerContext, TChiTietDonHang, TChiTietDonHangDto>
    {
        partial void ConvertToDtoPartial(ref TChiTietDonHangDto dto, TChiTietDonHang entity);
        partial void ConvertToEntityPartial(ref TChiTietDonHang entity, TChiTietDonHangDto dto);

        public override TChiTietDonHangDto ConvertToDto(TChiTietDonHang entity)
        {
            var dto = new TChiTietDonHangDto();
            dto.Ma = entity.Ma;
            dto.MaDonHang = entity.MaDonHang;
            dto.MaMatHang = entity.MaMatHang;
            dto.SoLuong = entity.SoLuong;
            dto.Xong = entity.Xong;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override TChiTietDonHang ConvertToEntity(TChiTietDonHangDto dto)
        {
            var entity = new TChiTietDonHang();
            entity.Ma = dto.Ma;
            entity.MaDonHang = dto.MaDonHang;
            entity.MaMatHang = dto.MaMatHang;
            entity.SoLuong = dto.SoLuong;
            entity.Xong = dto.Xong;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

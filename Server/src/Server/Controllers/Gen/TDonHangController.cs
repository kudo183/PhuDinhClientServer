using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TDonHangController : SwaEntityBaseController<PhuDinhServerContext, TDonHang, TDonHangDto>
    {
        partial void ConvertToDtoPartial(ref TDonHangDto dto, TDonHang entity);
        partial void ConvertToEntityPartial(ref TDonHang entity, TDonHangDto dto);

        public override TDonHangDto ConvertToDto(TDonHang entity)
        {
            var dto = new TDonHangDto();
            dto.GroupID = entity.GroupID;
            dto.Ma = entity.Ma;
            dto.MaChanh = entity.MaChanh;
            dto.MaKhachHang = entity.MaKhachHang;
            dto.MaKhoHang = entity.MaKhoHang;
            dto.Ngay = entity.Ngay;
            dto.TongSoLuong = entity.TongSoLuong;
            dto.Xong = entity.Xong;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override TDonHang ConvertToEntity(TDonHangDto dto)
        {
            var entity = new TDonHang();
            entity.GroupID = dto.GroupID;
            entity.Ma = dto.Ma;
            entity.MaChanh = dto.MaChanh;
            entity.MaKhachHang = dto.MaKhachHang;
            entity.MaKhoHang = dto.MaKhoHang;
            entity.Ngay = dto.Ngay;
            entity.TongSoLuong = dto.TongSoLuong;
            entity.Xong = dto.Xong;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

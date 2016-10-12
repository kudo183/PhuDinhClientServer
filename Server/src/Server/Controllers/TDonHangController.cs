using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public class TDonHangController : SwaEntityBaseController<PhuDinhServerContext, TDonHang, TDonHangDto>
    {        
        public override TDonHangDto ConvertToDto(TDonHang entity)
        {
            var dto = new TDonHangDto();
            dto.Ma = entity.Ma;
            dto.MaChanh = entity.MaChanh;
            dto.MaKhachHang = entity.MaKhachHang;
            dto.MaKhoHang = entity.MaKhoHang;
            dto.Ngay = entity.Ngay;
            dto.TongSoLuong = entity.TongSoLuong;
            dto.Xong = entity.Xong;
            return dto;
        }

        public override TDonHang ConvertToEntity(TDonHangDto dto)
        {
            var entity = new TDonHang();
            entity.Ma = dto.Ma;
            entity.MaChanh = dto.MaChanh;
            entity.MaKhachHang = dto.MaKhachHang;
            entity.MaKhoHang = dto.MaKhoHang;
            entity.Ngay = dto.Ngay;
            entity.TongSoLuong = dto.TongSoLuong;
            entity.Xong = dto.Xong;
            return entity;
        }
    }
}

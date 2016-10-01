using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public class TMatHangController : SwaEntityBaseController<PhuDinhServerContext, TMatHang, TMatHangDto>
    {
        public override TMatHangDto ConvertToDto(TMatHang entity)
        {
            var dto = new TMatHangDto();
            dto.Ma = entity.Ma;
            dto.MaLoai = entity.MaLoai;
            dto.SoMet = entity.SoMet;
            dto.SoKy = entity.SoKy;
            dto.TenMatHang = entity.TenMatHang;
            dto.TenMatHangDayDu = entity.TenMatHangDayDu;
            dto.TenMatHangIn = entity.TenMatHangIn;
            return dto;
        }

        public override TMatHang ConvertToEntity(TMatHangDto dto)
        {
            var entity = new TMatHang();
            entity.Ma = dto.Ma;
            entity.MaLoai = dto.MaLoai;
            entity.SoMet = dto.SoMet;
            entity.SoKy = dto.SoKy;
            entity.TenMatHang = dto.TenMatHang;
            entity.TenMatHangDayDu = dto.TenMatHangDayDu;
            entity.TenMatHangIn = dto.TenMatHangIn;
            return entity;
        }
    }
}

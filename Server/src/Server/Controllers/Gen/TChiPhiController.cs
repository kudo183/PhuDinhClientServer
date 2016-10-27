using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TChiPhiController : SwaEntityBaseController<PhuDinhServerContext, TChiPhi, TChiPhiDto>
    {
        public override TChiPhiDto ConvertToDto(TChiPhi entity)
        {
            var dto = new TChiPhiDto();
            dto.Ma = entity.Ma;
            dto.GhiChu = entity.GhiChu;
            dto.MaLoaiChiPhi = entity.MaLoaiChiPhi;
            dto.MaNhanVienGiaoHang = entity.MaNhanVienGiaoHang;
            dto.Ngay = entity.Ngay;
            dto.SoTien = entity.SoTien;
            return dto;
        }

        public override TChiPhi ConvertToEntity(TChiPhiDto dto)
        {
            var entity = new TChiPhi();
            entity.Ma = dto.Ma;
            entity.GhiChu = dto.GhiChu;
            entity.MaLoaiChiPhi = dto.MaLoaiChiPhi;
            entity.MaNhanVienGiaoHang = dto.MaNhanVienGiaoHang;
            entity.Ngay = dto.Ngay;
            entity.SoTien = dto.SoTien;
            return entity;
        }
    }
}

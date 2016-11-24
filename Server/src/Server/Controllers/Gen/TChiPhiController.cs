using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TChiPhiController : SwaEntityBaseController<PhuDinhServerContext, TChiPhi, TChiPhiDto>
    {
        partial void ConvertToDtoPartial(ref TChiPhiDto dto, TChiPhi entity);
        partial void ConvertToEntityPartial(ref TChiPhi entity, TChiPhiDto dto);

        public override TChiPhiDto ConvertToDto(TChiPhi entity)
        {
            var dto = new TChiPhiDto();
            dto.GhiChu = entity.GhiChu;
            dto.GroupID = entity.GroupID;
            dto.ID = entity.ID;
            dto.MaLoaiChiPhi = entity.MaLoaiChiPhi;
            dto.MaNhanVienGiaoHang = entity.MaNhanVienGiaoHang;
            dto.Ngay = entity.Ngay;
            dto.SoTien = entity.SoTien;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override TChiPhi ConvertToEntity(TChiPhiDto dto)
        {
            var entity = new TChiPhi();
            entity.GhiChu = dto.GhiChu;
            entity.GroupID = dto.GroupID;
            entity.ID = dto.ID;
            entity.MaLoaiChiPhi = dto.MaLoaiChiPhi;
            entity.MaNhanVienGiaoHang = dto.MaNhanVienGiaoHang;
            entity.Ngay = dto.Ngay;
            entity.SoTien = dto.SoTien;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

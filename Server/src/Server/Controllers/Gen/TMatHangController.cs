using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TMatHangController : SwaEntityBaseController<PhuDinhServerContext, TMatHang, TMatHangDto>
    {
        partial void ConvertToDtoPartial(ref TMatHangDto dto, TMatHang entity);
        partial void ConvertToEntityPartial(ref TMatHang entity, TMatHangDto dto);

        public override TMatHangDto ConvertToDto(TMatHang entity)
        {
            var dto = new TMatHangDto();
            dto.GroupID = entity.GroupID;
            dto.ID = entity.ID;
            dto.MaLoai = entity.MaLoai;
            dto.SoKy = entity.SoKy;
            dto.SoMet = entity.SoMet;
            dto.TenMatHang = entity.TenMatHang;
            dto.TenMatHangDayDu = entity.TenMatHangDayDu;
            dto.TenMatHangIn = entity.TenMatHangIn;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override TMatHang ConvertToEntity(TMatHangDto dto)
        {
            var entity = new TMatHang();
            entity.GroupID = dto.GroupID;
            entity.ID = dto.ID;
            entity.MaLoai = dto.MaLoai;
            entity.SoKy = dto.SoKy;
            entity.SoMet = dto.SoMet;
            entity.TenMatHang = dto.TenMatHang;
            entity.TenMatHangDayDu = dto.TenMatHangDayDu;
            entity.TenMatHangIn = dto.TenMatHangIn;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

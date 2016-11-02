using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TGiamTruKhachHangController : SwaEntityBaseController<PhuDinhServerContext, TGiamTruKhachHang, TGiamTruKhachHangDto>
    {
        partial void ConvertToDtoPartial(ref TGiamTruKhachHangDto dto, TGiamTruKhachHang entity);
        partial void ConvertToEntityPartial(ref TGiamTruKhachHang entity, TGiamTruKhachHangDto dto);

        public override TGiamTruKhachHangDto ConvertToDto(TGiamTruKhachHang entity)
        {
            var dto = new TGiamTruKhachHangDto();
            dto.Ma = entity.Ma;
            dto.GhiChu = entity.GhiChu;
            dto.MaKhachHang = entity.MaKhachHang;
            dto.Ngay = entity.Ngay;
            dto.SoTien = entity.SoTien;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override TGiamTruKhachHang ConvertToEntity(TGiamTruKhachHangDto dto)
        {
            var entity = new TGiamTruKhachHang();
            entity.Ma = dto.Ma;
            entity.GhiChu = dto.GhiChu;
            entity.MaKhachHang = dto.MaKhachHang;
            entity.Ngay = dto.Ngay;
            entity.SoTien = dto.SoTien;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

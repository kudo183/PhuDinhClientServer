using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RLoaiHangController : SwaEntityBaseController<PhuDinhServerContext, RLoaiHang, RLoaiHangDto>
    {
        partial void ConvertToDtoPartial(ref RLoaiHangDto dto, RLoaiHang entity);
        partial void ConvertToEntityPartial(ref RLoaiHang entity, RLoaiHangDto dto);

        public override RLoaiHangDto ConvertToDto(RLoaiHang entity)
        {
            var dto = new RLoaiHangDto();
            dto.HangNhaLam = entity.HangNhaLam;
            dto.Ma = entity.Ma;
            dto.TenLoai = entity.TenLoai;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override RLoaiHang ConvertToEntity(RLoaiHangDto dto)
        {
            var entity = new RLoaiHang();
            entity.HangNhaLam = dto.HangNhaLam;
            entity.Ma = dto.Ma;
            entity.TenLoai = dto.TenLoai;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

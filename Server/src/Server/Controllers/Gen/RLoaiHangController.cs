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
            dto.GroupID = entity.GroupID;
            dto.HangNhaLam = entity.HangNhaLam;
            dto.ID = entity.ID;
            dto.TenLoai = entity.TenLoai;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override RLoaiHang ConvertToEntity(RLoaiHangDto dto)
        {
            var entity = new RLoaiHang();
            entity.GroupID = dto.GroupID;
            entity.HangNhaLam = dto.HangNhaLam;
            entity.ID = dto.ID;
            entity.TenLoai = dto.TenLoai;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

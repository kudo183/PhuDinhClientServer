using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class ThamSoNgayController : SwaEntityBaseController<PhuDinhServerContext, ThamSoNgay, ThamSoNgayDto>
    {
        partial void ConvertToDtoPartial(ref ThamSoNgayDto dto, ThamSoNgay entity);
        partial void ConvertToEntityPartial(ref ThamSoNgay entity, ThamSoNgayDto dto);

        public override ThamSoNgayDto ConvertToDto(ThamSoNgay entity)
        {
            var dto = new ThamSoNgayDto();
            dto.Ma = entity.Ma;
            dto.GiaTri = entity.GiaTri;
            dto.Ten = entity.Ten;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override ThamSoNgay ConvertToEntity(ThamSoNgayDto dto)
        {
            var entity = new ThamSoNgay();
            entity.Ma = dto.Ma;
            entity.GiaTri = dto.GiaTri;
            entity.Ten = dto.Ten;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

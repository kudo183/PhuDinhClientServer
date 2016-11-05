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
            dto.GiaTri = entity.GiaTri;
            dto.Ma = entity.Ma;
            dto.Ten = entity.Ten;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override ThamSoNgay ConvertToEntity(ThamSoNgayDto dto)
        {
            var entity = new ThamSoNgay();
            entity.GiaTri = dto.GiaTri;
            entity.Ma = dto.Ma;
            entity.Ten = dto.Ten;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class ThamSoNgayController : SwaEntityBaseController<PhuDinhServerContext, ThamSoNgay, ThamSoNgayDto>
    {
        public override ThamSoNgayDto ConvertToDto(ThamSoNgay entity)
        {
            var dto = new ThamSoNgayDto();
            dto.Ma = entity.Ma;
            dto.GiaTri = entity.GiaTri;
            dto.Ten = entity.Ten;
            return dto;
        }

        public override ThamSoNgay ConvertToEntity(ThamSoNgayDto dto)
        {
            var entity = new ThamSoNgay();
            entity.Ma = dto.Ma;
            entity.GiaTri = dto.GiaTri;
            entity.Ten = dto.Ten;
            return entity;
        }
    }
}

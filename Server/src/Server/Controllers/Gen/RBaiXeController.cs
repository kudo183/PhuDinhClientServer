using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RBaiXeController : SwaEntityBaseController<PhuDinhServerContext, RBaiXe, RBaiXeDto>
    {
        partial void ConvertToDtoPartial(ref RBaiXeDto dto, RBaiXe entity);
        partial void ConvertToEntityPartial(ref RBaiXe entity, RBaiXeDto dto);

        public override RBaiXeDto ConvertToDto(RBaiXe entity)
        {
            var dto = new RBaiXeDto();
            dto.DiaDiemBaiXe = entity.DiaDiemBaiXe;
            dto.Ma = entity.Ma;

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override RBaiXe ConvertToEntity(RBaiXeDto dto)
        {
            var entity = new RBaiXe();
            entity.DiaDiemBaiXe = dto.DiaDiemBaiXe;
            entity.Ma = dto.Ma;

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
    }
}

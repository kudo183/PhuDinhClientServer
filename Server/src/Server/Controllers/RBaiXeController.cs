using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public class RBaiXeController : SwaEntityBaseController<PhuDinhServerContext, RBaiXe, RBaiXeDto>
    {
        public override RBaiXeDto ConvertToDto(RBaiXe entity)
        {
            var dto = new RBaiXeDto();
            dto.Ma = entity.Ma;
            dto.DiaDiemBaiXe = entity.DiaDiemBaiXe;
            return dto;
        }

        public override RBaiXe ConvertToEntity(RBaiXeDto dto)
        {
            var entity = new RBaiXe();
            entity.Ma = dto.Ma;
            entity.DiaDiemBaiXe = dto.DiaDiemBaiXe;
            return entity;
        }
    }
}

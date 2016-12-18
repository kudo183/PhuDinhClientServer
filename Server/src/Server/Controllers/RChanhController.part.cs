using huypq.SwaMiddleware;
using Server.Entities;
using DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    public partial class RChanhController : SwaEntityBaseController<PhuDinhServerContext, RChanh, RChanhDto>
    {
        partial void ConvertToDtoPartial(ref RChanhDto dto, RChanh entity)
        {
            dto.RBaiXe = new RBaiXeDto();
            dto.RBaiXe.DiaDiemBaiXe = entity.MaBaiXeNavigation.DiaDiemBaiXe;
        }

        protected override IQueryable<RChanh> GetQuery()
        {
            var q = base.GetQuery();
            return q.Include(p => p.MaBaiXeNavigation);
        }
    }
}

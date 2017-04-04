using huypq.SwaMiddleware;
using Server.Entities;
using DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    public partial class TChuyenKhoController : SwaEntityBaseController<PhuDinhServerContext, TChuyenKho, TChuyenKhoDto>
    {
        partial void ConvertToDtoPartial(ref TChuyenKhoDto dto, TChuyenKho entity)
        {
            dto.TongSoLuong = entity.TChiTietChuyenKhoMaChuyenKhoNavigation
                .Sum(p => p.SoLuong);
        }

        protected override IQueryable<TChuyenKho> GetQuery()
        {
            var q = base.GetQuery();
            return q.Include(p => p.TChiTietChuyenKhoMaChuyenKhoNavigation);
        }
    }
}

using huypq.SwaMiddleware;
using Server.Entities;
using DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    public partial class TToaHangController : SwaEntityBaseController<PhuDinhServerContext, TToaHang, TToaHangDto>
    {
        partial void ConvertToDtoPartial(ref TToaHangDto dto, TToaHang entity)
        {
            dto.ThanhTien = entity.TChiTietToaHangMaToaHangNavigation
                .Sum(p => p.GiaTien * p.MaChiTietDonHangNavigation.SoLuong);
        }

        protected override IQueryable<TToaHang> GetQuery()
        {
            var q = base.GetQuery();
            return q.Include(p => p.TChiTietToaHangMaToaHangNavigation)
                .ThenInclude(p=>p.MaChiTietDonHangNavigation);
        }
    }
}

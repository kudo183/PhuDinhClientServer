using huypq.SwaMiddleware;
using Server.Entities;
using DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Server.Controllers
{
    public partial class TNhapHangController : SwaEntityBaseController<PhuDinhServerContext, TNhapHang, TNhapHangDto>
    {
        partial void ConvertToDtoPartial(ref TNhapHangDto dto, TNhapHang entity)
        {
            dto.TongSoLuong = entity.TChiTietNhapHangMaNhapHangNavigation
                .Sum(p => p.SoLuong);
        }

        protected override IQueryable<TNhapHang> GetQuery()
        {
            var q = base.GetQuery();
            return q.Include(p => p.TChiTietNhapHangMaNhapHangNavigation);
        }

        protected override void AfterSave()
        {
            //because sql trigger updated MaKhoHang, Ngay of TTonKho
            TTonKhoController.IncreaseVersionNumber();
        }
    }
}

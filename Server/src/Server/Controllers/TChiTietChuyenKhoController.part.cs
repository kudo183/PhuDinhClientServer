using huypq.SwaMiddleware;
using Server.Entities;
using DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    public partial class TChiTietChuyenKhoController : SwaEntityBaseController<PhuDinhServerContext, TChiTietChuyenKho, TChiTietChuyenKhoDto>
    {
        partial void ConvertToDtoPartial(ref TChiTietChuyenKhoDto dto, TChiTietChuyenKho entity)
        {
            dto.TChuyenKho = new TChuyenKhoDto();
            dto.TChuyenKho.MaKhoHangXuat = entity.MaChuyenKhoNavigation.MaKhoHangXuat;
            dto.TChuyenKho.MaKhoHangNhap = entity.MaChuyenKhoNavigation.MaKhoHangNhap;
            dto.TChuyenKho.Ngay = entity.MaChuyenKhoNavigation.Ngay;
        }

        protected override IQueryable<TChiTietChuyenKho> GetQuery()
        {
            var q = base.GetQuery();
            return q.Include(p => p.MaChuyenKhoNavigation);
        }
    }
}

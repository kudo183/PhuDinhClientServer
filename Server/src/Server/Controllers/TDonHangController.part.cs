using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TDonHangController : SwaEntityBaseController<PhuDinhServerContext, TDonHang, TDonHangDto>
    {
        protected override void AfterSave()
        {
            //because sql trigger updated MaKhoHang, Ngay of TTonKho
            TTonKhoController.IncreaseVersionNumber(TokenModel.GroupId);
            //because sql trigger updated TongSoLuongTheoDonHang of TChuyenHang
            TChuyenHangController.IncreaseVersionNumber(TokenModel.GroupId);
            //because sql trigger updated TongSoLuongTheoDonHang of TChuyenHangDonHang
            TChuyenHangDonHangController.IncreaseVersionNumber(TokenModel.GroupId);
        }

        protected override void UpdateEntity(PhuDinhServerContext context, TDonHang entity)
        {
            var entry = context.TDonHang.Attach(entity);
            entry.Property(p => p.Ngay).IsModified = true;
            entry.Property(p => p.MaKhachHang).IsModified = true;
            entry.Property(p => p.MaKhoHang).IsModified = true;
            entry.Property(p => p.MaChanh).IsModified = true;
        }
    }
}

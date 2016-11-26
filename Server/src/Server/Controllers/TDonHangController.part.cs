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
            TTonKhoController.IncreaseVersionNumber();
            //because sql trigger updated TongSoLuongTheoDonHang of TChuyenHang
            TChuyenHangController.IncreaseVersionNumber();
            //because sql trigger updated TongSoLuongTheoDonHang of TChuyenHangDonHang
            TChuyenHangDonHangController.IncreaseVersionNumber();
        }
    }
}

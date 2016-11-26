using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TGiamTruKhachHangController : SwaEntityBaseController<PhuDinhServerContext, TGiamTruKhachHang, TGiamTruKhachHangDto>
    {
        protected override void AfterSave()
        {
            //because sql trigger updated SoTien of TCongNoKhachHang
            TCongNoKhachHangController.IncreaseVersionNumber();
        }
    }
}

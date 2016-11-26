using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TNhapHangController : SwaEntityBaseController<PhuDinhServerContext, TNhapHang, TNhapHangDto>
    {
        protected override void AfterSave()
        {
            //because sql trigger updated MaKhoHang, Ngay of TTonKho
            TTonKhoController.IncreaseVersionNumber();
        }
    }
}

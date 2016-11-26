using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TChuyenKhoController : SwaEntityBaseController<PhuDinhServerContext, TChuyenKho, TChuyenKhoDto>
    {
        protected override void AfterSave()
        {
            //because sql trigger updated MaKhoHangXuat, MaKhoHangNhap, Ngay of TTonKho
            TTonKhoController.IncreaseVersionNumber();
        }
    }
}

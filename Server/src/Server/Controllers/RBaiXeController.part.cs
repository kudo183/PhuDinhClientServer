using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class RBaiXeController : SwaEntityBaseController<PhuDinhServerContext, RBaiXe, RBaiXeDto>
    {
        protected override void AfterSave()
        {
            //because RChanh include RBaiXe
            RChanhController.IncreaseVersionNumber(TokenModel.GroupId);
        }
    }
}

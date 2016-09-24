using huypq.SwaMiddleware;
using Server.DTOs;
using Server.Entities;
using System.Collections.Generic;

namespace Server.Controllers
{
    public class KhoHangController : SwaEntityBaseController<PhuDinhServerContext, KhoHangDto, KhoHang, User>
    {
        public override SwaActionResult ActionInvoker(string actionName, Dictionary<string, object> parameter)
        {
            SwaActionResult result = null;

            switch (actionName)
            {
                case "getall":
                    result = GetAll(DBContext.KhoHang);
                    break;
                case "save":
                    result = Save(parameter["json"].ToString());
                    break;
                case "test":
                    result = Test();
                    break;
                default:
                    break;
            }

            return result;
        }

        public SwaActionResult Test()
        {
            return CreateObjectResult("test Object result");
        }
    }
}

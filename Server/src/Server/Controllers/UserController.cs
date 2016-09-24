using huypq.SwaMiddleware;
using Server.DTOs;
using Server.Entities;

namespace Server.Controllers
{
    public class UserController : SwaUserBaseController<PhuDinhServerContext, UserDto, User, User>
    {
        
    }
}

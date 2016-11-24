using huypq.SwaMiddleware;
using Server.Entities;
using System.Collections.Generic;

namespace Server.Controllers
{
    public class UserController : SwaUserBaseController<PhuDinhServerContext, SwaUser, SwaGroup, SwaUserGroup, DTO.SwaUserDto>
    {
        //public override SwaActionResult ActionInvoker(string actionName, Dictionary<string, object> parameter)
        //{
        //    SwaActionResult result = null;

        //    switch (actionName)
        //    {
        //        case "get":
        //            result = Get(parameter["body"] as System.IO.Stream, GetQuery());
        //            break;
        //        case "save":
        //            //result = Save(parameter["body"] as System.IO.Stream);
        //            break;
        //        default:
        //            result = base.ActionInvoker(actionName, parameter);
        //            break;
        //    }

        //    return result;
        //}

        //public override DTO.UserDto ConvertToDto(User entity)
        //{
        //    var dto = new DTO.UserDto();
        //    dto.Ma = entity.Ma;
        //    dto.Email = entity.Email;
        //    dto.PasswordHash = entity.PasswordHash;
        //    dto.NgayTao = entity.NgayTao;
        //    return dto;
        //}

        //public override User ConvertToEntity(DTO.UserDto dto)
        //{
        //    var entity = new User();
        //    entity.Ma = dto.Ma;
        //    entity.Email = dto.Email;
        //    entity.PasswordHash = dto.PasswordHash;
        //    entity.NgayTao = dto.NgayTao;
        //    return entity;
        //}
    }
}

using huypq.SwaMiddleware;
using Server.Entities;
using System.Collections.Generic;
using System;
using DTO;

namespace Server.Controllers
{
    public class KhoHangController : SwaEntityBaseController<PhuDinhServerContext, KhoHang, DTO.KhoHangDto>
    {
        public override SwaActionResult ActionInvoker(string actionName, Dictionary<string, object> parameter)
        {
            SwaActionResult result = null;

            switch (actionName)
            {
                case "getall":
                    result = CreateObjectResult(GetAll(DBContext.KhoHang));
                    break;
                case "get":
                    result = CreateObjectResult(Get(parameter["body"] as System.IO.Stream, DBContext.KhoHang));
                    break;
                case "save":
                    result = Save(parameter["body"] as System.IO.Stream);
                    break;
                case "test":
                    result = Test();
                    break;
                default:
                    break;
            }

            return result;
        }
        
        public override KhoHangDto ConvertToDto(KhoHang entity)
        {
            var dto = new DTO.KhoHangDto();
            dto.Ma = entity.Ma;
            dto.TenKho = entity.TenKho;
            dto.TrangThai = entity.TrangThai;
            return dto;
        }

        public override KhoHang ConvertToEntity(KhoHangDto dto)
        {
            var entity = new KhoHang();
            entity.Ma = dto.Ma;
            entity.TenKho = dto.TenKho;
            entity.TrangThai = dto.TrangThai;
            return entity;
        }

        public SwaActionResult Test()
        {
            return CreateObjectResult("test Object result");
        }
    }
}

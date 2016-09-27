using huypq.SwaMiddleware;
using Server.Entities;
using System.Collections.Generic;

namespace Server.Controllers
{
    public class KhoHangController : SwaEntityBaseController<PhuDinhServerContext, KhoHang>
    {
        public override SwaActionResult ActionInvoker(string actionName, Dictionary<string, object> parameter)
        {
            SwaActionResult result = null;

            switch (actionName)
            {
                case "getall":
                    var pagingResult = GetAll(DBContext.KhoHang);
                    var pagingResultDto = new DTO.PagingResultDto<DTO.KhoHangDto>();
                    pagingResultDto.PageCount = pagingResult.PageCount;
                    pagingResultDto.PageIndex = pagingResult.PageIndex;
                    pagingResultDto.TotalItemCount = pagingResult.TotalItemCount;
                    pagingResultDto.Items = new List<DTO.KhoHangDto>();
                    foreach(var item in pagingResult.Items)
                    {
                        var khoHangDto = new DTO.KhoHangDto();
                        khoHangDto.Ma = item.Ma;
                        khoHangDto.TenKho = item.TenKho;
                        khoHangDto.TrangThai = item.TrangThai;
                        pagingResultDto.Items.Add(khoHangDto);
                    }
                    result = CreateObjectResult(pagingResultDto);
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

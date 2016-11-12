using System;
using System.Collections.Generic;
using System.Linq;
using huypq.SwaMiddleware;
using Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    public class ReportController : SwaController, IDisposable
    {
        protected PhuDinhServerContext DBContext
        {
            get
            {
                var context = (PhuDinhServerContext)Context.RequestServices.GetService(typeof(PhuDinhServerContext));
                return context;
            }
        }

        public override SwaActionResult ActionInvoker(string actionName, Dictionary<string, object> parameter)
        {
            SwaActionResult result = null;

            switch (actionName)
            {
                case "daily":
                    result = Daily(parameter["date"].ToString());
                    break;
                default:
                    break;
            }

            return result;
        }

        public SwaActionResult Daily(string dateString)
        {
            var date = ParseDateFromString(dateString);
            var q = GetQuery<TDonHang>().Where(p => p.Ngay == date)
                .Include(p => p.MaKhoHangNavigation)
                .Include(p => p.MaKhachHangNavigation)
                .Include(p => p.TChiTietDonHangMaDonHangNavigation)
                .ThenInclude(p1 => p1.MaMatHangNavigation);

            var result = new List<DTO.Report.DailyReportDto>();

            foreach (var donHang in q)
            {
                var isFirst = true;
                foreach (var ctDonHang in donHang.TChiTietDonHangMaDonHangNavigation)
                {
                    if (isFirst == true)
                    {
                        result.Add(new DTO.Report.DailyReportDto()
                        {
                            TenKho = donHang.MaKhoHangNavigation.TenKho,
                            TenKhachHang = donHang.MaKhachHangNavigation.TenKhachHang,
                            TenMatHang = ctDonHang.MaMatHangNavigation.TenMatHangIn,
                            SoLuong = ctDonHang.SoLuong,
                            SoKg=ctDonHang.MaMatHangNavigation.SoKy
                        });
                        isFirst = false;
                        continue;
                    }

                    result.Add(new DTO.Report.DailyReportDto()
                    {
                        TenMatHang = ctDonHang.MaMatHangNavigation.TenMatHangIn,
                        SoLuong = ctDonHang.SoLuong,
                        SoKg = ctDonHang.MaMatHangNavigation.SoKy
                    });
                }
                result.Add(new DTO.Report.DailyReportDto());
            }
            return CreateObjectResult(result);
        }

        private DateTime ParseDateFromString(string date)
        {
            int year = int.Parse(date.Substring(0, 4));
            int mon = int.Parse(date.Substring(4, 2));
            int day = int.Parse(date.Substring(6, 2));

            return new DateTime(year, mon, day);
        }

        public IQueryable<T> GetQuery<T>() where T : class, SwaIEntity
        {
            return DBContext.Set<T>().Where(p => p.MaGroup == TokenModel.GroupId);
        }

        public void Dispose()
        {
            if (DBContext != null)
            {
                DBContext.Dispose();
            }
        }
    }
}

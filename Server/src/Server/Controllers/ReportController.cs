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
                    var date = ParseDateFromString(parameter["date"].ToString());
                    result = Daily(date);
                    break;
                case "chiphi":
                    var dateFrom = ParseDateFromString(parameter["dateFrom"].ToString());
                    var dateTo = ParseDateFromString(parameter["dateTo"].ToString());
                    result = ChiPhi(dateFrom, dateTo);
                    break;
                case "xuat":
                    dateFrom = ParseDateFromString(parameter["dateFrom"].ToString());
                    dateTo = ParseDateFromString(parameter["dateTo"].ToString());
                    result = Xuat(dateFrom, dateTo);
                    break;
                default:
                    break;
            }

            return result;
        }

        public SwaActionResult Daily(DateTime date)
        {
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
                            SoKg = ctDonHang.MaMatHangNavigation.SoKy
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

        public SwaActionResult ChiPhi(DateTime dateFrom, DateTime dateTo)
        {
            var q = GetQuery<TChiPhi>().Where(p => p.Ngay >= dateFrom && p.Ngay <= dateTo)
                .Include(p => p.MaLoaiChiPhiNavigation)
                .Include(p => p.MaNhanVienGiaoHangNavigation);

            var result = new List<DTO.Report.ChiPhiReportDto>();

            foreach (var chiPhi in q)
            {
                result.Add(new DTO.Report.ChiPhiReportDto()
                {
                    MaLoaiChiPhi = chiPhi.MaLoaiChiPhi,
                    TenLoaiChiPhi = chiPhi.MaLoaiChiPhiNavigation.TenLoaiChiPhi,
                    MaNhanVien = chiPhi.MaNhanVienGiaoHang,
                    TenNhanVien = chiPhi.MaNhanVienGiaoHangNavigation.TenNhanVien,
                    Ngay = chiPhi.Ngay,
                    SoTien = chiPhi.SoTien,
                    GhiChu = chiPhi.GhiChu
                });
            }

            return CreateObjectResult(result);
        }

        public SwaActionResult Xuat(DateTime dateFrom, DateTime dateTo)
        {
            var q = GetQuery<TDonHang>().Where(p => p.Ngay >= dateFrom && p.Ngay <= dateTo)
                .Include(p => p.MaKhoHangNavigation)
                .Include(p => p.MaKhachHangNavigation)
                .Include(p => p.TChiTietDonHangMaDonHangNavigation)
                .ThenInclude(p1 => p1.MaMatHangNavigation.MaLoaiNavigation);

            var result = new List<DTO.Report.XuatDto>();

            foreach (var donHang in q)
            {
                var xuat = new DTO.Report.XuatDto()
                {
                    MaKho = donHang.MaKhoHang,
                    TenKho = donHang.MaKhoHangNavigation.TenKho,
                    MaKhachHang = donHang.MaKhachHang,
                    TenKhachHang = donHang.MaKhachHangNavigation.TenKhachHang,
                    ChiTietXuat = new List<DTO.Report.ChiTietXuatDto>(),
                    Ngay = donHang.Ngay
                };

                foreach (var ctDonHang in donHang.TChiTietDonHangMaDonHangNavigation)
                {
                    xuat.ChiTietXuat.Add(new DTO.Report.ChiTietXuatDto()
                    {
                        MaLoaiHang = ctDonHang.MaMatHangNavigation.MaLoai,
                        TenLoaiHang = ctDonHang.MaMatHangNavigation.MaLoaiNavigation.TenLoai,
                        MaMatHang = ctDonHang.MaMatHang,
                        TenMatHang = ctDonHang.MaMatHangNavigation.TenMatHangDayDu,
                        SoLuong = ctDonHang.SoLuong,
                        SoKg = ctDonHang.MaMatHangNavigation.SoKy
                    });
                }

                result.Add(xuat);
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
            return DBContext.Set<T>().Where(p => p.GroupID == TokenModel.GroupId);
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

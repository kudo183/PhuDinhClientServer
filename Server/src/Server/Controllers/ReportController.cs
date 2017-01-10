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
                case "khachhang":
                    dateFrom = ParseDateFromString(parameter["dateFrom"].ToString());
                    dateTo = ParseDateFromString(parameter["dateTo"].ToString());
                    var maKhachHang = int.Parse(parameter["maKhachHang"].ToString());
                    result = KhachHang(dateFrom, dateTo, maKhachHang);
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
                .ThenInclude(p1 => p1.MaMatHangNavigation)
                .Include(p => p.TChuyenHangDonHangMaDonHangNavigation)
                .ThenInclude(p => p.MaChuyenHangNavigation)
                .ThenInclude(p => p.MaNhanVienGiaoHangNavigation);

            var result = new List<DTO.Report.DailyReportDto>();

            foreach (var donHang in q)
            {
                var sb = new System.Text.StringBuilder();
                sb.Append(" (");
                foreach (var chdh in donHang.TChuyenHangDonHangMaDonHangNavigation)
                {
                    sb.Append(chdh.MaChuyenHangNavigation.MaNhanVienGiaoHangNavigation.TenNhanVien);
                    sb.Append(", ");
                }
                sb.Remove(sb.Length - 2, 2);
                sb.Append(")");

                var isFirst = true;
                foreach (var ctDonHang in donHang.TChiTietDonHangMaDonHangNavigation)
                {
                    if (isFirst == true)
                    {
                        result.Add(new DTO.Report.DailyReportDto()
                        {
                            TenKho = donHang.MaKhoHangNavigation.TenKho,
                            TenKhachHang = donHang.MaKhachHangNavigation.TenKhachHang + sb.ToString(),
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

        public SwaActionResult KhachHang(DateTime dateFrom, DateTime dateTo, int maKhachHang)
        {
            var q = GetQuery<TDonHang>().Where(p => p.MaKhachHang == maKhachHang && p.Ngay >= dateFrom && p.Ngay <= dateTo)
                .Include(p => p.MaKhoHangNavigation)
                .Include(p => p.TChiTietDonHangMaDonHangNavigation)
                .ThenInclude(p => p.MaMatHangNavigation);

            var result = new List<DTO.Report.KhachHangDto>();

            foreach (var donHang in q)
            {
                var khachHang = new DTO.Report.KhachHangDto()
                {
                    MaKho = donHang.MaKhoHang,
                    TenKho = donHang.MaKhoHangNavigation.TenKho,
                    Ngay = donHang.Ngay,
                    ChiTiet = new List<DTO.Report.ChiTietKhachHangDto>()
                };

                foreach (var ctDonHang in donHang.TChiTietDonHangMaDonHangNavigation)
                {
                    khachHang.ChiTiet.Add(new DTO.Report.ChiTietKhachHangDto()
                    {
                        MaMatHang = ctDonHang.MaMatHang,
                        TenMatHang = ctDonHang.MaMatHangNavigation.TenMatHangDayDu,
                        SoLuong = ctDonHang.SoLuong
                    });
                }

                result.Add(khachHang);
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

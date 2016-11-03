﻿using huypq.SwaMiddleware;
using Server.Entities;
using DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    public partial class TChiTietChuyenHangDonHangController : SwaEntityBaseController<PhuDinhServerContext, TChiTietChuyenHangDonHang, TChiTietChuyenHangDonHangDto>
    {
        partial void ConvertToDtoPartial(ref TChiTietChuyenHangDonHangDto dto, TChiTietChuyenHangDonHang entity)
        {
            dto.TChuyenHangDonHang = new TChuyenHangDonHangDto();
            dto.TChuyenHangDonHang.TChuyenHang = new TChuyenHangDto();
            dto.TChuyenHangDonHang.TChuyenHang.MaNhanVienGiaoHang = entity.MaChuyenHangDonHangNavigation.MaChuyenHangNavigation.MaNhanVienGiaoHang;
            dto.TChuyenHangDonHang.TChuyenHang.Ngay = entity.MaChuyenHangDonHangNavigation.MaChuyenHangNavigation.Ngay;
            dto.TChuyenHangDonHang.TChuyenHang.Gio = entity.MaChuyenHangDonHangNavigation.MaChuyenHangNavigation.Gio;
            dto.TChuyenHangDonHang.TDonHang = new TDonHangDto();
            dto.TChuyenHangDonHang.TDonHang.MaKhachHang = entity.MaChuyenHangDonHangNavigation.MaDonHangNavigation.MaKhachHang;
            dto.TChuyenHangDonHang.TDonHang.MaKhoHang = entity.MaChuyenHangDonHangNavigation.MaDonHangNavigation.MaKhoHang;
            dto.TChuyenHangDonHang.TDonHang.Ngay = entity.MaChuyenHangDonHangNavigation.MaDonHangNavigation.Ngay;
            dto.TChiTietDonHang = new TChiTietDonHangDto();
            dto.TChiTietDonHang.Ma = entity.MaChiTietDonHangNavigation.Ma;
            dto.TChiTietDonHang.MaMatHang = entity.MaChiTietDonHangNavigation.MaMatHang;
            dto.TChiTietDonHang.TDonHang = new TDonHangDto();
            dto.TChiTietDonHang.TDonHang.MaKhachHang = entity.MaChiTietDonHangNavigation.MaDonHangNavigation.MaKhachHang;
            dto.TChiTietDonHang.TDonHang.MaKhoHang = entity.MaChiTietDonHangNavigation.MaDonHangNavigation.MaKhoHang;
            dto.TChiTietDonHang.TDonHang.Ngay = entity.MaChiTietDonHangNavigation.MaDonHangNavigation.Ngay;
        }

        protected override IQueryable<TChiTietChuyenHangDonHang> GetQuery()
        {
            var q = base.GetQuery();
            return q.Include(p => p.MaChuyenHangDonHangNavigation.MaChuyenHangNavigation)
                .Include(p => p.MaChuyenHangDonHangNavigation.MaDonHangNavigation)
                .Include(p => p.MaChiTietDonHangNavigation.MaDonHangNavigation)
                .Include(p => p.MaChiTietDonHangNavigation.MaMatHangNavigation);
        }
    }
}

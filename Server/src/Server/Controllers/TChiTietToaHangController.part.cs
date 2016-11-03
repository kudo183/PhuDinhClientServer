﻿using huypq.SwaMiddleware;
using Server.Entities;
using DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    public partial class TChiTietToaHangController : SwaEntityBaseController<PhuDinhServerContext, TChiTietToaHang, TChiTietToaHangDto>
    {
        partial void ConvertToDtoPartial(ref TChiTietToaHangDto dto, TChiTietToaHang entity)
        {
            dto.TToaHang = new TToaHangDto();
            dto.TToaHang.MaKhachHang = entity.MaToaHangNavigation.MaKhachHang;
            dto.TToaHang.Ngay = entity.MaToaHangNavigation.Ngay;
            dto.TChiTietDonHang = new TChiTietDonHangDto();
            dto.TChiTietDonHang.Ma = entity.MaChiTietDonHangNavigation.Ma;
            dto.TChiTietDonHang.MaMatHang = entity.MaChiTietDonHangNavigation.MaMatHang;
            dto.TChiTietDonHang.TDonHang = new TDonHangDto();
            dto.TChiTietDonHang.TDonHang.MaKhachHang = entity.MaChiTietDonHangNavigation.MaDonHangNavigation.MaKhachHang;
            dto.TChiTietDonHang.TDonHang.MaKhoHang = entity.MaChiTietDonHangNavigation.MaDonHangNavigation.MaKhoHang;
            dto.TChiTietDonHang.TDonHang.Ngay = entity.MaChiTietDonHangNavigation.MaDonHangNavigation.Ngay;
        }

        protected override IQueryable<TChiTietToaHang> GetQuery()
        {
            var q = base.GetQuery();
            return q.Include(p => p.MaToaHangNavigation.MaKhachHangNavigation)
                .Include(p => p.MaChiTietDonHangNavigation.MaDonHangNavigation)
                .Include(p => p.MaChiTietDonHangNavigation.MaMatHangNavigation);
        }
    }
}
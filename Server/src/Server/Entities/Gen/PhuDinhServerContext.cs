using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using huypq.SwaMiddleware;

namespace Server.Entities
{
    public partial class PhuDinhServerContext : DbContext, SwaIDbContext<SwaUser, SwaGroup, SwaUserGroup>
    {
        public PhuDinhServerContext(DbContextOptions<PhuDinhServerContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RBaiXe>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_rBaiXe");

                entity.ToTable("rBaiXe");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");

                entity.Property(e => e.DiaDiemBaiXe)
                    .IsRequired()
                    .HasMaxLength(300);

            });
            modelBuilder.Entity<RCanhBaoTonKho>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_rCanhBaoTonKho");

                entity.ToTable("rCanhBaoTonKho");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaKhoHangNavigation)
                    .WithMany(p => p.RCanhBaoTonKhoMaKhoHangNavigation)
                    .HasForeignKey(d => d.MaKhoHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rCanhBaoTonKho_rKhoHang");

                entity.HasOne(d => d.MaMatHangNavigation)
                    .WithMany(p => p.RCanhBaoTonKhoMaMatHangNavigation)
                    .HasForeignKey(d => d.MaMatHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rCanhBaoTonKho_tMatHang");

            });
            modelBuilder.Entity<RChanh>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_rChanh");

                entity.ToTable("rChanh");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");

                entity.Property(e => e.TenChanh)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.MaBaiXeNavigation)
                    .WithMany(p => p.RChanhMaBaiXeNavigation)
                    .HasForeignKey(d => d.MaBaiXe)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rChanh_rBaiXe");

            });
            modelBuilder.Entity<RDiaDiem>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_rDiaDiem");

                entity.ToTable("rDiaDiem");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");

                entity.Property(e => e.Tinh)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.MaNuocNavigation)
                    .WithMany(p => p.RDiaDiemMaNuocNavigation)
                    .HasForeignKey(d => d.MaNuoc)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rDiaDiem_rNuoc");

            });
            modelBuilder.Entity<RKhachHang>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_rKhachHang");

                entity.ToTable("rKhachHang");

                entity.HasIndex(e => e.TenKhachHang)
                    .HasName("idx_KhachHang_TenKhachHang")
                    .IsUnique();

                entity.Property(e => e.KhachRieng).HasDefaultValueSql("(0)");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");

                entity.Property(e => e.TenKhachHang)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.MaDiaDiemNavigation)
                    .WithMany(p => p.RKhachHangMaDiaDiemNavigation)
                    .HasForeignKey(d => d.MaDiaDiem)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rKhachHang_rDiaDiem");

            });
            modelBuilder.Entity<RKhachHangChanh>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_rKhachHangChanh");

                entity.ToTable("rKhachHangChanh");

                entity.Property(e => e.LaMacDinh).HasDefaultValueSql("(0)");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaChanhNavigation)
                    .WithMany(p => p.RKhachHangChanhMaChanhNavigation)
                    .HasForeignKey(d => d.MaChanh)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rKhachHangChanh_rChanh");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.RKhachHangChanhMaKhachHangNavigation)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rKhachHangChanh_rKhachHang");

            });
            modelBuilder.Entity<RKhoHang>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_rKhoHang");

                entity.ToTable("rKhoHang");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("(1)");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");

                entity.Property(e => e.TenKho)
                    .IsRequired()
                    .HasMaxLength(200);

            });
            modelBuilder.Entity<RLoaiChiPhi>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_rLoaiChiPhi");

                entity.ToTable("rLoaiChiPhi");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");

                entity.Property(e => e.TenLoaiChiPhi)
                    .IsRequired()
                    .HasMaxLength(200);

            });
            modelBuilder.Entity<RLoaiHang>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_rProductType");

                entity.ToTable("rLoaiHang");

                entity.Property(e => e.HangNhaLam).HasDefaultValueSql("(0)");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");

                entity.Property(e => e.TenLoai)
                    .IsRequired()
                    .HasMaxLength(200);

            });
            modelBuilder.Entity<RLoaiNguyenLieu>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_rLoaiNguyenLieu");

                entity.ToTable("rLoaiNguyenLieu");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");

                entity.Property(e => e.TenLoai)
                    .IsRequired()
                    .HasMaxLength(100);

            });
            modelBuilder.Entity<RMatHangNguyenLieu>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_rMatHangNguyenLieu");

                entity.ToTable("rMatHangNguyenLieu");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaNguyenLieuNavigation)
                    .WithMany(p => p.RMatHangNguyenLieuMaNguyenLieuNavigation)
                    .HasForeignKey(d => d.MaNguyenLieu)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rMatHangNguyenLieu_rNguyenLieu");

                entity.HasOne(d => d.MaMatHangNavigation)
                    .WithMany(p => p.RMatHangNguyenLieuMaMatHangNavigation)
                    .HasForeignKey(d => d.MaMatHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rMatHangNguyenLieu_tMatHang");

            });
            modelBuilder.Entity<RNuoc>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_rNuoc");

                entity.ToTable("rNuoc");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");

                entity.Property(e => e.TenNuoc)
                    .IsRequired()
                    .HasMaxLength(100);

            });
            modelBuilder.Entity<RNguyenLieu>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_rNguyenLieu");

                entity.ToTable("rNguyenLieu");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaLoaiNguyenLieuNavigation)
                    .WithMany(p => p.RNguyenLieuMaLoaiNguyenLieuNavigation)
                    .HasForeignKey(d => d.MaLoaiNguyenLieu)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rNguyenLieu_rLoaiNguyenLieu");

            });
            modelBuilder.Entity<RNhaCungCap>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_NhaCungCap");

                entity.ToTable("rNhaCungCap");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");

                entity.Property(e => e.TenNhaCungCap)
                    .IsRequired()
                    .HasMaxLength(200);

            });
            modelBuilder.Entity<RNhanVien>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_NhanVienGiaoHang");

                entity.ToTable("rNhanVien");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");

                entity.Property(e => e.TenNhanVien)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.MaPhuongTienNavigation)
                    .WithMany(p => p.RNhanVienMaPhuongTienNavigation)
                    .HasForeignKey(d => d.MaPhuongTien)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rNhanVienGiaoHang_rPhuongTien");

            });
            modelBuilder.Entity<RPhuongTien>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_LoaiPhuongTien");

                entity.ToTable("rPhuongTien");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");

                entity.Property(e => e.TenPhuongTien)
                    .IsRequired()
                    .HasMaxLength(200);

            });
            modelBuilder.Entity<SwaGroup>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_Group");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("getdate()");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(256);

            });
            modelBuilder.Entity<SwaUser>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_User");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("getdate()");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);
                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(128);

            });
            modelBuilder.Entity<SwaUserGroup>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_UserGroup");


                entity.HasOne(d => d.GroupIDNavigation)
                    .WithMany(p => p.SwaUserGroupGroupIDNavigation)
                    .HasForeignKey(d => d.GroupID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SwaUserGroup_SwaGroup");

                entity.HasOne(d => d.UserIDNavigation)
                    .WithMany(p => p.SwaUserGroupUserIDNavigation)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SwaUserGroup_SwaUser");

            });
            modelBuilder.Entity<TCongNoKhachHang>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_tCongNoKhachHang");

                entity.ToTable("tCongNoKhachHang");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.TCongNoKhachHangMaKhachHangNavigation)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tCongNoKhachHang_rKhachHang");

            });
            modelBuilder.Entity<TChiPhi>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_ChiPhiNhanVienGiaoHang");

                entity.ToTable("tChiPhi");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaLoaiChiPhiNavigation)
                    .WithMany(p => p.TChiPhiMaLoaiChiPhiNavigation)
                    .HasForeignKey(d => d.MaLoaiChiPhi)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiPhiNhanVienGiaoHang_rLoaiChiPhi");

                entity.HasOne(d => d.MaNhanVienGiaoHangNavigation)
                    .WithMany(p => p.TChiPhiMaNhanVienGiaoHangNavigation)
                    .HasForeignKey(d => d.MaNhanVienGiaoHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiPhiNhanVienGiaoHang_rNhanVienGiaoHang");

            });
            modelBuilder.Entity<TChiTietChuyenHangDonHang>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_tChiTietChuyenHangDonHang");

                entity.ToTable("tChiTietChuyenHangDonHang");

                entity.Property(e => e.SoLuongTheoDonHang).HasDefaultValueSql("(0)");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaChiTietDonHangNavigation)
                    .WithMany(p => p.TChiTietChuyenHangDonHangMaChiTietDonHangNavigation)
                    .HasForeignKey(d => d.MaChiTietDonHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiTietChuyenHangDonHang_tChiTietDonHang");

                entity.HasOne(d => d.MaChuyenHangDonHangNavigation)
                    .WithMany(p => p.TChiTietChuyenHangDonHangMaChuyenHangDonHangNavigation)
                    .HasForeignKey(d => d.MaChuyenHangDonHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiTietChuyenHangDonHang_tChuyenHangDonHang");

            });
            modelBuilder.Entity<TChiTietChuyenKho>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_tChiTietChuyenKho");

                entity.ToTable("tChiTietChuyenKho");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaChuyenKhoNavigation)
                    .WithMany(p => p.TChiTietChuyenKhoMaChuyenKhoNavigation)
                    .HasForeignKey(d => d.MaChuyenKho)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiTietChuyenKho_tChuyenKho");

                entity.HasOne(d => d.MaMatHangNavigation)
                    .WithMany(p => p.TChiTietChuyenKhoMaMatHangNavigation)
                    .HasForeignKey(d => d.MaMatHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiTietChuyenKho_tMatHang");

            });
            modelBuilder.Entity<TChiTietDonHang>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_tChiTietDonHang");

                entity.ToTable("tChiTietDonHang");

                entity.Property(e => e.Xong).HasDefaultValueSql("(0)");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaDonHangNavigation)
                    .WithMany(p => p.TChiTietDonHangMaDonHangNavigation)
                    .HasForeignKey(d => d.MaDonHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiTietDonHang_tDonHang");

                entity.HasOne(d => d.MaMatHangNavigation)
                    .WithMany(p => p.TChiTietDonHangMaMatHangNavigation)
                    .HasForeignKey(d => d.MaMatHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiTietDonHang_tMatHang");

            });
            modelBuilder.Entity<TChiTietNhapHang>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_NhapMatHang");

                entity.ToTable("tChiTietNhapHang");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaNhapHangNavigation)
                    .WithMany(p => p.TChiTietNhapHangMaNhapHangNavigation)
                    .HasForeignKey(d => d.MaNhapHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiTietNhapHang_tNhapHang");

                entity.HasOne(d => d.MaMatHangNavigation)
                    .WithMany(p => p.TChiTietNhapHangMaMatHangNavigation)
                    .HasForeignKey(d => d.MaMatHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhapMatHang_tMatHang");

            });
            modelBuilder.Entity<TChiTietToaHang>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_tChiTietToaHang");

                entity.ToTable("tChiTietToaHang");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaChiTietDonHangNavigation)
                    .WithMany(p => p.TChiTietToaHangMaChiTietDonHangNavigation)
                    .HasForeignKey(d => d.MaChiTietDonHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiTietToaHang_tChiTietDonHang");

                entity.HasOne(d => d.MaToaHangNavigation)
                    .WithMany(p => p.TChiTietToaHangMaToaHangNavigation)
                    .HasForeignKey(d => d.MaToaHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiTietToaHang_tToaHang");

            });
            modelBuilder.Entity<TChuyenHang>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_ChuyenHang");

                entity.ToTable("tChuyenHang");

                entity.Property(e => e.Gio).HasDefaultValueSql("getdate()");

                entity.Property(e => e.TongDonHang).HasDefaultValueSql("(0)");

                entity.Property(e => e.TongSoLuongTheoDonHang).HasDefaultValueSql("(0)");

                entity.Property(e => e.TongSoLuongThucTe).HasDefaultValueSql("(0)");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaNhanVienGiaoHangNavigation)
                    .WithMany(p => p.TChuyenHangMaNhanVienGiaoHangNavigation)
                    .HasForeignKey(d => d.MaNhanVienGiaoHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChuyenHang_rNhanVienGiaoHang");

            });
            modelBuilder.Entity<TChuyenHangDonHang>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_tChuyenHangDonHang");

                entity.ToTable("tChuyenHangDonHang");

                entity.Property(e => e.TongSoLuongTheoDonHang).HasDefaultValueSql("(0)");

                entity.Property(e => e.TongSoLuongThucTe).HasDefaultValueSql("(0)");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaChuyenHangNavigation)
                    .WithMany(p => p.TChuyenHangDonHangMaChuyenHangNavigation)
                    .HasForeignKey(d => d.MaChuyenHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChuyenHangDonHang_tChuyenHang");

                entity.HasOne(d => d.MaDonHangNavigation)
                    .WithMany(p => p.TChuyenHangDonHangMaDonHangNavigation)
                    .HasForeignKey(d => d.MaDonHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChuyenHangDonHang_tDonHang");

            });
            modelBuilder.Entity<TChuyenKho>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_tChuyenKho");

                entity.ToTable("tChuyenKho");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaKhoHangNhapNavigation)
                    .WithMany(p => p.TChuyenKhoMaKhoHangNhapNavigation)
                    .HasForeignKey(d => d.MaKhoHangNhap)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChuyenKho_rKhoHangNhap");

                entity.HasOne(d => d.MaKhoHangXuatNavigation)
                    .WithMany(p => p.TChuyenKhoMaKhoHangXuatNavigation)
                    .HasForeignKey(d => d.MaKhoHangXuat)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChuyenKho_rKhoHangXuat");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.TChuyenKhoMaNhanVienNavigation)
                    .HasForeignKey(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChuyenKho_rNhanVien");

            });
            modelBuilder.Entity<TDonHang>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_DonHang");

                entity.ToTable("tDonHang");

                entity.Property(e => e.Xong).HasDefaultValueSql("(0)");

                entity.Property(e => e.MaKhoHang).HasDefaultValueSql("(1)");

                entity.Property(e => e.TongSoLuong).HasDefaultValueSql("(0)");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaChanhNavigation)
                    .WithMany(p => p.TDonHangMaChanhNavigation)
                    .HasForeignKey(d => d.MaChanh)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tDonHang_rChanh");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.TDonHangMaKhachHangNavigation)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tDonHang_rKhachHang");

                entity.HasOne(d => d.MaKhoHangNavigation)
                    .WithMany(p => p.TDonHangMaKhoHangNavigation)
                    .HasForeignKey(d => d.MaKhoHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tDonHang_rKhoHang");

            });
            modelBuilder.Entity<TGiamTruKhachHang>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_tGiamTruKhachHang");

                entity.ToTable("tGiamTruKhachHang");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");

                entity.Property(e => e.GhiChu)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.TGiamTruKhachHangMaKhachHangNavigation)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tGiamTruKhachHang_rKhachHang");

            });
            modelBuilder.Entity<TMatHang>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_Product");

                entity.ToTable("tMatHang");

                entity.Property(e => e.SoKy).HasDefaultValueSql("(0)");

                entity.Property(e => e.SoMet).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenMatHangDayDu).HasDefaultValueSql("''");

                entity.Property(e => e.TenMatHangIn).HasDefaultValueSql("''");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");

                entity.Property(e => e.TenMatHang)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(e => e.TenMatHangDayDu)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(e => e.TenMatHangIn)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.TMatHangMaLoaiNavigation)
                    .HasForeignKey(d => d.MaLoai)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tMatHang_rLoaiHang");

            });
            modelBuilder.Entity<TNhanTienKhachHang>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_tNhanTienKhachHang");

                entity.ToTable("tNhanTienKhachHang");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.TNhanTienKhachHangMaKhachHangNavigation)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhanTienKhachHang_rKhachHang");

            });
            modelBuilder.Entity<TNhapHang>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_tNhapHang");

                entity.ToTable("tNhapHang");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaKhoHangNavigation)
                    .WithMany(p => p.TNhapHangMaKhoHangNavigation)
                    .HasForeignKey(d => d.MaKhoHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhapHang_rKhoHang");

                entity.HasOne(d => d.MaNhaCungCapNavigation)
                    .WithMany(p => p.TNhapHangMaNhaCungCapNavigation)
                    .HasForeignKey(d => d.MaNhaCungCap)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhapHang_rNhaCungCap");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.TNhapHangMaNhanVienNavigation)
                    .HasForeignKey(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhapHang_rNhanVien");

            });
            modelBuilder.Entity<TNhapNguyenLieu>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_NhapNguyenLieu");

                entity.ToTable("tNhapNguyenLieu");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaNguyenLieuNavigation)
                    .WithMany(p => p.TNhapNguyenLieuMaNguyenLieuNavigation)
                    .HasForeignKey(d => d.MaNguyenLieu)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhapNguyenLieu_rNguyenLieu");

                entity.HasOne(d => d.MaNhaCungCapNavigation)
                    .WithMany(p => p.TNhapNguyenLieuMaNhaCungCapNavigation)
                    .HasForeignKey(d => d.MaNhaCungCap)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhapNguyenLieu_rNhaCungCap");

            });
            modelBuilder.Entity<TPhuThuKhachHang>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_tPhuThuKhachHang");

                entity.ToTable("tPhuThuKhachHang");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");

                entity.Property(e => e.GhiChu)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.TPhuThuKhachHangMaKhachHangNavigation)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tPhuThuKhachHang_rKhachHang");

            });
            modelBuilder.Entity<TToaHang>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_tToaHang");

                entity.ToTable("tToaHang");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.TToaHangMaKhachHangNavigation)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tToaHang_rKhachHang");

            });
            modelBuilder.Entity<TTonKho>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_tTonKho");

                entity.ToTable("tTonKho");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");


                entity.HasOne(d => d.MaKhoHangNavigation)
                    .WithMany(p => p.TTonKhoMaKhoHangNavigation)
                    .HasForeignKey(d => d.MaKhoHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tTonKho_rKhoHang");

                entity.HasOne(d => d.MaMatHangNavigation)
                    .WithMany(p => p.TTonKhoMaMatHangNavigation)
                    .HasForeignKey(d => d.MaMatHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tTonKho_tMatHang");

            });
            modelBuilder.Entity<ThamSoNgay>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_ThamSoNgay");

                entity.Property(e => e.GroupID).HasDefaultValueSql("(1)");

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasMaxLength(50);

            });
        }
        public DbSet<RBaiXe> RBaiXe { get; set; }
        public DbSet<RCanhBaoTonKho> RCanhBaoTonKho { get; set; }
        public DbSet<RChanh> RChanh { get; set; }
        public DbSet<RDiaDiem> RDiaDiem { get; set; }
        public DbSet<RKhachHang> RKhachHang { get; set; }
        public DbSet<RKhachHangChanh> RKhachHangChanh { get; set; }
        public DbSet<RKhoHang> RKhoHang { get; set; }
        public DbSet<RLoaiChiPhi> RLoaiChiPhi { get; set; }
        public DbSet<RLoaiHang> RLoaiHang { get; set; }
        public DbSet<RLoaiNguyenLieu> RLoaiNguyenLieu { get; set; }
        public DbSet<RMatHangNguyenLieu> RMatHangNguyenLieu { get; set; }
        public DbSet<RNuoc> RNuoc { get; set; }
        public DbSet<RNguyenLieu> RNguyenLieu { get; set; }
        public DbSet<RNhaCungCap> RNhaCungCap { get; set; }
        public DbSet<RNhanVien> RNhanVien { get; set; }
        public DbSet<RPhuongTien> RPhuongTien { get; set; }
        public DbSet<SwaGroup> SwaGroup { get; set; }
        public DbSet<SwaUser> SwaUser { get; set; }
        public DbSet<SwaUserGroup> SwaUserGroup { get; set; }
        public DbSet<TCongNoKhachHang> TCongNoKhachHang { get; set; }
        public DbSet<TChiPhi> TChiPhi { get; set; }
        public DbSet<TChiTietChuyenHangDonHang> TChiTietChuyenHangDonHang { get; set; }
        public DbSet<TChiTietChuyenKho> TChiTietChuyenKho { get; set; }
        public DbSet<TChiTietDonHang> TChiTietDonHang { get; set; }
        public DbSet<TChiTietNhapHang> TChiTietNhapHang { get; set; }
        public DbSet<TChiTietToaHang> TChiTietToaHang { get; set; }
        public DbSet<TChuyenHang> TChuyenHang { get; set; }
        public DbSet<TChuyenHangDonHang> TChuyenHangDonHang { get; set; }
        public DbSet<TChuyenKho> TChuyenKho { get; set; }
        public DbSet<TDonHang> TDonHang { get; set; }
        public DbSet<TGiamTruKhachHang> TGiamTruKhachHang { get; set; }
        public DbSet<TMatHang> TMatHang { get; set; }
        public DbSet<TNhanTienKhachHang> TNhanTienKhachHang { get; set; }
        public DbSet<TNhapHang> TNhapHang { get; set; }
        public DbSet<TNhapNguyenLieu> TNhapNguyenLieu { get; set; }
        public DbSet<TPhuThuKhachHang> TPhuThuKhachHang { get; set; }
        public DbSet<TToaHang> TToaHang { get; set; }
        public DbSet<TTonKho> TTonKho { get; set; }
        public DbSet<ThamSoNgay> ThamSoNgay { get; set; }
    }
}

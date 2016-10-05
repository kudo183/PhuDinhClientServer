using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using huypq.SwaMiddleware;

namespace Server.Entities
{
    public partial class PhuDinhServerContext : DbContext, SwaIDbContext<User>
    {
        public PhuDinhServerContext(DbContextOptions<PhuDinhServerContext> options)
            : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_Group");

                entity.Property(e => e.TenGroup)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<RBaiXe>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rBaiXe");

                entity.ToTable("rBaiXe");

                entity.Property(e => e.DiaDiemBaiXe)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<RCanhBaoTonKho>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rCanhBaoTonKho");

                entity.ToTable("rCanhBaoTonKho");

                entity.HasIndex(e => e.MaKhoHang)
                    .HasName("IX_rCanhBaoTonKho_MaKhoHang");

                entity.HasIndex(e => e.MaMatHang)
                    .HasName("IX_rCanhBaoTonKho_MaMatHang");

                entity.HasOne(d => d.MaKhoHangNavigation)
                    .WithMany(p => p.RCanhBaoTonKho)
                    .HasForeignKey(d => d.MaKhoHang)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.MaMatHangNavigation)
                    .WithMany(p => p.RCanhBaoTonKho)
                    .HasForeignKey(d => d.MaMatHang)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RChanh>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rChanh");

                entity.ToTable("rChanh");

                entity.HasIndex(e => e.MaBaiXe)
                    .HasName("IX_rChanh_MaBaiXe");

                entity.Property(e => e.TenChanh)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.MaBaiXeNavigation)
                    .WithMany(p => p.RChanh)
                    .HasForeignKey(d => d.MaBaiXe)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rChanh_rBaiXe");
            });

            modelBuilder.Entity<RDiaDiem>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rDiaDiem");

                entity.ToTable("rDiaDiem");

                entity.HasIndex(e => e.MaNuoc)
                    .HasName("IX_rDiaDiem_MaNuoc");

                entity.Property(e => e.Tinh)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.MaNuocNavigation)
                    .WithMany(p => p.RDiaDiem)
                    .HasForeignKey(d => d.MaNuoc)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RKhachHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rKhachHang");

                entity.ToTable("rKhachHang");

                entity.HasIndex(e => e.MaDiaDiem)
                    .HasName("IX_rKhachHang_MaDiaDiem");

                entity.HasIndex(e => e.TenKhachHang)
                    .HasName("idx_KhachHang_TenKhachHang")
                    .IsUnique();

                entity.Property(e => e.KhachRieng).HasDefaultValueSql("0");

                entity.Property(e => e.TenKhachHang)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.MaDiaDiemNavigation)
                    .WithMany(p => p.RKhachHang)
                    .HasForeignKey(d => d.MaDiaDiem)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rKhachHang_rDiaDiem");
            });

            modelBuilder.Entity<RKhachHangChanh>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rKhachHangChanh");

                entity.ToTable("rKhachHangChanh");

                entity.HasIndex(e => e.MaChanh)
                    .HasName("IX_rKhachHangChanh_MaChanh");

                entity.HasIndex(e => e.MaKhachHang)
                    .HasName("IX_rKhachHangChanh_MaKhachHang");

                entity.Property(e => e.LaMacDinh).HasDefaultValueSql("0");

                entity.HasOne(d => d.MaChanhNavigation)
                    .WithMany(p => p.RKhachHangChanh)
                    .HasForeignKey(d => d.MaChanh)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rKhachHangChanh_rChanh");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.RKhachHangChanh)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rKhachHangChanh_rKhachHang");
            });

            modelBuilder.Entity<RKhoHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rKhoHang");

                entity.ToTable("rKhoHang");

                entity.Property(e => e.TenKho)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("1");
            });

            modelBuilder.Entity<RLoaiChiPhi>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rLoaiChiPhi");

                entity.ToTable("rLoaiChiPhi");

                entity.Property(e => e.TenLoaiChiPhi)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<RLoaiHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rProductType");

                entity.ToTable("rLoaiHang");

                entity.Property(e => e.HangNhaLam).HasDefaultValueSql("0");

                entity.Property(e => e.TenLoai)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<RLoaiNguyenLieu>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rLoaiNguyenLieu");

                entity.ToTable("rLoaiNguyenLieu");

                entity.Property(e => e.TenLoai)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<RMatHangNguyenLieu>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rMatHangNguyenLieu");

                entity.ToTable("rMatHangNguyenLieu");

                entity.HasIndex(e => e.MaMatHang)
                    .HasName("IX_rMatHangNguyenLieu_MaMatHang");

                entity.HasIndex(e => e.MaNguyenLieu)
                    .HasName("IX_rMatHangNguyenLieu_MaNguyenLieu");

                entity.HasOne(d => d.MaMatHangNavigation)
                    .WithMany(p => p.RMatHangNguyenLieu)
                    .HasForeignKey(d => d.MaMatHang)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.MaNguyenLieuNavigation)
                    .WithMany(p => p.RMatHangNguyenLieu)
                    .HasForeignKey(d => d.MaNguyenLieu)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RNguyenLieu>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rNguyenLieu");

                entity.ToTable("rNguyenLieu");

                entity.HasIndex(e => e.MaLoaiNguyenLieu)
                    .HasName("IX_rNguyenLieu_MaLoaiNguyenLieu");

                entity.HasOne(d => d.MaLoaiNguyenLieuNavigation)
                    .WithMany(p => p.RNguyenLieu)
                    .HasForeignKey(d => d.MaLoaiNguyenLieu)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rNguyenLieu_rLoaiNguyenLieu");
            });

            modelBuilder.Entity<RNhaCungCap>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_NhaCungCap");

                entity.ToTable("rNhaCungCap");

                entity.Property(e => e.TenNhaCungCap)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<RNhanVien>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_NhanVienGiaoHang");

                entity.ToTable("rNhanVien");

                entity.HasIndex(e => e.MaPhuongTien)
                    .HasName("IX_rNhanVien_MaPhuongTien");

                entity.Property(e => e.TenNhanVien)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.MaPhuongTienNavigation)
                    .WithMany(p => p.RNhanVien)
                    .HasForeignKey(d => d.MaPhuongTien)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RNuoc>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rNuoc");

                entity.ToTable("rNuoc");

                entity.Property(e => e.TenNuoc)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<RPhuongTien>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_LoaiPhuongTien");

                entity.ToTable("rPhuongTien");

                entity.Property(e => e.TenPhuongTien)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TChiPhi>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_ChiPhiNhanVienGiaoHang");

                entity.ToTable("tChiPhi");

                entity.HasIndex(e => e.MaLoaiChiPhi)
                    .HasName("IX_tChiPhi_MaLoaiChiPhi");

                entity.HasIndex(e => e.MaNhanVienGiaoHang)
                    .HasName("IX_tChiPhi_MaNhanVienGiaoHang");

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.HasOne(d => d.MaLoaiChiPhiNavigation)
                    .WithMany(p => p.TChiPhi)
                    .HasForeignKey(d => d.MaLoaiChiPhi)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiPhiNhanVienGiaoHang_rLoaiChiPhi");

                entity.HasOne(d => d.MaNhanVienGiaoHangNavigation)
                    .WithMany(p => p.TChiPhi)
                    .HasForeignKey(d => d.MaNhanVienGiaoHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiPhiNhanVienGiaoHang_rNhanVienGiaoHang");
            });

            modelBuilder.Entity<TChiTietChuyenHangDonHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tChiTietChuyenHangDonHang");

                entity.ToTable("tChiTietChuyenHangDonHang");

                entity.HasIndex(e => e.MaChiTietDonHang)
                    .HasName("IX_tChiTietChuyenHangDonHang_MaChiTietDonHang");

                entity.HasIndex(e => e.MaChuyenHangDonHang)
                    .HasName("IX_tChiTietChuyenHangDonHang_MaChuyenHangDonHang");

                entity.Property(e => e.SoLuongTheoDonHang).HasDefaultValueSql("0");

                entity.HasOne(d => d.MaChiTietDonHangNavigation)
                    .WithMany(p => p.TChiTietChuyenHangDonHang)
                    .HasForeignKey(d => d.MaChiTietDonHang)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.MaChuyenHangDonHangNavigation)
                    .WithMany(p => p.TChiTietChuyenHangDonHang)
                    .HasForeignKey(d => d.MaChuyenHangDonHang)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TChiTietChuyenKho>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tChiTietChuyenKho");

                entity.ToTable("tChiTietChuyenKho");

                entity.HasIndex(e => e.MaChuyenKho)
                    .HasName("IX_tChiTietChuyenKho_MaChuyenKho");

                entity.HasIndex(e => e.MaMatHang)
                    .HasName("IX_tChiTietChuyenKho_MaMatHang");

                entity.HasOne(d => d.MaChuyenKhoNavigation)
                    .WithMany(p => p.TChiTietChuyenKho)
                    .HasForeignKey(d => d.MaChuyenKho)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.MaMatHangNavigation)
                    .WithMany(p => p.TChiTietChuyenKho)
                    .HasForeignKey(d => d.MaMatHang)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TChiTietDonHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tChiTietDonHang");

                entity.ToTable("tChiTietDonHang");

                entity.HasIndex(e => e.MaDonHang)
                    .HasName("IX_tChiTietDonHang_MaDonHang");

                entity.HasIndex(e => e.MaMatHang)
                    .HasName("IX_tChiTietDonHang_MaMatHang");

                entity.Property(e => e.Xong).HasDefaultValueSql("0");

                entity.HasOne(d => d.MaDonHangNavigation)
                    .WithMany(p => p.TChiTietDonHang)
                    .HasForeignKey(d => d.MaDonHang)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.MaMatHangNavigation)
                    .WithMany(p => p.TChiTietDonHang)
                    .HasForeignKey(d => d.MaMatHang)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TChiTietNhapHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_NhapMatHang");

                entity.ToTable("tChiTietNhapHang");

                entity.HasIndex(e => e.MaMatHang)
                    .HasName("IX_tChiTietNhapHang_MaMatHang");

                entity.HasIndex(e => e.MaNhapHang)
                    .HasName("IX_tChiTietNhapHang_MaNhapHang");

                entity.HasOne(d => d.MaMatHangNavigation)
                    .WithMany(p => p.TChiTietNhapHang)
                    .HasForeignKey(d => d.MaMatHang)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.MaNhapHangNavigation)
                    .WithMany(p => p.TChiTietNhapHang)
                    .HasForeignKey(d => d.MaNhapHang)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TChiTietToaHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tChiTietToaHang");

                entity.ToTable("tChiTietToaHang");

                entity.HasIndex(e => e.MaChiTietDonHang)
                    .HasName("IX_tChiTietToaHang_MaChiTietDonHang");

                entity.HasIndex(e => e.MaToaHang)
                    .HasName("IX_tChiTietToaHang_MaToaHang");

                entity.HasOne(d => d.MaChiTietDonHangNavigation)
                    .WithMany(p => p.TChiTietToaHang)
                    .HasForeignKey(d => d.MaChiTietDonHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiTietToaHang_tChiTietDonHang");

                entity.HasOne(d => d.MaToaHangNavigation)
                    .WithMany(p => p.TChiTietToaHang)
                    .HasForeignKey(d => d.MaToaHang)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TChuyenHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_ChuyenHang");

                entity.ToTable("tChuyenHang");

                entity.HasIndex(e => e.MaNhanVienGiaoHang)
                    .HasName("IX_tChuyenHang_MaNhanVienGiaoHang");

                entity.Property(e => e.Gio)
                    .HasColumnType("time(0)")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.Property(e => e.TongDonHang).HasDefaultValueSql("0");

                entity.Property(e => e.TongSoLuongTheoDonHang).HasDefaultValueSql("0");

                entity.Property(e => e.TongSoLuongThucTe).HasDefaultValueSql("0");

                entity.HasOne(d => d.MaNhanVienGiaoHangNavigation)
                    .WithMany(p => p.TChuyenHang)
                    .HasForeignKey(d => d.MaNhanVienGiaoHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChuyenHang_rNhanVienGiaoHang");
            });

            modelBuilder.Entity<TChuyenHangDonHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tChuyenHangDonHang");

                entity.ToTable("tChuyenHangDonHang");

                entity.HasIndex(e => e.MaChuyenHang)
                    .HasName("IX_tChuyenHangDonHang_MaChuyenHang");

                entity.HasIndex(e => e.MaDonHang)
                    .HasName("IX_tChuyenHangDonHang_MaDonHang");

                entity.Property(e => e.TongSoLuongTheoDonHang).HasDefaultValueSql("0");

                entity.Property(e => e.TongSoLuongThucTe).HasDefaultValueSql("0");

                entity.HasOne(d => d.MaChuyenHangNavigation)
                    .WithMany(p => p.TChuyenHangDonHang)
                    .HasForeignKey(d => d.MaChuyenHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChuyenHangDonHang_tChuyenHang");

                entity.HasOne(d => d.MaDonHangNavigation)
                    .WithMany(p => p.TChuyenHangDonHang)
                    .HasForeignKey(d => d.MaDonHang)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TChuyenKho>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tChuyenKho");

                entity.ToTable("tChuyenKho");

                entity.HasIndex(e => e.MaKhoHangNhap)
                    .HasName("IX_tChuyenKho_MaKhoHangNhap");

                entity.HasIndex(e => e.MaKhoHangXuat)
                    .HasName("IX_tChuyenKho_MaKhoHangXuat");

                entity.HasIndex(e => e.MaNhanVien)
                    .HasName("IX_tChuyenKho_MaNhanVien");

                entity.Property(e => e.Ngay).HasColumnType("date");

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
                    .WithMany(p => p.TChuyenKho)
                    .HasForeignKey(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChuyenKho_rNhanVien");
            });

            modelBuilder.Entity<TCongNoKhachHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tCongNoKhachHang");

                entity.ToTable("tCongNoKhachHang");

                entity.HasIndex(e => e.MaKhachHang)
                    .HasName("IX_tCongNoKhachHang_MaKhachHang");

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.TCongNoKhachHang)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tCongNoKhachHang_rKhachHang");
            });

            modelBuilder.Entity<TDonHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_DonHang");

                entity.ToTable("tDonHang");

                entity.HasIndex(e => e.MaChanh)
                    .HasName("IX_tDonHang_MaChanh");

                entity.HasIndex(e => e.MaKhachHang)
                    .HasName("IX_tDonHang_MaKhachHang");

                entity.HasIndex(e => e.MaKhoHang)
                    .HasName("IX_tDonHang_MaKhoHang");

                entity.Property(e => e.MaKhoHang).HasDefaultValueSql("1");

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.Property(e => e.TongSoLuong).HasDefaultValueSql("0");

                entity.Property(e => e.Xong).HasDefaultValueSql("0");

                entity.HasOne(d => d.MaChanhNavigation)
                    .WithMany(p => p.TDonHang)
                    .HasForeignKey(d => d.MaChanh)
                    .HasConstraintName("FK_tDonHang_rChanh");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.TDonHang)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tDonHang_rKhachHang");

                entity.HasOne(d => d.MaKhoHangNavigation)
                    .WithMany(p => p.TDonHang)
                    .HasForeignKey(d => d.MaKhoHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tDonHang_rKhoHang");
            });

            modelBuilder.Entity<TGiamTruKhachHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tGiamTruKhachHang");

                entity.ToTable("tGiamTruKhachHang");

                entity.HasIndex(e => e.MaKhachHang)
                    .HasName("IX_tGiamTruKhachHang_MaKhachHang");

                entity.Property(e => e.GhiChu)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.TGiamTruKhachHang)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tGiamTruKhachHang_rKhachHang");
            });

            modelBuilder.Entity<TMatHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_Product");

                entity.ToTable("tMatHang");

                entity.HasIndex(e => e.MaLoai)
                    .HasName("IX_tMatHang_MaLoai");

                entity.Property(e => e.SoKy).HasDefaultValueSql("0");

                entity.Property(e => e.SoMet).HasDefaultValueSql("0");

                entity.Property(e => e.TenMatHang)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TenMatHangDayDu)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TenMatHangIn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.TMatHang)
                    .HasForeignKey(d => d.MaLoai)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tMatHang_rLoaiHang");
            });

            modelBuilder.Entity<TNhanTienKhachHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tNhanTienKhachHang");

                entity.ToTable("tNhanTienKhachHang");

                entity.HasIndex(e => e.MaKhachHang)
                    .HasName("IX_tNhanTienKhachHang_MaKhachHang");

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.TNhanTienKhachHang)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhanTienKhachHang_rKhachHang");
            });

            modelBuilder.Entity<TNhapHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tNhapHang");

                entity.ToTable("tNhapHang");

                entity.HasIndex(e => e.MaKhoHang)
                    .HasName("IX_tNhapHang_MaKhoHang");

                entity.HasIndex(e => e.MaNhaCungCap)
                    .HasName("IX_tNhapHang_MaNhaCungCap");

                entity.HasIndex(e => e.MaNhanVien)
                    .HasName("IX_tNhapHang_MaNhanVien");

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.HasOne(d => d.MaKhoHangNavigation)
                    .WithMany(p => p.TNhapHang)
                    .HasForeignKey(d => d.MaKhoHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhapHang_rKhoHang");

                entity.HasOne(d => d.MaNhaCungCapNavigation)
                    .WithMany(p => p.TNhapHang)
                    .HasForeignKey(d => d.MaNhaCungCap)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhapHang_rNhaCungCap");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.TNhapHang)
                    .HasForeignKey(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhapHang_rNhanVien");
            });

            modelBuilder.Entity<TNhapNguyenLieu>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_NhapNguyenLieu");

                entity.ToTable("tNhapNguyenLieu");

                entity.HasIndex(e => e.MaNguyenLieu)
                    .HasName("IX_tNhapNguyenLieu_MaNguyenLieu");

                entity.HasIndex(e => e.MaNhaCungCap)
                    .HasName("IX_tNhapNguyenLieu_MaNhaCungCap");

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.HasOne(d => d.MaNguyenLieuNavigation)
                    .WithMany(p => p.TNhapNguyenLieu)
                    .HasForeignKey(d => d.MaNguyenLieu)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhapNguyenLieu_rNguyenLieu");

                entity.HasOne(d => d.MaNhaCungCapNavigation)
                    .WithMany(p => p.TNhapNguyenLieu)
                    .HasForeignKey(d => d.MaNhaCungCap)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhapNguyenLieu_rNhaCungCap");
            });

            modelBuilder.Entity<TPhuThuKhachHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tPhuThuKhachHang");

                entity.ToTable("tPhuThuKhachHang");

                entity.HasIndex(e => e.MaKhachHang)
                    .HasName("IX_tPhuThuKhachHang_MaKhachHang");

                entity.Property(e => e.GhiChu)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.TPhuThuKhachHang)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tPhuThuKhachHang_rKhachHang");
            });

            modelBuilder.Entity<TToaHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tToaHang");

                entity.ToTable("tToaHang");

                entity.HasIndex(e => e.MaKhachHang)
                    .HasName("IX_tToaHang_MaKhachHang");

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.TToaHang)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tToaHang_rKhachHang");
            });

            modelBuilder.Entity<TTonKho>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tTonKho");

                entity.ToTable("tTonKho");

                entity.HasIndex(e => e.MaKhoHang)
                    .HasName("IX_tTonKho_MaKhoHang");

                entity.HasIndex(e => e.MaMatHang)
                    .HasName("IX_tTonKho_MaMatHang");

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.HasOne(d => d.MaKhoHangNavigation)
                    .WithMany(p => p.TTonKho)
                    .HasForeignKey(d => d.MaKhoHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tTonKho_rKhoHang");

                entity.HasOne(d => d.MaMatHangNavigation)
                    .WithMany(p => p.TTonKho)
                    .HasForeignKey(d => d.MaMatHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tTonKho_tMatHang");
            });

            modelBuilder.Entity<ThamSoNgay>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_ThamSoNgay");

                entity.Property(e => e.GiaTri).HasColumnType("date");

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_User");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_UserGroup");

                entity.HasIndex(e => e.MaGroup)
                    .HasName("IX_UserGroup_MaGroup");

                entity.HasIndex(e => e.MaUser)
                    .HasName("IX_UserGroup_MaUser");

                entity.HasOne(d => d.MaGroupNavigation)
                    .WithMany(p => p.UserGroup)
                    .HasForeignKey(d => d.MaGroup);

                entity.HasOne(d => d.MaUserNavigation)
                    .WithMany(p => p.UserGroup)
                    .HasForeignKey(d => d.MaUser);
            });
        }

        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<RBaiXe> RBaiXe { get; set; }
        public virtual DbSet<RCanhBaoTonKho> RCanhBaoTonKho { get; set; }
        public virtual DbSet<RChanh> RChanh { get; set; }
        public virtual DbSet<RDiaDiem> RDiaDiem { get; set; }
        public virtual DbSet<RKhachHang> RKhachHang { get; set; }
        public virtual DbSet<RKhachHangChanh> RKhachHangChanh { get; set; }
        public virtual DbSet<RKhoHang> RKhoHang { get; set; }
        public virtual DbSet<RLoaiChiPhi> RLoaiChiPhi { get; set; }
        public virtual DbSet<RLoaiHang> RLoaiHang { get; set; }
        public virtual DbSet<RLoaiNguyenLieu> RLoaiNguyenLieu { get; set; }
        public virtual DbSet<RMatHangNguyenLieu> RMatHangNguyenLieu { get; set; }
        public virtual DbSet<RNguyenLieu> RNguyenLieu { get; set; }
        public virtual DbSet<RNhaCungCap> RNhaCungCap { get; set; }
        public virtual DbSet<RNhanVien> RNhanVien { get; set; }
        public virtual DbSet<RNuoc> RNuoc { get; set; }
        public virtual DbSet<RPhuongTien> RPhuongTien { get; set; }
        public virtual DbSet<TChiPhi> TChiPhi { get; set; }
        public virtual DbSet<TChiTietChuyenHangDonHang> TChiTietChuyenHangDonHang { get; set; }
        public virtual DbSet<TChiTietChuyenKho> TChiTietChuyenKho { get; set; }
        public virtual DbSet<TChiTietDonHang> TChiTietDonHang { get; set; }
        public virtual DbSet<TChiTietNhapHang> TChiTietNhapHang { get; set; }
        public virtual DbSet<TChiTietToaHang> TChiTietToaHang { get; set; }
        public virtual DbSet<TChuyenHang> TChuyenHang { get; set; }
        public virtual DbSet<TChuyenHangDonHang> TChuyenHangDonHang { get; set; }
        public virtual DbSet<TChuyenKho> TChuyenKho { get; set; }
        public virtual DbSet<TCongNoKhachHang> TCongNoKhachHang { get; set; }
        public virtual DbSet<TDonHang> TDonHang { get; set; }
        public virtual DbSet<TGiamTruKhachHang> TGiamTruKhachHang { get; set; }
        public virtual DbSet<TMatHang> TMatHang { get; set; }
        public virtual DbSet<TNhanTienKhachHang> TNhanTienKhachHang { get; set; }
        public virtual DbSet<TNhapHang> TNhapHang { get; set; }
        public virtual DbSet<TNhapNguyenLieu> TNhapNguyenLieu { get; set; }
        public virtual DbSet<TPhuThuKhachHang> TPhuThuKhachHang { get; set; }
        public virtual DbSet<TToaHang> TToaHang { get; set; }
        public virtual DbSet<TTonKho> TTonKho { get; set; }
        public virtual DbSet<ThamSoNgay> ThamSoNgay { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }
    }
}
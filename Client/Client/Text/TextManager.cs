using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;

namespace Client
{
    public static class TextManager
    {
        static readonly Dictionary<string, string> _dic = new Dictionary<string, string>();
        static readonly string DefaultLanguage = "vi-vn";

        static TextManager()
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject()) == true)
            {
                InitDefaultLanguageData();
                return;
            }

            var language = Thread.CurrentThread.CurrentUICulture.Name.ToLower();
            if (language == DefaultLanguage)
            {
                InitDefaultLanguageData();
                return;
            }

            var fileName = language + ".txt";
            var di = new System.IO.DirectoryInfo("text");
            var fi = di.GetFiles(fileName);
            if (fi.Length == 1)
            {
                var sr = fi[0].OpenText();
                var line = sr.ReadLine();
                while (string.IsNullOrEmpty(line) == false)
                {
                    var texts = line.Split(new[] { "\t\t" }, System.StringSplitOptions.None);
                    _dic.Add(texts[0], texts[1]);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
        }

        public static string RBaiXe_Ma { get { return GetText(); } }
        public static string RBaiXe_DiaDiemBaiXe { get { return GetText(); } }
        public static string RCanhBaoTonKho_Ma { get { return GetText(); } }
        public static string RCanhBaoTonKho_MaMatHang { get { return GetText(); } }
        public static string RCanhBaoTonKho_MaKhoHang { get { return GetText(); } }
        public static string RCanhBaoTonKho_TonCaoNhat { get { return GetText(); } }
        public static string RCanhBaoTonKho_TonThapNhat { get { return GetText(); } }
        public static string RChanh_Ma { get { return GetText(); } }
        public static string RChanh_MaBaiXe { get { return GetText(); } }
        public static string RChanh_TenChanh { get { return GetText(); } }
        public static string RDiaDiem_Ma { get { return GetText(); } }
        public static string RDiaDiem_MaNuoc { get { return GetText(); } }
        public static string RDiaDiem_Tinh { get { return GetText(); } }
        public static string RKhachHang_Ma { get { return GetText(); } }
        public static string RKhachHang_MaDiaDiem { get { return GetText(); } }
        public static string RKhachHang_TenKhachHang { get { return GetText(); } }
        public static string RKhachHang_KhachRieng { get { return GetText(); } }
        public static string RKhachHangChanh_Ma { get { return GetText(); } }
        public static string RKhachHangChanh_MaChanh { get { return GetText(); } }
        public static string RKhachHangChanh_MaKhachHang { get { return GetText(); } }
        public static string RKhachHangChanh_LaMacDinh { get { return GetText(); } }
        public static string RKhoHang_Ma { get { return GetText(); } }
        public static string RKhoHang_TenKho { get { return GetText(); } }
        public static string RKhoHang_TrangThai { get { return GetText(); } }
        public static string RLoaiChiPhi_Ma { get { return GetText(); } }
        public static string RLoaiChiPhi_TenLoaiChiPhi { get { return GetText(); } }
        public static string RLoaiHang_Ma { get { return GetText(); } }
        public static string RLoaiHang_TenLoai { get { return GetText(); } }
        public static string RLoaiHang_HangNhaLam { get { return GetText(); } }
        public static string RLoaiNguyenLieu_Ma { get { return GetText(); } }
        public static string RLoaiNguyenLieu_TenLoai { get { return GetText(); } }
        public static string RMatHangNguyenLieu_Ma { get { return GetText(); } }
        public static string RMatHangNguyenLieu_MaMatHang { get { return GetText(); } }
        public static string RMatHangNguyenLieu_MaNguyenLieu { get { return GetText(); } }
        public static string RNuoc_Ma { get { return GetText(); } }
        public static string RNuoc_TenNuoc { get { return GetText(); } }
        public static string RNguyenLieu_Ma { get { return GetText(); } }
        public static string RNguyenLieu_MaLoaiNguyenLieu { get { return GetText(); } }
        public static string RNguyenLieu_DuongKinh { get { return GetText(); } }
        public static string RNhaCungCap_Ma { get { return GetText(); } }
        public static string RNhaCungCap_TenNhaCungCap { get { return GetText(); } }
        public static string RNhanVien_Ma { get { return GetText(); } }
        public static string RNhanVien_MaPhuongTien { get { return GetText(); } }
        public static string RNhanVien_TenNhanVien { get { return GetText(); } }
        public static string RPhuongTien_Ma { get { return GetText(); } }
        public static string RPhuongTien_TenPhuongTien { get { return GetText(); } }
        public static string SwaGroup_ID { get { return GetText(); } }
        public static string SwaGroup_CreateDate { get { return GetText(); } }
        public static string SwaGroup_GroupName { get { return GetText(); } }
        public static string SwaUser_ID { get { return GetText(); } }
        public static string SwaUser_Email { get { return GetText(); } }
        public static string SwaUser_CreateDate { get { return GetText(); } }
        public static string SwaUser_PasswordHash { get { return GetText(); } }
        public static string SwaUserGroup_ID { get { return GetText(); } }
        public static string SwaUserGroup_UserID { get { return GetText(); } }
        public static string SwaUserGroup_IsGroupOwner { get { return GetText(); } }
        public static string TCongNoKhachHang_Ma { get { return GetText(); } }
        public static string TCongNoKhachHang_MaKhachHang { get { return GetText(); } }
        public static string TCongNoKhachHang_Ngay { get { return GetText(); } }
        public static string TCongNoKhachHang_SoTien { get { return GetText(); } }
        public static string TChiPhi_Ma { get { return GetText(); } }
        public static string TChiPhi_MaNhanVienGiaoHang { get { return GetText(); } }
        public static string TChiPhi_MaLoaiChiPhi { get { return GetText(); } }
        public static string TChiPhi_SoTien { get { return GetText(); } }
        public static string TChiPhi_Ngay { get { return GetText(); } }
        public static string TChiPhi_GhiChu { get { return GetText(); } }
        public static string TChiTietChuyenHangDonHang_Ma { get { return GetText(); } }
        public static string TChiTietChuyenHangDonHang_MaChuyenHangDonHang { get { return GetText(); } }
        public static string TChiTietChuyenHangDonHang_MaChiTietDonHang { get { return GetText(); } }
        public static string TChiTietChuyenHangDonHang_SoLuong { get { return GetText(); } }
        public static string TChiTietChuyenHangDonHang_SoLuongTheoDonHang { get { return GetText(); } }
        public static string TChiTietChuyenKho_Ma { get { return GetText(); } }
        public static string TChiTietChuyenKho_MaChuyenKho { get { return GetText(); } }
        public static string TChiTietChuyenKho_MaMatHang { get { return GetText(); } }
        public static string TChiTietChuyenKho_SoLuong { get { return GetText(); } }
        public static string TChiTietDonHang_Ma { get { return GetText(); } }
        public static string TChiTietDonHang_MaDonHang { get { return GetText(); } }
        public static string TChiTietDonHang_MaMatHang { get { return GetText(); } }
        public static string TChiTietDonHang_SoLuong { get { return GetText(); } }
        public static string TChiTietDonHang_Xong { get { return GetText(); } }
        public static string TChiTietNhapHang_Ma { get { return GetText(); } }
        public static string TChiTietNhapHang_MaNhapHang { get { return GetText(); } }
        public static string TChiTietNhapHang_MaMatHang { get { return GetText(); } }
        public static string TChiTietNhapHang_SoLuong { get { return GetText(); } }
        public static string TChiTietToaHang_Ma { get { return GetText(); } }
        public static string TChiTietToaHang_MaToaHang { get { return GetText(); } }
        public static string TChiTietToaHang_MaChiTietDonHang { get { return GetText(); } }
        public static string TChiTietToaHang_GiaTien { get { return GetText(); } }
        public static string TChuyenHang_Ma { get { return GetText(); } }
        public static string TChuyenHang_MaNhanVienGiaoHang { get { return GetText(); } }
        public static string TChuyenHang_Ngay { get { return GetText(); } }
        public static string TChuyenHang_Gio { get { return GetText(); } }
        public static string TChuyenHang_TongDonHang { get { return GetText(); } }
        public static string TChuyenHang_TongSoLuongTheoDonHang { get { return GetText(); } }
        public static string TChuyenHang_TongSoLuongThucTe { get { return GetText(); } }
        public static string TChuyenHangDonHang_Ma { get { return GetText(); } }
        public static string TChuyenHangDonHang_MaChuyenHang { get { return GetText(); } }
        public static string TChuyenHangDonHang_MaDonHang { get { return GetText(); } }
        public static string TChuyenHangDonHang_TongSoLuongTheoDonHang { get { return GetText(); } }
        public static string TChuyenHangDonHang_TongSoLuongThucTe { get { return GetText(); } }
        public static string TChuyenKho_Ma { get { return GetText(); } }
        public static string TChuyenKho_MaNhanVien { get { return GetText(); } }
        public static string TChuyenKho_MaKhoHangXuat { get { return GetText(); } }
        public static string TChuyenKho_MaKhoHangNhap { get { return GetText(); } }
        public static string TChuyenKho_Ngay { get { return GetText(); } }
        public static string TDonHang_Ma { get { return GetText(); } }
        public static string TDonHang_MaKhachHang { get { return GetText(); } }
        public static string TDonHang_MaChanh { get { return GetText(); } }
        public static string TDonHang_Ngay { get { return GetText(); } }
        public static string TDonHang_Xong { get { return GetText(); } }
        public static string TDonHang_MaKhoHang { get { return GetText(); } }
        public static string TDonHang_TongSoLuong { get { return GetText(); } }
        public static string TGiamTruKhachHang_Ma { get { return GetText(); } }
        public static string TGiamTruKhachHang_MaKhachHang { get { return GetText(); } }
        public static string TGiamTruKhachHang_Ngay { get { return GetText(); } }
        public static string TGiamTruKhachHang_SoTien { get { return GetText(); } }
        public static string TGiamTruKhachHang_GhiChu { get { return GetText(); } }
        public static string TMatHang_Ma { get { return GetText(); } }
        public static string TMatHang_MaLoai { get { return GetText(); } }
        public static string TMatHang_TenMatHang { get { return GetText(); } }
        public static string TMatHang_SoKy { get { return GetText(); } }
        public static string TMatHang_SoMet { get { return GetText(); } }
        public static string TMatHang_TenMatHangDayDu { get { return GetText(); } }
        public static string TMatHang_TenMatHangIn { get { return GetText(); } }
        public static string TNhanTienKhachHang_Ma { get { return GetText(); } }
        public static string TNhanTienKhachHang_MaKhachHang { get { return GetText(); } }
        public static string TNhanTienKhachHang_Ngay { get { return GetText(); } }
        public static string TNhanTienKhachHang_SoTien { get { return GetText(); } }
        public static string TNhapHang_Ma { get { return GetText(); } }
        public static string TNhapHang_MaNhanVien { get { return GetText(); } }
        public static string TNhapHang_MaKhoHang { get { return GetText(); } }
        public static string TNhapHang_MaNhaCungCap { get { return GetText(); } }
        public static string TNhapHang_Ngay { get { return GetText(); } }
        public static string TNhapNguyenLieu_Ma { get { return GetText(); } }
        public static string TNhapNguyenLieu_Ngay { get { return GetText(); } }
        public static string TNhapNguyenLieu_MaNguyenLieu { get { return GetText(); } }
        public static string TNhapNguyenLieu_MaNhaCungCap { get { return GetText(); } }
        public static string TNhapNguyenLieu_SoLuong { get { return GetText(); } }
        public static string TPhuThuKhachHang_Ma { get { return GetText(); } }
        public static string TPhuThuKhachHang_MaKhachHang { get { return GetText(); } }
        public static string TPhuThuKhachHang_Ngay { get { return GetText(); } }
        public static string TPhuThuKhachHang_SoTien { get { return GetText(); } }
        public static string TPhuThuKhachHang_GhiChu { get { return GetText(); } }
        public static string TToaHang_Ma { get { return GetText(); } }
        public static string TToaHang_Ngay { get { return GetText(); } }
        public static string TToaHang_MaKhachHang { get { return GetText(); } }
        public static string TTonKho_Ma { get { return GetText(); } }
        public static string TTonKho_MaKhoHang { get { return GetText(); } }
        public static string TTonKho_MaMatHang { get { return GetText(); } }
        public static string TTonKho_Ngay { get { return GetText(); } }
        public static string TTonKho_SoLuong { get { return GetText(); } }
        public static string TTonKho_SoLuongCu { get { return GetText(); } }
        public static string ThamSoNgay_Ma { get { return GetText(); } }
        public static string ThamSoNgay_Ten { get { return GetText(); } }
        public static string ThamSoNgay_GiaTri { get { return GetText(); } }
        public static string Button_Ok { get { return GetText(); } }
        public static string LoginWindow_CannotConnect { get { return GetText(); } }
        public static string LoginWindow_LoginFailed { get { return GetText(); } }
        public static string LoginWindow_Title { get { return GetText(); } }
        public static string LoginWindow_TxtPassword { get { return GetText(); } }
        public static string LoginWindow_TxtUser { get { return GetText(); } }
        public static string LoginWindow_TxtGroupList { get { return GetText(); } }
        public static string LoginWindow_BtnLogin { get { return GetText(); } }

        public static string GetText([CallerMemberName] string textKey = null)
        {
            string text;
            if (_dic.TryGetValue(textKey, out text) == true)
            {
                return text;
            }
            return "[no text]";
        }

        private static void InitDefaultLanguageData()
        {
            _dic.Add("RBaiXe_Ma", "Ma");
            _dic.Add("RBaiXe_DiaDiemBaiXe", "DiaDiemBaiXe");
            _dic.Add("RCanhBaoTonKho_Ma", "Ma");
            _dic.Add("RCanhBaoTonKho_MaMatHang", "MaMatHang");
            _dic.Add("RCanhBaoTonKho_MaKhoHang", "MaKhoHang");
            _dic.Add("RCanhBaoTonKho_TonCaoNhat", "TonCaoNhat");
            _dic.Add("RCanhBaoTonKho_TonThapNhat", "TonThapNhat");
            _dic.Add("RChanh_Ma", "Ma");
            _dic.Add("RChanh_MaBaiXe", "MaBaiXe");
            _dic.Add("RChanh_TenChanh", "TenChanh");
            _dic.Add("RDiaDiem_Ma", "Ma");
            _dic.Add("RDiaDiem_MaNuoc", "MaNuoc");
            _dic.Add("RDiaDiem_Tinh", "Tinh");
            _dic.Add("RKhachHang_Ma", "Ma");
            _dic.Add("RKhachHang_MaDiaDiem", "MaDiaDiem");
            _dic.Add("RKhachHang_TenKhachHang", "TenKhachHang");
            _dic.Add("RKhachHang_KhachRieng", "KhachRieng");
            _dic.Add("RKhachHangChanh_Ma", "Ma");
            _dic.Add("RKhachHangChanh_MaChanh", "MaChanh");
            _dic.Add("RKhachHangChanh_MaKhachHang", "MaKhachHang");
            _dic.Add("RKhachHangChanh_LaMacDinh", "LaMacDinh");
            _dic.Add("RKhoHang_Ma", "Ma");
            _dic.Add("RKhoHang_TenKho", "TenKho");
            _dic.Add("RKhoHang_TrangThai", "TrangThai");
            _dic.Add("RLoaiChiPhi_Ma", "Ma");
            _dic.Add("RLoaiChiPhi_TenLoaiChiPhi", "TenLoaiChiPhi");
            _dic.Add("RLoaiHang_Ma", "Ma");
            _dic.Add("RLoaiHang_TenLoai", "TenLoai");
            _dic.Add("RLoaiHang_HangNhaLam", "HangNhaLam");
            _dic.Add("RLoaiNguyenLieu_Ma", "Ma");
            _dic.Add("RLoaiNguyenLieu_TenLoai", "TenLoai");
            _dic.Add("RMatHangNguyenLieu_Ma", "Ma");
            _dic.Add("RMatHangNguyenLieu_MaMatHang", "MaMatHang");
            _dic.Add("RMatHangNguyenLieu_MaNguyenLieu", "MaNguyenLieu");
            _dic.Add("RNuoc_Ma", "Ma");
            _dic.Add("RNuoc_TenNuoc", "TenNuoc");
            _dic.Add("RNguyenLieu_Ma", "Ma");
            _dic.Add("RNguyenLieu_MaLoaiNguyenLieu", "MaLoaiNguyenLieu");
            _dic.Add("RNguyenLieu_DuongKinh", "DuongKinh");
            _dic.Add("RNhaCungCap_Ma", "Ma");
            _dic.Add("RNhaCungCap_TenNhaCungCap", "TenNhaCungCap");
            _dic.Add("RNhanVien_Ma", "Ma");
            _dic.Add("RNhanVien_MaPhuongTien", "MaPhuongTien");
            _dic.Add("RNhanVien_TenNhanVien", "TenNhanVien");
            _dic.Add("RPhuongTien_Ma", "Ma");
            _dic.Add("RPhuongTien_TenPhuongTien", "TenPhuongTien");
            _dic.Add("SwaGroup_ID", "ID");
            _dic.Add("SwaGroup_CreateDate", "CreateDate");
            _dic.Add("SwaGroup_GroupName", "GroupName");
            _dic.Add("SwaUser_ID", "ID");
            _dic.Add("SwaUser_Email", "Email");
            _dic.Add("SwaUser_CreateDate", "CreateDate");
            _dic.Add("SwaUser_PasswordHash", "PasswordHash");
            _dic.Add("SwaUserGroup_ID", "ID");
            _dic.Add("SwaUserGroup_UserID", "UserID");
            _dic.Add("SwaUserGroup_IsGroupOwner", "IsGroupOwner");
            _dic.Add("TCongNoKhachHang_Ma", "Ma");
            _dic.Add("TCongNoKhachHang_MaKhachHang", "MaKhachHang");
            _dic.Add("TCongNoKhachHang_Ngay", "Ngay");
            _dic.Add("TCongNoKhachHang_SoTien", "SoTien");
            _dic.Add("TChiPhi_Ma", "Ma");
            _dic.Add("TChiPhi_MaNhanVienGiaoHang", "MaNhanVienGiaoHang");
            _dic.Add("TChiPhi_MaLoaiChiPhi", "MaLoaiChiPhi");
            _dic.Add("TChiPhi_SoTien", "SoTien");
            _dic.Add("TChiPhi_Ngay", "Ngay");
            _dic.Add("TChiPhi_GhiChu", "GhiChu");
            _dic.Add("TChiTietChuyenHangDonHang_Ma", "Ma");
            _dic.Add("TChiTietChuyenHangDonHang_MaChuyenHangDonHang", "MaChuyenHangDonHang");
            _dic.Add("TChiTietChuyenHangDonHang_MaChiTietDonHang", "MaChiTietDonHang");
            _dic.Add("TChiTietChuyenHangDonHang_SoLuong", "SoLuong");
            _dic.Add("TChiTietChuyenHangDonHang_SoLuongTheoDonHang", "SoLuongTheoDonHang");
            _dic.Add("TChiTietChuyenKho_Ma", "Ma");
            _dic.Add("TChiTietChuyenKho_MaChuyenKho", "MaChuyenKho");
            _dic.Add("TChiTietChuyenKho_MaMatHang", "MaMatHang");
            _dic.Add("TChiTietChuyenKho_SoLuong", "SoLuong");
            _dic.Add("TChiTietDonHang_Ma", "Ma");
            _dic.Add("TChiTietDonHang_MaDonHang", "MaDonHang");
            _dic.Add("TChiTietDonHang_MaMatHang", "MaMatHang");
            _dic.Add("TChiTietDonHang_SoLuong", "SoLuong");
            _dic.Add("TChiTietDonHang_Xong", "Xong");
            _dic.Add("TChiTietNhapHang_Ma", "Ma");
            _dic.Add("TChiTietNhapHang_MaNhapHang", "MaNhapHang");
            _dic.Add("TChiTietNhapHang_MaMatHang", "MaMatHang");
            _dic.Add("TChiTietNhapHang_SoLuong", "SoLuong");
            _dic.Add("TChiTietToaHang_Ma", "Ma");
            _dic.Add("TChiTietToaHang_MaToaHang", "MaToaHang");
            _dic.Add("TChiTietToaHang_MaChiTietDonHang", "MaChiTietDonHang");
            _dic.Add("TChiTietToaHang_GiaTien", "GiaTien");
            _dic.Add("TChuyenHang_Ma", "Ma");
            _dic.Add("TChuyenHang_MaNhanVienGiaoHang", "MaNhanVienGiaoHang");
            _dic.Add("TChuyenHang_Ngay", "Ngay");
            _dic.Add("TChuyenHang_Gio", "Gio");
            _dic.Add("TChuyenHang_TongDonHang", "TongDonHang");
            _dic.Add("TChuyenHang_TongSoLuongTheoDonHang", "TongSoLuongTheoDonHang");
            _dic.Add("TChuyenHang_TongSoLuongThucTe", "TongSoLuongThucTe");
            _dic.Add("TChuyenHangDonHang_Ma", "Ma");
            _dic.Add("TChuyenHangDonHang_MaChuyenHang", "MaChuyenHang");
            _dic.Add("TChuyenHangDonHang_MaDonHang", "MaDonHang");
            _dic.Add("TChuyenHangDonHang_TongSoLuongTheoDonHang", "TongSoLuongTheoDonHang");
            _dic.Add("TChuyenHangDonHang_TongSoLuongThucTe", "TongSoLuongThucTe");
            _dic.Add("TChuyenKho_Ma", "Ma");
            _dic.Add("TChuyenKho_MaNhanVien", "MaNhanVien");
            _dic.Add("TChuyenKho_MaKhoHangXuat", "MaKhoHangXuat");
            _dic.Add("TChuyenKho_MaKhoHangNhap", "MaKhoHangNhap");
            _dic.Add("TChuyenKho_Ngay", "Ngay");
            _dic.Add("TDonHang_Ma", "Ma");
            _dic.Add("TDonHang_MaKhachHang", "MaKhachHang");
            _dic.Add("TDonHang_MaChanh", "MaChanh");
            _dic.Add("TDonHang_Ngay", "Ngay");
            _dic.Add("TDonHang_Xong", "Xong");
            _dic.Add("TDonHang_MaKhoHang", "MaKhoHang");
            _dic.Add("TDonHang_TongSoLuong", "TongSoLuong");
            _dic.Add("TGiamTruKhachHang_Ma", "Ma");
            _dic.Add("TGiamTruKhachHang_MaKhachHang", "MaKhachHang");
            _dic.Add("TGiamTruKhachHang_Ngay", "Ngay");
            _dic.Add("TGiamTruKhachHang_SoTien", "SoTien");
            _dic.Add("TGiamTruKhachHang_GhiChu", "GhiChu");
            _dic.Add("TMatHang_Ma", "Ma");
            _dic.Add("TMatHang_MaLoai", "MaLoai");
            _dic.Add("TMatHang_TenMatHang", "TenMatHang");
            _dic.Add("TMatHang_SoKy", "SoKy");
            _dic.Add("TMatHang_SoMet", "SoMet");
            _dic.Add("TMatHang_TenMatHangDayDu", "TenMatHangDayDu");
            _dic.Add("TMatHang_TenMatHangIn", "TenMatHangIn");
            _dic.Add("TNhanTienKhachHang_Ma", "Ma");
            _dic.Add("TNhanTienKhachHang_MaKhachHang", "MaKhachHang");
            _dic.Add("TNhanTienKhachHang_Ngay", "Ngay");
            _dic.Add("TNhanTienKhachHang_SoTien", "SoTien");
            _dic.Add("TNhapHang_Ma", "Ma");
            _dic.Add("TNhapHang_MaNhanVien", "MaNhanVien");
            _dic.Add("TNhapHang_MaKhoHang", "MaKhoHang");
            _dic.Add("TNhapHang_MaNhaCungCap", "MaNhaCungCap");
            _dic.Add("TNhapHang_Ngay", "Ngay");
            _dic.Add("TNhapNguyenLieu_Ma", "Ma");
            _dic.Add("TNhapNguyenLieu_Ngay", "Ngay");
            _dic.Add("TNhapNguyenLieu_MaNguyenLieu", "MaNguyenLieu");
            _dic.Add("TNhapNguyenLieu_MaNhaCungCap", "MaNhaCungCap");
            _dic.Add("TNhapNguyenLieu_SoLuong", "SoLuong");
            _dic.Add("TPhuThuKhachHang_Ma", "Ma");
            _dic.Add("TPhuThuKhachHang_MaKhachHang", "MaKhachHang");
            _dic.Add("TPhuThuKhachHang_Ngay", "Ngay");
            _dic.Add("TPhuThuKhachHang_SoTien", "SoTien");
            _dic.Add("TPhuThuKhachHang_GhiChu", "GhiChu");
            _dic.Add("TToaHang_Ma", "Ma");
            _dic.Add("TToaHang_Ngay", "Ngay");
            _dic.Add("TToaHang_MaKhachHang", "MaKhachHang");
            _dic.Add("TTonKho_Ma", "Ma");
            _dic.Add("TTonKho_MaKhoHang", "MaKhoHang");
            _dic.Add("TTonKho_MaMatHang", "MaMatHang");
            _dic.Add("TTonKho_Ngay", "Ngay");
            _dic.Add("TTonKho_SoLuong", "SoLuong");
            _dic.Add("TTonKho_SoLuongCu", "SoLuongCu");
            _dic.Add("ThamSoNgay_Ma", "Ma");
            _dic.Add("ThamSoNgay_Ten", "Ten");
            _dic.Add("ThamSoNgay_GiaTri", "GiaTri");
            _dic.Add("Button_Ok", "OK");
            _dic.Add("LoginWindow_CannotConnect", "Không kết nối được máy chủ.");
            _dic.Add("LoginWindow_LoginFailed", "Sai Tên đăng nhập hoặc Mã đăng nhập.");
            _dic.Add("LoginWindow_Title", "Đăng Nhập");
            _dic.Add("LoginWindow_TxtPassword", "Mã đăng nhập:");
            _dic.Add("LoginWindow_TxtUser", "Tên đăng nhập:");
            _dic.Add("LoginWindow_TxtGroupList", "Tên tổ chức:");
            _dic.Add("LoginWindow_BtnLogin", "Đăng Nhập");
        }
    }
}

namespace Client
{
    public static partial class TextManager
    {
        public static string Button_Ok { get { return GetText(); } }
        public static string LoginWindow_CannotConnect { get { return GetText(); } }
        public static string LoginWindow_LoginFailed { get { return GetText(); } }
        public static string LoginWindow_Title { get { return GetText(); } }
        public static string LoginWindow_TxtPassword { get { return GetText(); } }
        public static string LoginWindow_TxtUser { get { return GetText(); } }
        public static string LoginWindow_TxtGroupList { get { return GetText(); } }
        public static string LoginWindow_BtnLogin { get { return GetText(); } }
        public static string TToaHang_ThanhTien { get { return GetText(); } }
        public static string TChiTietToaHang_ThanhTien { get { return GetText(); } }
        public static string TChuyenKho_TongSoLuong { get { return GetText(); } }

        static partial void InitDefaultLanguageDataPartial()
        {
            _dic.Add("Button_Ok", "OK");
            _dic.Add("LoginWindow_CannotConnect", "Không kết nối được máy chủ.");
            _dic.Add("LoginWindow_LoginFailed", "Sai Tên đăng nhập hoặc Mã đăng nhập.");
            _dic.Add("LoginWindow_Title", "Đăng Nhập");
            _dic.Add("LoginWindow_TxtPassword", "Mã đăng nhập:");
            _dic.Add("LoginWindow_TxtUser", "Tên đăng nhập:");
            _dic.Add("LoginWindow_TxtGroupList", "Tên tổ chức:");
            _dic.Add("LoginWindow_BtnLogin", "Đăng Nhập");
            _dic.Add("TToaHang_ThanhTien", "Thành Tiền");
            _dic.Add("TChiTietToaHang_ThanhTien", "Thành Tiền");
            _dic.Add("TChuyenKho_TongSoLuong", "Tổng số lượng");
        }
    }
}

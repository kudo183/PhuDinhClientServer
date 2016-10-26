using System.ComponentModel;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public class TDonHangDto : IDto, INotifyPropertyChanged
    {
        int _ma { get; set; }
        int? _maChanh { get; set; }
        int _maKhachHang { get; set; }
        int _maKhoHang { get; set; }
        System.DateTime _ngay { get; set; }
        int _tongSoLuong { get; set; }
        bool _xong { get; set; }

        int ma { get; set; }
        int? maChanh { get; set; }
        int maKhachHang { get; set; }
        int maKhoHang { get; set; }
        System.DateTime ngay { get; set; }
        int tongSoLuong { get; set; }
        bool xong { get; set; }

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public int? MaChanh { get { return maChanh; } set { maChanh = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaKhachHang { get { return maKhachHang; } set { maKhachHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaKhoHang { get { return maKhoHang; } set { maKhoHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public System.DateTime Ngay { get { return ngay; } set { ngay = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public int TongSoLuong { get { return tongSoLuong; } set { tongSoLuong = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(7)]
        public bool Xong { get { return xong; } set { xong = value; OnPropertyChanged(); } }

        public void SetCurrentValueAsOriginalValue()
        {
            _ma = Ma;
            _maChanh = MaChanh;
            _maKhachHang = MaKhachHang;
            _maKhoHang = MaKhoHang;
            _ngay = Ngay;
            _tongSoLuong = TongSoLuong;
            _xong = Xong;
        }

        public bool HasChange()
        {
            return (_ma != Ma)
                || (_maChanh != MaChanh)
                || (_maKhachHang != MaKhachHang)
                || (_maKhoHang != MaKhoHang)
                || (_ngay != Ngay)
                || (_tongSoLuong != TongSoLuong)
                || (_xong != Xong);
        }

        object chanhs;
        object khachHangs;
        object khoHangs;

        [Newtonsoft.Json.JsonIgnore]
        public object Chanhs { get { return chanhs; } set { chanhs = value; OnPropertyChanged(); } }

        [Newtonsoft.Json.JsonIgnore]
        public object KhachHangs { get { return khachHangs; } set { khachHangs = value; OnPropertyChanged(); } }

        [Newtonsoft.Json.JsonIgnore]
        public object KhoHangs { get { return khoHangs; } set { khoHangs = value; OnPropertyChanged(); } }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public class TDonHangDto : IDto
    {
        int _ma { get; set; }
        int? _maChanh { get; set; }
        int _maKhachHang { get; set; }
        int _maKhoHang { get; set; }
        System.DateTime _ngay { get; set; }
        int _tongSoLuong { get; set; }
        bool _xong { get; set; }

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public int? MaChanh { get; set; }

        private int maKhachHang;
        [ProtoBuf.ProtoMember(3)]
        public int MaKhachHang
        {
            get
            {
                return maKhachHang;
            }
            set
            {
                if (maKhachHang == value)
                    return;
                maKhachHang = value;
                if (MaKhachHangChangedAction != null)
                {
                    MaKhachHangChangedAction(this);
                }
            }
        }

        [ProtoBuf.ProtoMember(4)]
        public int MaKhoHang { get; set; }
        [ProtoBuf.ProtoMember(5)]
        public System.DateTime Ngay { get; set; }
        [ProtoBuf.ProtoMember(6)]
        public int TongSoLuong { get; set; }
        [ProtoBuf.ProtoMember(7)]
        public bool Xong { get; set; }

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

        [Newtonsoft.Json.JsonIgnore]
        public object KhachHangChanhs { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public object KhachHangs { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public object KhoHangs { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public System.Action<TDonHangDto> MaKhachHangChangedAction { get; set; }
    }
}

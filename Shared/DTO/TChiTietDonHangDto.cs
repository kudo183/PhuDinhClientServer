namespace DTO
{
    [ProtoBuf.ProtoContract]
    public class TChiTietDonHangDto : IDto
    {
        int _ma { get; set; }
        int _maDonHang { get; set; }
        int _maMatHang { get; set; }
        int _soLuong { get; set; }
        bool _xong { get; set; }
        
        [ProtoBuf.ProtoMember(1)]
        public int Ma { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public int MaDonHang { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public int MaMatHang { get; set; }
        [ProtoBuf.ProtoMember(4)]
        public int SoLuong { get; set; }
        [ProtoBuf.ProtoMember(5)]
        public bool Xong { get; set; }
        
        public void SetCurrentValueAsOriginalValue()
        {
            _ma = Ma;
            _maDonHang = MaDonHang;
            _maMatHang = MaMatHang;
            _soLuong = SoLuong;
            _xong = Xong;
        }

        public bool HasChange()
        {
            return (_ma != Ma)
                || (_maDonHang != MaDonHang)
                || (_maMatHang != MaMatHang)
                || (_soLuong != SoLuong)
                || (_xong != Xong);
        }
        
        [Newtonsoft.Json.JsonIgnore]
        public object DonHangs { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public object MatHangs { get; set; }
    }
}

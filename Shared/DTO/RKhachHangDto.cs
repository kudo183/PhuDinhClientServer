namespace DTO
{
    [ProtoBuf.ProtoContract]
    public class RKhachHangDto : IDto
    {
        int _ma;
        bool _khachRieng;
        int _maDiaDiem;
        string _tenKhachHang;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public bool KhachRieng { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public int MaDiaDiem { get; set; }
        [ProtoBuf.ProtoMember(4)]
        public string TenKhachHang { get; set; }

        public void SetCurrentValueAsOriginalValue()
        {
            _ma = Ma;
            _khachRieng = KhachRieng;
            _maDiaDiem = MaDiaDiem;
            _tenKhachHang = TenKhachHang;
        }

        public bool HasChange()
        {
            return (_ma != Ma)
                || (_khachRieng != KhachRieng)
                || (_maDiaDiem != MaDiaDiem)
                || (_tenKhachHang != TenKhachHang);
        }
    }
}

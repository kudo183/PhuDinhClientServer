namespace DTO
{
    [ProtoBuf.ProtoContract]
    public class TMatHangDto : IDto
    {
        int _ma;
        int _maLoai;
        int _soKy;
        int _soMet;
        string _tenMatHang;
        string _tenMatHangDayDu;
        string _tenMatHangIn;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public int MaLoai { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public int SoKy { get; set; }
        [ProtoBuf.ProtoMember(4)]
        public int SoMet { get; set; }
        [ProtoBuf.ProtoMember(5)]
        public string TenMatHang { get; set; }
        [ProtoBuf.ProtoMember(6)]
        public string TenMatHangDayDu { get; set; }
        [ProtoBuf.ProtoMember(7)]
        public string TenMatHangIn { get; set; }

        public void SetCurrentValueAsOriginalValue()
        {
            _ma = Ma;
            _maLoai = MaLoai;
            _soKy = SoKy;
            _soMet = SoMet;
            _tenMatHang = TenMatHang;
            _tenMatHangDayDu = TenMatHangDayDu;
            _tenMatHangIn = TenMatHangIn;
        }

        public bool HasChange()
        {
            return (_ma != Ma)
                || (_maLoai != MaLoai)
                || (_soKy != SoKy)
                || (_soMet != SoMet)
                || (_tenMatHang != TenMatHang)
                || (_tenMatHangDayDu != TenMatHangDayDu)
                || (_tenMatHangIn != TenMatHangIn);
        }
    }
}

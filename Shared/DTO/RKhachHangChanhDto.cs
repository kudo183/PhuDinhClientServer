namespace DTO
{
    [ProtoBuf.ProtoContract]
    public class RKhachHangChanhDto : IDto
    {
        int _ma;
        bool _laMacDinh;
        int _maChanh;
        int _maKhachHang;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public bool LaMacDinh { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public int MaChanh { get; set; }
        [ProtoBuf.ProtoMember(4)]
        public int MaKhachHang { get; set; }

        public void SetCurrentValueAsOriginalValue()
        {
            _ma = Ma;
            _laMacDinh = LaMacDinh;
            _maChanh = MaChanh;
            _maKhachHang = MaKhachHang;
        }

        public bool HasChange()
        {
            return (_ma != Ma)
            || (_laMacDinh != LaMacDinh)
            || (_maChanh != MaChanh)
            || (_maKhachHang != MaKhachHang);
        }
    }
}

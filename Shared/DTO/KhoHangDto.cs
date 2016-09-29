namespace DTO
{
    [ProtoBuf.ProtoContract]
    public class KhoHangDto : IDto
    {
        [ProtoBuf.ProtoMember(1)]
        public int Ma { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public string TenKho { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public bool TrangThai { get; set; }

        int _ma;
        string _tenKho;
        bool _trangThai;

        public void SetCurrentValueAsOriginalValue()
        {
            _ma = Ma;
            _tenKho = TenKho;
            _trangThai = TrangThai;
        }

        public bool HasChange()
        {
            return (_ma != Ma) || (_tenKho != TenKho) || (_trangThai != TrangThai);
        }
    }
}

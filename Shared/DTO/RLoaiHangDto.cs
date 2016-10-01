namespace DTO
{
    [ProtoBuf.ProtoContract]
    public class RLoaiHangDto : IDto
    {
        [ProtoBuf.ProtoMember(1)]
        public int Ma { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public bool HangNhaLam { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public string TenLoai { get; set; }

        int _ma;
        bool _hangNhaLam;
        string _tenLoai;

        public void SetCurrentValueAsOriginalValue()
        {
            _ma = Ma;
            _hangNhaLam = HangNhaLam;
            _tenLoai = TenLoai;
        }

        public bool HasChange()
        {
            return (_ma != Ma) || (_hangNhaLam != HangNhaLam) || (_tenLoai != TenLoai);
        }
    }
}

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public class RChanhDto : IDto
    {
        int _ma;
        int _maBaiXe;
        string _tenChanh;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public int MaBaiXe { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public string TenChanh { get; set; }

        public void SetCurrentValueAsOriginalValue()
        {
            _ma = Ma;
            _maBaiXe = MaBaiXe;
            _tenChanh = TenChanh;
        }

        public bool HasChange()
        {
            return (_ma != Ma) || (_maBaiXe != MaBaiXe) || (_tenChanh != TenChanh);
        }

        public System.Collections.Generic.List<RBaiXeDto> BaiXes { get; set; }
    }
}

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public class RBaiXeDto : IDto
    {
        int _ma;
        string _diaDiemBaiXe;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public string DiaDiemBaiXe { get; set; }

        public void SetCurrentValueAsOriginalValue()
        {
            _ma = Ma;
            _diaDiemBaiXe = DiaDiemBaiXe;
        }

        public bool HasChange()
        {
            return (_ma != Ma) || (_diaDiemBaiXe != DiaDiemBaiXe);
        }
    }
}

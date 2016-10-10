namespace DTO
{
    [ProtoBuf.ProtoContract]
    public class RDiaDiemDto : IDto
    {
        int _ma;
        int _maNuoc;
        string _tinh;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public int MaNuoc { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public string Tinh { get; set; }

        public void SetCurrentValueAsOriginalValue()
        {
            _ma = Ma;
            _maNuoc = MaNuoc;
            _tinh = Tinh;
        }

        public bool HasChange()
        {
            return (_ma != Ma) || (_maNuoc != MaNuoc) || (_tinh != Tinh);
        }


        [Newtonsoft.Json.JsonIgnore]
        public object Nuocs { get; set; }
    }
}

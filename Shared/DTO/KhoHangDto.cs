namespace DTO
{
    [ProtoBuf.ProtoContract]
    public class KhoHangDto
    {
        [ProtoBuf.ProtoMember(1)]
        public int Ma { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public string TenKho { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public bool TrangThai { get; set; }
    }
}

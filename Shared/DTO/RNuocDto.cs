namespace DTO
{
    [ProtoBuf.ProtoContract]
    public class RNuocDto : IDto
    {
        int _ma;
        string _tenNuoc;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public string TenNuoc { get; set; }

        public void SetCurrentValueAsOriginalValue()
        {
            _ma = Ma;
            _tenNuoc = TenNuoc;
        }

        public bool HasChange()
        {
            return (_ma != Ma) || (_tenNuoc != TenNuoc);
        }
    }
}

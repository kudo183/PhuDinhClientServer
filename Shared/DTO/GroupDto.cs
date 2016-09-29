namespace DTO
{
    [ProtoBuf.ProtoContract]
    public class GroupDto : IDto
    {
        int _ma;
        string _tenGroup;
        System.DateTime _ngayTao;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public string TenGroup { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public System.DateTime NgayTao { get; set; }

        public void SetCurrentValueAsOriginalValue()
        {
            _ma = Ma;
            _tenGroup = TenGroup;
            _ngayTao = NgayTao;
        }

        public bool HasChange()
        {
            return (_ma != Ma) || (_tenGroup != TenGroup) || (_ngayTao != NgayTao);
        }
    }
}

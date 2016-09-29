namespace DTO
{
    public class ChangeState
    {
        public const string Add = "a";
        public const string Delete = "d";
        public const string Update = "u";
    }

    [ProtoBuf.ProtoContract]
    public class ChangedItem<T>
    {
        [ProtoBuf.ProtoMember(1)]
        public string State { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public T Data { get; set; }
    }
}

using System.Collections.Generic;

namespace DTO
{
    [ProtoBuf.ProtoContract]
    public class PagingResultDto<T>
    {
        [ProtoBuf.ProtoMember(1)]
        public int TotalItemCount { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public int PageIndex { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public int PageCount { get; set; }
        [ProtoBuf.ProtoMember(4)]
        public List<T> Items { get; set; }
        [ProtoBuf.ProtoMember(5)]
        public long VersionNumber { get; set; }
        [ProtoBuf.ProtoMember(6)]
        public string ErrorMsg { get; set; }
        [ProtoBuf.ProtoMember(7)]
        public long ServerStartTime { get; set; }

        public PagingResultDto()
        {
            Items = new List<T>();
        }
    }
}

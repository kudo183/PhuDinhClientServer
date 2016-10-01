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

        public PagingResultDto()
        {
            Items = new List<T>();
        }
    }
}

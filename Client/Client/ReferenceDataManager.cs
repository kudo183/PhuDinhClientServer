using System.Collections.Generic;

namespace Client
{
    public sealed class ReferenceDataManager
    {
        private static readonly ReferenceDataManager _instance = new ReferenceDataManager();

        public static ReferenceDataManager Instance
        {
            get { return _instance; }
        }

        private List<DTO.RBaiXeDto> _baiXes;

        public List<DTO.RBaiXeDto> BaiXes(bool forceReload = false)
        {
            if (forceReload || _baiXes == null)
            {
                var qe = new QueryBuilder.QueryExpression();
                qe.PageIndex = 0;
                var service = new ProtoBufDataService<DTO.RBaiXeDto>("rbaixe");
                _baiXes = service.Get(qe).Items;
            }
            return _baiXes;
        }
    }
}

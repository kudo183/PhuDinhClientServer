using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RBaiXe : huypq.SwaMiddleware.SwaIEntity
    {
        public RBaiXe()
        {
            RChanhMaBaiXeNavigation = new HashSet<RChanh>();
        }

        public string DiaDiemBaiXe { get; set; }
        public int GroupID { get; set; }
        public int Ma { get; set; }

        public ICollection<RChanh> RChanhMaBaiXeNavigation { get; set; }


        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}

using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RBaiXe
    {
        public RBaiXe()
        {
            RChanh = new HashSet<RChanh>();
        }

        public int Ma { get; set; }
        public string DiaDiemBaiXe { get; set; }
        public int MaGroup { get; set; }

        public virtual ICollection<RChanh> RChanh { get; set; }
    }
}

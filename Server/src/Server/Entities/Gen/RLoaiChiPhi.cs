using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RLoaiChiPhi
    {
        public RLoaiChiPhi()
        {
            TChiPhi = new HashSet<TChiPhi>();
        }

        public int Ma { get; set; }
        public string TenLoaiChiPhi { get; set; }
        public int MaGroup { get; set; }

        public virtual ICollection<TChiPhi> TChiPhi { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RLoaiChiPhi : huypq.SwaMiddleware.SwaIEntity
    {
        public RLoaiChiPhi()
        {
            TChiPhiMaLoaiChiPhiNavigation = new HashSet<TChiPhi>();
        }

        public int Ma { get; set; }
        public int MaGroup { get; set; }
        public string TenLoaiChiPhi { get; set; }

        public ICollection<TChiPhi> TChiPhiMaLoaiChiPhiNavigation { get; set; }

    }
}

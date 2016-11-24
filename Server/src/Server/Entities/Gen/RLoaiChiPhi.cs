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

        public int GroupID { get; set; }
        public int ID { get; set; }
        public string TenLoaiChiPhi { get; set; }

        public ICollection<TChiPhi> TChiPhiMaLoaiChiPhiNavigation { get; set; }

    }
}

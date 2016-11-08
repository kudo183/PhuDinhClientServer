using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RNuoc : huypq.SwaMiddleware.SwaIEntity
    {
        public RNuoc()
        {
            RDiaDiemMaNuocNavigation = new HashSet<RDiaDiem>();
        }

        public int Ma { get; set; }
        public int MaGroup { get; set; }
        public string TenNuoc { get; set; }

        public ICollection<RDiaDiem> RDiaDiemMaNuocNavigation { get; set; }

    }
}

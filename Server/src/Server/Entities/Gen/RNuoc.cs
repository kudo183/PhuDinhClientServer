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

        public int GroupID { get; set; }
        public int ID { get; set; }
        public string TenNuoc { get; set; }

        public ICollection<RDiaDiem> RDiaDiemMaNuocNavigation { get; set; }

    }
}

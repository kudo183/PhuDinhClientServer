using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RNuoc
    {
        public RNuoc()
        {
            RDiaDiem = new HashSet<RDiaDiem>();
        }

        public int Ma { get; set; }
        public string TenNuoc { get; set; }

        public virtual ICollection<RDiaDiem> RDiaDiem { get; set; }
    }
}

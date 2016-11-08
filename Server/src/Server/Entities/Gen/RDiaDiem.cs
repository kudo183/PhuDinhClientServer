using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RDiaDiem
    {
        public RDiaDiem()
        {
            RKhachHang = new HashSet<RKhachHang>();
        }

        public int Ma { get; set; }
        public int MaNuoc { get; set; }
        public string Tinh { get; set; }
        public int MaGroup { get; set; }

        public virtual ICollection<RKhachHang> RKhachHang { get; set; }
        public virtual RNuoc MaNuocNavigation { get; set; }
    }
}

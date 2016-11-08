using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RDiaDiem : huypq.SwaMiddleware.SwaIEntity
    {
        public RDiaDiem()
        {
            RKhachHangMaDiaDiemNavigation = new HashSet<RKhachHang>();
        }

        public int Ma { get; set; }
        public int MaGroup { get; set; }
        public int MaNuoc { get; set; }
        public string Tinh { get; set; }

        public ICollection<RKhachHang> RKhachHangMaDiaDiemNavigation { get; set; }

        public RNuoc MaNuocNavigation { get; set; }
    }
}

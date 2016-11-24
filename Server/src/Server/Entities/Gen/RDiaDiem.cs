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

        public int GroupID { get; set; }
        public int ID { get; set; }
        public int MaNuoc { get; set; }
        public string Tinh { get; set; }

        public ICollection<RKhachHang> RKhachHangMaDiaDiemNavigation { get; set; }

        public RNuoc MaNuocNavigation { get; set; }
    }
}

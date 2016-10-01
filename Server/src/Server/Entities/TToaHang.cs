using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TToaHang
    {
        public TToaHang()
        {
            TChiTietToaHang = new HashSet<TChiTietToaHang>();
        }

        public int Ma { get; set; }
        public int MaKhachHang { get; set; }
        public DateTime Ngay { get; set; }

        public virtual ICollection<TChiTietToaHang> TChiTietToaHang { get; set; }
        public virtual RKhachHang MaKhachHangNavigation { get; set; }
    }
}

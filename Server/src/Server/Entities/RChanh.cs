using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RChanh
    {
        public RChanh()
        {
            RKhachHangChanh = new HashSet<RKhachHangChanh>();
            TDonHang = new HashSet<TDonHang>();
        }

        public int Ma { get; set; }
        public int MaBaiXe { get; set; }
        public string TenChanh { get; set; }

        public virtual ICollection<RKhachHangChanh> RKhachHangChanh { get; set; }
        public virtual ICollection<TDonHang> TDonHang { get; set; }
        public virtual RBaiXe MaBaiXeNavigation { get; set; }
    }
}

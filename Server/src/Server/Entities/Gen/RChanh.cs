using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RChanh : huypq.SwaMiddleware.SwaIEntity
    {
        public RChanh()
        {
            RKhachHangChanhMaChanhNavigation = new HashSet<RKhachHangChanh>();
            TDonHangMaChanhNavigation = new HashSet<TDonHang>();
        }

        public int GroupID { get; set; }
        public int Ma { get; set; }
        public int MaBaiXe { get; set; }
        public string TenChanh { get; set; }

        public ICollection<RKhachHangChanh> RKhachHangChanhMaChanhNavigation { get; set; }
        public ICollection<TDonHang> TDonHangMaChanhNavigation { get; set; }

        public RBaiXe MaBaiXeNavigation { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}

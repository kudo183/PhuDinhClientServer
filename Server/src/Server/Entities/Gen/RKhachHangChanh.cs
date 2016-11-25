using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RKhachHangChanh : huypq.SwaMiddleware.SwaIEntity
    {
        public RKhachHangChanh()
        {
        }

        public int GroupID { get; set; }
        public bool LaMacDinh { get; set; }
        public int Ma { get; set; }
        public int MaChanh { get; set; }
        public int MaKhachHang { get; set; }


        public RChanh MaChanhNavigation { get; set; }
        public RKhachHang MaKhachHangNavigation { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}

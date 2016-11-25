using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TCongNoKhachHang : huypq.SwaMiddleware.SwaIEntity
    {
        public TCongNoKhachHang()
        {
        }

        public int GroupID { get; set; }
        public int Ma { get; set; }
        public int MaKhachHang { get; set; }
        public System.DateTime Ngay { get; set; }
        public int SoTien { get; set; }


        public RKhachHang MaKhachHangNavigation { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}

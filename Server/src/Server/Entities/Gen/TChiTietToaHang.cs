using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TChiTietToaHang : huypq.SwaMiddleware.SwaIEntity
    {
        public TChiTietToaHang()
        {
        }

        public int GiaTien { get; set; }
        public int GroupID { get; set; }
        public int Ma { get; set; }
        public int MaChiTietDonHang { get; set; }
        public int MaToaHang { get; set; }


        public TChiTietDonHang MaChiTietDonHangNavigation { get; set; }
        public TToaHang MaToaHangNavigation { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}

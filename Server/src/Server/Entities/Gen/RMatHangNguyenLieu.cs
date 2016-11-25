using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RMatHangNguyenLieu : huypq.SwaMiddleware.SwaIEntity
    {
        public RMatHangNguyenLieu()
        {
        }

        public int GroupID { get; set; }
        public int Ma { get; set; }
        public int MaMatHang { get; set; }
        public int MaNguyenLieu { get; set; }


        public TMatHang MaMatHangNavigation { get; set; }
        public RNguyenLieu MaNguyenLieuNavigation { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}

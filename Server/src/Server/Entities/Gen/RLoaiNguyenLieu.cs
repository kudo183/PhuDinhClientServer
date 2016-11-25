using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RLoaiNguyenLieu : huypq.SwaMiddleware.SwaIEntity
    {
        public RLoaiNguyenLieu()
        {
            RNguyenLieuMaLoaiNguyenLieuNavigation = new HashSet<RNguyenLieu>();
        }

        public int GroupID { get; set; }
        public int Ma { get; set; }
        public string TenLoai { get; set; }

        public ICollection<RNguyenLieu> RNguyenLieuMaLoaiNguyenLieuNavigation { get; set; }


        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}

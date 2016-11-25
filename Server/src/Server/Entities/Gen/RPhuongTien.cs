using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RPhuongTien : huypq.SwaMiddleware.SwaIEntity
    {
        public RPhuongTien()
        {
            RNhanVienMaPhuongTienNavigation = new HashSet<RNhanVien>();
        }

        public int GroupID { get; set; }
        public int Ma { get; set; }
        public string TenPhuongTien { get; set; }

        public ICollection<RNhanVien> RNhanVienMaPhuongTienNavigation { get; set; }


        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }
    }
}

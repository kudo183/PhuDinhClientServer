using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class RPhuongTien
    {
        public RPhuongTien()
        {
            RNhanVien = new HashSet<RNhanVien>();
        }

        public int Ma { get; set; }
        public string TenPhuongTien { get; set; }

        public virtual ICollection<RNhanVien> RNhanVien { get; set; }
    }
}

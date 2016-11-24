using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class TNhapNguyenLieu : huypq.SwaMiddleware.SwaIEntity
    {
        public TNhapNguyenLieu()
        {
        }

        public int GroupID { get; set; }
        public int ID { get; set; }
        public int MaNguyenLieu { get; set; }
        public int MaNhaCungCap { get; set; }
        public System.DateTime Ngay { get; set; }
        public int SoLuong { get; set; }


        public RNguyenLieu MaNguyenLieuNavigation { get; set; }
        public RNhaCungCap MaNhaCungCapNavigation { get; set; }
    }
}

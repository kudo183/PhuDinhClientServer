using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class ThamSoNgay : huypq.SwaMiddleware.SwaIEntity
    {
        public ThamSoNgay()
        {
        }

        public System.DateTime GiaTri { get; set; }
        public int GroupID { get; set; }
        public int ID { get; set; }
        public string Ten { get; set; }


    }
}

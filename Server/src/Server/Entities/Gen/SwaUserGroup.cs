using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class SwaUserGroup : huypq.SwaMiddleware.SwaIUserGroup
    {
        public SwaUserGroup()
        {
        }

        public int GroupID { get; set; }
        public int ID { get; set; }
        public bool IsGroupOwner { get; set; }
        public int UserID { get; set; }


        public SwaGroup GroupIDNavigation { get; set; }
        public SwaUser UserIDNavigation { get; set; }
    }
}

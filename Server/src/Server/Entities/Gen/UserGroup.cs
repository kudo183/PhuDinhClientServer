using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class UserGroup
    {
        public int Ma { get; set; }
        public bool LaChuGroup { get; set; }
        public int MaGroup { get; set; }
        public int MaUser { get; set; }

        public virtual Group MaGroupNavigation { get; set; }
        public virtual User MaUserNavigation { get; set; }
    }
}

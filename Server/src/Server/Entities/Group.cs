using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class Group
    {
        public Group()
        {
            UserGroupMaGroupNavigation = new HashSet<UserGroup>();
        }

        public int Ma { get; set; }
        public System.DateTime NgayTao { get; set; }
        public string TenGroup { get; set; }

        public ICollection<UserGroup> UserGroupMaGroupNavigation { get; set; }

    }
}

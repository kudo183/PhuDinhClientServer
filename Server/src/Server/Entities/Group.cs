using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class Group
    {
        public Group()
        {
            UserGroup = new HashSet<UserGroup>();
        }

        public int Ma { get; set; }
        public DateTime NgayTao { get; set; }
        public string TenGroup { get; set; }

        public virtual ICollection<UserGroup> UserGroup { get; set; }
    }
}

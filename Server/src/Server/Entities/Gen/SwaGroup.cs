using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class SwaGroup : huypq.SwaMiddleware.SwaIGroup
    {
        public SwaGroup()
        {
            SwaUserGroupGroupIDNavigation = new HashSet<SwaUserGroup>();
        }

        public System.DateTime CreateDate { get; set; }
        public string GroupName { get; set; }
        public int ID { get; set; }

        public ICollection<SwaUserGroup> SwaUserGroupGroupIDNavigation { get; set; }

    }
}

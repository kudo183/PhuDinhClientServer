using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class SwaUser : huypq.SwaMiddleware.SwaIUser
    {
        public SwaUser()
        {
            SwaUserGroupUserIDNavigation = new HashSet<SwaUserGroup>();
        }

        public System.DateTime CreateDate { get; set; }
        public string Email { get; set; }
        public int ID { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<SwaUserGroup> SwaUserGroupUserIDNavigation { get; set; }

    }
}

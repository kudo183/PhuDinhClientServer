using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class User : huypq.SwaMiddleware.SwaIUser
    {
        public User()
        {
            UserGroupMaUserNavigation = new HashSet<UserGroup>();
        }

        public string Email { get; set; }
        public int Ma { get; set; }
        public System.DateTime NgayTao { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<UserGroup> UserGroupMaUserNavigation { get; set; }

    }
}

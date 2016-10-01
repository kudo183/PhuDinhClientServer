using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class User : huypq.SwaMiddleware.SwaIUser
    {
        public User()
        {
            UserGroup = new HashSet<UserGroup>();
        }

        public int Ma { get; set; }
        public string Email { get; set; }
        public DateTime NgayTao { get; set; }
        public string PasswordHash { get; set; }

        public virtual ICollection<UserGroup> UserGroup { get; set; }
    }
}

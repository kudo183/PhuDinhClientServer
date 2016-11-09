using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public partial class UserGroup : huypq.SwaMiddleware.SwaIUserGroup, huypq.SwaMiddleware.SwaIEntity
    {
        public UserGroup()
        {
        }

        public bool LaChuGroup { get; set; }
        public int Ma { get; set; }
        public int MaGroup { get; set; }
        public int MaUser { get; set; }


        public Group MaGroupNavigation { get; set; }
        public User MaUserNavigation { get; set; }
    }
}

using System.Collections.Generic;

namespace Server.Entities
{
    public class User : huypq.SwaMiddleware.SwaUser
    {
        public List<UserGroup> UserGroups { get; set; }
    }
}

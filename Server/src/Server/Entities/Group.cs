using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Entities
{
    public class Group : huypq.SwaMiddleware.SwaIEntity
    {
        [Key]
        public int Ma { get; set; }
        [Required]
        [MaxLength(256)]
        public string TenGroup { get; set; }
        public System.DateTime NgayTao { get; set; }

        public List<UserGroup> UserGroups { get; set; }
    }
}

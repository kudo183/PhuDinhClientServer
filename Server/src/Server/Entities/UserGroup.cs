using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entities
{
    public class UserGroup : huypq.SwaMiddleware.SwaIEntity
    {
        [Key]
        public int Ma { get; set; }
        [Required]
        public int MaUser { get; set; }
        [Required]
        public int MaGroup { get; set; }
        public bool LaChuGroup { get; set; }

        [ForeignKey("MaUser")]
        public User User { get; set; }
        [ForeignKey("MaGroup")]
        public Group Group { get; set; }
    }
}

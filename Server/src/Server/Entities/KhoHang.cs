using System.ComponentModel.DataAnnotations;

namespace Server.Entities
{
    public class KhoHang : huypq.SwaMiddleware.SwaIEntity
    {
        [Key]
        public int Ma { get; set; }
        [Required]
        [MaxLength(128)]
        public string TenKho { get; set; }
        public bool TrangThai { get; set; }
    }
}

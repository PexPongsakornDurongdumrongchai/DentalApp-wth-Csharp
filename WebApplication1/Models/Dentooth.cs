using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Dentooth
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("ชื่อสถานทันตกรรม")]
        public string Name { get; set; }
        [DisplayName("สถานที่ทันตกรรม")]
        public string Description { get; set; }
    }
}

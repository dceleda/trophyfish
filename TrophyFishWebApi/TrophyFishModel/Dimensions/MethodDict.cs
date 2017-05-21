using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrophyFish.Model
{
    public partial class MethodDict
    {
        [Key]
        [Required]
        public byte ID { get; set; }

        [StringLength(20)]
        [Required]
        public string Name { get; set; }
    }
}

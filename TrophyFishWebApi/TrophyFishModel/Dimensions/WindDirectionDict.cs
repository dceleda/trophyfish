using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrophyFish.Model
{
    public partial class WindDirectionDict
    {
        [Key]
        [Required]
        public byte ID { get; set; }

        [StringLength(2)]
        [Required]
        public string Name { get; set; }
    }
}

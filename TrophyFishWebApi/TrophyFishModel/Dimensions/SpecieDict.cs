using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrophyFish.Model
{
    public partial class SpecieDict
    {
        [Key]
        [Required]
        public byte ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}

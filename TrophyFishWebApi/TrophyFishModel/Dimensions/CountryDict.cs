using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrophyFish.Model
{
    public partial class CountryDict
    {
        [Key]
        [Required]
        public byte ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
    }
}

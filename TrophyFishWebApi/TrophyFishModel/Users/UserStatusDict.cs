﻿
using System.ComponentModel.DataAnnotations;

namespace TrophyFish.Model
{
    public class UserStatusDict
    {
        [Key]
        [Required]
        public byte ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}

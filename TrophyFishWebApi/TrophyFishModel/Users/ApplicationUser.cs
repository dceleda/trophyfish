using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace TrophyFish.Model
{

    public partial class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// File name
        /// </summary>
        [StringLength(50)]
        public string Avatar { get; set; }

        [Required]
        public byte StatusID { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime LastModifiedDate { get; set; }


        #region Related Properties

        [ForeignKey(nameof(StatusID))]
        public virtual UserStatusDict Status { get; set; }

        public virtual List<Fish> Fishes { get; set; }

        #endregion
    }
}

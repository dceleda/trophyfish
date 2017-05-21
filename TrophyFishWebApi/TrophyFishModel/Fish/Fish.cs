
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrophyFish.Model
{
    public partial class Fish
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public byte SpecieID { get; set; }

        public short? Length { get; set; }

        [Range(0, 1000000)]
        public short? Weight { get; set; }

        [Required]
        public DateTime CatchDate { get; set; }

        public short? WaterTemp { get; set; }

        public short? AirTemp { get; set; }

        public byte? WindDirID { get; set; }

        public byte? WindSpeed { get; set; }

        public byte? MoonPhase { get; set; }

        public short? Pressure { get; set; }

        public byte? PressureChangeID { get; set; }

        public byte? WaterLevelID { get; set; }

        public byte? CloudID { get; set; }

        [Required]
        public byte FisheryTypeID { get; set; }

        [Required]
        public byte CountryID { get; set; }

        public byte? PrecipitationID { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required]
        public byte StatusID { get; set; }

        public byte? MethodID { get; set; }

        public byte? LureBaitID { get; set; }

        [StringLength(50)]
        public string LureBaitDesc { get; set; }

        #region Foreign Keys

        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(CloudID))]
        public virtual CloudDict Cloud { get; set; }

        [ForeignKey(nameof(CountryID))]
        public virtual CountryDict Country { get; set; }

        [ForeignKey(nameof(FisheryTypeID))]
        public virtual FisheryTypeDict FisheryType { get; set; }

        [ForeignKey(nameof(StatusID))]
        public virtual FishStatusDict Status { get; set; }

        [ForeignKey(nameof(LureBaitID))]
        public virtual LureBaitDict LureBait { get; set; }

        [ForeignKey(nameof(MethodID))]
        public virtual MethodDict Method { get; set; }

        [ForeignKey(nameof(PrecipitationID))]
        public virtual PrecipitationDict Precipitation { get; set; }

        [ForeignKey(nameof(PressureChangeID))]
        public virtual PressureChangeDict PressureChange { get; set; }

        [ForeignKey(nameof(SpecieID))]
        public virtual SpecieDict Specie { get; set; }

        [ForeignKey(nameof(WaterLevelID))]
        public virtual WaterLevelDict WaterLevel { get; set; }

        [ForeignKey(nameof(WindDirID))]
        public virtual WindDirectionDict WindDirection { get; set; }

        #endregion
    }
}

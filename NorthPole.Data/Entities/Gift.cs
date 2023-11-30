using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthPoleGiftSystem.NorthPole.Data.Entities
{
    public class GiftEntity
    {
        [Key]
        public int GiftID { get; set; }

        [Required]
        public string GiftName { get; set; }

        public string GiftDescription { get; set; }

        public int WorkshopID { get; set; }

        [Required]
        public string ProductionStatus { get; set; }

        [ForeignKey("WorkshopID")]
        public virtual WorkshopEntity Workshop { get; set; }

        public DateTime LastUpdated { get; set; }

        public int WishlistID { get; set; }
    }
}

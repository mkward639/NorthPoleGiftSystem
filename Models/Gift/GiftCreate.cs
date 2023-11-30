using System.ComponentModel.DataAnnotations;

namespace NorthPoleGiftSystem.Models.Gift
{
    public class GiftCreate
    {
        [Required(ErrorMessage = "GiftName is required")]
        public string GiftName { get; set; }

        public string GiftDescription { get; set; }

        [Required(ErrorMessage = "WorkshopID is required")]
        public int WorkshopID { get; set; }

        [Required(ErrorMessage = "ProductionStatus is required")]
        public string ProductionStatus { get; set; }
    }
}

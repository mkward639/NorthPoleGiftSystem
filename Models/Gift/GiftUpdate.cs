using System.ComponentModel.DataAnnotations;

namespace NorthPoleGiftSystem.Models.Gift
{
    public class GiftUpdate
    {
        public int GiftID { get; set; }

        [Required(ErrorMessage = "GiftDescription is required")]
        public string GiftDescription { get; set; }

        [Required(ErrorMessage = "GiftName is required")]
        public string GiftName { get; set; }

        [Required(ErrorMessage = "ProductionStatus is required")]
        public string ProductionStatus { get; set; }

        [Required(ErrorMessage = "WorkshopID is required")]
        public int WorkshopID { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace NorthPoleGiftSystem.Models.WorkshopModel
{
    public class WorkshopUpdate
    {
        public int WorkshopID { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "WorkshopCapacity is required")]
        public int WorkshopCapacity { get; set; }

    }
}

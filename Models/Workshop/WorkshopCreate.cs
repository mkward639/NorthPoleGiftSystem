using System.ComponentModel.DataAnnotations;

namespace NorthPoleGiftSystem.Models.WorkshopModel
{
    public class WorkshopCreate
    {
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "WorkshopCapacity is required")]
        public int WorkshopCapacity { get; set; }

        [Required(ErrorMessage = "SupervisorID is required")]
        public int SupervisorID { get; set; }
    }
}

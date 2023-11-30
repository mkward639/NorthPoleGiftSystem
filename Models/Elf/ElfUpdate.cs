using System.ComponentModel.DataAnnotations;

namespace NorthPoleGiftSystem.Models.Elf
{
    public class ElfUpdate
    {
        public int ElfID { get; set; }

        [Required(ErrorMessage = "ElfName is required")]
        public string ElfName { get; set; }

        [Required(ErrorMessage = "ElfRole is required")]
        public string ElfRole { get; set; }

        [Required(ErrorMessage = "WorkshopID is required")]
        public int WorkshopID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NorthPoleGiftSystem.Models.Elf
{
    public class ElfCreate
    {
        [Required(ErrorMessage = "ElfName is required")]
        public string ElfName { get; set; }

        [Required(ErrorMessage = "ElfRole is required")]
        public string ElfRole { get; set; }

        [Required(ErrorMessage = "WorkshopID is required")]
        public int WorkshopID { get; set; }

        [Required(ErrorMessage = "WorkshopName is required")]
        public string WorkshopName { get; set; }
    }
}

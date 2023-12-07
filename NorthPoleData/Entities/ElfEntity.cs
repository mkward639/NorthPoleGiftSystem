using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NorthPoleGiftSystem.NorthPole.Data.Entities;
using NorthPoleGiftSystem.NorthPole.Data;

namespace NorthPoleGiftSystem.NorthPole.Data.Entities
{
    [Table("Elves")]
    public class ElfEntity
    {
        [Key]
        public int ElfID { get; set; }

        [Required]
        public string ElfName { get; set; }

        [Required]
        public string ElfRole { get; set; }

        public int WorkshopID { get; set; }

        [ForeignKey("WorkshopID")]
        public virtual WorkshopEntity Workshop { get; set; }
    }
}

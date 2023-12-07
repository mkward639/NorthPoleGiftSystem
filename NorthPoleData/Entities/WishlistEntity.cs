using System.ComponentModel.DataAnnotations;

namespace NorthPoleGiftSystem.NorthPole.Data.Entities
{
    public class WishlistEntity
    {
        [Key]
        public int WishlistID { get; set; }

        [Required(ErrorMessage = "Wishlist name is required")]
        public string WishlistName { get; set; }

        [Required(ErrorMessage = "Elf ID is required")]
        public int ElfID { get; set; }

        public ElfEntity Elf { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}

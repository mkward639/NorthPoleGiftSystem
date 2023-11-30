using System.ComponentModel.DataAnnotations;

namespace NorthPoleGiftSystem.Models.WishlistModel
{
    public class WishlistCreate
    {
        [Required(ErrorMessage = "Wishlist name is required")]
        public string WishlistName { get; set; }

        [Required(ErrorMessage = "Elf ID is required")]
        public int ElfID { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace NorthPoleGiftSystem.Models.WishlistModel
{
    public class WishlistUpdate
    {
        public int WishlistID { get; set; }

        [Required(ErrorMessage = "WishlistName is required")]
        public string WishlistName { get; set; }

        [Required(ErrorMessage = "ElfID is required")]
        public int ElfID { get; set; }
    }
}

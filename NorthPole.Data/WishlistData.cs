using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthPoleGiftSystem.NorthPole.Data
{
    public class Wishlist
    {

        public int WishlistID { get; set; }

        public string WishlistName { get; set; }

        public int ElfID { get; set; }

        public Elf Elf { get; set; }
    }
}

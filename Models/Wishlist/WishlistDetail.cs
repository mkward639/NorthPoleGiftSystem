using System;
using System.Collections.Generic;
using NorthPoleGiftSystem.Models.Gift;

namespace NorthPoleGiftSystem.Models.WishlistModel
{
    public class WishlistDetail
    {
        public int WishlistID { get; set; }
        public string WishlistName { get; set; }
        public int ElfID { get; set; }
        public DateTime LastUpdated { get; set; }

        public List<GiftDetail> Gifts { get; set; }
    }
}

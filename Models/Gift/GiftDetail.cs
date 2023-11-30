using System;

namespace NorthPoleGiftSystem.Models.Gift
{
    public class GiftDetail
    {
        public int GiftID { get; set; }
        public string GiftName { get; set; }
        public string GiftDescription { get; set; }
        public int WorkshopID { get; set; }
        public string ProductionStatus { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public int WishlistID { get; set; }
    }
}

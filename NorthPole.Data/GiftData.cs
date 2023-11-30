using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthPoleGiftSystem.NorthPole.Data
{
    public class Gift
    {
        public int GiftID { get; set; }
        public string GiftName { get; set; }
        public string GiftDescription { get; set; }
        public int WorkshopID { get; set; }
        public string ProductionStatus { get; set; }
    }
}

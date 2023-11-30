
using System;

namespace NorthPoleGiftSystem.Models.WorkshopModel
{
    public class WorkshopDetail
    {
        public int WorkshopID { get; set; }
        public string Location { get; set; }
        public int WorkshopCapacity { get; set; }
        public int SupervisorID { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}

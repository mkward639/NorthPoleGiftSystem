using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthPoleGiftSystem.NorthPole.Data.Entities;

namespace NorthPoleGiftSystem.NorthPole.Data
{
    public class Workshop
    {
        public int WorkshopID { get; set; }
        public string Location { get; set; }
        public int WorkshopCapacity { get; set; }
        public int SupervisorID { get; set; }
        public List<ElfEntity> Elves { get; set; }
    }
}

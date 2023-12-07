using System;

namespace NorthPoleGiftSystem.Models.Elf
{
    public class ElfDetail
    {
        public int ElfID { get; set; }
        public string ElfName { get; set; }
        public string ElfRole { get; set; }
        public string WorkshopName { get; set; }
        public string WorkshopLocation { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<ElfDetail> Elves { get; set; }
        public int WorkshopID { get; set; }

    }
}

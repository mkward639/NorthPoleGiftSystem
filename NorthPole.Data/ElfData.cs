using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthPoleGiftSystem.NorthPole.Data.Entities;
using NorthPoleGiftSystem.NorthPole.Data;

namespace NorthPoleGiftSystem.NorthPole.Data
{
    public class Elf
    {
        public int ElfID { get; set; }
        public string ElfName { get; set; }
        public string ElfRole { get; set; }
        public int WorkshopID { get; set; }
        public Workshop Workshop { get; set; }
    }
}


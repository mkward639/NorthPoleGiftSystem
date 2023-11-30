using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthPoleGiftSystem.NorthPole.Data;
using System.ComponentModel.DataAnnotations;

namespace NorthPoleGiftSystem.Models.Elf
{
    public class ElfListItem
    {
        public int ElfID { get; set; }
        public string ElfName { get; set; }
        public string ElfRole { get; set; }
        public string WorkshopName { get; set; }

        public ElfListItem() { }

        public ElfListItem(NorthPoleGiftSystem.NorthPole.Data.Elf elf)
        {
            ElfID = elf.ElfID;
            ElfName = elf.ElfName;
            ElfRole = elf.ElfRole;
            WorkshopName = elf.Workshop?.Location;
        }
    }
}

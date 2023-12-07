using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthPoleGiftSystem.NorthPole.Data.Entities
{
    public class WorkshopEntity
    {
        [Key]
        public int WorkshopID { get; set; }

        [Required]
        public string Location { get; set; }

        public int WorkshopCapacity { get; set; }

        public int SupervisorID { get; set; }




    }
}
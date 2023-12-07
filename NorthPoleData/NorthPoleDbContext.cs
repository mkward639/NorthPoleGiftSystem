using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthPoleGiftSystem.Models;
using NorthPoleGiftSystem.NorthPole.Data;
using NorthPoleGiftSystem.NorthPole.Data.Entities;




namespace NorthPoleGiftSystem.NorthPole.Data
{
    public class NorthPoleDbContext : DbContext
    {
        public NorthPoleDbContext(DbContextOptions<NorthPoleDbContext> options) : base(options)
        {
        }

        public DbSet<ElfEntity> Elves { get; set; }
        public DbSet<WorkshopEntity> Workshops { get; set; }
        public DbSet<GiftEntity> Gifts { get; set; }
        public DbSet<WishlistEntity> Wishlists { get; set; }


    }
}


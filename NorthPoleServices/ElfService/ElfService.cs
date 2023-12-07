using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthPoleGiftSystem.Models.Elf;
using NorthPoleGiftSystem.NorthPole.Data.Entities;
using NorthPoleGiftSystem.NorthPole.Data;
using NorthPoleGiftSystem.NorthPoleServices;

namespace NorthPoleGiftSystem.Services
{
    public class ElfService : IElfService
    {
        private readonly NorthPoleDbContext _dbContext;

        public ElfService(NorthPoleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ElfListItem>> GetAllElves()
        {
            List<ElfListItem> elves = await _dbContext.Elves
                .Include(e => e.Workshop)
                .Select(e => new ElfListItem()
                {
                    ElfID = e.ElfID,
                    ElfName = e.ElfName,
                    ElfRole = e.ElfRole,
                    WorkshopName = e.Workshop != null ? e.Workshop.Location : null,
                })
                .ToListAsync();

            return elves;
        }

        public ElfDetail GetElfById(int elfID)
        {
            var elf = _dbContext.Elves
                .Include(e => e.Workshop)
                .Select(e => new ElfDetail()
                {
                    ElfID = e.ElfID,
                    ElfName = e.ElfName,
                    ElfRole = e.ElfRole,
                    WorkshopID = e.WorkshopID,
                    WorkshopName = e.Workshop != null ? e.Workshop.Location : null,
                    WorkshopLocation = e.Workshop != null ? e.Workshop.Location : null,
                    LastUpdated = DateTime.UtcNow,
                })
                .FirstOrDefault(e => e.ElfID == elfID);

            return elf;
        }

        public async Task<bool> AddElfAsync(ElfCreate model)
        {
            ElfEntity elf = new ElfEntity()
            {
                ElfName = model.ElfName,
                ElfRole = model.ElfRole,
                WorkshopID = model.WorkshopID
            };

            _dbContext.Elves.Add(elf);
            int affectedRows = await _dbContext.SaveChangesAsync();

            return affectedRows == 1;
        }

        public async Task<bool> UpdateElfAsync(ElfUpdate model)
        {
            ElfEntity elf = await _dbContext.Elves.FindAsync(model.ElfID);

            if (elf == null)
                return false;

            elf.ElfName = model.ElfName;
            elf.ElfRole = model.ElfRole;
            elf.WorkshopID = model.WorkshopID;

            int numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public void DeleteElf(int elfId)
        {
            var elfToDelete = _dbContext.Elves.Find(elfId);
            if (elfToDelete != null)
            {
                _dbContext.Elves.Remove(elfToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}

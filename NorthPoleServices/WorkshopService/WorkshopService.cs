using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthPoleGiftSystem.Models.WorkshopModel;
using NorthPoleGiftSystem.NorthPole.Data;
using NorthPoleGiftSystem.NorthPole.Data.Entities;
using NorthPoleGiftSystem.NorthPoleServices;

namespace NorthPoleGiftSystem.Services
{
    public class WorkshopService : IWorkshopService
    {
        private readonly NorthPoleDbContext _dbContext;

        public WorkshopService(NorthPoleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<WorkshopListItem>> GetAllWorkshops()
        {
            List<WorkshopListItem> workshops = await _dbContext.Workshops
                .Select(w => new WorkshopListItem
                {
                    WorkshopID = w.WorkshopID,
                    Location = w.Location,
                    WorkshopCapacity = w.WorkshopCapacity
                })
                .ToListAsync();

            return workshops;
        }

        public WorkshopDetail GetWorkshopById(int workshopId)
        {
            WorkshopDetail workshop = _dbContext.Workshops
                .Where(w => w.WorkshopID == workshopId)
                .Select(w => new WorkshopDetail
                {
                    WorkshopID = w.WorkshopID,
                    Location = w.Location,
                    WorkshopCapacity = w.WorkshopCapacity,
                })
                .FirstOrDefault();

            return workshop;
        }

        public async Task<bool> AddWorkshopAsync(WorkshopCreate model)
        {
            WorkshopEntity workshop = new WorkshopEntity
            {
                Location = model.Location,
                WorkshopCapacity = model.WorkshopCapacity,
                SupervisorID = model.SupervisorID
            };

            _dbContext.Workshops.Add(workshop);
            int affectedRows = await _dbContext.SaveChangesAsync();

            return affectedRows == 1;
        }

        public async Task<bool> UpdateWorkshopAsync(WorkshopUpdate model)
        {
            WorkshopEntity workshop = await _dbContext.Workshops.FindAsync(model.WorkshopID);

            if (workshop == null)
                return false;

            workshop.Location = model.Location;
            workshop.WorkshopCapacity = model.WorkshopCapacity;

            int numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteWorkshopAsync(int workshopId)
        {
            var workshopToDelete = await _dbContext.Workshops.FindAsync(workshopId);
            if (workshopToDelete == null)
                return false;

            _dbContext.Workshops.Remove(workshopToDelete);
            int numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }
    }
}


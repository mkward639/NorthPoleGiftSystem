using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthPoleGiftSystem.Models.Gift;
using NorthPoleGiftSystem.NorthPole.Data;
using NorthPoleGiftSystem.NorthPole.Data.Entities;
using NorthPoleGiftSystem.NorthPoleServices;

namespace NorthPoleGiftSystem.Services
{
    public class GiftService : IGiftService
    {
        private readonly NorthPoleDbContext _dbContext;

        public GiftService(NorthPoleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GiftListItem>> GetAllGifts()
        {
            List<GiftListItem> gifts = await _dbContext.Gifts
                .Select(g => new GiftListItem
                {
                    GiftID = g.GiftID,
                    GiftName = g.GiftName,
                    ProductionStatus = g.ProductionStatus
                })
                .ToListAsync();

            return gifts;
        }

        public async Task<GiftDetail> GetGiftById(int giftId)
        {
            GiftDetail gift = _dbContext.Gifts
                .Where(g => g.GiftID == giftId)
                .Select(g => new GiftDetail
                {
                    GiftID = g.GiftID,
                    GiftName = g.GiftName,
                    GiftDescription = g.GiftDescription,
                    WorkshopID = g.WorkshopID,
                    ProductionStatus = g.ProductionStatus
                })
                .FirstOrDefault();

            return gift;
        }

        public async Task<bool> AddGiftAsync(GiftCreate model)
        {
            GiftEntity gift = new GiftEntity
            {
                GiftName = model.GiftName,
                GiftDescription = model.GiftDescription,
                WorkshopID = model.WorkshopID,
                ProductionStatus = model.ProductionStatus
            };

            _dbContext.Gifts.Add(gift);
            int affectedRows = await _dbContext.SaveChangesAsync();

            return affectedRows == 1;
        }

        public async Task<bool> UpdateGiftAsync(GiftUpdate model)
        {
            GiftEntity gift = await _dbContext.Gifts.FindAsync(model.GiftID);

            if (gift == null)
                return false;

            gift.GiftName = model.GiftName;
            gift.GiftDescription = model.GiftDescription;
            gift.WorkshopID = model.WorkshopID;
            gift.ProductionStatus = model.ProductionStatus;

            int numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteGiftAsync(int giftId)
        {
            var giftToDelete = await _dbContext.Gifts.FindAsync(giftId);

            if (giftToDelete == null)
                return false;

            _dbContext.Gifts.Remove(giftToDelete);
            int affectedRows = await _dbContext.SaveChangesAsync();

            return affectedRows == 1;
        }
    }
}

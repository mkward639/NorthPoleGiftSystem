// WishlistService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthPoleGiftSystem.Models.WishlistModel;
using NorthPoleGiftSystem.NorthPole.Data;
using NorthPoleGiftSystem.NorthPole.Data.Entities;
using NorthPoleGiftSystem.NorthPoleServices;
using NorthPoleGiftSystem.Models.Gift;

namespace NorthPoleGiftSystem.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly NorthPoleDbContext _dbContext;

        public WishlistService(NorthPoleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<WishlistListItem>> GetAllWishlists()
        {
            List<WishlistListItem> wishlists = await _dbContext.Wishlists
                .Select(w => new WishlistListItem
                {
                    WishlistID = w.WishlistID,
                    WishlistName = w.WishlistName,
                    ElfID = w.ElfID
                })
                .ToListAsync();

            return wishlists;
        }

        public async Task<WishlistDetail> GetWishlistById(int wishlistId)
        {
            WishlistDetail wishlist = _dbContext.Wishlists
                .Where(w => w.WishlistID == wishlistId)
                .Select(w => new WishlistDetail
                {
                    WishlistID = w.WishlistID,
                    WishlistName = w.WishlistName,
                    ElfID = w.ElfID,
                    LastUpdated = w.LastUpdated,
                    Gifts = _dbContext.Gifts
                        .Where(g => g.WishlistID == w.WishlistID)
                        .Select(g => new GiftDetail
                        {
                            GiftID = g.GiftID,
                            GiftName = g.GiftName,
                            GiftDescription = g.GiftDescription,
                            WorkshopID = g.WorkshopID,
                            ProductionStatus = g.ProductionStatus,
                            LastUpdated = g.LastUpdated
                        })
                        .ToList()
                })
                .FirstOrDefault();

            return wishlist;
        }

        public async Task<bool> AddWishlistAsync(WishlistCreate model)
        {
            WishlistEntity wishlist = new WishlistEntity
            {
                WishlistName = model.WishlistName,
                ElfID = model.ElfID
            };

            _dbContext.Wishlists.Add(wishlist);
            int affectedRows = await _dbContext.SaveChangesAsync();

            return affectedRows == 1;
        }

        public async Task<bool> UpdateWishlistAsync(WishlistUpdate model)
        {
            WishlistEntity wishlist = await _dbContext.Wishlists.FindAsync(model.WishlistID);

            if (wishlist == null)
                return false;

            wishlist.WishlistName = model.WishlistName;
            wishlist.ElfID = model.ElfID;

            int numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteWishlistAsync(int wishlistId)
        {
            var wishlistToDelete = await _dbContext.Wishlists.FindAsync(wishlistId);

            if (wishlistToDelete == null)
                return false;

            _dbContext.Wishlists.Remove(wishlistToDelete);
            int affectedRows = await _dbContext.SaveChangesAsync();

            return affectedRows == 1;
        }
    }
}

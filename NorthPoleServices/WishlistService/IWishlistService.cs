using System.Collections.Generic;
using System.Threading.Tasks;
using NorthPoleGiftSystem.Models.WishlistModel;

namespace NorthPoleGiftSystem.NorthPoleServices
{
    public interface IWishlistService
    {
        Task<List<WishlistListItem>> GetAllWishlists();
        Task<WishlistDetail> GetWishlistById(int wishlistId);
        Task<bool> AddWishlistAsync(WishlistCreate model);
        Task<bool> UpdateWishlistAsync(WishlistUpdate model);
        Task<bool> DeleteWishlistAsync(int wishlistId);
    }
}

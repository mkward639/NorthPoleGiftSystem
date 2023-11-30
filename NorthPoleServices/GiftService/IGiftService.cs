using System.Collections.Generic;
using System.Threading.Tasks;
using NorthPoleGiftSystem.Models.Gift;

namespace NorthPoleGiftSystem.NorthPoleServices
{
    public interface IGiftService
    {
        Task<List<GiftListItem>> GetAllGifts();
        Task<GiftDetail> GetGiftById(int giftId);
        Task<bool> AddGiftAsync(GiftCreate model);
        Task<bool> UpdateGiftAsync(GiftUpdate model);
        Task<bool> DeleteGiftAsync(int giftId);
    }
}

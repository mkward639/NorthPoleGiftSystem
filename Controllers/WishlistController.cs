using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthPoleGiftSystem.Models.WishlistModel;
using NorthPoleGiftSystem.NorthPoleServices;

namespace NorthPoleGiftSystem.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IWishlistService _wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        public async Task<IActionResult> Index()
        {
            var wishlists = await _wishlistService.GetAllWishlists();
            return View(wishlists);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WishlistCreate model)
        {
            if (ModelState.IsValid)
            {
                await _wishlistService.AddWishlistAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var wishlist = await _wishlistService.GetWishlistById(id);
            if (wishlist == null)
            {
                return NotFound();
            }
            return View(wishlist);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var wishlist = await _wishlistService.GetWishlistById(id);
            if (wishlist == null)
            {
                return NotFound();
            }
            return View(wishlist);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, WishlistUpdate model)
        {
            if (id != model.WishlistID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _wishlistService.UpdateWishlistAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var wishlist = await _wishlistService.GetWishlistById(id);
            if (wishlist == null)
            {
                return NotFound();
            }
            return View(wishlist);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _wishlistService.DeleteWishlistAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthPoleGiftSystem.Models.Gift;
using NorthPoleGiftSystem.NorthPoleServices;
using NorthPoleGiftSystem.Services;

namespace NorthPoleGiftSystem.Controllers
{
    public class GiftController : Controller
    {
        private readonly IGiftService _giftService;

        public GiftController(IGiftService giftService)
        {
            _giftService = giftService;
        }

        public async Task<IActionResult> Index()
        {
            var gifts = await _giftService.GetAllGifts();
            return View(gifts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GiftCreate model)
        {
            if (ModelState.IsValid)
            {
                await _giftService.AddGiftAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var gift = await _giftService.GetGiftById(id);
            if (gift == null)
            {
                return NotFound();
            }
            return View(gift);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var gift = await _giftService.GetGiftById(id);
            if (gift == null)
            {
                return NotFound();
            }
            return View(gift);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, GiftUpdate model)
        {
            if (id != model.GiftID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _giftService.UpdateGiftAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var gift = await _giftService.GetGiftById(id);
            if (gift == null)
            {
                return NotFound();
            }
            return View(gift);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _giftService.DeleteGiftAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

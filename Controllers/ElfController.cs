using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthPoleGiftSystem.Models.Elf;
using NorthPoleGiftSystem.NorthPoleServices;

namespace NorthPoleGiftSystem.Controllers
{
    public class ElfController : Controller
    {
        private readonly IElfService _elfService;

        public ElfController(IElfService elfService)
        {
            _elfService = elfService;
        }

        public async Task<IActionResult> Index()
        {
            var elves = await _elfService.GetAllElves();
            return View(elves);
        }

        public IActionResult Details(int id)
        {
            var elf = _elfService.GetElfById(id);

            if (elf == null)
            {
                return NotFound();
            }

            return View(elf);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ElfCreate model)
        {
            if (ModelState.IsValid)
            {
                await _elfService.AddElfAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var elf = _elfService.GetElfById(id);

            if (elf == null)
            {
                return NotFound();
            }

            return View(elf);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ElfUpdate model)
        {
            if (id != model.ElfID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var success = await _elfService.UpdateElfAsync(model);

                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var elf = _elfService.GetElfById(id);

            if (elf == null)
            {
                return NotFound();
            }

            return View(elf);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _elfService.DeleteElf(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

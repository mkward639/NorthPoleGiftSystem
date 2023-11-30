using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthPoleGiftSystem.Models.WorkshopModel;
using NorthPoleGiftSystem.NorthPoleServices;

namespace NorthPoleGiftSystem.Controllers
{
    public class WorkshopController : Controller
    {
        private readonly IWorkshopService _workshopService;

        public WorkshopController(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public async Task<IActionResult> Index()
        {
            var workshops = await _workshopService.GetAllWorkshops();
            return View(workshops);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkshopCreate model)
        {
            if (ModelState.IsValid)
            {
                await _workshopService.AddWorkshopAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var workshop = _workshopService.GetWorkshopById(id);
            if (workshop == null)
            {
                return NotFound();
            }
            return View(workshop);
        }

        public IActionResult Edit(int id)
        {
            var workshop = _workshopService.GetWorkshopById(id);
            if (workshop == null)
            {
                return NotFound();
            }
            return View(workshop);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, WorkshopUpdate model)
        {
            if (id != model.WorkshopID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _workshopService.UpdateWorkshopAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var workshop = _workshopService.GetWorkshopById(id);
            if (workshop == null)
            {
                return NotFound();
            }
            return View(workshop);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _workshopService.DeleteWorkshopAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

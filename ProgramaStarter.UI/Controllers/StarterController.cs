using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProgramaStarter.Application.DTO;
using ProgramaStarter.Application.Interfaces;

namespace ProgramaStarter.UI.Controllers
{
    public class StarterController : Controller
    {
        private readonly IStarterService _starterService;
        public StarterController(IStarterService starterService)
        {
            _starterService = starterService;
        }

        public async Task<IActionResult> Index()
        {
            var starters = await _starterService.GetAsync();
            return View(starters);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Create(StarterDTO starter)
        {
            if (ModelState.IsValid)
            {
                await _starterService.AddAsync(starter);
                return RedirectToAction(nameof(Index));
            }
            return View(starter);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var starterDTO = await _starterService.GetByIdAsync(id);
            if (starterDTO == null) return NotFound();
            return View(starterDTO);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(StarterDTO starterDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _starterService.UpdateAsync(starterDTO);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(starterDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var starterDTO = await _starterService.GetByIdAsync(id);

            if (starterDTO == null) return NotFound();

            return View(starterDTO);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _starterService.RemoveAsync(id);
            return RedirectToAction("Index");
        }
    }
}
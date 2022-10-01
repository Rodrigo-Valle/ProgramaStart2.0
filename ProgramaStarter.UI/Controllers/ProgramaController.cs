using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProgramaStarter.Application.DTO;
using ProgramaStarter.Application.Interfaces;

namespace ProgramaStarter.UI.Controllers
{
    public class ProgramaController : Controller
    {
        private readonly IProgramaService _programaService;
        public ProgramaController(IProgramaService programaService)
        {
            _programaService = programaService;
        }

        public async Task<IActionResult> Index()
        {
            var programas = await _programaService.GetAsync();
            return View(programas);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Create(ProgramaDTO programa)
        {
            if (ModelState.IsValid)
            {
                await _programaService.AddAsync(programa);
                return RedirectToAction(nameof(Index));
            }
            return View(programa);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var programaDTO = await _programaService.GetByIdAsync(id);
            if (programaDTO == null) return NotFound();
            return View(programaDTO);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(ProgramaDTO programaDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _programaService.UpdateAsync(programaDTO);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(programaDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var programaDTO = await _programaService.GetByIdAsync(id);

            if (programaDTO == null) return NotFound();

            return View(programaDTO);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _programaService.RemoveAsync(id);
            return RedirectToAction("Index");
        }
    }
}
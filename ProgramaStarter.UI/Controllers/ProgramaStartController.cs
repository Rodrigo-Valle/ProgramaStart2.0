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
    public class ProgramaStartController : Controller
    {
        private readonly IProgramaStartService _programaStartService;
        public ProgramaStartController(IProgramaStartService programaStartService)
        {
            _programaStartService = programaStartService;
        }

        public async Task<IActionResult> Index()
        {
            var programas = await _programaStartService.GetAsync();
            return View(programas);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Create(ProgramaStartDTO programa)
        {
            if (ModelState.IsValid)
            {
                await _programaStartService.AddAsync(programa);
                return RedirectToAction(nameof(Index));
            }
            return View(programa);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var programaStartDTO = await _programaStartService.GetByIdAsync(id);
            if (programaStartDTO == null) return NotFound();
            return View(programaStartDTO);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(ProgramaStartDTO programaStartDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _programaStartService.UpdateAsync(programaStartDTO);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(programaStartDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var programaStartDTO = await _programaStartService.GetByIdAsync(id);

            if (programaStartDTO == null) return NotFound();

            return View(programaStartDTO);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _programaStartService.RemoveAsync(id);
            return RedirectToAction("Index");
        }
    }
}
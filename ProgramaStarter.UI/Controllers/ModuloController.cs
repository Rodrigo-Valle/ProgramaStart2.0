using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProgramaStarter.Application.DTO;
using ProgramaStarter.Application.Interfaces;

namespace ProgramaStarter.UI.Controllers
{
    public class ModuloController : Controller
    {
        private readonly IModuloService _moduloService;
        public ModuloController(IModuloService moduloService)
        {
            _moduloService = moduloService;
        }

        public async Task<IActionResult> Index()
        {
            var modulos = await _moduloService.GetAsync();
            return View(modulos);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Create(ModuloDTO modulo)
        {
            if (ModelState.IsValid)
            {
                await _moduloService.AddAsync(modulo);
                return RedirectToAction(nameof(Index));
            }
            return View(modulo);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var moduloDTO = await _moduloService.GetByIdAsync(id);
            if (moduloDTO == null) return NotFound();
            return View(moduloDTO);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(ModuloDTO moduloDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _moduloService.UpdateAsync(moduloDTO);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(moduloDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var moduloDTO = await _moduloService.GetByIdAsync(id);

            if (moduloDTO == null) return NotFound();

            return View(moduloDTO);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _moduloService.RemoveAsync(id);
            return RedirectToAction("Index");
        }
    }
}
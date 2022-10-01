using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProgramaStarter.Application.DTO;
using ProgramaStarter.Application.Interfaces;

namespace ProgramaStarter.UI.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly IProjetoService _projetoService;
        private readonly IModuloService _moduloService;
        public ProjetoController(IProjetoService projetoService, IModuloService moduloService)
        {
            _projetoService = projetoService;
            _moduloService = moduloService;
        }

        public async Task<IActionResult> Index()
        {
            var projetos = await _projetoService.GetAsync();
            return View(projetos);
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ViewBag.ModuloId = new SelectList(await _moduloService.GetAsync(), "Id", "Nome");

            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Create(ProjetoDTO projetoDTO)
        {
            if (ModelState.IsValid)
            {
                await _projetoService.AddAsync(projetoDTO);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.ModuloId = new SelectList(await _moduloService.GetAsync(), "Id", "Nome");
            }
            return View(projetoDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var projetoDTO = await _projetoService.GetByIdAsync(id);
            if (projetoDTO == null) return NotFound();
            var modulos = await _moduloService.GetAsync();

            ViewBag.ModuloId = new SelectList(modulos, "Id", "Nome", projetoDTO.ModuloId);

            return View(projetoDTO);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(ProjetoDTO projetoDTO)
        {
            if (ModelState.IsValid)
            {
                await _projetoService.UpdateAsync(projetoDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(projetoDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var projetoDTO = await _projetoService.GetByIdAsync(id);

            if (projetoDTO == null) return NotFound();

            return View(projetoDTO);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _projetoService.RemoveAsync(id);
            return RedirectToAction("Index");
        }
    }
}
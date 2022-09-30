using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProgramaStarter.Application.DTO;
using ProgramaStarter.Application.Interfaces;

namespace ProgramaStarter.UI.Controllers
{
    public class TecnologiaController : Controller
    {
        private readonly ITecnologiaService _tecnologiaService;
        public TecnologiaController(ITecnologiaService tecnologiaService)
        {
            _tecnologiaService = tecnologiaService;
        }

        public async Task<IActionResult> Index()
        {
            var tecnologias = await _tecnologiaService.GetAsync();
            return View(tecnologias);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Create(TecnologiaDTO tecnologia)
        {
            if (ModelState.IsValid)
            {
                await _tecnologiaService.AddAsync(tecnologia);
                return RedirectToAction(nameof(Index));
            }
            return View(tecnologia);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var tecnologiaDTO = await _tecnologiaService.GetByIdAsync(id);
            if (tecnologiaDTO == null) return NotFound();
            return View(tecnologiaDTO);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(TecnologiaDTO tecnologiaDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _tecnologiaService.UpdateAsync(tecnologiaDTO);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tecnologiaDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var tecnologiaDTO = await _tecnologiaService.GetByIdAsync(id);

            if (tecnologiaDTO == null) return NotFound();

            return View(tecnologiaDTO);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _tecnologiaService.RemoveAsync(id);
            return RedirectToAction("Index");
        }
    }
}
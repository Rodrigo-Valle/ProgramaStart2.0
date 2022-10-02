using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProgramaStarter.Application.DTO;
using ProgramaStarter.Application.Interfaces;

namespace ProgramaStarter.UI.Controllers
{
    public class AvaliacaoController : Controller
    {
        private readonly IAvaliacaoService _avaliacaoService;
        private readonly IProjetoService _projetoService;
        private readonly IStarterService _starterservice;
        public AvaliacaoController(IAvaliacaoService avaliacaoService, IProjetoService projetoService, IStarterService starterservice)
        {
            _avaliacaoService = avaliacaoService;
            _projetoService = projetoService;
            _starterservice = starterservice;
        }

        public async Task<IActionResult> Index(int? starterId)
        {

            ViewBag.Starter = await _starterservice.GetByIdAsync(starterId);
            if (starterId == null) return NotFound();
            var avaliacoes = await _avaliacaoService.GetAsync(starterId);
            if (avaliacoes == null) return NotFound();

            return View(avaliacoes);
        }

        [HttpGet()]
        public async Task<IActionResult> Create(int? starterId)
        {
            ViewBag.ProjetoId = new SelectList(await _projetoService.GetAsync(), "Id", "Etapa");
            ViewBag.StarterId = starterId;

            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Create(AvaliacaoDTO avaliacaoDTO)
        {
            if (ModelState.IsValid)
            {
                await _avaliacaoService.AddAsync(avaliacaoDTO);
                return RedirectToAction("Index", "Avaliacao", new { starterId = avaliacaoDTO.StarterId });
            }

            ViewBag.ProjetoId = new SelectList(await _projetoService.GetAsync(), "Id", "Etapa");
            ViewBag.StarterId = avaliacaoDTO.StarterId;
            return View(avaliacaoDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var avaliacaoDTO = await _avaliacaoService.GetByIdAsync(id);
            if (avaliacaoDTO == null) return NotFound();
            ViewBag.ProjetoId = new SelectList(await _projetoService.GetAsync(), "Id", "Etapa");
            return View(avaliacaoDTO);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(AvaliacaoDTO avaliacaoDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _avaliacaoService.UpdateAsync(avaliacaoDTO);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction("Index", "Avaliacao", new { starterId = avaliacaoDTO.StarterId });
            }

            var avaliacao = await _avaliacaoService.GetByIdAsync(avaliacaoDTO.Id);
            ViewBag.ProjetoId = new SelectList(await _projetoService.GetAsync(), "Id", "Etapa");
            return View(avaliacao);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var avaliacaoDTO = await _avaliacaoService.GetByIdAsync(id);

            if (avaliacaoDTO == null) return NotFound();

            return View(avaliacaoDTO);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, int? starterId)
        {
            await _avaliacaoService.RemoveAsync(id);
            return RedirectToAction("Index", "Avaliacao", new { starterId = starterId });
        }
    }
}
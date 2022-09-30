using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProgramaStarter.Application.DTO;
using ProgramaStarter.Application.Interfaces;

namespace ProgramaStarter.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.GetAsync();
            return View(usuarios);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Create(UsuarioDTO usuario)
        {
            if (ModelState.IsValid)
            {
                await _usuarioService.AddAsync(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var usuarioDTO = await _usuarioService.GetByIdAsync(id);
            if (usuarioDTO == null) return NotFound();
            return View(usuarioDTO);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(UsuarioDTO usuarioDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _usuarioService.UpdateAsync(usuarioDTO);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var usuarioDTO = await _usuarioService.GetByIdAsync(id);

            if (usuarioDTO == null) return NotFound();

            return View(usuarioDTO);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _usuarioService.RemoveAsync(id);
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProgramaStarter.Application.DTO;
using ProgramaStarter.Application.Interfaces;
using ProgramaStarter.Domain.Account;
using ProgramaStarter.UI.ViewModels;

namespace ProgramaStarter.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAuthenticate _authenticate;
        public UsuarioController(IUsuarioService usuarioService, IAuthenticate authenticate)
        {
            _usuarioService = usuarioService;
            _authenticate = authenticate;
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
        public async Task<IActionResult> Create(UsuarioCreateViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                string identityId = await _authenticate.RegisterUser(usuario.Email, usuario.Senha);
                var usuarioDto = new UsuarioDTO {
                    Email = usuario.Email,
                    Letras = usuario.Letras,
                    Nome = usuario.Nome,
                    Identity = identityId
                };
                await _usuarioService.AddAsync(usuarioDto);
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
            var usuarioViewModel = new UsuarioEditViewModel {
                Id = usuarioDTO.Id,
                IdentityId = usuarioDTO.Identity,
                Email = usuarioDTO.Email,
                Letras = usuarioDTO.Letras,
                Nome = usuarioDTO.Nome,
            };
            return View(usuarioViewModel);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(UsuarioEditViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _authenticate.UpdateUser(usuarioViewModel.IdentityId, usuarioViewModel.Email);
                    var usuarioDTO = new UsuarioDTO {
                        Id = usuarioViewModel.Id,
                        Email = usuarioViewModel.Email,
                        Letras = usuarioViewModel.Letras,
                        Nome = usuarioViewModel.Nome,
                        Identity = usuarioViewModel.IdentityId,
                    };
                    await _usuarioService.UpdateAsync(usuarioDTO);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioViewModel);
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
        public async Task<IActionResult> DeleteConfirmed(int id, string identity)
        {
            await _authenticate.RemoveUser(identity);
            await _usuarioService.RemoveAsync(id);
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using a_tarefas_mvc.Models;
using a_tarefas_mvc.Data;

namespace a_tarefas_mvc.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Context _context;

        public UsuariosController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Usuarios != null ?
                        View(await _context.Usuarios.ToListAsync()) :
                        Problem("Usuários não está disponível no momento.");
        }

        public IActionResult CriarEditar(int id = 0)
        {
            if (id == 0)
                return View(new Usuario());
            else
                return View(_context.Usuarios.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarEditar([Bind("Id,Nome,Email")] Usuario usuario)
        {
            var usuarioCadastro = _context.Usuarios.Any(x => x.Id == usuario.Id);

            if (usuarioCadastro)
            {
                _context.Update(usuario);
            }
            else
            {
                _context.Add(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Usuário não está disponível no momento.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
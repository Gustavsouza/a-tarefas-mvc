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
    public class TarefasController : Controller
    {
        private readonly Context _context;

        public TarefasController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var context = _context.Tarefas.Include(t => t.Usuario).OrderBy(x => x.DataFim);
            return View(await context.ToListAsync());
        }

        public IActionResult CriarEditar(int id = 0)
        {
            if (id == 0)
            {
                ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome");
                return View(new Tarefa());
            }
            else
            {
                var tarefa = _context.Tarefas.Find(id);
                if (tarefa == null)
                {
                    return NotFound();
                }

                ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", tarefa.UsuarioId);
                return View(tarefa);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarEditar([Bind("Id,Descricao,UsuarioId,DataInicio,DataFim")] Tarefa tarefa)
        {
            var tarefaCadastro = _context.Tarefas.Any(x => x.Id == tarefa.Id);

            if (tarefaCadastro)
            {
                _context.Update(tarefa);
            }
            else
            {
                _context.Add(tarefa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (_context.Tarefas == null)
            {
                return Problem("Tarefas não está disponível no momento.");
            }
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
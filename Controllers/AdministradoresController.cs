using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using api_desafio21dias.Models;
using api_desafio21dias.Servicos;
using EntityFrameworkPaginateCore;

namespace api_desafio21dias.Controllers
{
    [ApiController]
    public class AdministradoresController : ControllerBase
    {
        private readonly DbContexto _context;
        private const int QUANTIDADE_POR_PAGINA = 3;
        public AdministradoresController(DbContexto context)
        {
            _context = context;
        }

        // GET: /administradores
        [HttpGet]
        [Route("/administradores")]
        public async Task<IActionResult> Index(int page = 1)
        {
            return StatusCode(200, await _context.Administradores.OrderBy(a => a.Id).PaginateAsync(page, QUANTIDADE_POR_PAGINA));
        }

        // GET: /administradores/5
        [HttpGet]
        [Route("/administradores/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return StatusCode(200, administrador);
        }

        // POST: /administradores
        [HttpPost]
        [Route("/administradores")]
        public async Task<IActionResult> Create(Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return StatusCode(201, administrador);
        }

        // PUT: /administradores/5
        [HttpPut]
        [Route("/administradores/{id}")]
        public async Task<IActionResult> Edit(int id, Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    administrador.Id = id;
                    _context.Update(administrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministradorExists(administrador.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return StatusCode(200, administrador);
            }
            return StatusCode(200, administrador);
        }

        // DELETE: /administradores/5
        [HttpDelete]
        [Route("/administradores/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrador = await _context.Administradores.FindAsync(id);
            _context.Administradores.Remove(administrador);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool AdministradorExists(int id)
        {
            return _context.Administradores.Any(e => e.Id == id);
        }
    }
}

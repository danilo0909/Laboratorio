using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Laboratorio.Data;
using Laboratorio.Models;

namespace Laboratorio.Controllers
{
    public class Cadastro_ClienteController : Controller
    {
        private readonly DBContext _context;

        public Cadastro_ClienteController(DBContext context)
        {
            _context = context;
        }

        // GET: Cadastro_Cliente
        public async Task<IActionResult> Index()
        {
              return _context.Cadastro_Cliente != null ? 
                          View(await _context.Cadastro_Cliente.ToListAsync()) :
                          Problem("Entity set 'DBContext.Cadastro_Cliente'  is null.");
        }

        // GET: Cadastro_Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cadastro_Cliente == null)
            {
                return NotFound();
            }

            var cadastro_Cliente = await _context.Cadastro_Cliente
                .FirstOrDefaultAsync(m => m.ID_Cliente == id);
            if (cadastro_Cliente == null)
            {
                return NotFound();
            }

            return View(cadastro_Cliente);
        }

        // GET: Cadastro_Cliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cadastro_Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Cliente,Nome_Cliente,Endereco,Telefone,Documento")] Cadastro_Cliente cadastro_Cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastro_Cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastro_Cliente);
        }

        // GET: Cadastro_Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cadastro_Cliente == null)
            {
                return NotFound();
            }

            var cadastro_Cliente = await _context.Cadastro_Cliente.FindAsync(id);
            if (cadastro_Cliente == null)
            {
                return NotFound();
            }
            return View(cadastro_Cliente);
        }

        // POST: Cadastro_Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Cliente,Nome_Cliente,Endereco,Telefone,Documento")] Cadastro_Cliente cadastro_Cliente)
        {
            if (id != cadastro_Cliente.ID_Cliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastro_Cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cadastro_ClienteExists(cadastro_Cliente.ID_Cliente))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cadastro_Cliente);
        }

        // GET: Cadastro_Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cadastro_Cliente == null)
            {
                return NotFound();
            }

            var cadastro_Cliente = await _context.Cadastro_Cliente
                .FirstOrDefaultAsync(m => m.ID_Cliente == id);
            if (cadastro_Cliente == null)
            {
                return NotFound();
            }

            return View(cadastro_Cliente);
        }

        // POST: Cadastro_Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cadastro_Cliente == null)
            {
                return Problem("Entity set 'DBContext.Cadastro_Cliente'  is null.");
            }
            var cadastro_Cliente = await _context.Cadastro_Cliente.FindAsync(id);
            if (cadastro_Cliente != null)
            {
                _context.Cadastro_Cliente.Remove(cadastro_Cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cadastro_ClienteExists(int id)
        {
          return (_context.Cadastro_Cliente?.Any(e => e.ID_Cliente == id)).GetValueOrDefault();
        }
    }
}

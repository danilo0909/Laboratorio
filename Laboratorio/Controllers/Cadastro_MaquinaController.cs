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
    public class Cadastro_MaquinaController : Controller
    {
        private readonly DBContext _context;

        public Cadastro_MaquinaController(DBContext context)
        {
            _context = context;
        }

        // GET: Cadastro_Maquina
        public async Task<IActionResult> Index()
        {
              return _context.Cadastro_Maquina != null ? 
                          View(await _context.Cadastro_Maquina.ToListAsync()) :
                          Problem("Entity set 'DBContext.Cadastro_Maquina'  is null.");
        }

        // GET: Cadastro_Maquina/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cadastro_Maquina == null)
            {
                return NotFound();
            }

            var cadastro_Maquina = await _context.Cadastro_Maquina
                .FirstOrDefaultAsync(m => m.ID_Maquina == id);
            if (cadastro_Maquina == null)
            {
                return NotFound();
            }

            return View(cadastro_Maquina);
        }

        // GET: Cadastro_Maquina/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cadastro_Maquina/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Maquina,Nome_Maquina")] Cadastro_Maquina cadastro_Maquina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastro_Maquina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastro_Maquina);
        }

        // GET: Cadastro_Maquina/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cadastro_Maquina == null)
            {
                return NotFound();
            }

            var cadastro_Maquina = await _context.Cadastro_Maquina.FindAsync(id);
            if (cadastro_Maquina == null)
            {
                return NotFound();
            }
            return View(cadastro_Maquina);
        }

        // POST: Cadastro_Maquina/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Maquina,Nome_Maquina")] Cadastro_Maquina cadastro_Maquina)
        {
            if (id != cadastro_Maquina.ID_Maquina)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastro_Maquina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cadastro_MaquinaExists(cadastro_Maquina.ID_Maquina))
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
            return View(cadastro_Maquina);
        }

        // GET: Cadastro_Maquina/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cadastro_Maquina == null)
            {
                return NotFound();
            }

            var cadastro_Maquina = await _context.Cadastro_Maquina
                .FirstOrDefaultAsync(m => m.ID_Maquina == id);
            if (cadastro_Maquina == null)
            {
                return NotFound();
            }

            return View(cadastro_Maquina);
        }

        // POST: Cadastro_Maquina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cadastro_Maquina == null)
            {
                return Problem("Entity set 'DBContext.Cadastro_Maquina'  is null.");
            }
            var cadastro_Maquina = await _context.Cadastro_Maquina.FindAsync(id);
            if (cadastro_Maquina != null)
            {
                _context.Cadastro_Maquina.Remove(cadastro_Maquina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cadastro_MaquinaExists(int id)
        {
          return (_context.Cadastro_Maquina?.Any(e => e.ID_Maquina == id)).GetValueOrDefault();
        }
    }
}

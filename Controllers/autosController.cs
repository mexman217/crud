using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_Autos.Datos;
using CRUD_Autos.Models;

namespace CRUD_Autos.Controllers
{
    public class autosController : Controller
    {
        private readonly contextoBD _context;

        public autosController(contextoBD context)
        {
            _context = context;
        }

        // GET: autos
        public async Task<IActionResult> Index()
        {
              return _context.tablaAutos != null ? 
                          View(await _context.tablaAutos.ToListAsync()) :
                          Problem("Entity set 'contextoBD.tablaAutos'  is null.");
        }

        // GET: autos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tablaAutos == null)
            {
                return NotFound();
            }

            var autos = await _context.tablaAutos
                .FirstOrDefaultAsync(m => m.idAlta == id);
            if (autos == null)
            {
                return NotFound();
            }

            return View(autos);
        }

        // GET: autos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: autos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idAlta,Nombre,fechaAlta")] autos autos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autos);
        }

        // GET: autos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tablaAutos == null)
            {
                return NotFound();
            }

            var autos = await _context.tablaAutos.FindAsync(id);
            if (autos == null)
            {
                return NotFound();
            }
            return View(autos);
        }

        // POST: autos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idAlta,Nombre,fechaAlta")] autos autos)
        {
            if (id != autos.idAlta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!autosExists(autos.idAlta))
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
            return View(autos);
        }

        // GET: autos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tablaAutos == null)
            {
                return NotFound();
            }

            var autos = await _context.tablaAutos
                .FirstOrDefaultAsync(m => m.idAlta == id);
            if (autos == null)
            {
                return NotFound();
            }

            return View(autos);
        }

        // POST: autos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tablaAutos == null)
            {
                return Problem("Entity set 'contextoBD.tablaAutos'  is null.");
            }
            var autos = await _context.tablaAutos.FindAsync(id);
            if (autos != null)
            {
                _context.tablaAutos.Remove(autos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool autosExists(int id)
        {
          return (_context.tablaAutos?.Any(e => e.idAlta == id)).GetValueOrDefault();
        }
    }
}

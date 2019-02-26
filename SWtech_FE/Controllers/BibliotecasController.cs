using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tech_Challenge.Models;

namespace Tech_Challenge.Controllers
{
    public class BibliotecasController : Controller
    {
        private readonly SW_TechContext _context;

        public BibliotecasController(SW_TechContext context)
        {
            _context = context;
        }

        // GET: Bibliotecas
        public async Task<IActionResult> Index(SWSearchModel searchModel, int? page)
        {
            var business = new SWBusinessLogic(_context);
            var bibliotecas = business.GetFilteredLibraries(searchModel);

            int pageSize = 5;

            return View(await PaginatedList<Biblioteca>.CreateAsync(bibliotecas.AsNoTracking(), page ?? 1, pageSize));
        }

        [HttpGet]
        public async Task<IActionResult> BtnFiltrar_Click(SWSearchModel searchModel, int? page)
        {
            var business = new SWBusinessLogic(_context);
            var bibliotecas = business.GetFilteredLibraries(searchModel);

            int pageSize = 5;

            return View(await PaginatedList<Biblioteca>.CreateAsync(bibliotecas.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Bibliotecas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biblioteca = await _context.Biblioteca
                .FirstOrDefaultAsync(m => m.BibliotecaId == id);
            if (biblioteca == null)
            {
                return NotFound();
            }

            return View(biblioteca);
        }

        // GET: Bibliotecas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bibliotecas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Calle,Altura,Calle2,Piso,Telefono,Observaciones,DireccionNormalizada,Long,Lat,Barrio,Comuna,CodigoPostal,CodigoPostalArgentino,BibliotecaId")] Biblioteca biblioteca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(biblioteca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(biblioteca);
        }

        // GET: Bibliotecas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biblioteca = await _context.Biblioteca.FindAsync(id);
            if (biblioteca == null)
            {
                return NotFound();
            }
            return View(biblioteca);
        }

        // POST: Bibliotecas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nombre,Calle,Altura,Calle2,Piso,Telefono,Observaciones,DireccionNormalizada,Long,Lat,Barrio,Comuna,CodigoPostal,CodigoPostalArgentino,BibliotecaId")] Biblioteca biblioteca)
        {
            if (id != biblioteca.BibliotecaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biblioteca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BibliotecaExists(biblioteca.BibliotecaId))
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
            return View(biblioteca);
        }

        // GET: Bibliotecas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biblioteca = await _context.Biblioteca
                .FirstOrDefaultAsync(m => m.BibliotecaId == id);
            if (biblioteca == null)
            {
                return NotFound();
            }

            return View(biblioteca);
        }

        // POST: Bibliotecas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var biblioteca = await _context.Biblioteca.FindAsync(id);
            _context.Biblioteca.Remove(biblioteca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BibliotecaExists(int id)
        {
            return _context.Biblioteca.Any(e => e.BibliotecaId == id);
        }
    }
}

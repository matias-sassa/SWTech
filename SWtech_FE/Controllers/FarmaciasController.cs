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
    public class FarmaciasController : Controller
    {
        private readonly SW_TechContext _context;

        public FarmaciasController(SW_TechContext context)
        {
            _context = context;
        }

        // GET: Farmacias
        public async Task<IActionResult> Index(SWSearchModel searchModel, int? page)
        {
            var business = new SWBusinessLogic(_context);
            var farmacias = business.GetFilteredFarmacies(searchModel);

            int pageSize = 5;

            return View(await PaginatedList<Farmacia>.CreateAsync(farmacias.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Farmacias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmacia = await _context.Farmacia
                .FirstOrDefaultAsync(m => m.FarmaciaId == id);
            if (farmacia == null)
            {
                return NotFound();
            }

            return View(farmacia);
        }

        // GET: Farmacias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farmacias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Long,Lat,Telefono,Objeto,CalleNombre,CalleAltura,CalleCruce,Barrio,Comuna,CodigoPostal,CodigoPostalArgentino,FarmaciaId")] Farmacia farmacia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmacia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmacia);
        }

        // GET: Farmacias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmacia = await _context.Farmacia.FindAsync(id);
            if (farmacia == null)
            {
                return NotFound();
            }
            return View(farmacia);
        }

        // POST: Farmacias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Long,Lat,Telefono,Objeto,CalleNombre,CalleAltura,CalleCruce,Barrio,Comuna,CodigoPostal,CodigoPostalArgentino,FarmaciaId")] Farmacia farmacia)
        {
            if (id != farmacia.FarmaciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmacia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmaciaExists(farmacia.FarmaciaId))
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
            return View(farmacia);
        }

        // GET: Farmacias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmacia = await _context.Farmacia
                .FirstOrDefaultAsync(m => m.FarmaciaId == id);
            if (farmacia == null)
            {
                return NotFound();
            }

            return View(farmacia);
        }

        // POST: Farmacias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmacia = await _context.Farmacia.FindAsync(id);
            _context.Farmacia.Remove(farmacia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmaciaExists(int id)
        {
            return _context.Farmacia.Any(e => e.FarmaciaId == id);
        }
    }
}

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
    public class AtmsController : Controller
    {
        private readonly SW_TechContext _context;

        public AtmsController(SW_TechContext context)
        {
            _context = context;
        }
        
        // GET: Atms
        public async Task<IActionResult> Index(SWSearchModel searchModel, int? page)
        {
            var business = new SWBusinessLogic(_context);
            var atms = business.GetFilteredATM(searchModel);

            int pageSize = 5;

            return View(await PaginatedList<Atm>.CreateAsync(atms.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Atms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atm = await _context.Atm.FindAsync(id);
            if (atm == null)
            {
                return NotFound();
            }
            return View(atm);
        }

        // POST: Atms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Long,Lat,Banco,Red,Ubicacion,Localidad,Terminales,NoVidente,Dolares,Calle,Altura,Calle2,Barrio,Comuna,CodigoPostal,CodigoPostalArgentino")] Atm atm)
        {
            if (id != atm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtmExists(atm.Id))
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
            return View(atm);
        }

        private bool AtmExists(int id)
        {
            return _context.Atm.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.CurriculumVitae;

namespace PortalEquador.Controllers.CurriculumVitae
{
    public class CurriculumController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CurriculumController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Curriculum
        public async Task<IActionResult> Index()
        {
              return _context.Curriculum != null ? 
                          View(await _context.Curriculum.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Curriculum'  is null.");
        }

        // GET: Curriculum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Curriculum == null)
            {
                return NotFound();
            }

            var curriculum = await _context.Curriculum
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curriculum == null)
            {
                return NotFound();
            }

            return View(curriculum);
        }

        // GET: Curriculum/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Curriculum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateCreated,DateModified")] Curriculum curriculum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curriculum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(curriculum);
        }

        // GET: Curriculum/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Curriculum == null)
            {
                return NotFound();
            }

            var curriculum = await _context.Curriculum.FindAsync(id);
            if (curriculum == null)
            {
                return NotFound();
            }
            return View(curriculum);
        }

        // POST: Curriculum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateCreated,DateModified")] Curriculum curriculum)
        {
            if (id != curriculum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curriculum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurriculumExists(curriculum.Id))
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
            return View(curriculum);
        }

        // GET: Curriculum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Curriculum == null)
            {
                return NotFound();
            }

            var curriculum = await _context.Curriculum
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curriculum == null)
            {
                return NotFound();
            }

            return View(curriculum);
        }

        // POST: Curriculum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Curriculum == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Curriculum'  is null.");
            }
            var curriculum = await _context.Curriculum.FindAsync(id);
            if (curriculum != null)
            {
                _context.Curriculum.Remove(curriculum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurriculumExists(int id)
        {
          return (_context.Curriculum?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

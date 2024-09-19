using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.Education.School.Entity;
using PortalEquador.Domain.Education.School.Repository;
using PortalEquador.Domain.Languages.Repository;

namespace PortalEquador.Controllers.Education
{
    public class SchoolController(ISchoolRepository repository) : Controller
    {

        /*
        // GET: School
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SchoolEntity.Include(s => s.ApplicationUserEntity).Include(s => s.DegreeGroupItemEntity).Include(s => s.InstitutionGroupItemEntity).Include(s => s.PersonalInformationEntity);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: School/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolEntity = await _context.SchoolEntity
                .Include(s => s.ApplicationUserEntity)
                .Include(s => s.DegreeGroupItemEntity)
                .Include(s => s.InstitutionGroupItemEntity)
                .Include(s => s.PersonalInformationEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolEntity == null)
            {
                return NotFound();
            }

            return View(schoolEntity);
        }

        // GET: School/Create
        public IActionResult Create()
        {
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["DegreeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            ViewData["InstitutionId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id");
            return View();
        }

        // POST: School/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalInformationId,InstitutionId,DegreeId,Major,Id,EditorId,DateCreated,DateModified")] SchoolEntity schoolEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schoolEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", schoolEntity.EditorId);
            ViewData["DegreeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", schoolEntity.DegreeId);
            ViewData["InstitutionId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", schoolEntity.InstitutionId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", schoolEntity.PersonalInformationId);
            return View(schoolEntity);
        }

        // GET: School/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolEntity = await _context.SchoolEntity.FindAsync(id);
            if (schoolEntity == null)
            {
                return NotFound();
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", schoolEntity.EditorId);
            ViewData["DegreeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", schoolEntity.DegreeId);
            ViewData["InstitutionId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", schoolEntity.InstitutionId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", schoolEntity.PersonalInformationId);
            return View(schoolEntity);
        }

        // POST: School/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonalInformationId,InstitutionId,DegreeId,Major,Id,EditorId,DateCreated,DateModified")] SchoolEntity schoolEntity)
        {
            if (id != schoolEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolEntityExists(schoolEntity.Id))
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
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", schoolEntity.EditorId);
            ViewData["DegreeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", schoolEntity.DegreeId);
            ViewData["InstitutionId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", schoolEntity.InstitutionId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", schoolEntity.PersonalInformationId);
            return View(schoolEntity);
        }

        // GET: School/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolEntity = await _context.SchoolEntity
                .Include(s => s.ApplicationUserEntity)
                .Include(s => s.DegreeGroupItemEntity)
                .Include(s => s.InstitutionGroupItemEntity)
                .Include(s => s.PersonalInformationEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolEntity == null)
            {
                return NotFound();
            }

            return View(schoolEntity);
        }

        // POST: School/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schoolEntity = await _context.SchoolEntity.FindAsync(id);
            if (schoolEntity != null)
            {
                _context.SchoolEntity.Remove(schoolEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolEntityExists(int id)
        {
            return _context.SchoolEntity.Any(e => e.Id == id);
        }
        */
    }
}

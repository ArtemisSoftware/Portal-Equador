using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.Education.University.Entity;
using PortalEquador.Domain.Education.University.Repository;
using PortalEquador.Domain.Languages.Repository;

namespace PortalEquador.Controllers.Education
{
    public class UniversityController(IUniversityRepository repository) : Controller
    {
        /*
        // GET: University
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UniversityEntity.Include(u => u.ApplicationUserEntity).Include(u => u.DegreeGroupItemEntity).Include(u => u.InstitutionGroupItemEntity).Include(u => u.MajorGroupItemEntity).Include(u => u.PersonalInformationEntity);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: University/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universityEntity = await _context.UniversityEntity
                .Include(u => u.ApplicationUserEntity)
                .Include(u => u.DegreeGroupItemEntity)
                .Include(u => u.InstitutionGroupItemEntity)
                .Include(u => u.MajorGroupItemEntity)
                .Include(u => u.PersonalInformationEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universityEntity == null)
            {
                return NotFound();
            }

            return View(universityEntity);
        }

        // GET: University/Create
        public IActionResult Create()
        {
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["DegreeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            ViewData["InstitutionId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            ViewData["MajorId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id");
            return View();
        }

        // POST: University/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalInformationId,InstitutionId,DegreeId,MajorId,Id,EditorId,DateCreated,DateModified")] UniversityEntity universityEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(universityEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", universityEntity.EditorId);
            ViewData["DegreeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", universityEntity.DegreeId);
            ViewData["InstitutionId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", universityEntity.InstitutionId);
            ViewData["MajorId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", universityEntity.MajorId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", universityEntity.PersonalInformationId);
            return View(universityEntity);
        }

        // GET: University/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universityEntity = await _context.UniversityEntity.FindAsync(id);
            if (universityEntity == null)
            {
                return NotFound();
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", universityEntity.EditorId);
            ViewData["DegreeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", universityEntity.DegreeId);
            ViewData["InstitutionId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", universityEntity.InstitutionId);
            ViewData["MajorId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", universityEntity.MajorId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", universityEntity.PersonalInformationId);
            return View(universityEntity);
        }

        // POST: University/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonalInformationId,InstitutionId,DegreeId,MajorId,Id,EditorId,DateCreated,DateModified")] UniversityEntity universityEntity)
        {
            if (id != universityEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(universityEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversityEntityExists(universityEntity.Id))
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
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", universityEntity.EditorId);
            ViewData["DegreeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", universityEntity.DegreeId);
            ViewData["InstitutionId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", universityEntity.InstitutionId);
            ViewData["MajorId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", universityEntity.MajorId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", universityEntity.PersonalInformationId);
            return View(universityEntity);
        }

        // GET: University/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universityEntity = await _context.UniversityEntity
                .Include(u => u.ApplicationUserEntity)
                .Include(u => u.DegreeGroupItemEntity)
                .Include(u => u.InstitutionGroupItemEntity)
                .Include(u => u.MajorGroupItemEntity)
                .Include(u => u.PersonalInformationEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universityEntity == null)
            {
                return NotFound();
            }

            return View(universityEntity);
        }

        // POST: University/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var universityEntity = await _context.UniversityEntity.FindAsync(id);
            if (universityEntity != null)
            {
                _context.UniversityEntity.Remove(universityEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversityEntityExists(int id)
        {
            return _context.UniversityEntity.Any(e => e.Id == id);
        }
        */
    }
}

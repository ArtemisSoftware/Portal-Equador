using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.ProfessionalExperience.Entities;

namespace PortalEquador.Controllers.ProfessionalExperience
{
    public class ProfessionalExperienceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfessionalExperienceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProfessionalExperience
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProfessionalExperienceEntity.Include(p => p.CompanyGroupItemEntity).Include(p => p.PersonalInformationEntity).Include(p => p.WorkstationGroupItemEntity);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProfessionalExperience/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProfessionalExperienceEntity == null)
            {
                return NotFound();
            }

            var professionalExperienceEntity = await _context.ProfessionalExperienceEntity
                .Include(p => p.CompanyGroupItemEntity)
                .Include(p => p.PersonalInformationEntity)
                .Include(p => p.WorkstationGroupItemEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professionalExperienceEntity == null)
            {
                return NotFound();
            }

            return View(professionalExperienceEntity);
        }

        // GET: ProfessionalExperience/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id");
            ViewData["WorkstationId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            return View();
        }

        // POST: ProfessionalExperience/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalInformationId,CompanyId,WorkstationId,Months,Id,DateCreated,DateModified")] ProfessionalExperienceEntity professionalExperienceEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professionalExperienceEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", professionalExperienceEntity.CompanyId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", professionalExperienceEntity.PersonalInformationId);
            ViewData["WorkstationId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", professionalExperienceEntity.WorkstationId);
            return View(professionalExperienceEntity);
        }

        // GET: ProfessionalExperience/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProfessionalExperienceEntity == null)
            {
                return NotFound();
            }

            var professionalExperienceEntity = await _context.ProfessionalExperienceEntity.FindAsync(id);
            if (professionalExperienceEntity == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", professionalExperienceEntity.CompanyId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", professionalExperienceEntity.PersonalInformationId);
            ViewData["WorkstationId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", professionalExperienceEntity.WorkstationId);
            return View(professionalExperienceEntity);
        }

        // POST: ProfessionalExperience/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonalInformationId,CompanyId,WorkstationId,Months,Id,DateCreated,DateModified")] ProfessionalExperienceEntity professionalExperienceEntity)
        {
            if (id != professionalExperienceEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professionalExperienceEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessionalExperienceEntityExists(professionalExperienceEntity.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", professionalExperienceEntity.CompanyId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", professionalExperienceEntity.PersonalInformationId);
            ViewData["WorkstationId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", professionalExperienceEntity.WorkstationId);
            return View(professionalExperienceEntity);
        }

        // GET: ProfessionalExperience/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProfessionalExperienceEntity == null)
            {
                return NotFound();
            }

            var professionalExperienceEntity = await _context.ProfessionalExperienceEntity
                .Include(p => p.CompanyGroupItemEntity)
                .Include(p => p.PersonalInformationEntity)
                .Include(p => p.WorkstationGroupItemEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professionalExperienceEntity == null)
            {
                return NotFound();
            }

            return View(professionalExperienceEntity);
        }

        // POST: ProfessionalExperience/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProfessionalExperienceEntity == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProfessionalExperienceEntity'  is null.");
            }
            var professionalExperienceEntity = await _context.ProfessionalExperienceEntity.FindAsync(id);
            if (professionalExperienceEntity != null)
            {
                _context.ProfessionalExperienceEntity.Remove(professionalExperienceEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessionalExperienceEntityExists(int id)
        {
            return (_context.ProfessionalExperienceEntity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.Profession.Competence.Entity;
using PortalEquador.Domain.Languages.Repository;
using PortalEquador.Domain.Profession.Competence.Repository;

namespace PortalEquador.Controllers.Profession
{
    public class ProfessionalCompetenceController(IProfessionalCompetenceRepository repository) : Controller
    {

        // GET: ProfessionalCompetence
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProfessionalCompetenceEntity.Include(p => p.ApplicationUserEntity).Include(p => p.CompetenceGroupItemEntity).Include(p => p.PersonalInformationEntity);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProfessionalCompetence/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professionalCompetenceEntity = await _context.ProfessionalCompetenceEntity
                .Include(p => p.ApplicationUserEntity)
                .Include(p => p.CompetenceGroupItemEntity)
                .Include(p => p.PersonalInformationEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professionalCompetenceEntity == null)
            {
                return NotFound();
            }

            return View(professionalCompetenceEntity);
        }

        // GET: ProfessionalCompetence/Create
        public IActionResult Create()
        {
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["CompetenceId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id");
            return View();
        }

        // POST: ProfessionalCompetence/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalInformationId,CompetenceId,Id,EditorId,DateCreated,DateModified")] ProfessionalCompetenceEntity professionalCompetenceEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professionalCompetenceEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", professionalCompetenceEntity.EditorId);
            ViewData["CompetenceId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", professionalCompetenceEntity.CompetenceId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", professionalCompetenceEntity.PersonalInformationId);
            return View(professionalCompetenceEntity);
        }

        // GET: ProfessionalCompetence/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professionalCompetenceEntity = await _context.ProfessionalCompetenceEntity.FindAsync(id);
            if (professionalCompetenceEntity == null)
            {
                return NotFound();
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", professionalCompetenceEntity.EditorId);
            ViewData["CompetenceId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", professionalCompetenceEntity.CompetenceId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", professionalCompetenceEntity.PersonalInformationId);
            return View(professionalCompetenceEntity);
        }

        // POST: ProfessionalCompetence/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonalInformationId,CompetenceId,Id,EditorId,DateCreated,DateModified")] ProfessionalCompetenceEntity professionalCompetenceEntity)
        {
            if (id != professionalCompetenceEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professionalCompetenceEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessionalCompetenceEntityExists(professionalCompetenceEntity.Id))
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
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", professionalCompetenceEntity.EditorId);
            ViewData["CompetenceId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", professionalCompetenceEntity.CompetenceId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", professionalCompetenceEntity.PersonalInformationId);
            return View(professionalCompetenceEntity);
        }

        // GET: ProfessionalCompetence/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professionalCompetenceEntity = await _context.ProfessionalCompetenceEntity
                .Include(p => p.ApplicationUserEntity)
                .Include(p => p.CompetenceGroupItemEntity)
                .Include(p => p.PersonalInformationEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professionalCompetenceEntity == null)
            {
                return NotFound();
            }

            return View(professionalCompetenceEntity);
        }

        // POST: ProfessionalCompetence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professionalCompetenceEntity = await _context.ProfessionalCompetenceEntity.FindAsync(id);
            if (professionalCompetenceEntity != null)
            {
                _context.ProfessionalCompetenceEntity.Remove(professionalCompetenceEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessionalCompetenceEntityExists(int id)
        {
            return _context.ProfessionalCompetenceEntity.Any(e => e.Id == id);
        }
    }
}

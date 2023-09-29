using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Constants;
using PortalEquador.Data;
using PortalEquador.Data.ProfessionalExperience.Entities;
using PortalEquador.Domain.ProfessionalCompetence.UseCases;
using PortalEquador.Domain.ProfessionalExperience.Repository;
using PortalEquador.Domain.ProfessionalExperience.UseCases;
using PortalEquador.Domain.ProfessionalExperience.ViewModels;

namespace PortalEquador.Controllers.ProfessionalExperience
{
    public class ProfessionalExperienceController : Controller
    {
        private readonly ProfessionalExperienceRepository _repository;
        private readonly GetProfessionalExperienceCreationUseCase _getProfessionalExperienceCreationUseCase;

        public ProfessionalExperienceController(ProfessionalExperienceRepository repository, GetProfessionalExperienceCreationUseCase getProfessionalExperienceCreationUseCase)
        {
            _repository = repository;
            _getProfessionalExperienceCreationUseCase = getProfessionalExperienceCreationUseCase;
        }

        // GET: ProfessionalExperience
        public async Task<IActionResult> Index(int identifier, string username)
        {
            ViewData["username"] = username;
            ViewData["personaiInformationid"] = identifier;
            var list = await _repository.GetAll(identifier);
            return View(list);
        }

        // GET: ProfessionalExperience/Create
        public async Task<IActionResult> Create(int identifier, string username)
        {
            ViewData["personaiInformationid"] = identifier;
            ViewData["username"] = username;
            var model = await _getProfessionalExperienceCreationUseCase.Invoke(identifier);
            return View(model);
        }

        // POST: ProfessionalExperience/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfessionalExperienceViewModel model)
        {
            var recover = await _getProfessionalExperienceCreationUseCase.Invoke(model.PersonaInformationId);
            ViewData["username"] = recover.PersonalInformation.FullName;
            ViewData["personaiInformationid"] = recover.PersonalInformation.Id;

            var exists = await _repository.Exists(model.PersonaInformationId, model.CompanyId, model.WorkstationId);
            if (exists == false)
            {
                await _repository.Save(model);
                return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, username = recover.PersonalInformation.FullName });
            }
            else
            {
                model.Companies = recover.Companies;
                model.Workstations = recover.Workstations; 
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.EXISTING_REGISTER);
                return View(model);
            }
        }

        // GET: ProfessionalExperience/Edit/5
        public async Task<IActionResult> Edit(int identifier, string username, int id)
        {

            ViewData["personaiInformationid"] = identifier;
            ViewData["username"] = username;

            var recover = await _getProfessionalExperienceCreationUseCase.Invoke(identifier);
            var model = await _repository.Get(id);
            model.Companies = recover.Companies;
            model.Workstations = recover.Workstations;
            return View(model);
        }

        // POST: ProfessionalExperience/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfessionalExperienceViewModel model)
        {
            await _repository.Save(model);
            var recover = await _getProfessionalExperienceCreationUseCase.Invoke(model.PersonaInformationId);
            return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, username = recover.PersonalInformation.FullName });
        }

        // POST: ProfessionalCompetence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int personalid, string username)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index), new { identifier = personalid, username = username });
        }























        /*

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
        */
    }
}

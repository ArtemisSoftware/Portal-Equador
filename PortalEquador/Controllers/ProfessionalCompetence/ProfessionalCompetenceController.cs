using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Constants;
using PortalEquador.Data;
using PortalEquador.Data.ProfessionalCompetence.Entities;
using PortalEquador.Domain.ProfessionalCompetence.Repository;
using PortalEquador.Domain.ProfessionalCompetence.UseCases;
using PortalEquador.Domain.ProfessionalCompetence.ViewModels;

namespace PortalEquador.Controllers.ProfessionalCompetence
{
    public class ProfessionalCompetenceController : Controller
    {
        private readonly ProfessionalCompetenceRepository _repository;
        private readonly GetProfessionalCompetenceCreationUseCase _getProfessionalCompetenceCreationUseCase;

        public ProfessionalCompetenceController(
            ProfessionalCompetenceRepository repository,
             GetProfessionalCompetenceCreationUseCase getProfessionalCompetenceCreationUseCase
            )
        {
            _repository = repository;
            _getProfessionalCompetenceCreationUseCase = getProfessionalCompetenceCreationUseCase;
        }

        // GET: ProfessionalCompetence
        public async Task<IActionResult> Index(int identifier, string username)
        {
            ViewData["username"] = username;
            ViewData["personaiInformationid"] = identifier;
            var list = await _repository.GetAll(identifier);
            return View(list);
        }

        // GET: ProfessionalCompetence/Create
        public async Task<IActionResult> Create(int identifier, string username)
        {
            ViewData["personaiInformationid"] = identifier;
            ViewData["username"] = username;
            var model = await _getProfessionalCompetenceCreationUseCase.Invoke(identifier);
            return View(model);
        }

        // POST: ProfessionalCompetence/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfessionalCompetenceViewModel model)
        {
            var recover = await _getProfessionalCompetenceCreationUseCase.Invoke(model.PersonaInformationId);
            ViewData["username"] = recover.PersonalInformation.FullName;
            ViewData["personaiInformationid"] = recover.PersonalInformation.Id;

            var exists = await _repository.Exists(model.PersonaInformationId, model.CompetenceId);
            if (exists == false)
            {
                await _repository.Save(model);
                return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, username = recover.PersonalInformation.FullName });
            }
            else
            {
                model.Competences = recover.Competences;
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.EXISTING_REGISTER);
                return View(model);
            }
        }

        // POST: ProfessionalCompetence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int personalid, string username)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index), new { identifier = personalid, username = username });
        }


        //---------------------










        // GET: ProfessionalCompetence/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _repository.GetDetail((int)id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }



        /*
        // GET: ProfessionalCompetence/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProfessionalCompetenceEntity == null)
            {
                return NotFound();
            }

            var professionalCompetenceEntity = await _context.ProfessionalCompetenceEntity
                .Include(p => p.CompetenceGroupItemEntity)
                .Include(p => p.PersonalInformationEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professionalCompetenceEntity == null)
            {
                return NotFound();
            }

            return View(professionalCompetenceEntity);
        }
        */
  

    }
}

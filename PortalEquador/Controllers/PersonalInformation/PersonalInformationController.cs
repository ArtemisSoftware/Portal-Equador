using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Constants;
using PortalEquador.Data;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Data.PersonalInformation.Entities;
using PortalEquador.Domain;
using PortalEquador.Domain.Documents.UseCases;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.GroupTypes.UseCases;
using PortalEquador.Domain.PersonalInformation.UseCases;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Domain.UseCases;
using PortalEquador.Domain.UseCases.DriversLicence;

namespace PortalEquador.Controllers.PersonalInformation
{
    public class PersonalInformationController : Controller
    {
        private readonly SavePersonalInformationUseCase _savePersonalInformationUseCase;
        private readonly GetPersonalInformationCreationModelUseCase _getPersonalInformationCreationModelUseCase;
        private readonly GetPersonalInformationModelUseCase _getPersonalInformationModelUseCase;
        private readonly GetPersonalInformationDetailModelUseCase _getPersonalInformationDetailModelUseCase;
        private readonly ValidateIdentityCardNumberUseCase _validateIdentityCardNumberUseCase;

        public PersonalInformationController(
            SavePersonalInformationUseCase savePersonalInformationUseCase, 
            GetPersonalInformationCreationModelUseCase getPersonalInformationCreationModelUseCase,
            ValidateIdentityCardNumberUseCase validateIdentityCardNumberUseCase,
            GetPersonalInformationModelUseCase getPersonalInformationModelUseCase,
            GetPersonalInformationDetailModelUseCase getPersonalInformationDetailModelUseCase
            )
        {
            _savePersonalInformationUseCase = savePersonalInformationUseCase;
            _getPersonalInformationCreationModelUseCase = getPersonalInformationCreationModelUseCase;
            _validateIdentityCardNumberUseCase = validateIdentityCardNumberUseCase;
            _getPersonalInformationModelUseCase = getPersonalInformationModelUseCase;
            _getPersonalInformationDetailModelUseCase = getPersonalInformationDetailModelUseCase;
        }


        // GET: PersonalInformation/Create
        public async Task<IActionResult> Create(string? identityCard, bool? validIdentityCard)
        {
            var model = await _getPersonalInformationCreationModelUseCase.Invoke(null);

            if(identityCard != null)
            {
                model.IdentityCard = identityCard;
                model.ValidatedIdentityCard = (bool)validIdentityCard;

                if (validIdentityCard == false)
                {
                    ModelState.AddModelError(nameof(model.Error), StringConstants.Error.EXISTING_IDENTITY_CARD);
                }
            }
            return View(model);
        }

        
        // POST: PersonalInformation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonalInformationViewModel model)
        {
            var valid = await _validateIdentityCardNumberUseCase.Invoke(model.IdentityCard);

            if (valid == false)
            {
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.EXISTING_IDENTITY_CARD);
            }
            else if (ModelState.IsValid && valid)
            {
                await _savePersonalInformationUseCase.Invoke(model, OperationType.Create);
                return RedirectToAction(StringConstants.Controller.Action.Dashboard, StringConstants.Controller.Curriculums, new { identifier = model.Id });
            }

            model = await RecoverPersonalInformationtModel(model);
            return View(model);
        }

        public async Task<IActionResult> ValidateIdentityCard(PersonalInformationViewModel model)
        {
            if(model.IdentityCard == null)
            {
                return RedirectToAction(nameof(Create));
            }
            else
            {
                var valid = await _validateIdentityCardNumberUseCase.Invoke(model.IdentityCard);
                return RedirectToAction(nameof(Create), new { identityCard = model.IdentityCard, validIdentityCard = valid });
            }
        }


        // GET: PersonalInformation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var model = await _getPersonalInformationDetailModelUseCase.Invoke((int)id);
                ViewData["id"] = model.Id;
                return View(model);
            }
        }


        // GET: PersonalInformation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["id"] = id;
            if (id == null)
            {
                return NotFound();
            }

            var model = await _getPersonalInformationModelUseCase.Invoke((int)id);
            model = await RecoverPersonalInformationtModel(model);
            return View(model);
        }

        // POST: PersonalInformation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PersonalInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _savePersonalInformationUseCase.Invoke(model, OperationType.Update);
                return RedirectToAction(StringConstants.Controller.Action.Dashboard, StringConstants.Controller.Curriculums, new { identifier = model.Id });
            }
            ViewData["identifier"] = model.Id;
            model = await RecoverPersonalInformationtModel(model);
            return View(model);
        }

        private async Task<PersonalInformationViewModel> RecoverPersonalInformationtModel(PersonalInformationViewModel model)
        {
            var recover = await _getPersonalInformationCreationModelUseCase.Invoke(model);
            return recover;
        }


        /*

        //--------------------------












        // GET: PersonalInformation
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PersonalInformationEntity.Include(p => p.AgencyGroupEntity).Include(p => p.ApplicationGroupEntity).Include(p => p.MaritalStatusGroupEntity).Include(p => p.MotherTongueGroupEntity).Include(p => p.NationalityGroupEntity).Include(p => p.NeighbourhoodGroupEntity).Include(p => p.ProvinceGroupEntity);
            return View(await applicationDbContext.ToListAsync());
        }











        // GET: PersonalInformation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PersonalInformationEntity == null)
            {
                return NotFound();
            }

            var personalInformationEntity = await _context.PersonalInformationEntity
                .Include(p => p.AgencyGroupEntity)
                .Include(p => p.ApplicationGroupEntity)
                .Include(p => p.MaritalStatusGroupEntity)
                .Include(p => p.MotherTongueGroupEntity)
                .Include(p => p.NationalityGroupEntity)
                .Include(p => p.NeighbourhoodGroupEntity)
                .Include(p => p.ProvinceGroupEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalInformationEntity == null)
            {
                return NotFound();
            }

            return View(personalInformationEntity);
        }

        // POST: PersonalInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PersonalInformationEntity == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PersonalInformationEntity'  is null.");
            }
            var personalInformationEntity = await _context.PersonalInformationEntity.FindAsync(id);
            if (personalInformationEntity != null)
            {
                _context.PersonalInformationEntity.Remove(personalInformationEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalInformationEntityExists(int id)
        {
          return (_context.PersonalInformationEntity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        */
    }
}

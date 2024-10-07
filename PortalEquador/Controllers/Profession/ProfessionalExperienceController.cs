using Microsoft.AspNetCore.Mvc;
using PortalEquador.Domain.Profession.Experience.Repository;
using PortalEquador.Domain.Profession.Experience.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.Profession
{
    public class ProfessionalExperienceController(IProfessionalExperienceRepository repository) : Controller
    {

        // GET: ProfessionalExperience
        public async Task<IActionResult> Index(int identifier, string fullName)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;

            var models = await repository.GetAll(identifier);
            return View(models);
        }

        // GET: ProfessionalExperience/Create
        public async Task<IActionResult> Create(int identifier, string fullName)
        {
            var model = await repository.GetCreateModel(identifier, fullName);
            return View(model);
        }


        // POST: ProfessionalExperience/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfessionalExperienceViewModel model)
        {
            var exists = await repository.ProfessionalExperienceExists(model.PersonaInformationId, model.CompanyId, model.WorkstationId);
            if (exists)
            {
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.EXISTING_PROFESSIONAL_EXPERIENCE);
                model.Error = StringConstants.Error.EXISTING_PROFESSIONAL_EXPERIENCE;
            }
            else if (model.IsValidDuration() == false)
            {
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.INVALID_DURATION);
                model.Error = StringConstants.Error.INVALID_DURATION;
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await repository.Save(model);
                    return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, fullName = model.FullName });
                }
                else
                {
                    model.Error = StringConstants.Error.UNDECLARED_ERROR;
                }
            }

            ViewData["id"] = model.Id;
            model = await RecoverModel(model);
            return View(model);
        }

        // GET: ProfessionalExperience/Edit/5
        public async Task<IActionResult> Edit(int id, int identifier, string fullName)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;

            var model = await repository.GetProfessionalExperience((int)id);
            model = await RecoverModel(model);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
        }

        // POST: ProfessionalExperience/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string fullName, ProfessionalExperienceViewModel model)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = id;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;

            if (model.IsValidDuration() == false)
            {
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.INVALID_DURATION);
                model.Error = StringConstants.Error.INVALID_DURATION;
            }
            else if (ModelState.IsValid)
            {
                await repository.Save(model);
                return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, fullName = model.FullName });
            }
            model = await RecoverModelEdit(model);
            return View(model);
        }

        private async Task<ProfessionalExperienceViewModel> RecoverModel(ProfessionalExperienceViewModel model)
        {
            return await repository.GetCreateModel(model);
        }

        private async Task<ProfessionalExperienceViewModel> RecoverModelEdit(ProfessionalExperienceViewModel model)
        {
            var item = await repository.GetProfessionalExperience(model.Id);
            var modelRecover = await RecoverModel(item);
            modelRecover.Years = model.Years;
            modelRecover.Months = model.Months;
            modelRecover.Error = model.Error;
            return modelRecover;
        }

        [HttpPost, ActionName("DeleteExperience")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteExperience(int id, int identifier, string username)
        {
            await repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index), new { identifier = identifier, fullName = username });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PortalEquador.Domain.Education.School.Repository;
using PortalEquador.Domain.Education.School.ViewModels;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.Education
{
    public class SchoolController(ISchoolRepository repository) : Controller
    {

        // GET: School
        public async Task<IActionResult> Index(int identifier, string fullName)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;

            var models = await repository.GetAll(identifier);
            return View(models);
        }

        // GET: School/Create
        public async Task<IActionResult> Create(int identifier, string fullName)
        {
            var model = await repository.GetCreateModel(identifier, fullName);
            return View(model);
        }

        // POST: School/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SchoolViewModel model)
        {
            var exists = await repository.SchoolExists(model.PersonaInformationId, model.InstitutionId, model.MajorId, model.DegreeId);
            if (exists)
            {
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.EXISTING_EDUCATION);
                model.Error = StringConstants.Error.EXISTING_EDUCATION;
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await repository.Save(model);
                    return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, fullName = model.FullName });
                }
            }

            ViewData["id"] = model.Id;
            model = await RecoverModel(model);
            return View(model);

        }


        // GET: School/Edit/5
        public async Task<IActionResult> Edit(int id, int identifier, string fullName)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;

            var model = await repository.GetSchool(id);
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

        // POST: School/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int identifier, string fullName, SchoolViewModel model)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = model.PersonaInformationId;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;

            var exists = await repository.SchoolExists(model.PersonaInformationId, model.InstitutionId, model.MajorId, model.DegreeId);
            if (exists)
            {
               model = await RecoverModelForEdit(model, fullName);
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.EXISTING_EDUCATION);
                model.Error = StringConstants.Error.EXISTING_EDUCATION;
                return View(model);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await repository.Save(model);
                    return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, fullName = model.FullName });
                }
            }

            ViewData["id"] = model.Id;
            model = await RecoverModel(model);
            return View(model);
        }


        [HttpPost, ActionName("DeleteEducation")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEducation(int id, int identifier, string username)
        {
            await repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index), new { identifier = identifier, fullName = username });
        }


        private async Task<SchoolViewModel> RecoverModel(SchoolViewModel model)
        {
            return await repository.GetCreateModel(model);
        }

        private async Task<SchoolViewModel> RecoverModelForEdit(SchoolViewModel model, string fullName)
        {
            model = await repository.GetSchool(model.Id);
            model = await RecoverModel(model);
            model.FullName = fullName;
            return model;
        }


    }
}

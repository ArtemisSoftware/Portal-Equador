using Microsoft.AspNetCore.Mvc;
using PortalEquador.Domain.Education.University.Repository;
using PortalEquador.Domain.Education.University.ViewModels;
using PortalEquador.Domain.Languages.Repository;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.Education
{
    public class UniversityController(IUniversityRepository repository) : Controller
    {

        // GET: University
        public async Task<IActionResult> Index(int identifier, string fullName)
        {
            ViewData["identifier"] = identifier;
            ViewData["username"] = fullName;

            var models = await repository.GetAll(identifier);
            return View(models);
        }

        // GET: University/Details/5
        public async Task<IActionResult> Create(int identifier, string fullName)
        {
            var model = await repository.GetCreateModel(identifier, fullName);
            return View(model);
        }

        // GET: University/Create
        public async Task<IActionResult> Create(UniversityViewModel model)
        {
            var exists = await repository.UniversityExists(model.PersonaInformationId, model.InstitutionId, model.MajorId);
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


        // GET: University/Edit/5
        public async Task<IActionResult> Edit(int id, int identifier, string fullName)
        {
            ViewData["identifier"] = identifier;
            ViewData["username"] = fullName;

            var model = await repository.GetUniversity((int)id);
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

        // POST: University/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int identifier, string fullName, UniversityViewModel model)
        {
            ViewData["identifier"] = identifier;
            ViewData["username"] = fullName;

            if (ModelState.IsValid)
            {
                await repository.Save(model);
                return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, fullName = model.FullName });
            }
            return View(model);
        }


        [HttpPost, ActionName("DeleteEducation")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEducation(int id, int identifier, string username)
        {
            await repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index), new { identifier = identifier, fullName = username });
        }


        private async Task<UniversityViewModel> RecoverModel(UniversityViewModel model)
        {
            return await repository.GetCreateModel(model);
        }

    }
}

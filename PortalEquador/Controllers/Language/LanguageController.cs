using Microsoft.AspNetCore.Mvc;
using PortalEquador.Domain.Languages.Repository;
using PortalEquador.Domain.Languages.ViewModels;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.Language
{
    public class LanguageController(ILanguageRepository repository) : Controller
    {

        // GET: Language
        public async Task<IActionResult> Index(int identifier, string fullName)
        {
            ViewData["identifier"] = identifier;
            ViewData["username"] = fullName;

            var models = await repository.GetAll(identifier);
            return View(models);
        }


        // GET: Language/Create
        public async Task<IActionResult> Create(int identifier, string fullName)
        {
            var model = await repository.GetCreateModel(identifier, fullName);
            return View(model);
        }

        // POST: Language/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LanguageViewModel model)
        {
            var exists = await repository.LanguageExists(model.PersonaInformationId, model.LanguageId);
            if (exists)
            {
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.EXISTING_LANGUAGE);
                model.Error = StringConstants.Error.EXISTING_LANGUAGE;
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

        // GET: GroupItems/Edit/5
        public async Task<IActionResult> Edit(int id, int identifier, string fullName)
        {
            ViewData["identifier"] = identifier;
            ViewData["username"] = fullName;

            var model = await repository.GetLanguage((int)id);
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

        // POST: GroupItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int identifier, string fullName, LanguageViewModel model)
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

        public async Task<IActionResult> Details(int id)
        {
            var model = await repository.GetLanguage(id);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
        }


        [HttpPost, ActionName("DeleteLanguage")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteLanguage(int id, int identifier, string username)
        {
            await repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index), new { identifier = identifier, fullName = username });
        }


        private async Task<LanguageViewModel> RecoverModel(LanguageViewModel model)
        {
            return await repository.GetCreateModel(model);
        }

    }
}

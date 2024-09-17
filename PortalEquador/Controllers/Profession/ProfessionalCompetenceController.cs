using Microsoft.AspNetCore.Mvc;
using PortalEquador.Domain.Profession.Competence.Repository;
using PortalEquador.Domain.Profession.Competence.ViewModels;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.Profession
{
    public class ProfessionalCompetenceController(IProfessionalCompetenceRepository repository) : Controller
    {

        // GET: ProfessionalCompetence
        public async Task<IActionResult> Index(int identifier, string fullName)
        {
            ViewData["identifier"] = identifier;
            ViewData["username"] = fullName;

            var models = await repository.GetAll(identifier);
            return View(models);
        }

        // GET: ProfessionalCompetence/Create
        public async Task<IActionResult> Create(int identifier, string fullName)
        {
            var model = await repository.GetCreateModel(identifier, fullName);
            return View(model);
        }

        // POST: ProfessionalCompetence/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfessionalCompetenceViewModel model)
        {
            var exists = await repository.ProfessionalCompetenceExists(model.PersonaInformationId, model.CompetenceId);
            if (exists)
            {
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.EXISTING_PROFESSIONAL_COMPETENCE);
                model.Error = StringConstants.Error.EXISTING_PROFESSIONAL_COMPETENCE;
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

        private async Task<ProfessionalCompetenceViewModel> RecoverModel(ProfessionalCompetenceViewModel model)
        {
            return await repository.GetCreateModel(model);
        }

        [HttpPost, ActionName("DeleteCompetence")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCompetence(int id, int identifier, string username)
        {
            await repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index), new { identifier = identifier, fullName = username });
        }
    }
}

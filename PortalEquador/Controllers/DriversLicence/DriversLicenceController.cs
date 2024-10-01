using Microsoft.AspNetCore.Mvc;
using PortalEquador.Domain.DriversLicence.Repository;
using PortalEquador.Domain.DriversLicence.UseCases;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.DriversLicence
{
    public class DriversLicenceController(
        IDriversLicenceRepository repository,
        SaveDriversLicenceUseCase saveDriversLicenceUseCase,
        SaveProvisionalUseCase saveProvisionalUseCase,
        RenewDriversLicenceUseCase renewDriversLicenceUseCase,
        GetDriversLicenceDetailUseCase getDriversLicenceDetailUseCase,
        GetDriversLicenceRenewUseCase getDriversLicenceRenewUseCase,
        GetDriversLicenceProvisionalUseCase getDriversLicenceProvisionalUseCase,
        GetDriversLicenceProvisionalRenewUseCase getDriversLicenceProvisionalRenewUseCase,
        GetDriversLicenceUseCase getDriversLicenceUseCase
     ) : Controller
    {

        // GET: DriversLicence
        public async Task<IActionResult> Index(int identifier, string fullName)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;

            var models = await repository.GetAll(identifier);
            return View(models);
        }



        // GET: DriversLicence/Create
        public async Task<IActionResult> Create(int identifier, string fullName)
        {
            var model = await repository.GetCreateModel(identifier, fullName);
            return View(model);
        }
        
        // POST: DriversLicence/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DriversLicenceViewModel model)
        {
            var exists = await repository.LicenceExists(model.PersonaInformationId, model.LicenceId);
            if (exists)
            {
                model = await RecoverModel(model);
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.EXISTING_DRIVERS_LICENCE);
                model.Error = StringConstants.Error.EXISTING_DRIVERS_LICENCE;
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await saveDriversLicenceUseCase.Invoke(model);
                    return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, fullName = model.FullName });
                }
                else
                {
                    model = await RecoverModel(model);
                    ModelState.AddModelError(nameof(model.Error), StringConstants.Error.UNDECLARED_ERROR);
                    model.Error = StringConstants.Error.UNDECLARED_ERROR;
                }
            }

            ViewData["id"] = model.Id;
            return View(model);
        }




        // GET: DriversLicence/Details/5
        public async Task<IActionResult> Details(int id, int identifier, string fullName)
        {
            var model = await getDriversLicenceDetailUseCase.Invoke(id);
            return View(model);
        }

        // GET: DriversLicence/RenewLicence
        public async Task<IActionResult> RenewLicence(int id, int identifier, string fullName)
        {

            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;

            var model = await getDriversLicenceRenewUseCase.Invoke(id);
            model.FullName = fullName;

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
 
        // POST: DriversLicence/RenewLicence/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RenewLicence(DriversLicenceRenewViewModel model)
        {
            await renewDriversLicenceUseCase.Invoke(model);
            return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, fullName = model.FullName });
        }

        // GET: DriversLicence/CreateProvisional
        public async Task<IActionResult> CreateProvisional(int id, int identifier, string fullName)
        {

            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;

            var model = await getDriversLicenceProvisionalUseCase.Invoke(id);
            model.FullName = fullName;

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: DriversLicence/RenewLicence/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProvisional(DriversLicenceProvisionalViewModel model)
        {
            if (ModelState.IsValid)
            {
                await saveProvisionalUseCase.Invoke(model);
                return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, fullName = model.FullName });
            }
            else
            {
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.UNDECLARED_ERROR);
                model.Error = StringConstants.Error.UNDECLARED_ERROR;
                return View(model);
            }
        }

        // GET: DriversLicence/Edit/5
        public async Task<IActionResult> Edit(int id, int identifier, string fullName)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;

            var model = await getDriversLicenceUseCase.Invoke(id);
            model = await RecoverModel(model);
            return View(model);
        }


        /*










        // POST: DriversLicence/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DriversLicenceViewModel_Finak model)
        {
            //model = await RecoverModel(model);
            await _saveDriversLicenceUseCase.Invoke(model, OperationType.Update);
            return RedirectToAction(StringConstants.Controller.Action.Dashboard, StringConstants.Controller.Curriculums, new { identifier = model.PersonaInformationId });
        }

        // GET: DriversLicence
        public async Task<IActionResult> Index()
        {
            var result = await _getAllDriversLicencesUseCase.Invoke();
            return View(result);
        }








        private async Task<DriversLicenceViewModel_Finak> RecoverModel(DriversLicenceViewModel_Finak model)
        {
            var recover = await _getDriversLicenceCreationModelUseCase.Invoke(model.PersonaInformationId);
            model.LicenceTypes = recover.LicenceTypes;
            model.PersonalInformation = recover.PersonalInformation;
            model.Documents = recover.Documents;
            return model;
        }


*/

        private async Task<DriversLicenceViewModel> RecoverModel(DriversLicenceViewModel model)
        {
            return await repository.GetCreateModel(model);
        }

    }
}

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
        RenewProvisionalUseCase renewProvisionalUseCase,
        RenewDriversLicenceUseCase renewDriversLicenceUseCase,
        GetDriversLicenceDetailUseCase getDriversLicenceDetailUseCase,
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
        public async Task<IActionResult> RenewLicence(int id)
        {

            var model = await getDriversLicenceUseCase.Invoke(id);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        /*
        // POST: DriversLicence/RenewLicence/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RenewLicence(DriversLicenceViewModel_Finak model)
        {
            await _renewDriversLicenceUseCase.Invoke(model);
            await _deleteDocumentUseCase.Invoke((int)model.ProvisionalLicenceDocumentId);
            return RedirectToAction(nameof(Index));
        }
        */

        /*



                // GET: DriversLicence/Details/5
                public async Task<IActionResult> Details(int identifier)
                {
                    var model = await _getDriversLicenceDetailModelUseCase.Invoke(identifier);
                    return View(model);
                }

                // GET: DriversLicence/Edit/5
                public async Task<IActionResult> Edit(int identifier)
                {
                    var model = await _getDriversLicenceUseCase.Invoke(identifier);
                    model = await RecoverModel(model);
                    return View(model);
                }

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





                // GET: DriversLicence/RenewLicence
                public async Task<IActionResult> RenewProvisional(int identifier)
                {

                    var model = await _getDriversLicenceUseCase.Invoke(identifier);

                    if (model == null)
                    {
                        return NotFound();
                    }
                    return View(model);
                }

                // POST: DriversLicence/RenewLicence/5
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> RenewProvisional(DriversLicenceViewModel_Finak model)
                {
                    await _renewProvisionalUseCase.Invoke(model);
                    return RedirectToAction(nameof(Index));
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


using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortalEquador.Constants;
using PortalEquador.Data;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Domain.Documents.UseCases;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.DriversLicence.UseCases;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Domain.PersonalInformation.UseCases;
using PortalEquador.Domain.Repositories;
using PortalEquador.Domain.UseCases;
using PortalEquador.Domain.UseCases.Documents;
using PortalEquador.Domain.UseCases.DriversLicence;

namespace PortalEquador.Controllers.DriversLicence
{
    public class DriversLicenceController : Controller
    {
        private readonly GetDriversLicenceCreationModelUseCase _getDriversLicenceCreationModelUseCase;
        private readonly SaveDriversLicenceUseCase _saveDriversLicenceUseCase;
        private readonly GetDriversLicenceDetailModelUseCase _getDriversLicenceDetailModelUseCase;
        private readonly GetDriversLicenceUseCase _getDriversLicenceUseCase;
        private readonly GetAllDriversLicencesUseCase _getAllDriversLicencesUseCase;
        private readonly RenewDriversLicenceUseCase _renewDriversLicenceUseCase;
        private readonly RenewProvisionalUseCase _renewProvisionalUseCase;
        private readonly DeleteDocumentUseCase _deleteDocumentUseCase;
        /*
        private readonly GetAllDriversLicencesUseCase _getAllDriversLicencesUseCase;
        private readonly GetDriversLicenceUseCase _getDriversLicenceUseCase;
        private readonly RenewDriversLicenceUseCase _renewDriversLicenceUseCase;*/

        public DriversLicenceController(
            GetDriversLicenceCreationModelUseCase getDriversLicenceCreationModelUseCase,
            SaveDriversLicenceUseCase saveDriversLicenceUseCase,
             GetDriversLicenceDetailModelUseCase getDriversLicenceDetailModelUseCase,
             GetAllDriversLicencesUseCase getAllDriversLicencesUseCase,
             GetDriversLicenceUseCase getDriversLicenceUseCase,
             RenewDriversLicenceUseCase renewDriversLicenceUseCase,
             RenewProvisionalUseCase renewProvisionalUseCase,
              DeleteDocumentUseCase deleteDocumentUseCase
            /*
           GetAllDriversLicencesUseCase getAllDriversLicencesUseCase,
           GetDriversLicenceUseCase getDriversLicenceUseCase,
           GetDriversLicenceDetailModelUseCase getDriversLicenceUseCase__,
           RenewDriversLicenceUseCase renewDriversLicenceUseCase*/
            )
        {
            _getDriversLicenceCreationModelUseCase = getDriversLicenceCreationModelUseCase;
            _saveDriversLicenceUseCase = saveDriversLicenceUseCase;
            _getDriversLicenceDetailModelUseCase = getDriversLicenceDetailModelUseCase;
            _getAllDriversLicencesUseCase = getAllDriversLicencesUseCase;
            _getDriversLicenceUseCase = getDriversLicenceUseCase;
            _renewDriversLicenceUseCase = renewDriversLicenceUseCase;
            _renewProvisionalUseCase = renewProvisionalUseCase;
            _deleteDocumentUseCase = deleteDocumentUseCase;

            /*
            _getAllDriversLicencesUseCase = getAllDriversLicencesUseCase;
            _getDriversLicenceUseCase = getDriversLicenceUseCase;
            
            */
        }


        // GET: DriversLicence/Create
        public async Task<IActionResult> Create(int identifier)
        {
            var model = await _getDriversLicenceCreationModelUseCase.Invoke(identifier);
            model.PersonaInformationId = identifier;
            return View(model);
        }


        // POST: DriversLicence/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DriversLicenceViewModel_Finak model)
        {
            
            if (ModelState.IsValid)
            {
                 await _saveDriversLicenceUseCase.Invoke(model, OperationType.Create);
                return RedirectToAction(StringConstants.Controller.Action.Dashboard, StringConstants.Controller.Curriculums, new { curriculumId = model.PersonaInformationId });
            }
            //ModelState.AddModelError(nameof(model.Error), StringConstants.Error.EXISTING_DOCUMENT);
            model = await RecoverModel(model);
            return View(model);
        }



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
        public async Task<IActionResult> RenewLicence(int identifier)
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
        public async Task<IActionResult> RenewLicence(DriversLicenceViewModel_Finak model)
        {
            await _renewDriversLicenceUseCase.Invoke(model);
            await _deleteDocumentUseCase.Invoke((int)model.ProvisionalLicenceDocumentId);
            return RedirectToAction(nameof(Index));
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
            await  _renewProvisionalUseCase.Invoke(model);
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
        





        //-------------------------------





    }
}

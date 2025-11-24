using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PortalEquador.Domain.Accident.Repository;
using PortalEquador.Domain.Accident.UseCases;
using PortalEquador.Domain.Accident.ViewModels;
using PortalEquador.Domain.Document;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.UseCases;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.Accident
{
    public class AccidentController(
        IAccidentRepository repository,
        GetVehiclesUseCase getVehiclesUseCase,
        GetVehicleUseCase getVehicleUse,
        SaveAccidentUseCase saveAccidentUseCase,
        DeleteAccidentUseCase deleteAccidentUseCase,
        DeleteDocumentUseCase deleteDocumentUseCase,
         IMapper mapper
) : Controller { 

        // GET: Accident
        public async Task<IActionResult> Index(int identifier, string fullName)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;

            var models = await repository.GetAll(identifier);
            return View(models);
        }

        public async Task<IActionResult> Create(int identifier, string fullName)
        {
            var model = await repository.GetCreateModel(identifier, fullName);
            model.Vehicles = getVehiclesUseCase.Invoke();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccidentViewModel model)
        {
            var exists = await repository.AccidentNumberExists(model.Number);
            if (exists)
            {
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.EXISTING_ACCIDENT_NUMBER);
                model.Error = StringConstants.Error.EXISTING_ACCIDENT_NUMBER;
            }
            else if (model.HasSelectedCauses() == false)
            {
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.NO_ACCIDENT_CAUSES);
                model.Error = StringConstants.Error.NO_ACCIDENT_CAUSES;
            }
            else
            {
                if (ModelState.IsValid)
                {
                    model = await RecoverModel(model);
                    await saveAccidentUseCase.Invoke(model);
                    return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, fullName = model.FullName });
                }
            }

            ViewData[ViewBagConstants.ID] = model.Id;
            model = await RecoverModel(model);
            return View(model);
        }

        public async Task<IActionResult> GetVehicleDetails(int vehicleId)
        {
            var vehicle = await getVehicleUse.Invoke(vehicleId);

            if (vehicle == null)
            {
                return NotFound();
            }

            var vehicleDetails = new
            {
                Model = vehicle.Model,
                Contract = vehicle.Contract.Description
            };

            return Json(vehicleDetails);
        }

        private async Task<AccidentViewModel> RecoverModel(AccidentViewModel model)
        {
            var result = await repository.GetCreateModel(model);
            result.Vehicles = getVehiclesUseCase.Invoke();
            return result;
        }


        public async Task<IActionResult> Details(int id, int identifier, string fullName)
        {
            ViewData[ViewBagConstants.ID] = id;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;

            var model = await repository.GetAccident(id);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id, int identifier, string fullName)
        {
            ViewData[ViewBagConstants.ID] = id;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;

            var model = await repository.GetAccidentForEdition(id);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AccidentEditViewModel model)
        {
            try
            {
                ViewData[ViewBagConstants.ID] = model.Id;
                ViewData[ViewBagConstants.FULL_NAME] = model.FullName;
                ViewData[ViewBagConstants.PERSONAL_ID] = model.PersonaInformationId;

                if (model.HasSelectedCauses() == false)
                {
                    ModelState.AddModelError(nameof(model.Error), StringConstants.Error.NO_ACCIDENT_CAUSES);
                    model.Error = StringConstants.Error.NO_ACCIDENT_CAUSES;
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        var pdf = model.PdfFile;
                        model = await repository.GetAccidentForEdition(model.Id, model);
                        var newModel = mapper.Map<AccidentViewModel>(model);
                        newModel.FormFile = pdf;
                        await saveAccidentUseCase.Invoke(newModel);
                        return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, fullName = model.FullName });
                    }
                }

                model = await repository.GetAccidentForEdition(model.Id, model);
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(model.Error), ex.InnerException.ToString());
                model.Error = ">" + ex.InnerException.ToString();
                return View(model);
            }


        }

        [HttpPost, ActionName("DeleteAccident")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAccident(int id, int identifier, string username)
        {
            await deleteAccidentUseCase.Invoke(id);
            return RedirectToAction(nameof(Index), new { identifier = identifier, fullName = username });
        }

        [HttpPost, ActionName("DeleteAccidentDocument")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAccidentDocument(int id, int identifier, string username)
        {
            await deleteDocumentUseCase.Invoke(id, Util.EnumTypes.FolderType.Accident);
            return RedirectToAction(nameof(Index), new { identifier = identifier, fullName = username });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PortalEquador.Data;
using PortalEquador.Data.MechanicalWorkshop.Vehicle.Entity;
using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.ViewModels;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.MechanicalWorkshop
{
    public class MechanicalWorkshopVehicleController(IMechanicalWorkshopVehicleRepository repository) : Controller
    {

        // GET: MechanicalWorkshopVehicle
        public async Task<IActionResult> Index()
        {
            var models = await repository.GetVehicles();
            return View(models);
        }

        // GET: MechanicalWorkshopVehicle/Create
        public async Task<IActionResult> Create()
        {
            var model = await repository.GetCreateModel(null);
            return View(model);
        }

        // POST: MechanicalWorkshopVehicle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleViewModel @viewModel)
        {
            if (@viewModel.IsLicencePlateValid() == false)
            {
                ModelState.AddModelError(nameof(viewModel.Error), StringConstants.Error.INVALID_LICENCE_PLATE);
            }
            else
            {
                var exists = await repository.LicencePlateExists(viewModel.LicencePlate);

                if (exists)
                {
                    ModelState.AddModelError(nameof(viewModel.Error), StringConstants.Error.EXISTING_LICENCE_PLATE);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        await repository.Save(viewModel);
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            viewModel = await RecoverModel(viewModel);
            return View(viewModel);
        }

        // GET: MechanicalWorkshopVehicle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["id"] = id;
            if (id == null)
            {
                return NotFound();
            }

            var model = await repository.GetVehicle((int)id);
            model = await RecoverModel(model);
            return View(model);
        }

        // POST: MechanicalWorkshopVehicle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VehicleViewModel @viewModel)
        {
            if (ModelState.IsValid)
            {
                await repository.Save(viewModel);
                return RedirectToAction(nameof(Index));
            }
            ViewData["id"] = viewModel.Id;
            viewModel = await RecoverModel(viewModel);
            return View(viewModel);
        }

        // GET: MechanicalWorkshopVehicle/Details/5
        public async Task<IActionResult> Details(int id)
        {
           var model = await repository.GetVehicleDetail(id);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
        }


        [HttpPost, ActionName("Deactivate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deactivate(int id)
        {
            await repository.UpdateState(id, false);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Activate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Activate(int id)
        {
            await repository.UpdateState(id, true);
            return RedirectToAction(nameof(Index));
        }


        private async Task<VehicleViewModel> RecoverModel(VehicleViewModel model)
        {
            return await repository.GetCreateModel(model);
        }
    }
}

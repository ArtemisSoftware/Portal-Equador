using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using PortalEquador.Data;
using PortalEquador.Data.MechanicalWorkshop.Scheduler.Entity;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.ViewModels;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.MechanicalWorkshop
{
    public class MechanicalWorkshopSchedulerController(
        IMechanicalWorkshopSchedulerRepository repository,
        IMechanicalWorkshopVehicleRepository vehicleRepository
     ) : Controller
    {

        // GET: MechanicalWorkshopScheduler
        public async Task<IActionResult> Index(string? time)
        {
            DateOnly currentDate = DateOnly.MinValue;

            if (time == null)
            {
                currentDate = DateOnly.FromDateTime(DateTime.Now);
            }
            else
            {
                currentDate = DateOnly.FromDateTime(DateTime.Parse(time));
            }
            var model = await repository.GetDayPlan(currentDate);
            return View(model);
        }

        // GET: MechanicalWorkshopScheduler/Create
        public async Task<IActionResult> Create(string date, int interventionTimeId, int mechanicId)
        {
            var model = await repository.GetCreateModel(date, mechanicId, interventionTimeId);
            return View(model);
        }

        // POST: MechanicalWorkshopScheduler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SchedulerViewModel @viewModel)
        {
            if (ModelState.IsValid)
            {
                await repository.Save(viewModel);
                return RedirectToAction(nameof(Index));
            }

            viewModel = await RecoverModel(viewModel);
            return View(viewModel);
        }

        // GET: MechanicalWorkshopScheduler/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var model = await repository.GetSchedule(id);
            return View(model);
        }


        // GET: MechanicalWorkshopScheduler/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        private async Task<SchedulerViewModel> RecoverModel(SchedulerViewModel model)
        {
            return await repository.GetCreateModel(model);
        }

        public async Task<IActionResult> GetVehicleDetails(int vehicleId)
        {
            var vehicle = await vehicleRepository.GetVehicleDetail(vehicleId);

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

    }
}

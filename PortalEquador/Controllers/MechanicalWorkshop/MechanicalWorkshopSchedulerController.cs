using Microsoft.AspNetCore.Mvc;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.Repository;
using PortalEquador.Util;
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
                return RedirectToAction(nameof(Index), new { time = TimeUtil.ToDateTime(viewModel.ScheduleDate).ToString() });
            }

            viewModel = await RecoverModel(viewModel);
            return View(viewModel);
        }

        // GET: MechanicalWorkshopScheduler/Details/5
        public async Task<IActionResult> Details(int id, string? origin)
        {
            ViewData[ViewBagConstants.ORIGIN] = origin;
            var model = await repository.GetSchedule(id);
            return View(model);
        }


        // GET: MechanicalWorkshopScheduler/Delete/5
        public async Task<IActionResult> Delete(int id, string time, string? origin, string? vehicleId)
        {
            await repository.DeleteAsync(id);
            if(origin == null)
            {
                return RedirectToAction(nameof(Index), new { time = time });
            } else
            {
                return RedirectToAction(nameof(Search), new { vehicleId = vehicleId });
            }
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

        // GET: MechanicalWorkshopScheduler
        public async Task<IActionResult> Search(string? vehicleId)
        {
            var model = await repository.SearchGetDayPlan(vehicleId);
            return View(model);
        }
    }
}

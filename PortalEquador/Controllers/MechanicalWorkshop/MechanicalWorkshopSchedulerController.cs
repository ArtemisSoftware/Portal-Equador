using Microsoft.AspNetCore.Mvc;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.UseCase;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.Repository;
using PortalEquador.Util;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.MechanicalWorkshop
{
    public class MechanicalWorkshopSchedulerController(
        IMechanicalWorkshopSchedulerRepository repository,
        IMechanicalWorkshopVehicleRepository vehicleRepository,
        GetDayPlanUseCase getDayPlanUseCase,
        SearchDayPlanUseCase searchDayPlanUseCase
     ) : Controller
    {

        // GET: MechanicalWorkshopScheduler
        public async Task<IActionResult> Index(string? time, int workshopid, string workshopname)
        {
            ViewData[ViewBagConstants.WORKSHOP_ID] = workshopid;
            ViewData[ViewBagConstants.WORKSHOP_NAME] = workshopname;

            DateOnly currentDate = DateOnly.MinValue;

            if (time == null)
            {
                currentDate = DateOnly.FromDateTime(DateTime.Now);
            }
            else
            {
                currentDate = DateOnly.FromDateTime(DateTime.Parse(time));
            }
            var model = await getDayPlanUseCase.Invoke(currentDate, workshopid, workshopname);
            return View(model);
        }

        // GET: MechanicalWorkshopScheduler/Create
        public async Task<IActionResult> Create(string date, int workshopid, string workshopname, int interventionTimeId, int mechanicId)
        {
            ViewData[ViewBagConstants.WORKSHOP_ID] = workshopid;
            ViewData[ViewBagConstants.WORKSHOP_NAME] = workshopname;
            var model = await repository.GetCreateModel(date, mechanicId, interventionTimeId, workshopid, workshopname);
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
                return RedirectToAction(nameof(Index), new { time = TimeUtil.ToDateTime(viewModel.ScheduleDate).ToString(), workshopid = viewModel.WorkshopId, workshopname = viewModel.WorkshopName });
            }

            viewModel = await RecoverModel(viewModel);
            return View(viewModel);
        }

        // GET: MechanicalWorkshopScheduler/Details/5
        public async Task<IActionResult> Details(int id, string? origin)
        {
            ViewData[ViewBagConstants.ORIGIN] = origin;
            var model = await repository.GetSchedule(id);

            ViewData[ViewBagConstants.WORKSHOP_ID] = model.Workshop.Id;
            ViewData[ViewBagConstants.WORKSHOP_NAME] = model.Workshop.Name;

            return View(model);
        }


        // GET: MechanicalWorkshopScheduler/Delete/5
        public async Task<IActionResult> Delete(int id, string time, int workshopid, string workshopname, string? origin, string? vehicleId)
        {
            ViewData[ViewBagConstants.WORKSHOP_ID] = workshopid;
            ViewData[ViewBagConstants.WORKSHOP_NAME] = workshopname;
            await repository.DeleteAsync(id);
            if(origin == null)
            {
                return RedirectToAction(nameof(Index), new { time = time, workshopid = workshopid, workshopname = workshopname });
            } else
            {
                return RedirectToAction(nameof(Search), new { vehicleId = vehicleId, workshopid = workshopid, workshopname = workshopname });
            }
        }

        public async Task<IActionResult> Confirm(int id, string? time, int workshopid, string workshopname, string? origin, string? vehicleId)
        {
            await repository.ConfirmRevision(id);
            if (origin == null)
            {
                return RedirectToAction(nameof(Index), new { time = time, workshopid = workshopid, workshopname = workshopname });
            }
            else
            {
                return RedirectToAction(nameof(Search), new { vehicleId = vehicleId, workshopid = workshopid, workshopname = workshopname });
            }
        }

        public async Task<IActionResult> NotPerformed(int id, string? time, int workshopid, string workshopname, string? origin, string? vehicleId)
        {
            await repository.NotPerformed(id);
            if (origin == null)
            {
                return RedirectToAction(nameof(Index), new { time = time, workshopid = workshopid, workshopname = workshopname });
            }
            else
            {
                return RedirectToAction(nameof(Search), new { vehicleId = vehicleId, workshopid = workshopid, workshopname = workshopname });
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
        public async Task<IActionResult> Search(string? vehicleId, int workshopId, string workshopName)
        {
            ViewData[ViewBagConstants.WORKSHOP_ID] = workshopId;
            ViewData[ViewBagConstants.WORKSHOP_NAME] = workshopName;

            var model = await searchDayPlanUseCase.Invoke(vehicleId, workshopId);
            return View(model);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.Repository;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.Repository;
using PortalEquador.Util;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.MechanicalWorkshop
{

    public class CarWashSchedulerController(
        ICarWashSchedulerRepository repository,
        IMechanicalWorkshopVehicleRepository vehicleRepository
    ) : Controller
    {

        // GET: CarWashScheduler
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

        // GET: CarWashScheduler/Create
        public async Task<IActionResult> Create(string date, int interventionTimeId)
        {
            var model = await repository.GetCreateModel(date, interventionTimeId);
            return View(model);
        }

        // POST: CarWashScheduler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarWashViewModel @viewModel)
        {
            if (ModelState.IsValid)
            {
                await repository.Save(viewModel);
                return RedirectToAction(nameof(Index), new { time = TimeUtil.ToDateTime(viewModel.ScheduleDate).ToString() });
            }

            viewModel = await RecoverModel(viewModel);
            return View(viewModel);
        }

        private async Task<CarWashViewModel> RecoverModel(CarWashViewModel model)
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



        // GET: CarWashScheduler/Details/5
        public async Task<IActionResult> Details(int id, string? origin)
        {
            ViewData[ViewBagConstants.ORIGIN] = origin;
            var model = await repository.GetSchedule(id);
            return View(model);
        }

        // GET: CarWashScheduler/Delete/5
        public async Task<IActionResult> Delete(int id, string time, string? origin, string? licencePlate)
        {
            await repository.DeleteAsync(id);
            if (origin == null)
            {
                return RedirectToAction(nameof(Index), new { time = time });
            }
            else
            {
                return RedirectToAction(nameof(Search), new { licencePlate = licencePlate });
            }
        }

        // GET: CarWashScheduler/Delete/5
        public async Task<IActionResult> Confirm(int id, string? time, string? origin, string? licencePlate)
        {
            await repository.ConfirmWash(id);
            if (origin == null)
            {
                return RedirectToAction(nameof(Index), new { time = time });
            }
            else
            {
                return RedirectToAction(nameof(Search), new { licencePlate = licencePlate });
            }
        }

        public async Task<IActionResult> NotPerformed(int id, string? time, string? origin, string? licencePlate)
        {
            await repository.NotPerformed(id);
            if (origin == null)
            {
                return RedirectToAction(nameof(Index), new { time = time });
            }
            else
            {
                return RedirectToAction(nameof(Search), new { licencePlate = licencePlate });
            }
        }

        public async Task<IActionResult> Search(string? licencePlate)
        {
            if (licencePlate == null)
            {
                return View(new CarWashSearchDayPlannerViewModel());
            }
            else
            {
                var model = await repository.SearchGetDayPlan(licencePlate);
                return View(model);
            }
        }


        /*

                // GET: CarWashScheduler/Details/5
                public async Task<IActionResult> Details(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var carWashSchedulerEntity = await _context.CarWashSchedulerEntity
                        .Include(c => c.ApplicationUserEntity)
                        .Include(c => c.ContractGroupItemEntity)
                        .Include(c => c.InterventionTimeGroupItemEntity)
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (carWashSchedulerEntity == null)
                    {
                        return NotFound();
                    }

                    return View(carWashSchedulerEntity);
                }



                // GET: CarWashScheduler/Edit/5
                public async Task<IActionResult> Edit(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var carWashSchedulerEntity = await _context.CarWashSchedulerEntity.FindAsync(id);
                    if (carWashSchedulerEntity == null)
                    {
                        return NotFound();
                    }
                    ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", carWashSchedulerEntity.EditorId);
                    ViewData["ContractId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", carWashSchedulerEntity.ContractId);
                    ViewData["InterventionTimeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", carWashSchedulerEntity.InterventionTimeId);
                    return View(carWashSchedulerEntity);
                }

                // POST: CarWashScheduler/Edit/5
                // To protect from overposting attacks, enable the specific properties you want to bind to.
                // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Edit(int id, [Bind("ScheduleDate,ContractId,InterventionTimeId,Id,EditorId,DateCreated,DateModified")] CarWashSchedulerEntity carWashSchedulerEntity)
                {
                    if (id != carWashSchedulerEntity.Id)
                    {
                        return NotFound();
                    }

                    if (ModelState.IsValid)
                    {
                        try
                        {
                            _context.Update(carWashSchedulerEntity);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!CarWashSchedulerEntityExists(carWashSchedulerEntity.Id))
                            {
                                return NotFound();
                            }
                            else
                            {
                                throw;
                            }
                        }
                        return RedirectToAction(nameof(Index));
                    }
                    ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", carWashSchedulerEntity.EditorId);
                    ViewData["ContractId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", carWashSchedulerEntity.ContractId);
                    ViewData["InterventionTimeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", carWashSchedulerEntity.InterventionTimeId);
                    return View(carWashSchedulerEntity);
                }

                // GET: CarWashScheduler/Delete/5
                public async Task<IActionResult> Delete(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var carWashSchedulerEntity = await _context.CarWashSchedulerEntity
                        .Include(c => c.ApplicationUserEntity)
                        .Include(c => c.ContractGroupItemEntity)
                        .Include(c => c.InterventionTimeGroupItemEntity)
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (carWashSchedulerEntity == null)
                    {
                        return NotFound();
                    }

                    return View(carWashSchedulerEntity);
                }

                // POST: CarWashScheduler/Delete/5
                [HttpPost, ActionName("Delete")]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> DeleteConfirmed(int id)
                {
                    var carWashSchedulerEntity = await _context.CarWashSchedulerEntity.FindAsync(id);
                    if (carWashSchedulerEntity != null)
                    {
                        _context.CarWashSchedulerEntity.Remove(carWashSchedulerEntity);
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                private bool CarWashSchedulerEntityExists(int id)
                {
                    return _context.CarWashSchedulerEntity.Any(e => e.Id == id);
                }
        */
    }
}

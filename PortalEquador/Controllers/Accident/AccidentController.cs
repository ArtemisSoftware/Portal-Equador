using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.Accident.Entities;
using PortalEquador.Domain.Accident.Repository;
using PortalEquador.Domain.Accident.UseCases;
using PortalEquador.Domain.Accident.ViewModels;
using PortalEquador.Domain.Contract.Repository;
using PortalEquador.Domain.Languages.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.UseCases;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.Accident
{
    public class AccidentController(
        IAccidentRepository repository,
        GetVehiclesUseCase getVehiclesUseCase,
        GetVehicleUseCase getVehicleUse,
        SaveAccidentUseCase saveAccidentUseCase
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

        /*
                // GET: Accident/Details/5
                public async Task<IActionResult> Details(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var accidentEntity = await _context.AccidentEntity
                        .Include(a => a.ApplicationUserEntity)
                        .Include(a => a.CityGroupItemEntity)
                        .Include(a => a.ContractGroupItemEntity)
                        .Include(a => a.EstimatedValueGroupItemEntity)
                        .Include(a => a.LevelGroupItemEntity)
                        .Include(a => a.PersonalInformationEntity)
                        .Include(a => a.VehicleEntity)
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (accidentEntity == null)
                    {
                        return NotFound();
                    }

                    return View(accidentEntity);
                }

                // GET: Accident/Create
                public IActionResult Create()
                {
                    ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id");
                    ViewData["CityId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
                    ViewData["ContractId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
                    ViewData["EstimatedValueId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
                    ViewData["LevelId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
                    ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id");
                    ViewData["VehicleId"] = new SelectList(_context.MechanicalWorkshopVehicleEntity, "Id", "Id");
                    return View();
                }

                // POST: Accident/Create
                // To protect from overposting attacks, enable the specific properties you want to bind to.
                // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Create([Bind("PersonalInformationId,Number,Date,VehicleId,ContractId,Address,CityId,EstimatedValueId,HumanDamage,LevelId,Id,EditorId,DateCreated,DateModified")] AccidentEntity accidentEntity)
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(accidentEntity);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", accidentEntity.EditorId);
                    ViewData["CityId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", accidentEntity.CityId);
                    ViewData["ContractId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", accidentEntity.ContractId);
                    ViewData["EstimatedValueId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", accidentEntity.EstimatedValueId);
                    ViewData["LevelId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", accidentEntity.LevelId);
                    ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", accidentEntity.PersonalInformationId);
                    ViewData["VehicleId"] = new SelectList(_context.MechanicalWorkshopVehicleEntity, "Id", "Id", accidentEntity.VehicleId);
                    return View(accidentEntity);
                }

                // GET: Accident/Edit/5
                public async Task<IActionResult> Edit(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var accidentEntity = await _context.AccidentEntity.FindAsync(id);
                    if (accidentEntity == null)
                    {
                        return NotFound();
                    }
                    ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", accidentEntity.EditorId);
                    ViewData["CityId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", accidentEntity.CityId);
                    ViewData["ContractId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", accidentEntity.ContractId);
                    ViewData["EstimatedValueId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", accidentEntity.EstimatedValueId);
                    ViewData["LevelId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", accidentEntity.LevelId);
                    ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", accidentEntity.PersonalInformationId);
                    ViewData["VehicleId"] = new SelectList(_context.MechanicalWorkshopVehicleEntity, "Id", "Id", accidentEntity.VehicleId);
                    return View(accidentEntity);
                }

                // POST: Accident/Edit/5
                // To protect from overposting attacks, enable the specific properties you want to bind to.
                // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Edit(int id, [Bind("PersonalInformationId,Number,Date,VehicleId,ContractId,Address,CityId,EstimatedValueId,HumanDamage,LevelId,Id,EditorId,DateCreated,DateModified")] AccidentEntity accidentEntity)
                {
                    if (id != accidentEntity.Id)
                    {
                        return NotFound();
                    }

                    if (ModelState.IsValid)
                    {
                        try
                        {
                            _context.Update(accidentEntity);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!AccidentEntityExists(accidentEntity.Id))
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
                    ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", accidentEntity.EditorId);
                    ViewData["CityId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", accidentEntity.CityId);
                    ViewData["ContractId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", accidentEntity.ContractId);
                    ViewData["EstimatedValueId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", accidentEntity.EstimatedValueId);
                    ViewData["LevelId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", accidentEntity.LevelId);
                    ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", accidentEntity.PersonalInformationId);
                    ViewData["VehicleId"] = new SelectList(_context.MechanicalWorkshopVehicleEntity, "Id", "Id", accidentEntity.VehicleId);
                    return View(accidentEntity);
                }

                // GET: Accident/Delete/5
                public async Task<IActionResult> Delete(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var accidentEntity = await _context.AccidentEntity
                        .Include(a => a.ApplicationUserEntity)
                        .Include(a => a.CityGroupItemEntity)
                        .Include(a => a.ContractGroupItemEntity)
                        .Include(a => a.EstimatedValueGroupItemEntity)
                        .Include(a => a.LevelGroupItemEntity)
                        .Include(a => a.PersonalInformationEntity)
                        .Include(a => a.VehicleEntity)
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (accidentEntity == null)
                    {
                        return NotFound();
                    }

                    return View(accidentEntity);
                }

                // POST: Accident/Delete/5
                [HttpPost, ActionName("Delete")]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> DeleteConfirmed(int id)
                {
                    var accidentEntity = await _context.AccidentEntity.FindAsync(id);
                    if (accidentEntity != null)
                    {
                        _context.AccidentEntity.Remove(accidentEntity);
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                private bool AccidentEntityExists(int id)
                {
                    return _context.AccidentEntity.Any(e => e.Id == id);
                }
        */
    }
}

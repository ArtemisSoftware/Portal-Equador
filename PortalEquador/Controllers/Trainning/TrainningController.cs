using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.Trainning.Entity;
using PortalEquador.Domain.DisciplinaryNotification.ViewModels;
using PortalEquador.Domain.MedicalExam.UseCases;
using PortalEquador.Domain.Trainning.Repository;
using PortalEquador.Domain.Trainning.UseCases;
using PortalEquador.Domain.Trainning.ViewModels;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.Trainning
{
    public class TrainningController(
        ITrainningRepository repository,
        SaveTrainningUseCase saveTrainningUseCase,
        DeleteTrainningUseCase deleteTrainningUseCase
        ) : Controller
    {


        // GET: Trainning
        public async Task<IActionResult> Index(int identifier, string fullName)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;

            var models = await repository.GetAll(identifier);
            return View(models);
        }

        // GET: Trainning/Create
        public async Task<IActionResult> Create(int identifier, string fullName)
        {
            var model = await repository.GetCreateModel(identifier, fullName);
            return View(model);
        }

        // POST: Trainning/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainningCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await saveTrainningUseCase.Invoke(model);
                return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, fullName = model.FullName });
            }
            else
            {
                ViewData["id"] = model.Id;
                model = await RecoverModel(model);
                return View(model);
            }
        }

        // GET: DisciplinaryNotification/Details/5
        public async Task<IActionResult> Details(int identifier, string fullName)
        {
            var model = await repository.GetDetail(identifier);
            return View(model);
        }

        [HttpPost, ActionName("DeleteTrainning")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTrainning(int id, int identifier, string username)
        {
            await deleteTrainningUseCase.Invoke(id);
            return RedirectToAction(nameof(Index), new { identifier = identifier, fullName = username });
        }


        private async Task<TrainningCreateViewModel> RecoverModel(TrainningCreateViewModel model)
        {
            return await repository.GetCreateModel(model);
        }
        /*
                // GET: Trainning/Details/5
                public async Task<IActionResult> Details(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var trainningEntity = await _context.TrainningEntity
                        .Include(t => t.ApplicationUserEntity)
                        .Include(t => t.PersonalInformationEntity)
                        .Include(t => t.TrainningGroupItemEntity)
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (trainningEntity == null)
                    {
                        return NotFound();
                    }

                    return View(trainningEntity);
                }



                // GET: Trainning/Edit/5
                public async Task<IActionResult> Edit(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var trainningEntity = await _context.TrainningEntity.FindAsync(id);
                    if (trainningEntity == null)
                    {
                        return NotFound();
                    }
                    ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", trainningEntity.EditorId);
                    ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", trainningEntity.PersonalInformationId);
                    ViewData["TrainningId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", trainningEntity.TrainningId);
                    return View(trainningEntity);
                }

                // POST: Trainning/Edit/5
                // To protect from overposting attacks, enable the specific properties you want to bind to.
                // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Edit(int id, [Bind("PersonalInformationId,Date,TrainningId,Nature,Observation,Extension,Id,EditorId,DateCreated,DateModified")] TrainningEntity trainningEntity)
                {
                    if (id != trainningEntity.Id)
                    {
                        return NotFound();
                    }

                    if (ModelState.IsValid)
                    {
                        try
                        {
                            _context.Update(trainningEntity);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!TrainningEntityExists(trainningEntity.Id))
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
                    ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", trainningEntity.EditorId);
                    ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", trainningEntity.PersonalInformationId);
                    ViewData["TrainningId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", trainningEntity.TrainningId);
                    return View(trainningEntity);
                }

                // GET: Trainning/Delete/5
                public async Task<IActionResult> Delete(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var trainningEntity = await _context.TrainningEntity
                        .Include(t => t.ApplicationUserEntity)
                        .Include(t => t.PersonalInformationEntity)
                        .Include(t => t.TrainningGroupItemEntity)
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (trainningEntity == null)
                    {
                        return NotFound();
                    }

                    return View(trainningEntity);
                }

                // POST: Trainning/Delete/5
                [HttpPost, ActionName("Delete")]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> DeleteConfirmed(int id)
                {
                    var trainningEntity = await _context.TrainningEntity.FindAsync(id);
                    if (trainningEntity != null)
                    {
                        _context.TrainningEntity.Remove(trainningEntity);
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                private bool TrainningEntityExists(int id)
                {
                    return _context.TrainningEntity.Any(e => e.Id == id);
                }
        */
    }
}

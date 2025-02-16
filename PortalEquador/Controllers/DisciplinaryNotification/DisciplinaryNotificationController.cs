using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.DisciplinaryNotification.Entity;
using PortalEquador.Domain.DisciplinaryNotification.Repository;
using PortalEquador.Domain.DisciplinaryNotification.UseCases;
using PortalEquador.Domain.DisciplinaryNotification.ViewModels;
using PortalEquador.Domain.Education.School.ViewModels;
using PortalEquador.Domain.MedicalExam.ViewModels;
using PortalEquador.Domain.Trainning.UseCases;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.DisciplinaryNotification
{
    public class DisciplinaryNotificationController(
        IDisciplinaryNotificationRepository repository,
        SaveDisciplinaryNotificationUseCase saveDisciplinaryNotificationUseCase,
        DeleteDisciplinaryNotificationUseCase deleteDisciplinaryNotificationUseCase
        ) : Controller
    {

        // GET: DisciplinaryNotification

        public async Task<IActionResult> Index(int identifier, string fullName)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;

            var models = await repository.GetAll(identifier);
            return View(models);
        }

        // GET: DisciplinaryNotification/Create
        public async Task<IActionResult> Create(int identifier, string fullName)
        {
            var model = await repository.GetCreateModel(identifier, fullName);
            return View(model);
        }

        // POST: DisciplinaryNotification/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DisciplinaryNotificationCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await saveDisciplinaryNotificationUseCase.Invoke(model);
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
            var model = await repository.GetDetail (identifier);
            return View(model);
        }

        [HttpPost, ActionName("DisciplinaryNotification")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DisciplinaryNotification(int id, int identifier, string username)
        {
            await deleteDisciplinaryNotificationUseCase.Invoke(id);
            return RedirectToAction(nameof(Index), new { identifier = identifier, fullName = username });
        }

        private async Task<DisciplinaryNotificationCreateViewModel> RecoverModel(DisciplinaryNotificationCreateViewModel model)
        {
            return await repository.GetCreateModel(model);
        }

        /*





        // GET: DisciplinaryNotification/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplinaryNotificationEntity = await _context.DisciplinaryNotificationEntity.FindAsync(id);
            if (disciplinaryNotificationEntity == null)
            {
                return NotFound();
            }
            ViewData["AccidentLevelId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", disciplinaryNotificationEntity.AccidentLevelId);
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", disciplinaryNotificationEntity.EditorId);
            ViewData["NotificationId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", disciplinaryNotificationEntity.NotificationId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", disciplinaryNotificationEntity.PersonalInformationId);
            return View(disciplinaryNotificationEntity);
        }

        // POST: DisciplinaryNotification/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonalInformationId,Date,NotificationId,Local,AccidentLevelId,Decision,Observation,Extension,Id,EditorId,DateCreated,DateModified")] DisciplinaryNotificationEntity disciplinaryNotificationEntity)
        {
            if (id != disciplinaryNotificationEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disciplinaryNotificationEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplinaryNotificationEntityExists(disciplinaryNotificationEntity.Id))
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
            ViewData["AccidentLevelId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", disciplinaryNotificationEntity.AccidentLevelId);
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", disciplinaryNotificationEntity.EditorId);
            ViewData["NotificationId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", disciplinaryNotificationEntity.NotificationId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", disciplinaryNotificationEntity.PersonalInformationId);
            return View(disciplinaryNotificationEntity);
        }

        // GET: DisciplinaryNotification/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplinaryNotificationEntity = await _context.DisciplinaryNotificationEntity
                .Include(d => d.AccidentLevelGroupItemEntity)
                .Include(d => d.ApplicationUserEntity)
                .Include(d => d.NotificationGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disciplinaryNotificationEntity == null)
            {
                return NotFound();
            }

            return View(disciplinaryNotificationEntity);
        }

        // POST: DisciplinaryNotification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disciplinaryNotificationEntity = await _context.DisciplinaryNotificationEntity.FindAsync(id);
            if (disciplinaryNotificationEntity != null)
            {
                _context.DisciplinaryNotificationEntity.Remove(disciplinaryNotificationEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisciplinaryNotificationEntityExists(int id)
        {
            return _context.DisciplinaryNotificationEntity.Any(e => e.Id == id);
        }
        */
    }
}

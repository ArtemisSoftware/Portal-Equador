using Microsoft.AspNetCore.Mvc;
using PortalEquador.Domain.Education.School.ViewModels;
using PortalEquador.Domain.Languages.ViewModels;
using PortalEquador.Domain.MedicalExam.Repository;
using PortalEquador.Domain.MedicalExam.UseCases;
using PortalEquador.Domain.MedicalExam.ViewModels;
using PortalEquador.Domain.Trainning.ViewModels;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.MedicalExam
{
    public class MedicalExamController(
        IMedicalExamRepository repository,
        SaveMedicalExamUseCase saveMedicalExamUseCase,
        DeleteMedicalExamUseCase deleteMedicalExamUseCase
        ) : Controller
    {

        // GET: MedicalExam
        public async Task<IActionResult> Index(int identifier, string fullName)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;

            var models = await repository.GetAll(identifier);
            return View(models);
        }

        // GET: MedicalExam/Create
        public async Task<IActionResult> Create(int identifier, string fullName)
        {
            var model = await repository.GetCreateModel(identifier, fullName);
            return View(model);
        }

        // POST: MedicalExam/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicalExamCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await saveMedicalExamUseCase.Invoke(model);
                return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, fullName = model.FullName });
            }
            else
            {
                ViewData["id"] = model.Id;
                model = await RecoverModel(model);
                return View(model);
            }
        }

        public async Task<IActionResult> Details(int identifier, string fullName)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;
            var model = await repository.GetDetail(identifier);
            return View(model);
        }

        [HttpPost, ActionName("DeleteMedicalExam")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMedicalExam(int id, int identifier, string username)
        {
            await deleteMedicalExamUseCase.Invoke(id);
            return RedirectToAction(nameof(Index), new { identifier = identifier, fullName = username });
        }

        private async Task<MedicalExamCreateViewModel> RecoverModel(MedicalExamCreateViewModel model)
        {
            return await repository.GetCreateModel(model);
        }




        // GET: GroupItems/Edit/5
        public async Task<IActionResult> Edit(int id, int identifier, string fullName)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;

            var model = await repository.GetMedicalExam((int)id);
            model = await RecoverModel(model);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
        }

        // POST: GroupItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int identifier, string fullName, MedicalExamCreateViewModel model)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;

            if (ModelState.IsValid)
            {
                await repository.Save(model);
                return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, fullName = model.FullName });
            }
            return View(model);
        }





        /*



        // GET: MedicalExam/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalExamEntity = await _context.MedicalExamEntity.FindAsync(id);
            if (medicalExamEntity == null)
            {
                return NotFound();
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", medicalExamEntity.EditorId);
            ViewData["ExamId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", medicalExamEntity.ExamId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", medicalExamEntity.PersonalInformationId);
            return View(medicalExamEntity);
        }

        // POST: MedicalExam/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonalInformationId,ExamId,Observation,Extension,Id,EditorId,DateCreated,DateModified")] MedicalExamEntity medicalExamEntity)
        {
            if (id != medicalExamEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalExamEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalExamEntityExists(medicalExamEntity.Id))
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
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", medicalExamEntity.EditorId);
            ViewData["ExamId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", medicalExamEntity.ExamId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", medicalExamEntity.PersonalInformationId);
            return View(medicalExamEntity);
        }

        // GET: MedicalExam/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalExamEntity = await _context.MedicalExamEntity
                .Include(m => m.ApplicationUserEntity)
                .Include(m => m.ExamGroupItemEntity)
                .Include(m => m.PersonalInformationEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalExamEntity == null)
            {
                return NotFound();
            }

            return View(medicalExamEntity);
        }

        // POST: MedicalExam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicalExamEntity = await _context.MedicalExamEntity.FindAsync(id);
            if (medicalExamEntity != null)
            {
                _context.MedicalExamEntity.Remove(medicalExamEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalExamEntityExists(int id)
        {
            return _context.MedicalExamEntity.Any(e => e.Id == id);
        }
        */
    }
}

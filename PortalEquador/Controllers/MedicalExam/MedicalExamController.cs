using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.MedicalExam.Entity;
using PortalEquador.Domain.Education.University.Repository;
using PortalEquador.Domain.MedicalExam.Repository;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.MedicalExam
{
    public class MedicalExamController(IMedicalExamRepository repository) : Controller
    {

        // GET: MedicalExam
        public async Task<IActionResult> Index(int identifier, string fullName)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;

            var models = await repository.GetAll(identifier);
            return View(models);
        }

        /*
        // GET: MedicalExam/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: MedicalExam/Create
        public IActionResult Create()
        {
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["ExamId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id");
            return View();
        }

        // POST: MedicalExam/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalInformationId,ExamId,Observation,Extension,Id,EditorId,DateCreated,DateModified")] MedicalExamEntity medicalExamEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalExamEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", medicalExamEntity.EditorId);
            ViewData["ExamId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", medicalExamEntity.ExamId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", medicalExamEntity.PersonalInformationId);
            return View(medicalExamEntity);
        }

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

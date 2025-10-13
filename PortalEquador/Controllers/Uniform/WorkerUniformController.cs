using Microsoft.AspNetCore.Mvc;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.Education.School.ViewModels;
using PortalEquador.Domain.MedicalExam.UseCases;
using PortalEquador.Domain.Uniforms.Repository;
using PortalEquador.Domain.Uniforms.ViewModels;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.Uniform
{
    public class WorkerUniformController(
        IWorkerUniformRepository repository,
        IUniformRepository uniformRepository
        ) : Controller
    {

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
            model.Uniforms = uniformRepository.GetUniforms(OrderType.Alphabetic);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkerUniformCreateViewModel model)
        {
            var uniform = await uniformRepository.GetUniform(model.UniformId);

            if (uniform == null)
            {
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.NON_EXISTING_UNIFORM);
                model = await RecoverModel(model);
                return View(model);
            }
            else
            {
                model.IsNumericSize = uniform.isSizeNumeric;

                if (ModelState.IsValid && uniform.isSizeNumeric && model.Size != null)
                {
                    await repository.Save(model);
                    return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, fullName = model.FullName });
                }
                else if (ModelState.IsValid && uniform.isSizeNumeric == false && model.LabelSizeId != null)
                {
                    await repository.Save(model);
                    return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, fullName = model.FullName });
                }
                else
                {
                    model = await RecoverModel(model);
                    return View(model);
                }
            }
        }

        private async Task<WorkerUniformCreateViewModel> RecoverModel(WorkerUniformCreateViewModel model)
        {
            return await repository.GetCreateModel(model);
        }

        public async Task<IActionResult> GetSizeDetails(int uniformId)
        {
            var uniform = await uniformRepository.GetUniform(uniformId);

            if (uniform == null)
            {
                return NotFound();
            }

            var sizeDetails = new
            {
                IsSizeNumeric = !uniform.isSizeNumeric,
            };

            return Json(sizeDetails);
        }




        public async Task<IActionResult> Edit(int id, int identifier, string fullName)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;

            var model = await repository.GetEdit(id);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> ReturnDate(int id, int identifier, string fullName)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = identifier;
            ViewData[ViewBagConstants.FULL_NAME] = fullName;

            var model = await repository.GetReturnDateModel(id);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReturnDate(WorkerUniformReturnDateViewModel model)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = model.PersonaInformationId;
            ViewData[ViewBagConstants.FULL_NAME] = model.FullName;

            await repository.Save(model);
            return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, fullName = model.FullName });
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(WorkerUniformEditViewModel model)
        {
            ViewData[ViewBagConstants.PERSONAL_ID] = model.PersonaInformationId;
            ViewData[ViewBagConstants.FULL_NAME] = model.FullName;

            model = await repository.RecoverForEdit(model);

            if (ModelState.IsValid && model.Uniform.isSizeNumeric && model.Size != null)
            {
                await repository.Save(model);
                return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, fullName = model.FullName });
            }
            else if (ModelState.IsValid && model.Uniform.isSizeNumeric == false && model.LabelSizeId != null)
            {
                await repository.Save(model);
                return RedirectToAction(nameof(Index), new { identifier = model.PersonaInformationId, fullName = model.FullName });
            }
            else
            {
                return View(model);
            }
        }


        [HttpPost, ActionName("DeleteWorkerUniform")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteWorkerUniform(int id, int identifier, string username)
        {
            await repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index), new { identifier = identifier, fullName = username });
        }


        /*

        // GET: WorkerUniform
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WorkerUniformEntity.Include(w => w.ApplicationUserEntity).Include(w => w.PersonalInformationEntity).Include(w => w.UniformItemEntity);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WorkerUniform/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerUniformEntity = await _context.WorkerUniformEntity
                .Include(w => w.ApplicationUserEntity)
                .Include(w => w.PersonalInformationEntity)
                .Include(w => w.UniformItemEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workerUniformEntity == null)
            {
                return NotFound();
            }

            return View(workerUniformEntity);
        }

        // GET: WorkerUniform/Create
        public IActionResult Create()
        {
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id");
            ViewData["UniformId"] = new SelectList(_context.UniformEntity, "Id", "Id");
            return View();
        }

        // POST: WorkerUniform/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalInformationId,UniformId,Quantity,Size,Date,Observation,Id,EditorId,DateCreated,DateModified")] WorkerUniformEntity workerUniformEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workerUniformEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", workerUniformEntity.EditorId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", workerUniformEntity.PersonalInformationId);
            ViewData["UniformId"] = new SelectList(_context.UniformEntity, "Id", "Id", workerUniformEntity.UniformId);
            return View(workerUniformEntity);
        }

        // GET: WorkerUniform/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerUniformEntity = await _context.WorkerUniformEntity.FindAsync(id);
            if (workerUniformEntity == null)
            {
                return NotFound();
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", workerUniformEntity.EditorId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", workerUniformEntity.PersonalInformationId);
            ViewData["UniformId"] = new SelectList(_context.UniformEntity, "Id", "Id", workerUniformEntity.UniformId);
            return View(workerUniformEntity);
        }

        // POST: WorkerUniform/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonalInformationId,UniformId,Quantity,Size,Date,Observation,Id,EditorId,DateCreated,DateModified")] WorkerUniformEntity workerUniformEntity)
        {
            if (id != workerUniformEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workerUniformEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerUniformEntityExists(workerUniformEntity.Id))
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
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", workerUniformEntity.EditorId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", workerUniformEntity.PersonalInformationId);
            ViewData["UniformId"] = new SelectList(_context.UniformEntity, "Id", "Id", workerUniformEntity.UniformId);
            return View(workerUniformEntity);
        }

        // GET: WorkerUniform/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerUniformEntity = await _context.WorkerUniformEntity
                .Include(w => w.ApplicationUserEntity)
                .Include(w => w.PersonalInformationEntity)
                .Include(w => w.UniformItemEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workerUniformEntity == null)
            {
                return NotFound();
            }

            return View(workerUniformEntity);
        }

        // POST: WorkerUniform/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workerUniformEntity = await _context.WorkerUniformEntity.FindAsync(id);
            if (workerUniformEntity != null)
            {
                _context.WorkerUniformEntity.Remove(workerUniformEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerUniformEntityExists(int id)
        {
            return _context.WorkerUniformEntity.Any(e => e.Id == id);
        }
        */
    }
}

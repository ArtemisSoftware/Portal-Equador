using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Workshop.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Workshop.ViewModels;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.MechanicalWorkshop
{
    public class WorkshopController(
        IWorkshopRepository repository,
        IWorkshopLaneRepository workshopLaneRepository,
        IWorkshopMechanicRepository workshopMechanicRepository
        ) : Controller
    {

        public async Task<IActionResult> Dashboard()
        {
            var model = await repository.GetDashboard();
            return View(model);
        }

        public async Task<IActionResult> Management(int id, string name)
        {
            ViewData[ViewBagConstants.WORKSHOP_ID] = id;
            ViewData[ViewBagConstants.WORKSHOP_NAME] = name;

            return View();
        }



        public async Task<IActionResult> LanesIndex(int workshopid, string workshopname)
        {
            ViewData[ViewBagConstants.WORKSHOP_ID] = workshopid;
            ViewData[ViewBagConstants.WORKSHOP_NAME] = workshopname;

            var model = await repository.GetLanes(workshopid);

            return View(model);
        }

        public async Task<IActionResult> AddLane(int workshopid, string workshopname)
        {
            ViewData[ViewBagConstants.WORKSHOP_ID] = workshopid;
            ViewData[ViewBagConstants.WORKSHOP_NAME] = workshopname;
            await workshopLaneRepository.Save(workshopid);

            return RedirectToAction(nameof(LanesIndex), new { workshopid  = workshopid, workshopname  = workshopname });

        }

        public async Task<IActionResult> MechanicsIndex(int workshopid, string workshopname)
        {
            ViewData[ViewBagConstants.WORKSHOP_ID] = workshopid;
            ViewData[ViewBagConstants.WORKSHOP_NAME] = workshopname;

            var model = await repository.GetMechanics(workshopid);

            return View(model);
        }





        public async Task<IActionResult> AddMechanic(int workshopid, string workshopname)
        {
            ViewData[ViewBagConstants.WORKSHOP_ID] = workshopid;
            ViewData[ViewBagConstants.WORKSHOP_NAME] = workshopname;
            await workshopMechanicRepository.Save(workshopid);

            return RedirectToAction(nameof(MechanicsIndex), new { workshopid = workshopid, workshopname = workshopname });

        }

        [HttpPost, ActionName("DeactivateMechanic")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateMechanic(int id, int workshopid, string workshopname)
        {
            return await UpdateMechanicState(id, workshopid, workshopname, false);
        }

        [HttpPost, ActionName("ActivateMechanic")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActivateMechanic(int id, int workshopid, string workshopname)
        {
            return await UpdateMechanicState(id, workshopid, workshopname, true);
        }

        public async Task<IActionResult> UpdateMechanicState(int id, int workshopid, string workshopname, bool activate)
        {
            ViewData[ViewBagConstants.WORKSHOP_ID] = workshopid;
            ViewData[ViewBagConstants.WORKSHOP_NAME] = workshopname;

            await workshopMechanicRepository.UpdateState(id, activate);
            return RedirectToAction(nameof(MechanicsIndex), new { workshopid = workshopid, workshopname = workshopname });
        }




        // GET: Workshop
        public async Task<IActionResult> Index()
        {
            var model = await repository.GetAllWorkshops();
            return View(model);
        }

        // GET: Workshop/Create
        public IActionResult Create()
        {
            var model = new WorkshopCreateViewModel { Name = ""};
            return View(model);
        }

        // POST: Workshop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkshopCreateViewModel @model)
        {
            var exists = await repository.WorkshopExists(model.Name);
            if (exists)
            {
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.EXISTING_WORKSHOP);
                model.Error = StringConstants.Error.EXISTING_WORKSHOP;
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await repository.Save(model);
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }



        public async Task<IActionResult> Details(int id)
        {
            ViewData[ViewBagConstants.ID] = id;

            var model = await repository.GetWorkshop(id);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
        }



        [HttpPost, ActionName("DeactivateWorkshop")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateWorkshop(int id)
        {
            return await UpdateWorkshopState(id, false);
        }

        [HttpPost, ActionName("ActivateWorkshop")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActivateWorkshop(int id)
        {
            return await UpdateWorkshopState(id, true);
        }

        public async Task<IActionResult> UpdateWorkshopState(int id, bool activate)
        {
            await repository.UpdateState(id, activate);
            return RedirectToAction(nameof(Index));
        }







        /*

        // GET: Workshop/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshopEntity = await _context.WorkshopEntity
                .Include(w => w.ApplicationUserEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workshopEntity == null)
            {
                return NotFound();
            }

            return View(workshopEntity);
        }



        // GET: Workshop/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshopEntity = await _context.WorkshopEntity.FindAsync(id);
            if (workshopEntity == null)
            {
                return NotFound();
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", workshopEntity.EditorId);
            return View(workshopEntity);
        }

        // POST: Workshop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Active,Id,EditorId,DateCreated,DateModified")] WorkshopEntity workshopEntity)
        {
            if (id != workshopEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workshopEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkshopEntityExists(workshopEntity.Id))
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
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", workshopEntity.EditorId);
            return View(workshopEntity);
        }

        // GET: Workshop/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshopEntity = await _context.WorkshopEntity
                .Include(w => w.ApplicationUserEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workshopEntity == null)
            {
                return NotFound();
            }

            return View(workshopEntity);
        }

        // POST: Workshop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workshopEntity = await _context.WorkshopEntity.FindAsync(id);
            if (workshopEntity != null)
            {
                _context.WorkshopEntity.Remove(workshopEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkshopEntityExists(int id)
        {
            return _context.WorkshopEntity.Any(e => e.Id == id);
        }
        */
    }
}

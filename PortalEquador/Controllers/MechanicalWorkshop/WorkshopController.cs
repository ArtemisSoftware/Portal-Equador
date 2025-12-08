using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.MechanicalWorkshop.Workshop.Entities;
using PortalEquador.Domain.Accident.UseCases;
using PortalEquador.Domain.MechanicalWorkshop.Admin.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Workshop.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Workshop.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.MechanicalWorkshop
{
    public class WorkshopController(
        IWorkshopRepository repository,
        IWorkshopLaneRepository workshopLaneRepository
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

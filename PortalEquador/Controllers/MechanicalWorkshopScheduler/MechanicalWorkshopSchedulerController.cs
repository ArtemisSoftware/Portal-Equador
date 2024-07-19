using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using PortalEquador.Data;
using PortalEquador.Data.Scheduler.Entities;
using PortalEquador.Domain.GroupTypes.UseCases;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Scheduler.MechanicalWorkshop.ViewModels;
using PortalEquador.Preview;

namespace PortalEquador.Controllers.MechanicalWorkshopScheduler
{
    public class MechanicalWorkshopSchedulerController : Controller
    {
        private const string  DDD = "";

        private readonly ApplicationDbContext _context;

        public MechanicalWorkshopSchedulerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MechanicalWorkshopScheduler
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.MechanicalWorkshopSchedulerEntity.Include(m => m.InterventionTimeGroupItemEntity).Include(m => m.MechanicGroupItemEntity);
            //return View(await applicationDbContext.ToListAsync());

           
            return View(MechanicalWorkshopSchedulerPreview.GetIndex());
        }


        // GET: MechanicalWorkshopScheduler/Create
        public async Task<IActionResult> Create(string? date, int? scheduleId, int? mechanicId)
        {
            /*
            ViewData["InterventionTimeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            ViewData["MechanicId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            */
            if(mechanicId != null && scheduleId != null && date != null) {
                return View(MechanicalWorkshopSchedulerPreview.GetCreate((string)date, (int)mechanicId, (int)scheduleId));
            }
            else
            {
                return NotFound();
            }
        }


        // GET: MechanicalWorkshopScheduler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            /*
            if (id == null || _context.MechanicalWorkshopSchedulerEntity == null)
            {
                return NotFound();
            }

            var mechanicalWorkshopSchedulerEntity = await _context.MechanicalWorkshopSchedulerEntity.FindAsync(id);
            if (mechanicalWorkshopSchedulerEntity == null)
            {
                return NotFound();
            }
            ViewData["InterventionTimeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", mechanicalWorkshopSchedulerEntity.InterventionTimeId);
            ViewData["MechanicId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", mechanicalWorkshopSchedulerEntity.MechanicId);
            */
            var model = MechanicalWorkshopSchedulerPreview.GetEdit();
            model.FormatLicencePlate();
            return View(model);
        }



        // GET: MechanicalWorkshopScheduler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            /*
            if (id == null || _context.MechanicalWorkshopSchedulerEntity == null)
            {
                return NotFound();
            }

            var mechanicalWorkshopSchedulerEntity = await _context.MechanicalWorkshopSchedulerEntity
                .Include(m => m.InterventionTimeGroupItemEntity)
                .Include(m => m.MechanicGroupItemEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mechanicalWorkshopSchedulerEntity == null)
            {
                return NotFound();
            }
            */
            var model = MechanicalWorkshopSchedulerPreview.GetEdit();
            model.FormatLicencePlate();
            return View(model);
        }

        /*

// POST: MechanicalWorkshopScheduler/Create
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("InterventionTimeId,MechanicId,LicencePlate,ScheduleDate,Id,DateCreated,DateModified")] MechanicalWorkshopSchedulerEntity mechanicalWorkshopSchedulerEntity)
{
    if (ModelState.IsValid)
    {
        _context.Add(mechanicalWorkshopSchedulerEntity);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    ViewData["InterventionTimeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", mechanicalWorkshopSchedulerEntity.InterventionTimeId);
    ViewData["MechanicId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", mechanicalWorkshopSchedulerEntity.MechanicId);
    return View(mechanicalWorkshopSchedulerEntity);
}



// POST: MechanicalWorkshopScheduler/Edit/5
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("InterventionTimeId,MechanicId,LicencePlate,ScheduleDate,Id,DateCreated,DateModified")] MechanicalWorkshopSchedulerEntity mechanicalWorkshopSchedulerEntity)
{
    if (id != mechanicalWorkshopSchedulerEntity.Id)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(mechanicalWorkshopSchedulerEntity);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MechanicalWorkshopSchedulerEntityExists(mechanicalWorkshopSchedulerEntity.Id))
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
    ViewData["InterventionTimeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", mechanicalWorkshopSchedulerEntity.InterventionTimeId);
    ViewData["MechanicId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", mechanicalWorkshopSchedulerEntity.MechanicId);
    return View(mechanicalWorkshopSchedulerEntity);
}

// GET: MechanicalWorkshopScheduler/Delete/5
public async Task<IActionResult> Delete(int? id)
{
    if (id == null || _context.MechanicalWorkshopSchedulerEntity == null)
    {
        return NotFound();
    }

    var mechanicalWorkshopSchedulerEntity = await _context.MechanicalWorkshopSchedulerEntity
        .Include(m => m.InterventionTimeGroupItemEntity)
        .Include(m => m.MechanicGroupItemEntity)
        .FirstOrDefaultAsync(m => m.Id == id);
    if (mechanicalWorkshopSchedulerEntity == null)
    {
        return NotFound();
    }

    return View(mechanicalWorkshopSchedulerEntity);
}

// POST: MechanicalWorkshopScheduler/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    if (_context.MechanicalWorkshopSchedulerEntity == null)
    {
        return Problem("Entity set 'ApplicationDbContext.MechanicalWorkshopSchedulerEntity'  is null.");
    }
    var mechanicalWorkshopSchedulerEntity = await _context.MechanicalWorkshopSchedulerEntity.FindAsync(id);
    if (mechanicalWorkshopSchedulerEntity != null)
    {
        _context.MechanicalWorkshopSchedulerEntity.Remove(mechanicalWorkshopSchedulerEntity);
    }

    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}

private bool MechanicalWorkshopSchedulerEntityExists(int id)
{
  return (_context.MechanicalWorkshopSchedulerEntity?.Any(e => e.Id == id)).GetValueOrDefault();
}
*/
    }
}

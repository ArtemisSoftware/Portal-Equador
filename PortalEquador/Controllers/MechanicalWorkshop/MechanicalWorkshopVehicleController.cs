using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Constants;
using PortalEquador.Data;
using PortalEquador.Data.Scheduler.MechanicalWorkshop.Entities;
using PortalEquador.Domain.GroupTypes.UseCases;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Scheduler.MechanicalWorkshop.ViewModels.vehicle;
using PortalEquador.Domain.UseCases;

namespace PortalEquador.Controllers.MechanicalWorkshop
{
    public class MechanicalWorkshopVehicleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MechanicalWorkshopVehicleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MechanicalWorkshopVehicle
        public async Task<IActionResult> Index()
        {
            return View(Preview.MechanicalWorkshopVehiclePreview.GetIndex());
        }


        // GET: Groups/Create
        public IActionResult Create()
        {
            return View(Preview.MechanicalWorkshopVehiclePreview.GetEmpty());
        }

        // POST: Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MechanicalWorkshopVehicleViewModel @viewmodel)
        {
            /*
            if (await _groupExistsUseCase.Invoke(groupViewModel.Description))
            {
                ModelState.AddModelError(nameof(@viewmodel.Error), StringConstants.Error.EXISTING_GROUP_DESCRIPTION);
            }
            else
            {
                if (ModelState.IsValid)
                {
                   // await _saveGroupUseCase.Invoke(groupViewModel, OperationType.Create);
                    return RedirectToAction(nameof(Index));
                }
            }
            */
            return View(@viewmodel);
        }


        // GET: MechanicalWorkshopVehicle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //--var model = await _getGroupUseCase.Invoke(id);
            var model = Preview.MechanicalWorkshopVehiclePreview.GetItem();

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
        }

        // POST: MechanicalWorkshopVehicle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MechanicalWorkshopVehicleViewModel @viewmodel)
        {
            if (ModelState.IsValid)
            {
                //--await _saveGroupUseCase.Invoke(groupViewModel, OperationType.Update);
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }


        // GET: MechanicalWorkshopVehicle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //--var model = await _getGroupUseCase.Invoke(id);
            var model = Preview.MechanicalWorkshopVehiclePreview.GetItem();

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // ViewData["groupId"] = id;
            //ViewData["groupName"] = groupName;

            //--await _updateGroupItemStateUseCase.Invoke(id, false);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActivateVehicle(int id)
        {
            //ViewData["groupId"] = groupId;
            //ViewData["groupName"] = groupName;

            //await _updateGroupItemStateUseCase.Invoke(id, true);
            return RedirectToAction(nameof(Index));
        }


        /*






// GET: MechanicalWorkshopVehicle/Delete/5
public async Task<IActionResult> Delete(int? id)
{
    if (id == null || _context.MechanicalWorkshopVehicleEntity == null)
    {
        return NotFound();
    }

    var mechanicalWorkshopVehicleEntity = await _context.MechanicalWorkshopVehicleEntity
        .FirstOrDefaultAsync(m => m.Id == id);
    if (mechanicalWorkshopVehicleEntity == null)
    {
        return NotFound();
    }

    return View(mechanicalWorkshopVehicleEntity);
}

// POST: MechanicalWorkshopVehicle/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    if (_context.MechanicalWorkshopVehicleEntity == null)
    {
        return Problem("Entity set 'ApplicationDbContext.MechanicalWorkshopVehicleEntity'  is null.");
    }
    var mechanicalWorkshopVehicleEntity = await _context.MechanicalWorkshopVehicleEntity.FindAsync(id);
    if (mechanicalWorkshopVehicleEntity != null)
    {
        _context.MechanicalWorkshopVehicleEntity.Remove(mechanicalWorkshopVehicleEntity);
    }

    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}

private bool MechanicalWorkshopVehicleEntityExists(int id)
{
  return (_context.MechanicalWorkshopVehicleEntity?.Any(e => e.Id == id)).GetValueOrDefault();
}
*/
    }
}

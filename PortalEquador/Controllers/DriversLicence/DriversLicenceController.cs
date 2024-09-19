using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.DriversLicence.Entity;
using PortalEquador.Domain.DriversLicence.Repository;
using PortalEquador.Domain.Languages.Repository;

namespace PortalEquador.Controllers.DriversLicence
{
    public class DriversLicenceController(IDriversLicenceRepository repository) : Controller
    {
        /*
        // GET: DriversLicence
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DriversLicenceEntity.Include(d => d.ApplicationUserEntity).Include(d => d.LicenceTypeGroupItemEntity).Include(d => d.PersonalInformationEntity);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DriversLicence/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driversLicenceEntity = await _context.DriversLicenceEntity
                .Include(d => d.ApplicationUserEntity)
                .Include(d => d.LicenceTypeGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driversLicenceEntity == null)
            {
                return NotFound();
            }

            return View(driversLicenceEntity);
        }

        // GET: DriversLicence/Create
        public IActionResult Create()
        {
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["LicenceTypeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id");
            return View();
        }

        // POST: DriversLicence/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalInformationId,LicenceTypeId,ExpirationDate,ProvisionalRenewalNumber,ProvisionalExpirationDate,Id,EditorId,DateCreated,DateModified")] DriversLicenceEntity driversLicenceEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driversLicenceEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", driversLicenceEntity.EditorId);
            ViewData["LicenceTypeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", driversLicenceEntity.LicenceTypeId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", driversLicenceEntity.PersonalInformationId);
            return View(driversLicenceEntity);
        }

        // GET: DriversLicence/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driversLicenceEntity = await _context.DriversLicenceEntity.FindAsync(id);
            if (driversLicenceEntity == null)
            {
                return NotFound();
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", driversLicenceEntity.EditorId);
            ViewData["LicenceTypeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", driversLicenceEntity.LicenceTypeId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", driversLicenceEntity.PersonalInformationId);
            return View(driversLicenceEntity);
        }

        // POST: DriversLicence/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonalInformationId,LicenceTypeId,ExpirationDate,ProvisionalRenewalNumber,ProvisionalExpirationDate,Id,EditorId,DateCreated,DateModified")] DriversLicenceEntity driversLicenceEntity)
        {
            if (id != driversLicenceEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driversLicenceEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriversLicenceEntityExists(driversLicenceEntity.Id))
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
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", driversLicenceEntity.EditorId);
            ViewData["LicenceTypeId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", driversLicenceEntity.LicenceTypeId);
            ViewData["PersonalInformationId"] = new SelectList(_context.PersonalInformationEntity, "Id", "Id", driversLicenceEntity.PersonalInformationId);
            return View(driversLicenceEntity);
        }

        // GET: DriversLicence/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driversLicenceEntity = await _context.DriversLicenceEntity
                .Include(d => d.ApplicationUserEntity)
                .Include(d => d.LicenceTypeGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driversLicenceEntity == null)
            {
                return NotFound();
            }

            return View(driversLicenceEntity);
        }

        // POST: DriversLicence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var driversLicenceEntity = await _context.DriversLicenceEntity.FindAsync(id);
            if (driversLicenceEntity != null)
            {
                _context.DriversLicenceEntity.Remove(driversLicenceEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriversLicenceEntityExists(int id)
        {
            return _context.DriversLicenceEntity.Any(e => e.Id == id);
        }
        */
    }
}

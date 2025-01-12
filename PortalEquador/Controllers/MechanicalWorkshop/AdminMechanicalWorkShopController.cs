using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.MechanicalWorkshop.Admin.Entity;
using PortalEquador.Domain.MechanicalWorkshop.Admin.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Admin.ViewModels;

namespace PortalEquador.Controllers.MechanicalWorkshop
{
    public class AdminMechanicalWorkShopController(
        IAdminMechanicalWorkShopRepository repository
        ) : Controller
    {

        // GET: AdminMechanicalWorkShop
        public async Task<IActionResult> Index()
        {
            var model = await repository.GetAdmins();
            return View(model);
        }
/*
        // GET: AdminMechanicalWorkShop/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminMechanicalWorkShopContractEntity = await _context.AdminMechanicalWorkShopContractEntity
                .Include(a => a.ApplicationUserEntity)
                .Include(a => a.ContractGroupItemEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminMechanicalWorkShopContractEntity == null)
            {
                return NotFound();
            }

            return View(adminMechanicalWorkShopContractEntity);
        }

        // GET: AdminMechanicalWorkShop/Create
        public IActionResult Create()
        {
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["ContractId"] = new SelectList(_context.GroupItemEntity, "Id", "Id");
            return View();
        }

        // POST: AdminMechanicalWorkShop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContractId,EditorId,DateCreated,DateModified")] AdminMechanicalWorkShopContractEntity adminMechanicalWorkShopContractEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminMechanicalWorkShopContractEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", adminMechanicalWorkShopContractEntity.EditorId);
            ViewData["ContractId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", adminMechanicalWorkShopContractEntity.ContractId);
            return View(adminMechanicalWorkShopContractEntity);
        }

        // GET: AdminMechanicalWorkShop/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminMechanicalWorkShopContractEntity = await _context.AdminMechanicalWorkShopContractEntity.FindAsync(id);
            if (adminMechanicalWorkShopContractEntity == null)
            {
                return NotFound();
            }
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", adminMechanicalWorkShopContractEntity.EditorId);
            ViewData["ContractId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", adminMechanicalWorkShopContractEntity.ContractId);
            return View(adminMechanicalWorkShopContractEntity);
        }

        // POST: AdminMechanicalWorkShop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContractId,EditorId,DateCreated,DateModified")] AdminMechanicalWorkShopContractEntity adminMechanicalWorkShopContractEntity)
        {
            if (id != adminMechanicalWorkShopContractEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminMechanicalWorkShopContractEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminMechanicalWorkShopContractEntityExists(adminMechanicalWorkShopContractEntity.Id))
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
            ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", adminMechanicalWorkShopContractEntity.EditorId);
            ViewData["ContractId"] = new SelectList(_context.GroupItemEntity, "Id", "Id", adminMechanicalWorkShopContractEntity.ContractId);
            return View(adminMechanicalWorkShopContractEntity);
        }

        // GET: AdminMechanicalWorkShop/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminMechanicalWorkShopContractEntity = await _context.AdminMechanicalWorkShopContractEntity
                .Include(a => a.ApplicationUserEntity)
                .Include(a => a.ContractGroupItemEntity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminMechanicalWorkShopContractEntity == null)
            {
                return NotFound();
            }

            return View(adminMechanicalWorkShopContractEntity);
        }

        // POST: AdminMechanicalWorkShop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminMechanicalWorkShopContractEntity = await _context.AdminMechanicalWorkShopContractEntity.FindAsync(id);
            if (adminMechanicalWorkShopContractEntity != null)
            {
                _context.AdminMechanicalWorkShopContractEntity.Remove(adminMechanicalWorkShopContractEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminMechanicalWorkShopContractEntityExists(int id)
        {
            return _context.AdminMechanicalWorkShopContractEntity.Any(e => e.Id == id);
        }
*/
    }
}

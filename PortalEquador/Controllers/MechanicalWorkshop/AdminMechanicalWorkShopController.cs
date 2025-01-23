using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.MechanicalWorkshop.Admin.Entity;
using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Admin.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Admin.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.Constants;

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

        // GET: AdminMechanicalWorkShop/Create
        public async Task<IActionResult> Create()
        {
            var model = await repository.GetCreateModel();
            return View(model);
        }

        // POST: AdminMechanicalWorkShop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminMechanicalWorkshopCreateViewModel @viewModel)
        {
            viewModel = await RecoverModel(viewModel);
            if (@viewModel.HasSelectedContracts() == false)
            {
                ModelState.AddModelError(nameof(viewModel.Error), StringConstants.Error.MANDATORY_CONTRACT_SELECTION);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await repository.Save(viewModel);
                    return RedirectToAction(nameof(Index));
                }
            }
            
            return View(viewModel);
        }

        // GET: AdminMechanicalWorkShop/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            ViewData["id"] = id;
            if (id == null)
            {
                return NotFound();
            }

            var model = await repository.GetAdmin(id);
            return View(model);
        }

        // POST: AdminMechanicalWorkShop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdminMechanicalWorkshopViewModel @viewModel)
        {
            viewModel = await repository.RecoverModel(viewModel);

            if (ModelState.IsValid)
            {

                if (@viewModel.HasSelectedContracts() == false)
                {
                    ModelState.AddModelError(nameof(@viewModel.Error), StringConstants.Error.MANDATORY_CONTRACT_SELECTION);
                    return View(@viewModel);
                }

                await repository.Save(viewModel);
                return RedirectToAction(nameof(Index));
            }
            ViewData["id"] = viewModel.user.UserId;
            return View(viewModel);
        }


        [HttpPost, ActionName("DeleteContracts")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteContracts(string? identifier)
        {
            if (identifier == null)
            {
                return NotFound();
            }

            await repository.DeleteContracts(identifier);
            return RedirectToAction(nameof(Index));
        }


        private async Task<AdminMechanicalWorkshopCreateViewModel> RecoverModel(AdminMechanicalWorkshopCreateViewModel model)
        {
            return await repository.GetCreateModel(model);
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

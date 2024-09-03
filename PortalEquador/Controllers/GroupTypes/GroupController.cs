using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.GroupTypes
{
    [Authorize(Roles = Roles.Administrator + "," + Roles.Supervisor)]
    public class GroupController(GroupRepository groupRepository) : Controller
    {
        
        // GET: Group
        public async Task<IActionResult> Index()
        {
            var models = await groupRepository.GetAllGroups() ;
            return View(models);
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GroupViewModel @viewModel)
        {
            if (await groupRepository.GroupExists(@viewModel.Description))
            {
                ModelState.AddModelError(nameof(@viewModel.Error), StringConstants.Error.EXISTING_GROUP_DESCRIPTION);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await groupRepository.Save(@viewModel);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(@viewModel);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var model = await groupRepository.GetGroup(id);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GroupViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                await groupRepository.Save(viewmodel);
               return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }


        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var model = await groupRepository.GetGroup(id);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
        }
    }
}

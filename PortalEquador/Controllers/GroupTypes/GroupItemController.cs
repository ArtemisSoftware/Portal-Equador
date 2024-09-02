using System;
using System.Collections.Generic;
using System.Linq;
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
    [Authorize(Roles = Roles.Administrator)]
    public class GroupItemController(GroupItemRepository groupItemRepository) : Controller
    {

        // GET: GroupItems
        public async Task<IActionResult> Index(int? groupId, string? groupName)
        {
            ViewData["groupId"] = groupId;
            ViewData["groupName"] = groupName;

            if (groupId == null)
            {
                return NotFound();
            }

            var model = await groupItemRepository.GetAll((int)groupId);
            return View(model);

        }

        // GET: GroupItems/Create
        public IActionResult Create(int? groupId, string? groupName)
        {
            ViewData["groupId"] = groupId;
            ViewData["groupName"] = groupName;
            if (groupId == null) return NotFound();
            return View();
        }
        
        // POST: GroupItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? groupId, string? groupName, GroupItemViewModel viewModel)
        {

            ViewData["groupId"] = groupId;
            ViewData["groupName"] = groupName;
            if (await groupItemRepository.GroupItemExists(viewModel.GroupId, viewModel.Description))
            {
                ModelState.AddModelError(nameof(viewModel.Error), StringConstants.Error.EXISTING_GROUP_DESCRIPTION);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await groupItemRepository.Save(viewModel);
                    return RedirectToAction(nameof(Index), new { groupId = groupId, groupName = groupName });
                }
            }
            return View(viewModel);
        }


        // GET: GroupItems/Details/5
        public async Task<IActionResult> Details(int? id, int? groupId, string? groupName)
        {
            ViewData["groupId"] = groupId;
            ViewData["groupName"] = groupName;
            var model = await groupItemRepository.GetGroupItem((int)id);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
        }

        // GET: GroupItems/Edit/5
        public async Task<IActionResult> Edit(int? id, int? groupId, string? groupName)
        {
            ViewData["groupId"] = groupId;
            ViewData["groupName"] = groupName;

            var model = await groupItemRepository.GetGroupItem((int)id);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
        }

        // POST: GroupItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? groupId, string? groupName, GroupItemViewModel model)
        {
            ViewData["groupId"] = groupId;
            ViewData["groupName"] = groupName;

            if (ModelState.IsValid)
            {
                await groupItemRepository.Save(model);
                return RedirectToAction(nameof(Index), new { groupId = groupId, groupName = groupName });
            }
            return View(model);
        }
        
        [HttpPost, ActionName("DeactivateItem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateItem(int? groupId, string? groupName, int id)
        {
            ViewData["groupId"] = groupId;
            ViewData["groupName"] = groupName;

            await groupItemRepository.UpdateState(id, false);
            return RedirectToAction(nameof(Index), new { groupId = groupId, groupName = groupName });
        }


        [HttpPost, ActionName("ActivateItem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActivateItem(int? groupId, string? groupName, int id)
        {
            ViewData["groupId"] = groupId;
            ViewData["groupName"] = groupName;

            await groupItemRepository.UpdateState(id, true);
            return RedirectToAction(nameof(Index), new { groupId = groupId, groupName = groupName });
        }

    }
}

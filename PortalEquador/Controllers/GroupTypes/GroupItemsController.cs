using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Constants;
using PortalEquador.Contracts;
using PortalEquador.Data;
using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Domain.GroupTypes.UseCases;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.UseCases;
using PortalEquador.Repositories;

namespace PortalEquador.Controllers.GroupTypes
{
    public class GroupItemsController : Controller
    {
        private readonly GetAllGroupItemsUseCase _getAllGroupItemsUseCase;
        private readonly SaveGroupItemUseCase _saveGroupItemUseCase;
        private readonly GetGroupItemUseCase _getGroupItemUseCase;
        private readonly GroupItemExistsUseCase _groupItemExistsUseCase;
        private readonly UpdateGroupItemStateUseCase _updateGroupItemStateUseCase;

        public GroupItemsController(
            GetAllGroupItemsUseCase getAllGroupItemsUseCase, 
            SaveGroupItemUseCase saveGroupItemUseCase,
            GetGroupItemUseCase getGroupItemUseCase,
            GroupItemExistsUseCase groupItemExistsUseCase,
            UpdateGroupItemStateUseCase updateGroupItemStateUseCase)
        {
            _getAllGroupItemsUseCase = getAllGroupItemsUseCase;
            _saveGroupItemUseCase = saveGroupItemUseCase;
            _getGroupItemUseCase = getGroupItemUseCase;
            _groupItemExistsUseCase = groupItemExistsUseCase;
            _updateGroupItemStateUseCase = updateGroupItemStateUseCase;
        }

        // GET: GroupItems
        public async Task<IActionResult> Index(int? groupId, string? groupName)
        {
            ViewData["groupId"] = groupId;
            ViewData["groupName"] = groupName;

            if (groupId == null)
            {
                return NotFound();
            }

            var model = await _getAllGroupItemsUseCase.Invoke((int)groupId);
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
            if (await _groupItemExistsUseCase.Invoke(viewModel))
            {
                ModelState.AddModelError(nameof(viewModel.Error), StringConstants.Error.EXISTING_GROUP_DESCRIPTION);
            }
            else
            {
                
                if (ModelState.IsValid)
                {
                    await _saveGroupItemUseCase.Invoke(viewModel, OperationType.Create);
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
            var model = await _getGroupItemUseCase.Invoke((int)id);

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

            var model = await _getGroupItemUseCase.Invoke((int) id);

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
                await _saveGroupItemUseCase.Invoke(model, OperationType.Update);
                return RedirectToAction(nameof(Index), new { groupId = groupId, groupName = groupName });
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? groupId, string? groupName, int id)
        {
            ViewData["groupId"] = groupId;
            ViewData["groupName"] = groupName;

            await _updateGroupItemStateUseCase.Invoke(id, false);
            return RedirectToAction(nameof(Index), new { groupId = groupId, groupName = groupName });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AllocateLeave(int? groupId, string? groupName, int id)
        {
            ViewData["groupId"] = groupId;
            ViewData["groupName"] = groupName;

            await _updateGroupItemStateUseCase.Invoke(id, true);
            return RedirectToAction(nameof(Index), new { groupId = groupId, groupName = groupName });
        }


        //--------------

        // GET: GroupItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return NotFound();
            /*
            if (id == null || _context.GroupItems == null)
            {
                return NotFound();
            }

            var groupItem = await _context.GroupItems
                .Include(g => g.Group)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupItem == null)
            {
                return NotFound();
            }

            return View(groupItem);
            */
        }



        private bool GroupItemExists(int id)
        {
          return /*(_context.GroupItems?.Any(e => e.Id == id)).GetValueOrDefault()*/ true;
        }
    }
}

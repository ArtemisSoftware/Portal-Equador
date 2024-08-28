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

            var model = await groupItemRepository.GetGroupItem((int)groupId);
            return View(model);

        }
        /*

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
     /*   }



        private bool GroupItemExists(int id)
        {
            return*/ /*(_context.GroupItems?.Any(e => e.Id == id)).GetValueOrDefault()*/ /*true;
        }

        */










        /*
                // GET: GroupItem
                public async Task<IActionResult> Index()
                {
                    var applicationDbContext = _context.GroupItemEntity.Include(g => g.ApplicationUserEntity).Include(g => g.GroupEntity);
                    return View(await applicationDbContext.ToListAsync());
                }

                // GET: GroupItem/Details/5
                public async Task<IActionResult> Details(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var groupItemEntity = await _context.GroupItemEntity
                        .Include(g => g.ApplicationUserEntity)
                        .Include(g => g.GroupEntity)
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (groupItemEntity == null)
                    {
                        return NotFound();
                    }

                    return View(groupItemEntity);
                }

                // GET: GroupItem/Create
                public IActionResult Create()
                {
                    ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id");
                    ViewData["GroupEntityId"] = new SelectList(_context.GroupEntity, "Id", "Id");
                    return View();
                }

                // POST: GroupItem/Create
                // To protect from overposting attacks, enable the specific properties you want to bind to.
                // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Create([Bind("Description,Observation,Active,GroupEntityId,Id,EditorId,DateCreated,DateModified")] GroupItemEntity groupItemEntity)
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(groupItemEntity);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", groupItemEntity.EditorId);
                    ViewData["GroupEntityId"] = new SelectList(_context.GroupEntity, "Id", "Id", groupItemEntity.GroupEntityId);
                    return View(groupItemEntity);
                }

                // GET: GroupItem/Edit/5
                public async Task<IActionResult> Edit(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var groupItemEntity = await _context.GroupItemEntity.FindAsync(id);
                    if (groupItemEntity == null)
                    {
                        return NotFound();
                    }
                    ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", groupItemEntity.EditorId);
                    ViewData["GroupEntityId"] = new SelectList(_context.GroupEntity, "Id", "Id", groupItemEntity.GroupEntityId);
                    return View(groupItemEntity);
                }

                // POST: GroupItem/Edit/5
                // To protect from overposting attacks, enable the specific properties you want to bind to.
                // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Edit(int id, [Bind("Description,Observation,Active,GroupEntityId,Id,EditorId,DateCreated,DateModified")] GroupItemEntity groupItemEntity)
                {
                    if (id != groupItemEntity.Id)
                    {
                        return NotFound();
                    }

                    if (ModelState.IsValid)
                    {
                        try
                        {
                            _context.Update(groupItemEntity);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!GroupItemEntityExists(groupItemEntity.Id))
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
                    ViewData["EditorId"] = new SelectList(_context.Users, "Id", "Id", groupItemEntity.EditorId);
                    ViewData["GroupEntityId"] = new SelectList(_context.GroupEntity, "Id", "Id", groupItemEntity.GroupEntityId);
                    return View(groupItemEntity);
                }

                // GET: GroupItem/Delete/5
                public async Task<IActionResult> Delete(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var groupItemEntity = await _context.GroupItemEntity
                        .Include(g => g.ApplicationUserEntity)
                        .Include(g => g.GroupEntity)
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (groupItemEntity == null)
                    {
                        return NotFound();
                    }

                    return View(groupItemEntity);
                }

                // POST: GroupItem/Delete/5
                [HttpPost, ActionName("Delete")]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> DeleteConfirmed(int id)
                {
                    var groupItemEntity = await _context.GroupItemEntity.FindAsync(id);
                    if (groupItemEntity != null)
                    {
                        _context.GroupItemEntity.Remove(groupItemEntity);
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                private bool GroupItemEntityExists(int id)
                {
                    return _context.GroupItemEntity.Any(e => e.Id == id);
                }
        */
    }
}

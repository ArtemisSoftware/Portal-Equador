using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Contracts;
using PortalEquador.Data;
using PortalEquador.Data.GroupTypes;
using PortalEquador.Models.GroupTypes;
using PortalEquador.Repositories;

namespace PortalEquador.Controllers.GroupTypes
{
    public class GroupItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IGroupItemRepository groupItemRepository;
        private readonly IMapper mapper;

        public GroupItemsController(ApplicationDbContext context, IGroupItemRepository groupItemRepository, IMapper mapper)
        {
            _context = context;
            this.groupItemRepository = groupItemRepository;
            this.mapper = mapper;
        }

        // GET: GroupItems
        public async Task<IActionResult> Index(int? GroupId)
        {
            if (GroupId == null)
            {
                return NotFound();
            }

            var group = mapper.Map<List<GroupItemViewModel>>(await groupItemRepository.GetAllAsync(GroupId.Value));
            ViewData["GroupId"] = GroupId;
            return View(group);
        }

        // GET: GroupItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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
        }

        // GET: GroupItems/Create
        public IActionResult Create(int? GroupId)
        {
            if (GroupId == null) return NotFound();
            ViewData["GroupId"] = GroupId;
            //ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id");
            return View();
        }

        // POST: GroupItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id, GroupItemViewModel groupItemViewModel)
        {

            if (ModelState.IsValid)
            {
                var groupItem = mapper.Map<GroupItem>(groupItemViewModel);
                var itemExists = await groupItemRepository.GroupItemExists(groupItemViewModel.GroupId, groupItemViewModel.Description);

                if (itemExists)
                {
                    ModelState.AddModelError(nameof(groupItemViewModel.Occurred), "A descrição já existe para o grupo especificado");
                }
                else
                {
                    await groupItemRepository.AddAsync(groupItem);
                    return RedirectToAction(nameof(Index), new { id = groupItem.GroupId });
                }
            }
            
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id", groupItemViewModel.GroupId);
            return View(@groupItemViewModel);
        }

        // GET: GroupItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GroupItems == null)
            {
                return NotFound();
            }

            var groupItem = await _context.GroupItems.FindAsync(id);
            if (groupItem == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id", groupItem.GroupId);
            return View(groupItem);
        }

        // POST: GroupItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,Observation,GroupId,Id,DateCreated,DateModified")] GroupItem groupItem)
        {
            if (id != groupItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupItemExists(groupItem.Id))
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
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id", groupItem.GroupId);
            return View(groupItem);
        }

        // GET: GroupItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
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
        }

        // POST: GroupItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GroupItems == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GroupItems'  is null.");
            }
            var groupItem = await _context.GroupItems.FindAsync(id);
            if (groupItem != null)
            {
                _context.GroupItems.Remove(groupItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupItemExists(int id)
        {
          return (_context.GroupItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

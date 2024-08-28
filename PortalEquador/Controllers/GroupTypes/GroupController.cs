using System;
using System.Collections.Generic;
using System.Data;
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

namespace PortalEquador.Controllers.GroupTypes
{
    [Authorize(Roles = Roles.Administrator)]
    public class GroupController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly GroupRepository _groupRepository;

        public GroupController(GroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        // GET: Group
        public async Task<IActionResult> Index()
        {
            var models = await _groupRepository.GetAllGroups() ;
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
            if (await _groupRepository.GroupExists(@viewModel.Description))
            {
                //ModelState.AddModelError(nameof(@viewModel.Error), StringConstants.Error.EXISTING_GROUP_DESCRIPTION);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await _groupRepository.Save(@viewModel/*, OperationType.Create*/);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(@viewModel);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var model = await _groupRepository.GetAsync(id);

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
                await _groupRepository.Save(viewmodel/*, OperationType.Create*/);
               return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }


        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var model = await _groupRepository.GetAsync(id);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
        }




        /*

        // GET: Group/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupEntity = await _context.GroupEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupEntity == null)
            {
                return NotFound();
            }

            return View(groupEntity);
        }

        // GET: Group/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Group/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Observation,Id,EditorId,DateCreated,DateModified")] GroupEntity groupEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupEntity);
        }

        // GET: Group/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupEntity = await _context.GroupEntity.FindAsync(id);
            if (groupEntity == null)
            {
                return NotFound();
            }
            return View(groupEntity);
        }

        // POST: Group/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,Observation,Id,EditorId,DateCreated,DateModified")] GroupEntity groupEntity)
        {
            if (id != groupEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupEntityExists(groupEntity.Id))
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
            return View(groupEntity);
        }

        // GET: Group/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupEntity = await _context.GroupEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupEntity == null)
            {
                return NotFound();
            }

            return View(groupEntity);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupEntity = await _context.GroupEntity.FindAsync(id);
            if (groupEntity != null)
            {
                _context.GroupEntity.Remove(groupEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupEntityExists(int id)
        {
            return _context.GroupEntity.Any(e => e.Id == id);
        }
        */


    }
}

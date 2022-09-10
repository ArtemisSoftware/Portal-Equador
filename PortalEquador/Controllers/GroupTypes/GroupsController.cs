using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Contracts;
using PortalEquador.Data;
using PortalEquador.Data.GroupTypes;
using PortalEquador.Models.GroupTypes;

namespace PortalEquador.Controllers.GroupTypes
{
    [Authorize(Roles ="Administrator")]
    public class GroupsController : Controller
    {
        private readonly IGroupRepository groupRepository;
        private readonly IMapper mapper;

        public GroupsController(IGroupRepository groupRepository, IMapper mapper)
        {
            this.groupRepository = groupRepository;
            this.mapper = mapper;
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {
            var group = mapper.Map<List<GroupsViewModel>>(await groupRepository.GetAllAsync());

            return View(group);
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var @group = await groupRepository.GetAsync(id);
            if (@group == null)
            {
                return NotFound();
            }

            var groupsViewModel = mapper.Map<GroupsViewModel>(@group);
            return View(groupsViewModel);
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
        public async Task<IActionResult> Create(GroupsViewModel @groupViewModel)
        {
            if (ModelState.IsValid)
            {
                var group = mapper.Map<Group>(@groupViewModel);
                await groupRepository.AddAsync(group);
                return RedirectToAction(nameof(Index));
            }
            return View(@groupViewModel);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var @group = await groupRepository.GetAsync(id);
            if (@group == null)
            {
                return NotFound();
            }

            var groupsViewModel = mapper.Map<GroupsViewModel>(@group);
            return View(groupsViewModel);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GroupsViewModel @groupViewModel)
        {
            if (id != @groupViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var group = mapper.Map<Group>(@groupViewModel);
                    
                    await groupRepository.UpdateAsync(group);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await groupRepository.Exists(@groupViewModel.Id))
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
            return View(@groupViewModel);
        }



        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await groupRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

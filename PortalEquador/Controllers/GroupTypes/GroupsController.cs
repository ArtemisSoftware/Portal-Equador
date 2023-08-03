using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalEquador.Constants;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.UseCases;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.UseCases;

namespace PortalEquador.Controllers.GroupTypes
{
    [Authorize(Roles = Roles.Administrator)]
    public class GroupsController : Controller
    {
        private readonly GetAllGroupsUseCase _getAllGroupsUseCase;
        private readonly SaveGroupUseCase _saveGroupUseCase;
        private readonly GetGroupUseCase _getGroupUseCase;

        public GroupsController(
            GetAllGroupsUseCase getAllGroupsUseCase,
            SaveGroupUseCase saveGroupUseCase,
            GetGroupUseCase getGroupUseCase)
        {
            _getAllGroupsUseCase = getAllGroupsUseCase;
            _saveGroupUseCase = saveGroupUseCase;
            _getGroupUseCase = getGroupUseCase;
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {
            var models = await _getAllGroupsUseCase.Invoke();
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
        public async Task<IActionResult> Create(GroupViewModel @groupViewModel)
        {
            if (ModelState.IsValid)
            {
                await _saveGroupUseCase.Invoke(groupViewModel, OperationType.Create);
                return RedirectToAction(nameof(Index));
            }
            return View(@groupViewModel);
        }


        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var model = await _getGroupUseCase.Invoke(id);

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
        public async Task<IActionResult> Edit(GroupViewModel groupViewModel)
        {
            if (ModelState.IsValid)
            {
                await _saveGroupUseCase.Invoke(groupViewModel, OperationType.Update);
                return RedirectToAction(nameof(Index));
            }
            return View(@groupViewModel);
        }


        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var model = await _getGroupUseCase.Invoke(id);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShowGroupItems(int id, GroupViewModel @groupViewModel)
        {
            return RedirectToAction(nameof(Index));
        }

        //--------------------------------








        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*
            await groupRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
            */
            return NotFound();
        }


    }
}

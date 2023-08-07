using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalEquador.Constants;
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
        private readonly GroupExistsUseCase _groupExistsUseCase;

        public GroupsController(
            GetAllGroupsUseCase getAllGroupsUseCase,
            SaveGroupUseCase saveGroupUseCase,
            GetGroupUseCase getGroupUseCase,
            GroupExistsUseCase groupExistsUseCase)
        {
            _getAllGroupsUseCase = getAllGroupsUseCase;
            _saveGroupUseCase = saveGroupUseCase;
            _getGroupUseCase = getGroupUseCase;
            _groupExistsUseCase = groupExistsUseCase;
            _groupExistsUseCase = groupExistsUseCase;
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
            if (await _groupExistsUseCase.Invoke(groupViewModel.Description))
            {
                ModelState.AddModelError(nameof(@groupViewModel.Error), StringConstants.Error.EXISTING_GROUP_DESCRIPTION);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await _saveGroupUseCase.Invoke(groupViewModel, OperationType.Create);
                    return RedirectToAction(nameof(Index));
                }
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

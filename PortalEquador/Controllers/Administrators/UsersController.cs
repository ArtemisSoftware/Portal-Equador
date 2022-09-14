using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortalEquador.Constants;
using PortalEquador.Data;
using PortalEquador.Models.Users;

namespace PortalEquador.Controllers.Administrators
{
    public class UsersController : Controller
    {

        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        //private readonly ILeaveAllocationRepository leaveAllocationRepository;
        //private readonly ILeaveTypeRepository leaveTypeRepository;

        public UsersController(
            UserManager<User> userManager,
            IMapper mapper
            //ILeaveAllocationRepository leaveAllocationRepository,
            //ILeaveTypeRepository leaveTypeRepository
            )
        {
            this.userManager = userManager;
            this.mapper = mapper;
            //this.leaveAllocationRepository = leaveAllocationRepository;
            //this.leaveTypeRepository = leaveTypeRepository;
        }



        // GET: UsersController
        public async Task<IActionResult> Index()
        {
            var users = await userManager.GetUsersInRoleAsync(Roles.User);
            var model = mapper.Map<List<UserListViewModel>>(users);
            return View(model);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

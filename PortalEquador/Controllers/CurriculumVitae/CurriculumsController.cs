using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortalEquador.Data;
using PortalEquador.Models.CurriculumVitae;

namespace PortalEquador.Controllers.CurriculumVitae
{
    public class CurriculumsController : Controller
    {

        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        //private readonly ILeaveAllocationRepository leaveAllocationRepository;
        //private readonly ILeaveTypeRepository leaveTypeRepository;

        public CurriculumsController(
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




        // GET: CurriculumsController
        public ActionResult Index()
        {
            var list = new List<CurriculumListViewModel>();
            return View(list);
        }

        // GET: CurriculumsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CurriculumsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurriculumsController/Create
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

        // GET: CurriculumsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CurriculumsController/Edit/5
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

        // GET: CurriculumsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CurriculumsController/Delete/5
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

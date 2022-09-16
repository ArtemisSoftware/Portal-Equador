using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Contracts;
using PortalEquador.Data;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Data.GroupTypes;
using PortalEquador.Models.CurriculumVitae;
using PortalEquador.Models.GroupTypes;
using PortalEquador.Repositories;

namespace PortalEquador.Controllers.CurriculumVitae
{
    public class CurriculumsController : Controller
    {

        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IPersonalInformationRepository personalInformationRepository;
        //private readonly ILeaveTypeRepository leaveTypeRepository;

        public CurriculumsController(
            UserManager<User> userManager,
            IMapper mapper,
            IPersonalInformationRepository personalInformationRepository
            //ILeaveAllocationRepository leaveAllocationRepository,
            //ILeaveTypeRepository leaveTypeRepository
            )
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.personalInformationRepository = personalInformationRepository;
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
        public async Task<IActionResult> Create(PersonalInformationViewModel personalInformationViewModel)
        {
            if (ModelState.IsValid)
            {
                var personalInformation = mapper.Map<PersonalInformation>(personalInformationViewModel);
                var itemExists = await personalInformationRepository.PersonalInformationExists(personalInformationViewModel.IdentityCard);

                if (itemExists)
                {
                    ModelState.AddModelError(nameof(personalInformationViewModel.Occurred), "O bilhete de identidade já se encontra registado");
                }
                else
                {
                    //await personalInformationRepository.AddAsync(personalInformation);
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(@personalInformationViewModel);

            /*
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            */
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

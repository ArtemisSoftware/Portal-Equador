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
using PortalEquador.Data.PersonalInformation.Entities;
using PortalEquador.Models.CurriculumVitae;
using PortalEquador.Repositories;

namespace PortalEquador.Controllers.CurriculumVitae
{
    public class CurriculumsController : Controller
    {

        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IPersonalInformationRepository personalInformationRepository;
        private readonly ICurriculumRepository curriculumRepository;


        //private readonly GetCurriculumDashboardUseCase _getCurriculumDashboardUseCase;


        public CurriculumsController(
            UserManager<User> userManager,
            IMapper mapper,
            IPersonalInformationRepository personalInformationRepository,
            ICurriculumRepository curriculumRepository
            //GetCurriculumDashboardUseCase getCurriculumDashboardUseCase
            )
        {
            //_getCurriculumDashboardUseCase = getCurriculumDashboardUseCase;

            this.userManager = userManager;
            this.mapper = mapper;
            this.personalInformationRepository = personalInformationRepository;
            this.curriculumRepository = curriculumRepository;
        }




        // GET: CurriculumsController
        public async Task<IActionResult> Index()
        {
            var result = await personalInformationRepository.GetAllAsync();
            var list = mapper.Map<List<CurriculumListViewModel>>(result);
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
                var personalInformation = mapper.Map<PersonalInformationEntity>(personalInformationViewModel);
                var itemExists = await personalInformationRepository.PersonalInformationExists(personalInformationViewModel.IdentityCard);

                if (itemExists)
                {
                    ModelState.AddModelError(nameof(personalInformationViewModel.Occurred), "O bilhete de identidade já se encontra registado");
                }
                else
                {
                    var curriculum = new Curriculum();
                    curriculum = await curriculumRepository.AddAsync(curriculum);

                    personalInformation.CurriculumId = curriculum.Id; 
                    await personalInformationRepository.AddAsync(personalInformation);
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

        // GET: CurriculumsController/Dashboard
        public async Task<IActionResult> Dashboard(int curriculumId)
        {
            //var model = await getCurriculumDashboardUseCase.Invoke(curriculumId)
            //return View(model);
            return View();
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

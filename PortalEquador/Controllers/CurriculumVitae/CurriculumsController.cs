using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortalEquador.Data;
using PortalEquador.Data.PersonalInformation.Entities;
using PortalEquador.Domain.CurriculumVitae.UseCases;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.PersonalInformation.ViewModels;

namespace PortalEquador.Controllers.CurriculumVitae
{
    public class CurriculumsController : Controller
    {

        private readonly UserManager<User> userManager;
        private readonly GetAllCurriculumsUseCase _getAllCurriculumsUseCase;
        private readonly GetCurriculumDashboardUseCase _getCurriculumDashboardUseCase;


        public CurriculumsController(
            GetAllCurriculumsUseCase getAllCurriculumsUseCase,
            UserManager<User> userManager,
            GetCurriculumDashboardUseCase getCurriculumDashboardUseCase
            )
        {
            _getAllCurriculumsUseCase = getAllCurriculumsUseCase;
            _getCurriculumDashboardUseCase = getCurriculumDashboardUseCase;

            this.userManager = userManager;
        }


        // GET: CurriculumsController
        public async Task<IActionResult> Index()
        {
            var result = await _getAllCurriculumsUseCase.Invoke();
            return View(result);
        }

        // GET: CurriculumsController/Dashboard
        public async Task<IActionResult> Dashboard(int identifier)
        {
            var model = await _getCurriculumDashboardUseCase.Invoke(identifier);
            return View(model);
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
            return View();
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

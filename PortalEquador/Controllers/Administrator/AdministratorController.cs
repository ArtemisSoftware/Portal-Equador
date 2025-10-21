using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalEquador.Domain.Administrator.Repository;
using PortalEquador.Domain.Administrator.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Util.Constants;

namespace PortalEquador.Controllers.Administrator
{
    public class AdministratorController(
        IAdministratorRepository repository
        ) : Controller
    {
        // GET: AdministratorController
        public async Task<IActionResult> Index()
        {
            var result = await repository.GetAll();
            return View(result);
        }

        // GET: AdministratorController/Create
        public async Task<IActionResult> Create()
        {
            var result = await repository.GetCreateModel();
            return View(result);
        }

        // POST: AdministratorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdministratorCreateViewModel model)
        {
            var emailExists = await repository.EmailExistsAsync(model.Email);

            if (emailExists)
            {
                ModelState.AddModelError(nameof(model.Error), StringConstants.Error.EXISTING_USER);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await repository.Save(model);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ResetPassword(string id)
        {
            var result = await repository.GetResetPasswordAdmin(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(AdministratorResetPasswordViewModel model)
        {
                if (ModelState.IsValid)
                {
                    await repository.ResetPasswordAsync(model.Id, model.Password);
                    return RedirectToAction(nameof(Index));
                }
            else
            {
                return View(model);
            }   
        }


        // GET: AdministratorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: AdministratorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdministratorController/Edit/5
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

        // GET: AdministratorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdministratorController/Delete/5
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

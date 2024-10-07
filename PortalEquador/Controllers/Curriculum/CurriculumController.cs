using Microsoft.AspNetCore.Mvc;
using PortalEquador.Domain.Curriculum.Repository;
using PortalEquador.Domain.PersonalInformation.Repository;

namespace PortalEquador.Controllers.Curriculum
{
    public class CurriculumController(
        CurriculumRepository repository,
        IPersonalInformationRepository personalInformationRepository
        ) : Controller
    {

        // GET: CurriculumsController
        public async Task<IActionResult> Index()
        {
            var result = await personalInformationRepository.GetAll();
            return View(result);
        }

        // GET: CurriculumsController/Dashboard
        public async Task<IActionResult> Dashboard(int identifier)
        {
            var model = await repository.GetCurriculumDashboard(identifier);
            return View(model);
        }
    }
}

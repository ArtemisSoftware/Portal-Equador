using Microsoft.AspNetCore.Mvc;
using PortalEquador.Models;
using System.Diagnostics;

namespace PortalEquador.Controllers
{
    public class MechanicalWorkshopController : Controller
    {
        private readonly ILogger<MechanicalWorkshopController> _logger;

        public MechanicalWorkshopController(ILogger<MechanicalWorkshopController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

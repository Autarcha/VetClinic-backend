using Microsoft.AspNetCore.Mvc;

namespace VetClinic_backend.Controllers
{
    public class VisitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

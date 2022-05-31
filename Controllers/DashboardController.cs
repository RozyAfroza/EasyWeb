using Microsoft.AspNetCore.Mvc;

namespace LearningProject.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

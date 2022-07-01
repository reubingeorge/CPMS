using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}

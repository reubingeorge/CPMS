using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    public class PaperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}

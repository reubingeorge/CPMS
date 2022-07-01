using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    public class PaperReviewerController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}

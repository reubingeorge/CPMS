using CPMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CPMS.Controllers
{

    [Authorize(Roles = "Reviewer")]
    public class ReviewSubmission : Controller
    {
        public IActionResult Index()
        {
            SwitchDAO switchDataAccess = new();
            if (switchDataAccess.reviewEnabled())
                return View();
            else
                return View("SubmissionOver");
        }
    }
}

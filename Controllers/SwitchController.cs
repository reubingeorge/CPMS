using CPMS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SwitchController : Controller
    {
        public IActionResult Index()
        {
            SwitchDAO switchDataAccess = new();
            return View("Index", switchDataAccess.fetchSwitches());
        }

        public IActionResult Toggle(string toggleBtn)
        {
            SwitchDAO switchDataAccess = new();
            if (toggleBtn.Equals("Toggle Reviews"))
            {
                switchDataAccess.toggleReviewer();
            }
            else
            {
                switchDataAccess.togglePaper();
            }
            return RedirectToAction("Index");
        }
    }
}

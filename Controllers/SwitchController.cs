using CPMS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    /// <summary>
    /// Class <c>SwitchController</c> performs the role of the controller. This controller allows the 
    /// administrator to choose if the author or the reviewer can submit papers and reviews respectively.
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class SwitchController : Controller
    {
        /// <summary>
        /// Method <c>Index</c> returns a view that allows the user to stop and start various submission services. 
        /// </summary>
        /// <returns>HTML page that have various switch to start or stop submission services</returns>
        public IActionResult Index()
        {
            SwitchDAO switchDataAccess = new();
            return View("Index", switchDataAccess.FetchSwitches());
        }

        /// <summary>
        /// Method <c>Toggle</c> is a method that allows the user to start or stop submission services.
        /// </summary>
        /// <param name="toggleBtn">Name of the front-end controller that toggle the switch.</param>
        /// <returns>HTML containing the switches.</returns>
        public IActionResult Toggle(string toggleBtn)
        {
            SwitchDAO switchDataAccess = new();
            if (toggleBtn.Equals("Toggle Reviews"))
            {
                switchDataAccess.ToggleReviewer();
            }
            else
            {
                switchDataAccess.TogglePaper();
            }
            return RedirectToAction("Index");
        }

    }
}

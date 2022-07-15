using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    /// <summary>
    /// Class <c>PaperReviewerController</c> performs the role of the controller. This controller acts
    /// as the bridge table between the Paper & Reviewer table.
    /// </summary>
    public class PaperReviewerController : Controller
    {
        /// <summary>
        /// Method <c>Index</c> returns a view that will allow the user to match papers with reviewers.
        /// </summary>
        /// <returns>an html page that allows user to pick their choices.</returns>
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}

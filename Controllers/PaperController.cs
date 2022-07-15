using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    /// <summary>
    /// Class <c>PaperController</c> performs the role of a controller. This controller is used to submit
    /// a paper from the author.
    /// </summary>
    [Obsolete("This class is not needed anymore", true)]
    public class PaperController : Controller
    {
        /// <summary>
        /// Method <c>Index</c> is used to submit a paper from the author.
        /// </summary>
        /// <returns>an html page containing a form to submit the paper</returns>
        [Obsolete("This method has been superceeded by the Index method in PaperSubmissionController")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

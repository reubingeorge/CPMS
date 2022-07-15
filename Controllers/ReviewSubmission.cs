using CPMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CPMS.Controllers
{
    /// <summary>
    /// Class <c>ReviewSubmission</c> is used to verify if the reviewer is allowed to 
    /// upload reviews of a paper. This class is needed because there is a time frame within
    /// which the reviewer MUST submit the review.
    /// </summary>
    [Authorize(Roles = "Reviewer")]
    public class ReviewSubmission : Controller
    {
        /// <summary>
        /// Method <c>Index</c> is used to control the access to the review submission page.
        /// </summary>
        /// <returns>an html page containing the submission page OR a redirected page if outside the time frame.</returns>
        public IActionResult Index()
        {
            SwitchDAO switchDataAccess = new();
            if (switchDataAccess.ReviewEnabled())
                return View();
            else
                return View("SubmissionOver");
        }
    }
}

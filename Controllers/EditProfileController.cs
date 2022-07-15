using CPMS.Data;
using CPMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    /// <summary>
    /// Class <c>EditProfileController</c> performs the role of the controller. This controller is used to perform
    /// the operation to Edit the information of ANY user who are registered as an Author or Reviewer. The logged in
    /// user can change their profile ONLY.
    /// </summary>
    [Authorize(Roles = "Author,Reviewer")]
    public class EditProfileController : Controller
    {
        /// <summary>
        /// Method <c>Index</c> returns a view of a page that contains all the information of a logged in user.
        /// </summary>
        /// <returns>html page containing a form that allows the user to edit their information.</returns>
        public IActionResult Index()
        {
            int possibleID;
            if (User.IsInRole("Reviewer"))
            {
                ReviewerDAO reviewerDAO = new();
                _ = int.TryParse(User.FindFirst("ReviewerId")?.Value, out possibleID);
  
                return View("ReviewerProfile", reviewerDAO.FetchOne(possibleID));
            }
            else if (User.IsInRole("Author"))
            {
                AuthorDAO authorDAO = new();
                
                _ = int.TryParse(@User.FindFirst("AuthorId")?.Value, out possibleID);
                return View("AuthorProfile", authorDAO.FetchOne(possibleID));
            }
            else return RedirectToAction("Error", "Home");
        }

        /// <summary>
        /// Method <c>ProcessCreateAuthor</c> allows the users to change their information. NOTE: This method is 
        /// allowed for Authors ONLY.
        /// </summary>
        /// <param name="authorModel">Model containing the information of the current author</param>
        /// <returns>an html page of a form that allows the author to change their only information.</returns>
        public IActionResult ProcessCreateAuthor(AuthorModel authorModel)
        {
            AuthorDAO authorDAO = new();
            int newID = authorDAO.CreateOrUpdate(authorModel);
            if(newID > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Method <c>ProcessCreateReviewer</c> allows the users to change their information. NOTE: This method is 
        /// allowed for Reviewers ONLY.
        /// </summary>
        /// <param name="reviewerModel">Model containing the information of the current reviewer</param>
        /// <returns>an html page of a form that allows the reviewer to change their only information.</returns>
        public IActionResult ProcessCreateReviewer(ReviewerModel reviewerModel)
        {
            ReviewerDAO reviewerDAO = new();
            int newID = reviewerDAO.CreateOrUpdate(reviewerModel);
            if(newID > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

    }
}

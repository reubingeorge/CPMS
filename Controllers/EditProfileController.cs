using CPMS.Data;
using CPMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    [Authorize(Roles = "Author,Reviewer")]
    public class EditProfileController : Controller
    {
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

using CPMS.Data;
using CPMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    /// <summary>
    ///Class <c>ReviewController</c> perform the role of the controller. This controller is used to perform
    /// the CRUD operation on the the Review table in the database.
    /// </summary>
    [Authorize(Roles = "Reviewer, Admin")]
    public class ReviewController : Controller
    {
        /// <summary>
        /// Method <c>Index</c> returns a view of the list of all reviews that need to be performed by the 
        /// reviewer logged into the system.
        /// </summary>
        /// <returns>an html page containing a list of all reviews performed by a particular user.</returns>
        public IActionResult Index()
        {
            ReviewDAO reviewDAO = new();
            //if(User.IsInRole("Reviewer")){
                int reviewerID;
                _ = int.TryParse(User.FindFirst("ReviewerId")?.Value, out reviewerID);
                return View("Index", reviewDAO.FetchAllReviews(reviewerID));
            //}

            /*if (User.IsInRole("Admin"))
            {
                return View("Index", reviewDAO.FetchAll());
            }*/

            //return View("Error", "Home");
        }

        /// <summary>
        /// Method <c>Create</c> returns a view that contains a form that allows the administator to create a 
        /// new review on behalf of an existing reviewer in the database.
        /// </summary>
        /// <returns>an html page containing a form to enter a new review in the database</returns>
        [HttpPost]
        public IActionResult Create()
        {
            return PartialView("ReviewForm");
        }

        /// <summary>
        /// Method <c>Edit</c> returns a view of a form that allows the user to edit a specific review in the database.
        /// </summary>
        /// <param name="id">ID of the review (primary key in the database)</param>
        /// <returns>an html page containing a form that allows review to edit a review.</returns>
        [HttpPost]
        public IActionResult Edit(int id)
        {
            ReviewDAO reviewDAO = new();
            return PartialView("ReviewForm", reviewDAO.FetchOne(id));
        }

        /// <summary>
        /// Method <c>ProcessCreate</c> returns a view containing a list of all reviews assigned to the logged in reviewer
        /// in the database.
        /// </summary>
        /// <param name="reviewReviewerModel">Model containing the information of the review</param>
        /// <returns>an html page containing a list of all authors</returns>
        public IActionResult ProcessCreate(ReviewReviewerModel reviewReviewerModel)
        {
            int reviewerID;
            _ = int.TryParse(User.FindFirst("ReviewerId")?.Value, out reviewerID);
            ReviewDAO reviewDAO = new();
            reviewDAO.CreateOrUpdate(reviewReviewerModel);
            return View("Index", reviewDAO.FetchAllReviews(reviewerID));
        }

        /// <summary>
        /// Method <c>DownloadFile</c> returns a file from the server to the user.
        /// </summary>
        /// <param name="fileName">Name of the file to be downloaded.</param>
        /// <returns>The file stored in the server.</returns>
        public FileResult DownloadFile(string fileName)
        {
            var FileVirtualPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "uploads/")) + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(FileVirtualPath);
            return File(bytes, "application/octet-stream", fileName);
        }
    }
}

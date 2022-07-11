using CPMS.Data;
using CPMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    [Authorize(Roles = "Reviewer, Admin")]
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            int reviewerID;
            _ = int.TryParse(User.FindFirst("ReviewerId")?.Value, out reviewerID);
            ReviewDAO reviewDAO = new();

            return View("Index", reviewDAO.FetchAllReviews(reviewerID));
        }

        [HttpPost]
        public IActionResult Create ()
        {
            return PartialView("ReviewForm");
        }


        [HttpPost]
        public IActionResult Edit(int id)
        {
            ReviewDAO reviewDAO = new();
            return PartialView("ReviewForm", reviewDAO.FetchOne(id));
        }

        public IActionResult ProcessCreate(ReviewReviewerModel reviewReviewerModel)
        {
            int reviewerID;
            _ = int.TryParse(User.FindFirst("ReviewerId")?.Value, out reviewerID);
            ReviewDAO reviewDAO = new();
            reviewDAO.CreateOrUpdate(reviewReviewerModel);
            return View("Index", reviewDAO.FetchAllReviews(reviewerID));
        }
        public FileResult DownloadFile(string fileName)
        {
            var FileVirtualPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "uploads/")) + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(FileVirtualPath);
            return File(bytes, "application/octet-stream", fileName);
        }
    }
}

using CPMS.Data;
using CPMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    /// <summary>
    /// Class <c>PaperReviewerController</c> performs the role of the controller. This controller acts
    /// as the bridge table between the Paper & Reviewer table.
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class PaperReviewerController : Controller
    {
        /// <summary>
        /// Method <c>Index</c> returns a view that will allow the user to match papers with reviewers.
        /// </summary>
        /// <returns>an html page that allows user to pick their choices.</returns>
        public IActionResult Index()
        {
            List<PaperReviewerModel> papersAndReviewersList = new();
            List<PaperModel> papers;
            PaperDAO paperDAO = new();
            papers = paperDAO.FetchAll();
            ReviewDAO reviewDAO = new();
            foreach(var paper in papers)
            {
                PaperReviewerModel paperReviewerModel = new();
                paperReviewerModel.PaperModel = paper;
                List<ReviewerModel> assignedReviewers = reviewDAO.FetchAllAssignedReviewers(paper.PaperID);
                if (assignedReviewers.Count is <= 3 and > 0) // we need to have at least 1 and a max of 3 reviewers
                {
                    paperReviewerModel.AssignedReviewers.AddRange(assignedReviewers);
                }
                paperReviewerModel.AvailableReviewers.AddRange(reviewDAO.FetchAllAvailableReviewers(paper.PaperID));
                papersAndReviewersList.Add(paperReviewerModel);
            }
            return View("Index", papersAndReviewersList);
        }

        /// <summary>
        /// Method <c>Create</c> returns a view that shows the potential match between paper and reviewers.
        /// </summary>
        /// <param name="paperID">ID of paper</param>
        /// <param name="select_0">ID of Reviewer 1 (can be null)</param>
        /// <param name="select_1">ID of Reviewer 2 (can be null)</param>
        /// <param name="select_2">ID of Reviewer 3 (can be null)</param>
        /// <returns></returns>
        public IActionResult Create(int paperID, string? select_0, string? select_1, string? select_2)
        {
            ReviewDAO reviewDAO = new();
            List<string> unprocessedReviewerIDs = new();
            if (!string.IsNullOrEmpty(select_0))
            {
                unprocessedReviewerIDs.Add(select_0);
            }
            if (!string.IsNullOrEmpty(select_1))
            {
                unprocessedReviewerIDs.Add(select_1);
            }
            if (!string.IsNullOrEmpty(select_2))
            {
                unprocessedReviewerIDs.Add(select_2);
            }

            var processedReviewerIDs = unprocessedReviewerIDs.DistinctBy(x => x).ToList();
            foreach (var processedReviewerID in processedReviewerIDs)
            {
                ReviewModel review = new()
                {
                    PaperID = paperID,
                    ReviewerID = int.Parse(processedReviewerID)
                };
                reviewDAO.Create(review);
            }
            
            return RedirectToAction("Index");
        }
    }
}

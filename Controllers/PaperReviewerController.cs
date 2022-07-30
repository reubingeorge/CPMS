﻿using CPMS.Data;
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
                if (assignedReviewers.Count is <= 3 and > 0) // we need to have at least 1 or a max of 3 reviewers
                {
                    paperReviewerModel.AssignedReviewers.AddRange(assignedReviewers);
                }
                paperReviewerModel.AvailableReviewers.AddRange(reviewDAO.FetchAllAvailableReviewers(paper.PaperID));
                papersAndReviewersList.Add(paperReviewerModel);
            }
            return View("Index", papersAndReviewersList);
        }

        public IActionResult Create(int paperID, string? select_0, string? select_1, string? select_2)
        {
            ReviewDAO reviewDAO = new();
            if (select_0 != null)
            {
                ReviewModel review = new()
                {
                    PaperID = paperID,
                    ReviewerID = int.Parse(select_0)
                };
                reviewDAO.Create(review);
            }
            if (select_1 != null)
            {
                ReviewModel review = new()
                {
                    PaperID = paperID,
                    ReviewerID = int.Parse(select_1)
                };
                reviewDAO.Create(review);
            }
            if (select_2 != null)
            {
                ReviewModel review = new()
                {
                    PaperID = paperID,
                    ReviewerID = int.Parse(select_2)
                };
                reviewDAO.Create(review);
            }
            /*ReviewDAO reviewDAO= new();

            foreach(var reviewerID in reviewerIDs)
            {
                ReviewModel review = new();
                review.PaperID = paperID;
                review.ReviewID = reviewerID;
                reviewDAO.Create(review);
            }*/
            
            return RedirectToAction("Index");
        }
    }
}

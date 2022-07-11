using CPMS.Data;
using CPMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReviewerController : Controller
    {
        public IActionResult Index()
        {
            ReviewerDAO reviewerDAO = new();
            return View("Index", reviewerDAO.FetchAll());
        }


        [HttpPost]
        public IActionResult Details(int id)
        {
            ReviewerDAO reviewerDAO = new();
            return PartialView("Details", reviewerDAO.FetchOne(id));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            ReviewerDAO reviewerDAO = new();
            reviewerDAO.Delete(id);
            return View("Index", reviewerDAO.FetchAll());
        }

        [HttpPost]
        public IActionResult Create()
        {
            return PartialView("ReviewerForm");
        }

        [HttpPost]
        public IActionResult ProcessCreate(ReviewerModel reviewerModel)
        {
            ReviewerDAO reviewerDAO = new();
            reviewerDAO.CreateOrUpdate(reviewerModel);
            return View("Index", reviewerDAO.FetchAll());
        }

        
        public IActionResult Edit(int id)
        {
            ReviewerDAO reviewerDAO = new();
            reviewerDAO.FetchOne(id);
            return PartialView("ReviewerForm", reviewerDAO.FetchOne(id));
        }
    }
}

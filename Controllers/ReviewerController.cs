using CPMS.Data;
using CPMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    /// <summary>
    /// Class <c>ReviewerController</c> performs the role of the controller. This controller is used to perform
    /// the CRUD operation on the Reviewer table in the database. 
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class ReviewerController : Controller
    {
        /// <summary>
        /// Method <c>Index</c> returns a view of the list of all approved reviewers in the database.
        /// </summary>
        /// <returns>an HTML page containing a list of all reviewers</returns>
        public IActionResult Index()
        {
            ReviewerDAO reviewerDAO = new();
            return View("Index", reviewerDAO.FetchAll());
        }


        /// <summary>
        /// Method <c>Details</c> returns a view of a very specific reviewer in the database.
        /// </summary>
        /// <param name="id">ID of the reviewer (primary key in the database).</param>
        /// <returns>an HTML page containing all the information of the requested reviewer.</returns>
        [HttpPost]
        public IActionResult Details(int id)
        {
            ReviewerDAO reviewerDAO = new();
            return PartialView("Details", reviewerDAO.FetchOne(id));
        }

        /// <summary>
        /// Method <c>Delete</c> returns a view containing a list of all reviewers authors after deleting 
        /// a particular reviewer in the database.
        /// </summary>
        /// <param name="id">ID of the reviewer (primary key in the database).</param>
        /// <returns>an HTML page containing a list of all reviewers</returns>
        [HttpPost]
        public IActionResult Delete(int id)
        {
            ReviewerDAO reviewerDAO = new();
            reviewerDAO.Delete(id);
            return View("Index", reviewerDAO.FetchAll());
        }

        /// <summary>
        /// Method <c>Create</c> returns a view that contains a form that allows the user to enter a 
        /// new reviewer in the database.
        /// </summary>
        /// <returns>an HTML page containing a form to enter a new reviewer in the database</returns>
        [HttpPost]
        public IActionResult Create()
        {
            return PartialView("ReviewerForm");
        }

        /// <summary>
        /// Method <c>ProcessCreate</c> returns a view containing a list of all available reviewers after inserting
        /// a new reviewer in the database.
        /// </summary>
        /// <param name="reviewerModel">Model containing the information of the new reviewer</param>
        /// <returns>an HTML page containing a list of all reviewers</returns>
        [HttpPost]
        public IActionResult ProcessCreate(ReviewerModel reviewerModel)
        {
            ReviewerDAO reviewerDAO = new();
            reviewerDAO.CreateOrUpdate(reviewerModel);
            return View("Index", reviewerDAO.FetchAll());
        }


        /// <summary>
        /// Method <c>Edit</c> returns a view of a form that allows the user to edit the information about
        /// a specific user in the database.
        /// </summary>
        /// <param name="id">ID of the reviewer (primary key in the database).</param>
        /// <returns>an HTML page containing a form that allows user to edit information of a specific user.</returns>
        public IActionResult Edit(int id)
        {
            ReviewerDAO reviewerDAO = new();
            reviewerDAO.FetchOne(id);
            return PartialView("ReviewerForm", reviewerDAO.FetchOne(id));
        }
    }
}

using CPMS.Data;
using CPMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    /// <summary>
    /// Class <c>AuthorController</c> performs the role of the controller. This controller is used to perform
    /// the CRUD operation on the Author table in the database. 
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class AuthorController : Controller
    {
        /// <summary>
        /// Method <c>Index</c> returns a view of the list of all approved authors in the database.
        /// </summary>
        /// <returns>an HTML page containing a list of all authors</returns>
        public IActionResult Index()
        {
            if (HttpContext.User.IsInRole("Reviewer") || HttpContext.User.IsInRole("Author"))
            {
                return RedirectToAction("Error","Home");
            }
            AuthorDAO authorDAO = new();
            return View("Index", authorDAO.FetchAll());
        }

        /// <summary>
        /// Method <c>Details</c> returns a view of a very specific author in the database.
        /// </summary>
        /// <param name="id">ID of the author (primary key in the database).</param>
        /// <returns>an HTML page containing all the information of the requested author.</returns>
        [HttpPost]
        public IActionResult Details(int id)
        {
            if (HttpContext.User.IsInRole("Reviewer") || HttpContext.User.IsInRole("Author"))
            {
                return RedirectToAction("Error", "Home");
            }
            AuthorDAO authorDAO = new();
            return PartialView("Details", authorDAO.FetchOne(id));
        }

        /// <summary>
        /// Method <c>Create</c> returns a view that contains a form that allows the user to enter a 
        /// new author in the database.
        /// </summary>
        /// <returns>an HTML page containing a form to enter a new author in the database</returns>
        [HttpPost]
        public IActionResult Create()
        {
            if (HttpContext.User.IsInRole("Reviewer") || HttpContext.User.IsInRole("Author"))
            {
                return RedirectToAction("Error", "Home");
            }
            return PartialView("AuthorForm");
        }

        /// <summary>
        /// Method <c>Edit</c> returns a view of a form that allows the user to edit the information about
        /// a specific user in the database.
        /// </summary>
        /// <param name="id">ID of the author (primary key in the database).</param>
        /// <returns>an HTML page containing a form that allows user to edit information of a specific user.</returns>
        [HttpPost]
        public IActionResult Edit(int id)
        {
            if (HttpContext.User.IsInRole("Reviewer") || HttpContext.User.IsInRole("Author"))
            {
                return RedirectToAction("Error", "Home");
            }
            AuthorDAO authorDAO = new();
            return PartialView("AuthorForm", authorDAO.FetchOne(id));
        }


        /// <summary>
        /// Method <c>ProcessCreate</c> returns a view containing a list of all available authors after inserting
        /// a new author in the database.
        /// </summary>
        /// <param name="authorModel">Model containing the information of the new author</param>
        /// <returns>an HTML page containing a list of all authors</returns>
        [HttpPost]
        public IActionResult ProcessCreate(AuthorModel authorModel)
        {
            if (HttpContext.User.IsInRole("Reviewer") || HttpContext.User.IsInRole("Author"))
            {
                return RedirectToAction("Error", "Home");
            }
            AuthorDAO authorDAO = new();
            authorDAO.CreateOrUpdate(authorModel);
            return View("Index", authorDAO.FetchAll());
        }

        /// <summary>
        /// Method <c>Delete</c> returns a view containing a list of all available authors after deleting 
        /// a particular author in the database.
        /// </summary>
        /// <param name="id">ID of the author (primary key in the database).</param>
        /// <returns>an HTML page containing a list of all authors</returns>
        [HttpPost]
        public IActionResult Delete(int id)
        {
            AuthorDAO authorDAO = new();
            authorDAO.Delete(id);
            return View("Index", authorDAO.FetchAll());
        }
    }
}

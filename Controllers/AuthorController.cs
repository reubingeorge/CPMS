using CPMS.Data;
using CPMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.User.IsInRole("Reviewer") || HttpContext.User.IsInRole("Author"))
            {
                return RedirectToAction("Error","Home");
            }
            AuthorDAO authorDAO = new();
            return View("Index", authorDAO.FetchAll());
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create()
        {
            if (HttpContext.User.IsInRole("Reviewer") || HttpContext.User.IsInRole("Author"))
            {
                return RedirectToAction("Error", "Home");
            }
            return PartialView("AuthorForm");
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            AuthorDAO authorDAO = new();
            authorDAO.Delete(id);
            return View("Index", authorDAO.FetchAll());
        }
    }
}

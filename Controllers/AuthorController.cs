using CPMS.Data;
using CPMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    [Authorize(Roles = "Admin,Author")]
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.User.IsInRole("Reviewer"))
            {
                return RedirectToAction("Error","Home");
            }
            AuthorDAO authorDAO = new();
            return View("Index", authorDAO.FetchAll());
        }

        public IActionResult Details(int id)
        {
            AuthorDAO authorDAO = new();
            return PartialView("Details", authorDAO.FetchOne(id));
        }

        public IActionResult Create()
        {
            return PartialView("AuthorForm");
        }

        public IActionResult Edit(int id)
        {
            AuthorDAO authorDAO = new();
            return PartialView("AuthorForm", authorDAO.FetchOne(id));
        }

        public IActionResult ProcessCreate(AuthorModel authorModel)
        {
            AuthorDAO authorDAO = new();
            authorDAO.CreateOrUpdate(authorModel);
            return PartialView("Details", authorModel);
        }
    }
}

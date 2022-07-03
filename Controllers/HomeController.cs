using CPMS.Data;
using CPMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace CPMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("validAuthor") != null || 
                HttpContext.Session.GetInt32("validReviewer") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // NOTE: the button decider method within only works in English.
        // The specific value of buttonPress depends on which button is pressed in Login.cshtml.
        // The basis of it is that only one button can be pressed before redirection, so whichever
        // value was passed in must be the button that was pressed.
        public IActionResult Login(string email, string password, string buttonPress)
        {
            // Checks that all function arguments are not empty
            if (ModelState.IsValid)
            {
                // String check - this is where translated page would fail
                if (buttonPress.Equals("Author Login")) 
                {
                    AuthorDAO authorDAO = new();
                    if (authorDAO.LoginCheck(email, password))
                    {
                        HttpContext.Session.SetInt32("validAuthor", 1); // Set as int but value is not checked later
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.error = "Login failed";
                        return RedirectToAction("Login");
                    }
                }
                else  // for reviewers, no code yet because reviewer data class has not been made 
                {
                    HttpContext.Session.SetInt32("validReviewer", 1);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();    
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
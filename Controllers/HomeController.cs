using CPMS.Data;
using CPMS.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;


namespace CPMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // NOTE: the button decider method within only works in English.
        // The specific value of buttonPress depends on which button is pressed in Login.cshtml.
        // The basis of it is that only one of the two identically named buttons can be pressed before redirection,
        // so whichever value was passed in must be the button that was pressed.
        [AllowAnonymous]
        public async Task<IActionResult> Login(string email, string password, string buttonPress)
        {
            // No model, checks that all function arguments are not empty
            if (ModelState.IsValid)
            {
                // admin can use either button to log in
                if (email.Equals("admin@cpms.org") && password.Equals("12345"))
                {
                    var claims = new List<Claim>() {
                            new Claim(ClaimTypes.Name, "Admin"),
                            new Claim(ClaimTypes.Role, "Admin")
                        };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index");
                }
                //String check -this is where translated page would fail
                else if (buttonPress.Equals("Author Login"))
                {
                    AuthorDAO authorDataAccess = new();
                    if (authorDataAccess.LoginCheck(email, password))
                    {
                        // Generate claims
                        var claims = new List<Claim>() {
                            new Claim(ClaimTypes.Name, email),
                            new Claim(ClaimTypes.Role, "Author")
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.error = "Login failed";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ReviewerDAO reviewerDataAccess = new();
                    if (reviewerDataAccess.LoginCheck(email, password))
                    {
                        // Generate claims
                        var claims = new List<Claim>() {
                            new Claim(ClaimTypes.Name, email),
                            new Claim(ClaimTypes.Role, "Reviewer")
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.error = "Login failed";
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult RegisterSelect(string buttonPress)
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> RegisterAuthor(AuthorModel author)
        {
            if (ModelState.IsValid)
            {
                AuthorDAO authorDataAccess = new();
                if (authorDataAccess.LoginCheck(author.Email, author.Password))
                {
                    
                }
                authorDataAccess.CreateOrUpdate(author);

                await Login(author.Email, author.Password, "Author Login");

                return RedirectToAction("Index");
            }
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> RegisterReviewer(ReviewerModel reviewer)
        {
            if (ModelState.IsValid)
            {
                ReviewerDAO reviewerDataAccess = new();
                if (reviewerDataAccess.LoginCheck(reviewer.Email, reviewer.Password))
                {

                }
                reviewerDataAccess.CreateOrUpdate(reviewer);

                await Login(reviewer.Email, reviewer.Password, "reviewer Login");

                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
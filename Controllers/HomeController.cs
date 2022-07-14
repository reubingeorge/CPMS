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
    /// <summary>
    /// Class <c>HomeController</c> perform the role of the controller. This controller is responsible for
    /// the authentication services as well as the logout operation. 
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; //no logging operation is used for this project.

        /// <summary>
        /// Constructor used to define the <c>HomeController</c> object.
        /// </summary>
        /// <param name="logger">Logger object</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Method <c>Index</c> returns the view of the login page.
        /// </summary>
        /// <returns>an html page of the login page.</returns>
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Method <c>Privacy</c> returns the view of the privacy page.
        /// </summary>
        /// <returns>an html page of the privacy page.</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Method <c>Login</c> is used to login to the web application. This method assigns roles to the logged in users.
        /// A user can be an Administrator, Author or a Reviewer. If the user is an Author or a Reviewer, their credentials are
        /// stored as cookies. 
        /// </summary>
        /// <param name="email">Email of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <param name="buttonPress">Credentials that the user wants to be logged in as.</param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> Login(string email, string password, string buttonPress)
        {
            // NOTE: the button decider method within only works in English.
            // The specific value of buttonPress depends on which button is pressed in Login.cshtml.
            // The basis of it is that only one of the two identically named buttons can be pressed before redirection,
            // so whichever value was passed in must be the button that was pressed.

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
                    int authorId = authorDataAccess.GetIdByCredential(email, password);
                    if (authorId > 0)
                    {
                        // Generate claims
                        var claims = new List<Claim>() {
                            new Claim(ClaimTypes.Name, email),
                            new Claim(ClaimTypes.Role, "Author"),
                            new Claim("AuthorId", authorId.ToString())
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
                    var reviewerId = reviewerDataAccess.GetIdByCredential(email, password);
                    if (reviewerId > 0)
                    {
                        // Generate claims
                        var claims = new List<Claim>() {
                            new Claim(ClaimTypes.Name, email),
                            new Claim(ClaimTypes.Role, "Reviewer"),
                            new Claim("ReviewerId", reviewerId.ToString())
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

        /// <summary>
        /// Method <c>RegisterSelect</c> is used to register as an Author or a Reviewer.
        /// </summary>
        /// <param name="buttonPress">Credentials that the user wants to be registered as.</param>
        /// <returns>an html page of the user's choice.</returns>
        [AllowAnonymous]
        public IActionResult RegisterSelect(string buttonPress)
        {
            return View();
        }

        /// <summary>
        /// Method <c>RegisterAuthor</c> is used to register an Author into the database.
        /// </summary>
        /// <param name="author">Model containining all the necessary information of the author</param>
        /// <returns>the dashboard page that contains all the tasks that the author can perform.</returns>
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAuthor(AuthorModel author)
        {
            if (ModelState.IsValid)
            {
                AuthorDAO authorDataAccess = new();
                if (authorDataAccess.GetIdByCredential(author.Email, author.Password) > 0)
                {
                    ViewBag.Message = "You already have an account within our system!";
                    return RedirectToAction("Login");
                }
                authorDataAccess.CreateOrUpdate(author);

                await Login(author.Email, author.Password, "Author Login");

                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// Method <c>RegisterReviewer</c> is used to register a Reviewer into the database.
        /// </summary>
        /// <param name="reviewer">Model containining all the necessary information of the reviewer</param>
        /// <returns>the dashboard page that contains all the tasks that the reviewer can perform.</returns>
        [AllowAnonymous]
        public async Task<IActionResult> RegisterReviewer(ReviewerModel reviewer)
        {
            if (ModelState.IsValid)
            {
                ReviewerDAO reviewerDataAccess = new();
                if (reviewerDataAccess.GetIdByCredential(reviewer.Email, reviewer.Password) > 0)
                {
                    ViewBag.Message = "You already have an account within our system!";
                    return RedirectToAction("Login");
                }
                reviewerDataAccess.CreateOrUpdate(reviewer);

                await Login(reviewer.Email, reviewer.Password, "reviewer Login");

                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// Method <c>Logout</c> is used to completely log out of the web app.
        /// </summary>
        /// <returns>the html page containing the login form.</returns>
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        /// <summary>
        /// Method <c>Error</c> is used to redirect the user to an error page whenever the app registers
        /// an exception.
        /// </summary>
        /// <returns>an html page containing the error caused.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
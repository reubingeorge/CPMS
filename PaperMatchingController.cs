using CPMS.Data;
using CPMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    public class PaperReviewerController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Insert(int i)
        {
            ReviewModel reviewModel = new ReviewModel();
            PaperMatchingDAO paperMatchingDao = new PaperMatchingDAO();
            if (paperMatchingDao.Check(i)) // if paperID already exist
                return View("Index"); // do nothing
            else // else if paperID doesn't exist
            {
                for (int j = 0; j < 3; j++)
                {
                    paperMatchingDao.InsertThreeTimes(reviewModel, i);
                }
            }

            return View("Index"); // return index after updating review table
            // will insertThreeReviewers
        }
    }
    
}
/

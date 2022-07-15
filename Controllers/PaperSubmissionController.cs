using CPMS.Data;
using CPMS.Interfaces;
using CPMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    /// <summary>
    /// Class <c>PaperSubmissionController</c> performs the role of the controller. This controller is used to
    /// submit a paper from the author alongside with the paper's corresponding data. 
    /// </summary>
    [Authorize(Roles = "Author")]
    public class PaperSubmissionController : Controller
    {

        readonly IBufferedFileUploadService _bufferedFileUploadService;

        /// <summary>
        /// Constructor that accepts a file.
        /// </summary>
        /// <param name="bufferedFileUploadService">File to be uploaded in the backend.</param>
        public PaperSubmissionController(IBufferedFileUploadService bufferedFileUploadService)
        {
            _bufferedFileUploadService = bufferedFileUploadService;
        }


        /// <summary>
        /// Method <c>Index</c> returns a view of the page that accepts a paper from the user alongside with the
        /// data associated with the paper.
        /// </summary>
        /// <returns>an html page that contains a form to upload the paper and data.</returns>
        public IActionResult Index()
        {
            SwitchDAO switchDataAccess = new();
            if (switchDataAccess.PaperEnabled())
                return View("Index");
            else
                return View("SubmissionOver");
        }

        /// <summary>
        /// Method <c>ProcessCreate</c> is a POST only page that allows the user to upload a file to the backend. There 
        /// are some error checking involved to verify if the file has been successfully uploaded or not.
        /// </summary>
        /// <param name="paperSubmissionModel">Model containing the information of the new paper.</param>
        /// <returns>an html page of the user dashboard.</returns>
        [HttpPost]
        public async Task<IActionResult> ProcessCreate(PaperSubmissionModel paperSubmissionModel)
        {
            try
            {
                if(await _bufferedFileUploadService.UploadFile(paperSubmissionModel.Formfile))
                {
                    ViewBag.Message = "File Upload successful";
                }
                else
                {
                    ViewBag.Message = "File Upload Failed";
                }
            }
            catch (Exception)
            {
                ViewBag.Message = "Upload failed";
            }
            int authorID;
            _ = int.TryParse(User.FindFirst("AuthorId")?.Value, out authorID);
            paperSubmissionModel.AuthorID = authorID;
            PaperDAO paperDAO = new();
            paperSubmissionModel.FilenameOriginal = paperSubmissionModel.Formfile.FileName;
            paperSubmissionModel.Filename = Path.GetFileNameWithoutExtension(paperSubmissionModel.FilenameOriginal)
                + "_"
                + Guid.NewGuid().ToString()[..4]
                + Path.GetExtension(paperSubmissionModel.FilenameOriginal);
            paperDAO.CreateOrUpdate(paperSubmissionModel);
            return RedirectToAction("Index", "Home");
        }
    }
}

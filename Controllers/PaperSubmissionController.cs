using CPMS.Data;
using CPMS.Interfaces;
using CPMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    [Authorize(Roles = "Author")]
    public class PaperSubmissionController : Controller
    {
        readonly IBufferedFileUploadService _bufferedFileUploadService;
        public PaperSubmissionController(IBufferedFileUploadService bufferedFileUploadService)
        {
            _bufferedFileUploadService = bufferedFileUploadService;
        }

        public IActionResult Index()
        {
            SwitchDAO switchDataAccess = new();
            if (switchDataAccess.paperEnabled())
                return View("Index");
            else
                return View("SubmissionOver");
        }

        [HttpPost]
        public async Task<IActionResult> ProcessCreate(PaperSubmissionModel paperSubmissionModel)
        {
            try
            {
                if(await _bufferedFileUploadService.UploadFile(paperSubmissionModel.formfile))
                {
                    ViewBag.Message = "File Upload successful";
                }
                else
                {
                    ViewBag.Message = "File Upload Failed";
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Upload failed";
            }
            int authorID;
            _ = int.TryParse(User.FindFirst("AuthorId")?.Value, out authorID);
            paperSubmissionModel.AuthorID = authorID;
            PaperDAO paperDAO = new();
            paperSubmissionModel.FilenameOriginal = paperSubmissionModel.formfile.FileName;
            paperSubmissionModel.Filename = Path.GetFileNameWithoutExtension(paperSubmissionModel.FilenameOriginal)
                + "_"
                + Guid.NewGuid().ToString().Substring(0, 4)
                + Path.GetExtension(paperSubmissionModel.FilenameOriginal);
            paperDAO.CreateOrUpdate(paperSubmissionModel);
            return RedirectToAction("Index", "Home");
        }
    }
}

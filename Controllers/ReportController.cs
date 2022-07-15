using Excel = Microsoft.Office.Interop.Excel;
using CPMS.Data;
using CPMS.Models;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CPMS.Controllers
{
    /// <summary>
    /// Class <c>ReportController</c> performs the role of the controller. This controller is used to 
    /// perform two operations simultaneously: CREATE and DOWNLOAD an Excel file. The Excel file are essentially 
    /// reports of the various data.
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class ReportController : Controller
    {
        /// <summary>
        /// Method <c>Index</c> returns a view of a page that allows users to download various files.
        /// </summary>
        /// <returns>an HTML with all the options to download various information.</returns>
        public IActionResult Index()
        {
            return View("Index");
        }

        /// <summary>
        /// Method <c>DownloadAuthor</c> return a file of the Author Report. This method essentially creates 
        /// an Excel file while downloading the information from the database. This method forces the program to be
        /// run on a Windows 10 OS because of the Excel file creation and download.
        /// </summary>
        /// <returns>an HTML page of the index page if the file has been downloaded correctly.</returns>
        public IActionResult DownloadAuthor()
        {
            // Attempt to initialize Excel
            Excel.Application xlApp = new();
            if (xlApp == null)
            {
                ViewBag.Message("Excel not installed on this device");
                return View();
            }

            // Generate new blank workbook and enter initial sheet
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add(Missing.Value);
            Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.ActiveSheet;

            // Populate table headers
            xlWorksheet.Cells[1, 1] = "Last Name";
            xlWorksheet.Cells[1, 2] = "First Name";
            xlWorksheet.Cells[1, 3] = "Middle Initial";
            xlWorksheet.Cells[1, 4] = "Affiliation";
            xlWorksheet.Cells[1, 5] = "Department";
            xlWorksheet.Cells[1, 6] = "Address";
            xlWorksheet.Cells[1, 7] = "City";
            xlWorksheet.Cells[1, 8] = "State";
            xlWorksheet.Cells[1, 9] = "Zip Code";
            xlWorksheet.Cells[1, 10] = "Phone Number";
            xlWorksheet.Cells[1, 11] = "Email Address";

            // Fetch and populate author data
            AuthorDAO authorDataAccess = new();
            List<AuthorModel> authorList = authorDataAccess.FetchAll();

            for (int i = 0; i < authorList.Count; i++)
            {
                xlWorksheet.Cells[i + 2, 1] = authorList[i].LastName;
                xlWorksheet.Cells[i + 2, 2] = authorList[i].FirstName;
                xlWorksheet.Cells[i + 2, 3] = authorList[i].MiddleInitial;
                xlWorksheet.Cells[i + 2, 4] = authorList[i].Affiliation;
                xlWorksheet.Cells[i + 2, 5] = authorList[i].Department;
                xlWorksheet.Cells[i + 2, 6] = authorList[i].Address;
                xlWorksheet.Cells[i + 2, 7] = authorList[i].City;
                xlWorksheet.Cells[i + 2, 8] = authorList[i].State;
                xlWorksheet.Cells[i + 2, 9] = authorList[i].ZipCode;
                xlWorksheet.Cells[i + 2, 10] = authorList[i].PhoneNumber;
                xlWorksheet.Cells[i + 2, 11] = authorList[i].Email;
            }

            // "Save as" dialogue box
            xlApp.DisplayAlerts = false;
            Excel.Dialog saveAsDialog = xlApp.Dialogs[Excel.XlBuiltInDialog.xlDialogSaveAs];
            saveAsDialog.Show("AuthorReport");

            xlWorkbook.Close();
            xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

            return RedirectToAction("Index");
        }


        /// <summary>
        /// Method <c>DownloadReviewer</c> return a file of the Reviewer Report. This method essentially creates 
        /// an Excel file while downloading the information from the database. This method forces the program to be
        /// run on a Windows 10 OS because of the Excel file creation and download.
        /// </summary>
        /// <returns>an HTML page of the index page if the file has been downloaded correctly.</returns>
        public IActionResult DownloadReviewer()
        {
            // Attempt to initialize Excel
            Excel.Application xlApp = new();
            if (xlApp == null)
            {
                ViewBag.Message("Excel not installed on this device");
                return View();
            }

            // Generate new blank workbook and enter initial sheet
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add(Missing.Value);
            Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.ActiveSheet;

            // Populate table headers
            xlWorksheet.Cells[1, 1] = "Last Name";
            xlWorksheet.Cells[1, 2] = "First Name";
            xlWorksheet.Cells[1, 3] = "Middle Initial";
            xlWorksheet.Cells[1, 4] = "Affiliation";
            xlWorksheet.Cells[1, 5] = "Department";
            xlWorksheet.Cells[1, 6] = "Address";
            xlWorksheet.Cells[1, 7] = "City";
            xlWorksheet.Cells[1, 8] = "State";
            xlWorksheet.Cells[1, 9] = "Zip Code";
            xlWorksheet.Cells[1, 10] = "Phone Number";
            xlWorksheet.Cells[1, 11] = "Email Address";

            // Fetch and populate reviewer data
            ReviewerDAO reviewerDataAccess = new();
            List<ReviewerModel> reviewerList = reviewerDataAccess.FetchAll();

            for (int i = 0; i < reviewerList.Count; i++)
            {
                xlWorksheet.Cells[i + 2, 1] = reviewerList[i].LastName;
                xlWorksheet.Cells[i + 2, 2] = reviewerList[i].FirstName;
                xlWorksheet.Cells[i + 2, 3] = reviewerList[i].MiddleInitial;
                xlWorksheet.Cells[i + 2, 4] = reviewerList[i].Affiliation;
                xlWorksheet.Cells[i + 2, 5] = reviewerList[i].Department;
                xlWorksheet.Cells[i + 2, 6] = reviewerList[i].Address;
                xlWorksheet.Cells[i + 2, 7] = reviewerList[i].City;
                xlWorksheet.Cells[i + 2, 8] = reviewerList[i].State;
                xlWorksheet.Cells[i + 2, 9] = reviewerList[i].ZipCode;
                xlWorksheet.Cells[i + 2, 10] = reviewerList[i].PhoneNumber;
                xlWorksheet.Cells[i + 2, 11] = reviewerList[i].Email;
            }

            // "Save as" dialogue box
            xlApp.DisplayAlerts = false;
            Excel.Dialog saveAsDialog = xlApp.Dialogs[Excel.XlBuiltInDialog.xlDialogSaveAs];
            saveAsDialog.Show("ReviewerReport");

            xlWorkbook.Close();
            xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Method <c>DownloadReviews</c> return a file of the Reviewer Report. This method essentially creates 
        /// an Excel file while downloading the information from the database. This method forces the program to be
        /// run on a Windows 10 OS because of the Excel file creation and download.
        /// </summary>
        /// <returns>an HTML page of the index page if the file has been downloaded correctly.</returns>
        public IActionResult DownloadReviews()
        {
            // Attempt to initialize Excel
            Excel.Application xlApp = new();
            if (xlApp == null)
            {
                ViewBag.Message("Excel not installed on this device");
                return View();
            }

            // Generate new blank workbook and enter initial sheet
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add(Missing.Value);
            Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.ActiveSheet;

            // Populate table headers
            xlWorksheet.Cells[1, 1] = "Paper Number";
            xlWorksheet.Cells[1, 2] = "Appropriateness of Topic";
            xlWorksheet.Cells[1, 3] = "Timeliness of Topic";
            xlWorksheet.Cells[1, 4] = "Supportive Evidence";
            xlWorksheet.Cells[1, 5] = "Technical Quality";
            xlWorksheet.Cells[1, 6] = "Scope of Coverage";
            xlWorksheet.Cells[1, 7] = "Citation of Previous Work";
            xlWorksheet.Cells[1, 8] = "Originality";
            xlWorksheet.Cells[1, 9] = "Organization of Paper";
            xlWorksheet.Cells[1, 10] = "Clarity of Main Message";
            xlWorksheet.Cells[1, 11] = "Mechanics";
            xlWorksheet.Cells[1, 12] = "Suitability for Presentation";
            xlWorksheet.Cells[1, 13] = "Potential Interest in Topic";
            xlWorksheet.Cells[1, 14] = "Overall Rating";

            // Fetch and populate review data
            ReviewDAO reviewDataAccess = new();
            List<ReviewModel> reviewList = reviewDataAccess.FetchAll();

            for (int i = 0; i < reviewList.Count; i++)
            {
                xlWorksheet.Cells[i + 2, 1] = reviewList[i].PaperID;
                xlWorksheet.Cells[i + 2, 2] = reviewList[i].AppropriatenessOfTopic;
                xlWorksheet.Cells[i + 2, 3] = reviewList[i].TimelinessOfTopic;
                xlWorksheet.Cells[i + 2, 4] = reviewList[i].SupportiveEvidence;
                xlWorksheet.Cells[i + 2, 5] = reviewList[i].TechnicalQuality;
                xlWorksheet.Cells[i + 2, 6] = reviewList[i].ScopeOfCoverage;
                xlWorksheet.Cells[i + 2, 7] = reviewList[i].CitationOfPreviousWork;
                xlWorksheet.Cells[i + 2, 8] = reviewList[i].Originality;
                xlWorksheet.Cells[i + 2, 9] = reviewList[i].OrganizationOfPaper;
                xlWorksheet.Cells[i + 2, 10] = reviewList[i].ClarityOfMainMessage;
                xlWorksheet.Cells[i + 2, 11] = reviewList[i].Mechanics;
                xlWorksheet.Cells[i + 2, 12] = reviewList[i].SuitabilityForPresentation;
                xlWorksheet.Cells[i + 2, 13] = reviewList[i].PotentialInterestInTopic;
                xlWorksheet.Cells[i + 2, 14] = reviewList[i].OverallRating;
            }

            // "Save as" dialogue box
            xlApp.DisplayAlerts = false;
            Excel.Dialog saveAsDialog = xlApp.Dialogs[Excel.XlBuiltInDialog.xlDialogSaveAs];
            saveAsDialog.Show("PaperReviewsSheet");

            xlWorkbook.Close();
            xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

            return RedirectToAction("Index");            
        }

        /// <summary>
        /// Method <c>DownloadReviewSummary</c> return a file of the Reviewer Report. This method essentially creates 
        /// an Excel file while downloading the information from the database. This method forces the program to be
        /// run on a Windows 10 OS because of the Excel file creation and download.
        /// </summary>
        /// <returns>an HTML page of the index page if the file has been downloaded correctly.</returns>
        public IActionResult DownloadReviewSummary()
        {
            // Attempt to initialize Excel
            Excel.Application xlApp = new();
            if (xlApp == null)
            {
                ViewBag.Message("Excel not installed on this device");
                return View();
            }

            // Generate new blank workbook and enter initial sheet
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add(Missing.Value);
            Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.ActiveSheet;

            // Format column for weighted score to two decimal places
            Excel.Range formatRange = xlWorksheet.Range["B1", "P1"];
            formatRange.EntireColumn.NumberFormat = "#.00";

            // Populate table headers
            xlWorksheet.Cells[1, 1] = "Title";
            xlWorksheet.Cells[1, 2] = "Appropriateness of Topic";
            xlWorksheet.Cells[1, 3] = "Timeliness of Topic";
            xlWorksheet.Cells[1, 4] = "Supportive Evidence";
            xlWorksheet.Cells[1, 5] = "Technical Quality";
            xlWorksheet.Cells[1, 6] = "Scope of Coverage";
            xlWorksheet.Cells[1, 7] = "Citation of Previous Work";
            xlWorksheet.Cells[1, 8] = "Originality";
            xlWorksheet.Cells[1, 9] = "Organization of Paper";
            xlWorksheet.Cells[1, 10] = "Clarity of Main Message";
            xlWorksheet.Cells[1, 11] = "Mechanics";
            xlWorksheet.Cells[1, 12] = "Suitability for Presentation";
            xlWorksheet.Cells[1, 13] = "Potential Interest in Topic";
            xlWorksheet.Cells[1, 14] = "Overall Rating";
            xlWorksheet.Cells[1, 15] = "File Name";
            xlWorksheet.Cells[1, 16] = "Weighted Score";

            // Fetch relevant data and populate spreadsheet
            ReportDAO reportDataAccess = new();
            List<ReportInfoModel> reviewList = reportDataAccess.FetchReviewSummary();

            int i;
            for (i = 0; i < reviewList.Count; i++)
            {
                xlWorksheet.Cells[i + 2, 1] = reviewList[i].Paper.Title;
                xlWorksheet.Cells[i + 2, 2] = reviewList[i].Review.AppropriatenessOfTopic;
                xlWorksheet.Cells[i + 2, 3] = reviewList[i].Review.TimelinessOfTopic;
                xlWorksheet.Cells[i + 2, 4] = reviewList[i].Review.SupportiveEvidence;
                xlWorksheet.Cells[i + 2, 5] = reviewList[i].Review.TechnicalQuality;
                xlWorksheet.Cells[i + 2, 6] = reviewList[i].Review.ScopeOfCoverage;
                xlWorksheet.Cells[i + 2, 7] = reviewList[i].Review.CitationOfPreviousWork;
                xlWorksheet.Cells[i + 2, 8] = reviewList[i].Review.Originality;
                xlWorksheet.Cells[i + 2, 9] = reviewList[i].Review.OrganizationOfPaper;
                xlWorksheet.Cells[i + 2, 10] = reviewList[i].Review.ClarityOfMainMessage;
                xlWorksheet.Cells[i + 2, 11] = reviewList[i].Review.Mechanics;
                xlWorksheet.Cells[i + 2, 12] = reviewList[i].Review.SuitabilityForPresentation;
                xlWorksheet.Cells[i + 2, 13] = reviewList[i].Review.PotentialInterestInTopic;
                xlWorksheet.Cells[i + 2, 14] = reviewList[i].Review.OverallRating;
                xlWorksheet.Cells[i + 2, 15] = reviewList[i].Paper.Filename;
                xlWorksheet.Cells[i + 2, 16] = String.Format("=0.5*AVERAGE(B{0}:M{0})+0.5*N{0}", i + 2);
            }

            // Generate bar chart
            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorksheet.ChartObjects(Type.Missing);
            Excel.ChartObject chartObj = xlCharts.Add(10, (i * 20) + 15, (i * 25) + 250, 250);
            Excel.Chart scoreChart = chartObj.Chart;

            Excel.Range chartRange = xlWorksheet.Range["O1", String.Format("P{0}", i + 1)];

            scoreChart.SetSourceData(chartRange);
            scoreChart.ChartType = Excel.XlChartType.xlColumnClustered;

            // "Save as" dialogue box
            xlApp.DisplayAlerts = false;
            Excel.Dialog saveAsDialog = xlApp.Dialogs[Excel.XlBuiltInDialog.xlDialogSaveAs];
            saveAsDialog.Show("PaperReviewSummaryReport");

            xlWorkbook.Close();
            xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Method <c>DownloadReviewerComments</c> return a file of the Reviewer Report. This method essentially creates 
        /// an Excel file while downloading the information from the database. This method forces the program to be
        /// run on a Windows 10 OS because of the Excel file creation and download.
        /// </summary>
        /// <returns>an HTML page of the index page if the file has been downloaded correctly.</returns>
        public IActionResult DownloadReviewerComments()
        {
            // Attempt to initialize Excel
            Excel.Application xlApp = new();
            if (xlApp == null)
            {
                ViewBag.Message("Excel not installed on this device");
                return View();
            }

            // Generate new blank workbook and enter initial sheet
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add(Missing.Value);
            Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.ActiveSheet;

            // Populate table headers
            xlWorksheet.Cells[1, 1] = "Last Name";
            xlWorksheet.Cells[1, 2] = "First Name";
            xlWorksheet.Cells[1, 3] = "Middle Initial";
            xlWorksheet.Cells[1, 4] = "Email Address";
            xlWorksheet.Cells[1, 5] = "File Name";
            xlWorksheet.Cells[1, 6] = "Title";
            xlWorksheet.Cells[1, 7] = "Content Comments";
            xlWorksheet.Cells[1, 8] = "Written Document Comments";
            xlWorksheet.Cells[1, 9] = "Potential for Oral Presentation Comments";
            xlWorksheet.Cells[1, 10] = "Overall Rating Comments";

            // Fetch relevant data and populate spreadsheet
            ReportDAO reportDataAccess = new();
            List<ReportInfoModel> infoList = reportDataAccess.FetchComments();

            int i;
            for (i = 0; i < infoList.Count; i++)
            {
                xlWorksheet.Cells[i + 2, 1] = infoList[i].Author.FirstName;
                xlWorksheet.Cells[i + 2, 2] = infoList[i].Author.LastName;
                xlWorksheet.Cells[i + 2, 3] = infoList[i].Author.MiddleInitial;
                xlWorksheet.Cells[i + 2, 4] = infoList[i].Author.Email;
                xlWorksheet.Cells[i + 2, 5] = infoList[i].Paper.Filename;
                xlWorksheet.Cells[i + 2, 6] = infoList[i].Paper.Title;
                xlWorksheet.Cells[i + 2, 7] = infoList[i].Review.ContentComments;
                xlWorksheet.Cells[i + 2, 8] = infoList[i].Review.WrittenDocumentComments;
                xlWorksheet.Cells[i + 2, 9] = infoList[i].Review.PotentialForOralPresentationComments;
                xlWorksheet.Cells[i + 2, 10] = infoList[i].Review.OverallRatingComments;
            }

            // "Save as" dialogue box
            xlApp.DisplayAlerts = false;
            Excel.Dialog saveAsDialog = xlApp.Dialogs[Excel.XlBuiltInDialog.xlDialogSaveAs];
            saveAsDialog.Show("ReviewerCommentsReport");

            xlWorkbook.Close();
            xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

            return RedirectToAction("Index");
        }
    }
}

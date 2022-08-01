using Excel = Microsoft.Office.Interop.Excel;
using CPMS.Data;
using CPMS.Models;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using System;
using System.Diagnostics.CodeAnalysis;

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
        [Obsolete("This method is Windows dependent", true)]
        [SuppressMessage("Usage", "CA1416:Validate platform compatibility", Justification = "Not production code.")]
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
        [Obsolete("This method is Windows dependent", true)]
        [SuppressMessage("Usage", "CA1416:Validate platform compatibility", Justification = "Not production code.")]
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
        [Obsolete("This method is Windows dependent", true)]
        [SuppressMessage("Usage", "CA1416:Validate platform compatibility", Justification = "Not production code.")]
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
        [Obsolete("This method is Windows dependent", true)]
        [SuppressMessage("Usage", "CA1416:Validate platform compatibility", Justification = "Not production code.")]
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
        [Obsolete("This method is Windows dependent", true)]
        [SuppressMessage("Usage", "CA1416:Validate platform compatibility", Justification = "Not production code.")]
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


        /// <summary>
        /// Method <c>GenerateAuthorReport</c> return a file of the Author Report.
        /// </summary>
        /// <returns></returns>
        private static async Task GenerateAuthorReport()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _ = System.IO.Directory.CreateDirectory("Report");
            var file = new FileInfo(@"Report/AuthorReport.xlsx");
            DeleteFile(file);
            using var package = new ExcelPackage(file);
            var worksheet = package.Workbook.Worksheets.Add("Main");
            worksheet.Cells[1, 1].Value = "Last Name";
            worksheet.Cells[1, 2].Value = "First Name";
            worksheet.Cells[1, 3].Value = "Middle Initial";
            worksheet.Cells[1, 4].Value = "Affiliation";
            worksheet.Cells[1, 5].Value = "Department";
            worksheet.Cells[1, 6].Value = "Address";
            worksheet.Cells[1, 7].Value = "City";
            worksheet.Cells[1, 8].Value = "State";
            worksheet.Cells[1, 9].Value = "Zip Code";
            worksheet.Cells[1, 10].Value = "Phone Number";
            worksheet.Cells[1, 11].Value = "Email Address";

            AuthorDAO authorDAO = new();
            List<AuthorModel> authorModels = authorDAO.FetchAll();
            for (int i = 0; i < authorModels.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value = authorModels[i].LastName;
                worksheet.Cells[i + 2, 2].Value = authorModels[i].FirstName;
                worksheet.Cells[i + 2, 3].Value = authorModels[i].MiddleInitial;
                worksheet.Cells[i + 2, 4].Value = authorModels[i].Affiliation;
                worksheet.Cells[i + 2, 5].Value = authorModels[i].Department;
                worksheet.Cells[i + 2, 6].Value = authorModels[i].Address;
                worksheet.Cells[i + 2, 7].Value = authorModels[i].City;
                worksheet.Cells[i + 2, 8].Value = authorModels[i].State;
                worksheet.Cells[i + 2, 9].Value = authorModels[i].ZipCode;
                worksheet.Cells[i + 2, 10].Value = authorModels[i].PhoneNumber;
                worksheet.Cells[i + 2, 11].Value = authorModels[i].Email;
            }
            await package.SaveAsync();

        }

        /// <summary>
        /// Method <c>GenerateReviewerReport</c> return a file of the Reviewer Report.
        /// </summary>
        /// <returns></returns>
        private static async Task GenerateReviewerReport()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _ = System.IO.Directory.CreateDirectory("Report");
            var file = new FileInfo(@"Report/ReviewerReport.xlsx");
            DeleteFile(file);
            using var package = new ExcelPackage(file);
            var worksheet = package.Workbook.Worksheets.Add("Main");
            worksheet.Cells[1, 1].Value = "Last Name";
            worksheet.Cells[1, 2].Value = "First Name";
            worksheet.Cells[1, 3].Value = "Middle Initial";
            worksheet.Cells[1, 4].Value = "Affiliation";
            worksheet.Cells[1, 5].Value = "Department";
            worksheet.Cells[1, 6].Value = "Address";
            worksheet.Cells[1, 7].Value = "City";
            worksheet.Cells[1, 8].Value = "State";
            worksheet.Cells[1, 9].Value = "Zip Code";
            worksheet.Cells[1, 10].Value = "Phone Number";
            worksheet.Cells[1, 11].Value = "Email Address";

            ReviewerDAO reviewerDAO = new();
            List<ReviewerModel> reviewerModels = reviewerDAO.FetchAll();
            for (int i = 0; i < reviewerModels.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value = reviewerModels[i].LastName;
                worksheet.Cells[i + 2, 2].Value = reviewerModels[i].FirstName;
                worksheet.Cells[i + 2, 3].Value = reviewerModels[i].MiddleInitial;
                worksheet.Cells[i + 2, 4].Value = reviewerModels[i].Affiliation;
                worksheet.Cells[i + 2, 5].Value = reviewerModels[i].Department;
                worksheet.Cells[i + 2, 6].Value = reviewerModels[i].Address;
                worksheet.Cells[i + 2, 7].Value = reviewerModels[i].City;
                worksheet.Cells[i + 2, 8].Value = reviewerModels[i].State;
                worksheet.Cells[i + 2, 9].Value = reviewerModels[i].ZipCode;
                worksheet.Cells[i + 2, 10].Value = reviewerModels[i].PhoneNumber;
                worksheet.Cells[i + 2, 11].Value = reviewerModels[i].Email;
            }
            await package.SaveAsync();
        }

        /// <summary>
        /// Method <c>GenerateReviewReport</c> return a file of the Review Report.
        /// </summary>
        /// <returns></returns>
        private static async Task GenerateReviewReport()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _ = System.IO.Directory.CreateDirectory("Report");
            var file = new FileInfo(@"Report/PaperReviewsSheet.xlsx");
            DeleteFile(file);
            using var package = new ExcelPackage(file);
            var worksheet = package.Workbook.Worksheets.Add("Main");
            worksheet.Cells[1, 1].Value = "Paper Number";
            worksheet.Cells[1, 2].Value = "Appropriateness of Topic";
            worksheet.Cells[1, 3].Value = "Timeliness of Topic";
            worksheet.Cells[1, 4].Value = "Supportive Evidence";
            worksheet.Cells[1, 5].Value = "Technical Quality";
            worksheet.Cells[1, 6].Value = "Scope of Coverage";
            worksheet.Cells[1, 7].Value = "Citation of Previous Work";
            worksheet.Cells[1, 8].Value = "Originality";
            worksheet.Cells[1, 9].Value = "Organization of Paper";
            worksheet.Cells[1, 10].Value = "Clarity of Main Message";
            worksheet.Cells[1, 11].Value = "Mechanics";
            worksheet.Cells[1, 12].Value = "Suitability for Presentation";
            worksheet.Cells[1, 13].Value = "Potential Interest in Topic";
            worksheet.Cells[1, 14].Value = "Overall Rating";

            // Fetch and populate review data
            ReviewDAO reviewDAO = new();
            List<ReviewModel> reviewModels = reviewDAO.FetchAll();

            for (int i = 0; i < reviewModels.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value = reviewModels[i].PaperID;
                worksheet.Cells[i + 2, 2].Value = reviewModels[i].AppropriatenessOfTopic;
                worksheet.Cells[i + 2, 3].Value = reviewModels[i].TimelinessOfTopic;
                worksheet.Cells[i + 2, 4].Value = reviewModels[i].SupportiveEvidence;
                worksheet.Cells[i + 2, 5].Value = reviewModels[i].TechnicalQuality;
                worksheet.Cells[i + 2, 6].Value = reviewModels[i].ScopeOfCoverage;
                worksheet.Cells[i + 2, 7].Value = reviewModels[i].CitationOfPreviousWork;
                worksheet.Cells[i + 2, 8].Value = reviewModels[i].Originality;
                worksheet.Cells[i + 2, 9].Value = reviewModels[i].OrganizationOfPaper;
                worksheet.Cells[i + 2, 10].Value = reviewModels[i].ClarityOfMainMessage;
                worksheet.Cells[i + 2, 11].Value = reviewModels[i].Mechanics;
                worksheet.Cells[i + 2, 12].Value = reviewModels[i].SuitabilityForPresentation;
                worksheet.Cells[i + 2, 13].Value = reviewModels[i].PotentialInterestInTopic;
                worksheet.Cells[i + 2, 14].Value = reviewModels[i].OverallRating;
            }
            await package.SaveAsync();
        }

        /// <summary>
        /// Method <c>GenerateReviewSummaryReport</c> return a file of the Review Summary Report.
        /// </summary>
        /// <returns></returns>
        private static async Task GenerateReviewSummaryReport()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _ = System.IO.Directory.CreateDirectory("Report");
            var file = new FileInfo(@"Report/PaperReviewSummaryReport.xlsx");
            DeleteFile(file);
            using var package = new ExcelPackage(file);
            var worksheet = package.Workbook.Worksheets.Add("Main");
            worksheet.Cells["B1:P1"].EntireColumn.Style.Numberformat.Format = "#.00";

            worksheet.Cells[1, 1].Value     = "Title";
            worksheet.Cells[1, 2].Value     = "Appropriateness of Topic";
            worksheet.Cells[1, 3].Value     = "Timeliness of Topic";
            worksheet.Cells[1, 4].Value     = "Supportive Evidence";
            worksheet.Cells[1, 5].Value     = "Technical Quality";
            worksheet.Cells[1, 6].Value     = "Scope of Coverage";
            worksheet.Cells[1, 7].Value     = "Citation of Previous Work";
            worksheet.Cells[1, 8].Value     = "Originality";
            worksheet.Cells[1, 9].Value     = "Organization of Paper";
            worksheet.Cells[1, 10].Value    = "Clarity of Main Message";
            worksheet.Cells[1, 11].Value    = "Mechanics";
            worksheet.Cells[1, 12].Value    = "Suitability for Presentation";
            worksheet.Cells[1, 13].Value    = "Potential Interest in Topic";
            worksheet.Cells[1, 14].Value    = "Overall Rating";
            worksheet.Cells[1, 15].Value    = "File Name";
            worksheet.Cells[1, 16].Value    = "Weighted Score";

            ReportDAO reportDAO = new();
            List<ReportInfoModel> reviewList = reportDAO.FetchReviewSummary();

            int i;
            for (i = 0; i < reviewList.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value     = reviewList[i].Paper.Title;
                worksheet.Cells[i + 2, 2].Value     = reviewList[i].Review.AppropriatenessOfTopic;
                worksheet.Cells[i + 2, 3].Value     = reviewList[i].Review.TimelinessOfTopic;
                worksheet.Cells[i + 2, 4].Value     = reviewList[i].Review.SupportiveEvidence;
                worksheet.Cells[i + 2, 5].Value     = reviewList[i].Review.TechnicalQuality;
                worksheet.Cells[i + 2, 6].Value     = reviewList[i].Review.ScopeOfCoverage;
                worksheet.Cells[i + 2, 7].Value     = reviewList[i].Review.CitationOfPreviousWork;
                worksheet.Cells[i + 2, 8].Value     = reviewList[i].Review.Originality;
                worksheet.Cells[i + 2, 9].Value     = reviewList[i].Review.OrganizationOfPaper;
                worksheet.Cells[i + 2, 10].Value    = reviewList[i].Review.ClarityOfMainMessage;
                worksheet.Cells[i + 2, 11].Value    = reviewList[i].Review.Mechanics;
                worksheet.Cells[i + 2, 12].Value    = reviewList[i].Review.SuitabilityForPresentation;
                worksheet.Cells[i + 2, 13].Value    = reviewList[i].Review.PotentialInterestInTopic;
                worksheet.Cells[i + 2, 14].Value    = reviewList[i].Review.OverallRating;
                worksheet.Cells[i + 2, 15].Value    = reviewList[i].Paper.Filename;
                worksheet.Cells[i + 2, 16].Formula  = string.Format("=0.5*AVERAGE(B{0}:M{0})+0.5*N{0}", i + 2);
            }

            ExcelChart chart = worksheet.Drawings.AddChart("chtline", eChartType.ColumnClustered);

            var rangeLabel = worksheet.Cells["O2"];
            var range = worksheet.Cells["P2"];
            
            chart.Series.Add(range, rangeLabel);
            chart.Series[0].Header = worksheet.Cells["P1"].Value.ToString();
            chart.Title.Text = worksheet.Cells["P1"].Value.ToString();
            chart.SetPosition(0, 0, 18, 5);
            chart.YAxis.AddTitle("Weighted Score");
            chart.YAxis.Title.Rotation = 270;
            chart.XAxis.AddTitle("Paper Name");
            chart.YAxis.MaxValue = 5;
            chart.YAxis.MinValue = 0;
            chart.YAxis.MinorTickMark = eAxisTickMark.None;
            chart.SetSize(600, 300);

            await package.SaveAsync();
        }

        /// <summary>
        /// Method <c>GenerateReviewerComments</c> return a file of the Review Comment Report.
        /// </summary>
        /// <returns></returns>
        private static async Task GenerateReviewerComments()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _ = System.IO.Directory.CreateDirectory("Report");
            var file = new FileInfo(@"Report/ReviewerCommentsReport.xlsx");
            DeleteFile(file);
            using var package = new ExcelPackage(file);
            var worksheet = package.Workbook.Worksheets.Add("Main");

            worksheet.Cells[1, 1].Value = "Last Name";
            worksheet.Cells[1, 2].Value = "First Name";
            worksheet.Cells[1, 3].Value = "Middle Initial";
            worksheet.Cells[1, 4].Value = "Email Address";
            worksheet.Cells[1, 5].Value = "File Name";
            worksheet.Cells[1, 6].Value = "Title";
            worksheet.Cells[1, 7].Value = "Content Comments";
            worksheet.Cells[1, 8].Value = "Written Document Comments";
            worksheet.Cells[1, 9].Value = "Potential for Oral Presentation Comments";
            worksheet.Cells[1, 10].Value = "Overall Rating Comments";

            ReportDAO reportDAO = new();
            List<ReportInfoModel> reportInfoModels = reportDAO.FetchComments();

            for (int i = 0; i < reportInfoModels.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value = reportInfoModels[i].Author.FirstName;
                worksheet.Cells[i + 2, 2].Value = reportInfoModels[i].Author.LastName;
                worksheet.Cells[i + 2, 3].Value = reportInfoModels[i].Author.MiddleInitial;
                worksheet.Cells[i + 2, 4].Value = reportInfoModels[i].Author.Email;
                worksheet.Cells[i + 2, 5].Value = reportInfoModels[i].Paper.Filename;
                worksheet.Cells[i + 2, 6].Value = reportInfoModels[i].Paper.Title;
                worksheet.Cells[i + 2, 7].Value = reportInfoModels[i].Review.ContentComments;
                worksheet.Cells[i + 2, 8].Value = reportInfoModels[i].Review.WrittenDocumentComments;
                worksheet.Cells[i + 2, 9].Value = reportInfoModels[i].Review.PotentialForOralPresentationComments;
                worksheet.Cells[i + 2, 10].Value = reportInfoModels[i].Review.OverallRatingComments;
            }

            await package.SaveAsync();
        }

        /// <summary>
        /// Method <c>DeleteFile</c> deletes a file if the file exists in the
        /// specified folder.
        /// </summary>
        /// <param name="file">File object containing data including complete path and file name.</param>
        private static void DeleteFile(FileInfo file)
        {
            if (file.Exists)
            {
                file.Delete();
            }
        }

        /// <summary>
        /// Method <c>DownloadFile</c> lets the user download file from the server. 
        /// </summary>
        /// <param name="report">Report name that the user wants to download</param>
        /// <returns>Report file (in excel format)</returns>
        public async Task<FileResult> DownloadFile (string report)
        {

            string? fileName;
            var possibleAction = report.ToLower();
            switch (possibleAction)
            {
                case "author":
                    fileName = "AuthorReport.xlsx";
                    _ = GenerateAuthorReport();
                    break;

                case "reviewer":
                    fileName = "ReviewerReport.xlsx";
                    _ = GenerateReviewerReport();
                    break;

                case "review":
                    fileName = "PaperReviewsSheet.xlsx";
                    _ = GenerateReviewReport();
                    break;

                case "review summary":
                    fileName = "PaperReviewSummaryReport.xlsx";
                    _ = GenerateReviewSummaryReport();
                    break;

                case "review comments":
                    fileName = "ReviewerCommentsReport.xlsx";
                    _ = GenerateReviewerComments();
                    break;

                default:
                    fileName = "";
                    break;
            }
            var fileVirtualPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Report/")) + fileName;
            byte[] bytes;
            try
            {
                bytes =  System.IO.File.ReadAllBytes(fileVirtualPath);
            }

            catch
            {
                Thread.Sleep(500); // easy way to prevent thread collision. 
                using FileStream fileStream = System.IO.File.Open(fileVirtualPath, FileMode.Open);
                bytes = new byte[fileStream.Length];
                await fileStream.ReadAsync(bytes.AsMemory(0, (int)fileStream.Length));
            }
            return File(bytes, "application/octet-stream", fileName);
        }
    }
}

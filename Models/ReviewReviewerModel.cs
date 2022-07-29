using System.ComponentModel.DataAnnotations;

namespace CPMS.Models
{
    /// <summary>
    /// Class <c>ReviewReviewerModel</c> depicts the model of the review as well as the Title and 
    /// Original FileName of the submitted paper.
    /// </summary>
    public class ReviewReviewerModel : ReviewModel
    {
       
        [Display(Name = "Paper Title")]
        public string? Title { get; set; }


        [Display(Name = "Original Title")]
        public string? FilenameOriginal { get; set; }


        [Display(Name = "Author Name")]
        public string? AuthorName { get; set; }


        [Display(Name = "Reviewer Name")]
        public string? ReviewerName { get; set; }
    }
}

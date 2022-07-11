using System.ComponentModel.DataAnnotations;

namespace CPMS.Models
{
    public class ReviewModel
    {
        [Display(Name = "Review ID")]
        [Range(0, 100000, ErrorMessage = "ID must be between 1 and 100000")]
        [Required(ErrorMessage = "Review ID is required")]
        public int ReviewID { get; set; }

        [Display(Name = "Paper ID")]
        public int PaperID { get; set; }


        [Display(Name = "Reviewer ID")]
        public int ReviewerID { get; set; }


        [Display(Name = "Appropriateness Of Topic")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0.00, 5.00, ErrorMessage = "Score must be between 0.00 and 5.00")]
        public decimal AppropriatenessOfTopic { get; set; }

        [Display(Name = "Timeliness Of Topic")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0.00, 5.00, ErrorMessage = "Score must be between 0.00 and 5.00")]
        public decimal TimelinessOfTopic { get; set; }


        [Display(Name = "Supportive Evidence")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0.00, 5.00, ErrorMessage = "Score must be between 0.00 and 5.00")]
        public decimal SupportiveEvidence { get; set; }

        [Display(Name = "Technical Quality")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0.00, 5.00, ErrorMessage = "Score must be between 0.00 and 5.00")]
        public decimal TechnicalQuality { get; set; }


        [Display(Name = "Scope Of Coverage")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0.00, 5.00, ErrorMessage = "Score must be between 0.00 and 5.00")]
        public decimal ScopeOfCoverage { get; set; }

        [Display(Name = "Citation Of Previous Work")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0.00, 5.00, ErrorMessage = "Score must be between 0.00 and 5.00")]
        public decimal CitationOfPreviousWork { get; set; }

        [Display(Name = "Originality")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0.00, 5.00, ErrorMessage = "Score must be between 0.00 and 5.00")]
        public decimal Originality { get; set; }

        [Display(Name = "Content Comments")]
        public string? ContentComments { get; set; }

        [Display(Name = "Organization Of Paper")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0.00, 5.00, ErrorMessage = "Score must be between 0.00 and 5.00")]
        public decimal OrganizationOfPaper { get; set; }

        [Display(Name = "Clarity Of Main Message")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0.00, 5.00, ErrorMessage = "Score must be between 0.00 and 5.00")]
        public decimal ClarityOfMainMessage { get; set; }

        [Display(Name = "Mechanics")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0.00, 5.00, ErrorMessage = "Score must be between 0.00 and 5.00")]
        public decimal Mechanics { get; set; }

        [Display(Name = "Written Document Comments")]
        public string? WrittenDocumentComments { get; set; }

        [Display(Name = "Suitability For Presentation")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0.00, 5.00, ErrorMessage = "Score must be between 0.00 and 5.00")]
        public decimal SuitabilityForPresentation { get; set; }

        [Display(Name = "Potential Interest In Topic")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0.00, 5.00, ErrorMessage = "Score must be between 0.00 and 5.00")]
        public decimal PotentialInterestInTopic { get; set; }

        [Display(Name = "Potential For Oral Presentation Comments")]
        public string? PotentialForOralPresentationComments { get; set; }

        [Display(Name = "Overall Rating")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0.00, 5.00, ErrorMessage = "Score must be between 0.00 and 5.00")]
        public decimal OverallRating { get; set; }

        [Display(Name = "Overall Rating Comments")]
        public string? OverallRatingComments { get; set; }

        [Display(Name = "Comfort Level Topic")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0.00, 5.00, ErrorMessage = "Score must be between 0.00 and 5.00")]
        public decimal ComfortLevelTopic { get; set; }

        [Display(Name = "Comfort Level Acceptability")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0.00, 5.00, ErrorMessage = "Score must be between 0.00 and 5.00")]
        public decimal ComfortLevelAcceptability { get; set; }

        [Display(Name = "Complete")]
        public bool Complete { get; set; }

    }
}
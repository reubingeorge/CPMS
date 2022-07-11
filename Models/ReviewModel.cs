using System.ComponentModel.DataAnnotations;

namespace CPMS.Models
{
    public class ReviewModel
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID is required")]
        public int ReviewID { get; set; }

        [Display(Name = "Paper ID")]
        public int? PaperID { get; set; }

        [Display(Name = "Reviewer ID")]
        public int? ReviewerID { get; set; }

        [Display(Name = "Appropriateness of Topic")]
        [Range(0, 10)]
        public decimal? AppropriatenessOfTopic { get; set; }

        [Display(Name = "Timeliness of Topic")]
        [Range(0, 10)]
        public decimal? TimelinessOfTopic { get; set; }

        [Display(Name = "Supportive Evidence")]
        [Range(0, 10)]
        public decimal? SupportiveEvidence { get; set; }

        [Display(Name = "Technical Quality")]
        [Range(0, 10)]
        public decimal? TechnicalQuality { get; set; }

        [Display(Name = "Scope of Coverage")]
        [Range(0, 10)]
        public decimal? ScopeOfCoverage { get; set; }

        [Display(Name = "Citation of Previous Work")]
        [Range(0, 10)]
        public decimal? CitationOfPreviousWork { get; set; }

        [Display(Name = "Originality")]
        [Range(0, 10)]
        public decimal? Originality { get; set; }

        [Display(Name = "Comments on Content")]
        public string? ContentComments { get; set; }

        [Display(Name = "Organization of Paper")]
        [Range(0, 10)]
        public decimal? OrganizationOfPaper { get; set; }

        [Display(Name = "Clarity of Main Message")]
        [Range(0, 10)]
        public decimal? ClarityOfMainMessage { get; set; }

        [Display(Name = "Mechanics")]
        [Range(0, 10)]
        public decimal? Mechanics { get; set; }

        [Display(Name = "Comments on Written Document")]
        public string? WrittenDocumentComments { get; set; }

        [Display(Name = "Suitability for Presentation")]
        [Range(0, 10)]
        public decimal? SuitabilityForPresentation { get; set; }

        [Display(Name = "Potential Interest in Topic")]
        [Range(0, 10)]
        public decimal? PotentialInterestInTopic { get; set; }

        [Display(Name = "Comments on Potential for Oral s")]
        public string? PotentialForOralPresentationComments { get; set; }

        [Display(Name = "Overall Rating")]
        [Range(0, 10)]
        public decimal? OverallRating { get; set; }

        [Display(Name = "Comments on Overall Rating")]
        public string? OverallRatingComments { get; set; }

        [Display(Name = "Comfort Level Topic")]
        [Range(0, 10)]
        public decimal? ComfortLevelTopic { get; set; }

        [Display(Name = "Comfort Level Acceptability")]
        [Range(0, 10)]
        public decimal? ComfortLevelAcceptability { get; set; }

        [Display(Name = "Complete")]
        public bool? Complete { get; set; }

        public ReviewModel()
        {
            ReviewID                    = 0;
            PaperID                     = 0;
            ReviewerID                  = 0;    
            AppropriatenessOfTopic      = null;
            TimelinessOfTopic           = null;
            SupportiveEvidence          = null;
            TechnicalQuality            = null;
            ScopeOfCoverage             = null;
            CitationOfPreviousWork      = null;
            Originality                 = null;
            ContentComments             = null;
            OrganizationOfPaper         = null;
            ClarityOfMainMessage        = null;
            Mechanics                   = null;
            WrittenDocumentComments     = null;
            SuitabilityForPresentation  = null;
            PotentialInterestInTopic    = null;
            PotentialForOralPresentationComments = null;
            OverallRating               = null;
            OverallRatingComments       = null;
            ComfortLevelTopic           = null;
            ComfortLevelAcceptability   = null;
            Complete                    = null;
        }
    }
}
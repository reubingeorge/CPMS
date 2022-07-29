namespace CPMS.Models
{
    public class PaperReviewerModel
    {
        public PaperModel PaperModel { get; set; }

        public List<ReviewerModel> AssignedReviewers { get; set; } = new();

        public List<ReviewerModel> AvailableReviewers { get; set; } = new();
    }
}

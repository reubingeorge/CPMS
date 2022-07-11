namespace CPMS.Models
{
    public class SwitchModel
    {
        public bool EnabledReviewers { get; set; }
        public bool EnabledAuthors { get; set; }

        public SwitchModel(bool enabledReviewer, bool enabledAuthor)
        {
            EnabledReviewers = enabledReviewer;
            EnabledAuthors = enabledAuthor;
        }
    }
}

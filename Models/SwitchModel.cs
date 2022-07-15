namespace CPMS.Models
{
    /// <summary>
    /// Class <c>SwitchModel</c> represents the model of the state of the author and reviewer.
    /// </summary>
    public class SwitchModel
    {
        public bool EnabledReviewers { get; set; }
        public bool EnabledAuthors { get; set; }

        /// <summary>
        /// Non-Default constructor
        /// </summary>
        /// <param name="enabledReviewer"></param>
        /// <param name="enabledAuthor"></param>
        public SwitchModel(bool enabledReviewer, bool enabledAuthor)
        {
            EnabledReviewers = enabledReviewer;
            EnabledAuthors = enabledAuthor;
        }
    }
}

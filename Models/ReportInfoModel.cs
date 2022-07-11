namespace CPMS.Models
{
    public class ReportInfoModel
    {
        public ReviewModel Review;
        public AuthorModel Author;
        public PaperModel Paper;

        public ReportInfoModel()
        {
            Review = new ReviewModel();
            Author = new AuthorModel();
            Paper = new PaperModel();
        }
    }
}

using CPMS.Models;
using System.Data.SqlClient;

namespace CPMS.Data
{
    internal class ReportDAO
    {
        private string connectionString =
            @"Data Source=(localdb)\ProjectModels;
                Initial Catalog=CPMS;
                Integrated Security=True;
                Connect Timeout=30;Encrypt=False;
                TrustServerCertificate=False;
                ApplicationIntent=ReadWrite;
                MultiSubnetFailover=False";

        public List<ReportInfoModel> FetchReviewSummary()
        {
            List<ReportInfoModel> reviewList = new();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT MAX(Title), AVG(AppropriatenessOfTopic), AVG(TimelinessOfTopic), " +
                    "AVG(SupportiveEvidence), AVG(TechnicalQuality), AVG(ScopeOfCoverage), " +
                    "AVG(CitationOfPreviousWork), AVG(Originality), AVG(OrganizationOfPaper), " +
                    "AVG(ClarityOfMainMessage), AVG(Mechanics), AVG(SuitabilityForPresentation), " +
                    "AVG(PotentialInterestInTopic), AVG(OverallRating), MAX(Filename) " +
                    "FROM dbo.Review JOIN dbo.Paper ON Review.PaperID = Paper.PaperID " +
                    "GROUP BY Review.PaperID";
                SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ReportInfoModel reviewModel = new();
                        reviewModel.Paper.Title = dataReader.GetString(0);
                        reviewModel.Review.AppropriatenessOfTopic = dataReader.IsDBNull(1) ? null : dataReader.GetDecimal(1);
                        reviewModel.Review.TimelinessOfTopic = dataReader.IsDBNull(2) ? null : dataReader.GetDecimal(2);
                        reviewModel.Review.SupportiveEvidence = dataReader.IsDBNull(3) ? null : dataReader.GetDecimal(3);
                        reviewModel.Review.TechnicalQuality = dataReader.IsDBNull(4) ? null : dataReader.GetDecimal(4);
                        reviewModel.Review.ScopeOfCoverage = dataReader.IsDBNull(5) ? null : dataReader.GetDecimal(5);
                        reviewModel.Review.CitationOfPreviousWork = dataReader.IsDBNull(6) ? null : dataReader.GetDecimal(6);
                        reviewModel.Review.Originality = dataReader.IsDBNull(7) ? null : dataReader.GetDecimal(7);
                        reviewModel.Review.OrganizationOfPaper = dataReader.IsDBNull(8) ? null : dataReader.GetDecimal(8);
                        reviewModel.Review.ClarityOfMainMessage = dataReader.IsDBNull(9) ? null : dataReader.GetDecimal(9);
                        reviewModel.Review.Mechanics = dataReader.IsDBNull(10) ? null : dataReader.GetDecimal(10);
                        reviewModel.Review.SuitabilityForPresentation = dataReader.IsDBNull(11) ? null : dataReader.GetDecimal(11);
                        reviewModel.Review.PotentialInterestInTopic = dataReader.IsDBNull(12) ? null : dataReader.GetDecimal(12);
                        reviewModel.Review.OverallRating = dataReader.IsDBNull(13) ? null : dataReader.GetDecimal(13);
                        reviewModel.Paper.Filename = dataReader.GetString(14);
                        reviewList.Add(reviewModel);
                    }
                }
            }
            return reviewList;
        }

        public List<ReportInfoModel> FetchComments()
        {
            List<ReportInfoModel> infoList = new();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT LastName, FirstName, MiddleInitial, EmailAddress, Filename, Title, " +
                    "ContentComments, WrittenDocumentComments, PotentialForOralPresentationComments, OverallRatingComments " +
                    "FROM dbo.Author JOIN dbo.Paper ON Author.AuthorID = Paper.AuthorID " +
                    "JOIN dbo.Review ON Review.PaperID = Paper.PaperID";
                SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
                sqlConnection.Open();


                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ReportInfoModel infoModel = new();
                        infoModel.Author.FirstName = dataReader.IsDBNull(0) ? null : dataReader.GetString(0);
                        infoModel.Author.LastName = dataReader.IsDBNull(1) ? null : dataReader.GetString(1);
                        infoModel.Author.MiddleInitial = dataReader.IsDBNull(2) ? null : dataReader.GetString(2);
                        infoModel.Author.Email = dataReader.GetString(3);
                        infoModel.Paper.Filename = dataReader.GetString(4);
                        infoModel.Paper.Title = dataReader.GetString(5);
                        infoModel.Review.ContentComments = dataReader.IsDBNull(6) ? null : dataReader.GetString(6);
                        infoModel.Review.WrittenDocumentComments = dataReader.IsDBNull(7) ? null : dataReader.GetString(7);
                        infoModel.Review.PotentialForOralPresentationComments = dataReader.IsDBNull(8) ? null : dataReader.GetString(8);
                        infoModel.Review.OverallRatingComments = dataReader.IsDBNull(9) ? null : dataReader.GetString(9);
                        infoList.Add(infoModel);
                    }
                }
            }
            return infoList;
        }
    }
}

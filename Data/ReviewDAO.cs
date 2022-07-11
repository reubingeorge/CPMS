using CPMS.Models;
using System.Data.SqlClient;

namespace CPMS.Data
{
    internal class ReviewDAO
    {
        private string connectionString =
            @"Data Source=(localdb)\ProjectModels;
                Initial Catalog=CPMS;
                Integrated Security=True;
                Connect Timeout=30;Encrypt=False;
                TrustServerCertificate=False;
                ApplicationIntent=ReadWrite;
                MultiSubnetFailover=False";

        public List<ReviewModel> FetchAll()
        {
            List<ReviewModel> reviewList = new();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Review";
                SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ReviewModel reviewModel             = new();
                        reviewModel.ReviewID                = dataReader.GetInt32(0);
                        reviewModel.PaperID                 = dataReader.IsDBNull(1) ? null : dataReader.GetInt32(1);
                        reviewModel.ReviewerID              = dataReader.IsDBNull(2) ? null : dataReader.GetInt32(2);
                        reviewModel.AppropriatenessOfTopic  = dataReader.IsDBNull(3) ? null : dataReader.GetDecimal(3);
                        reviewModel.TimelinessOfTopic       = dataReader.IsDBNull(4) ? null : dataReader.GetDecimal(4);
                        reviewModel.SupportiveEvidence      = dataReader.IsDBNull(5) ? null : dataReader.GetDecimal(5);
                        reviewModel.TechnicalQuality        = dataReader.IsDBNull(6) ? null : dataReader.GetDecimal(6);
                        reviewModel.ScopeOfCoverage         = dataReader.IsDBNull(7) ? null : dataReader.GetDecimal(7);
                        reviewModel.CitationOfPreviousWork  = dataReader.IsDBNull(8) ? null : dataReader.GetDecimal(8);
                        reviewModel.Originality             = dataReader.IsDBNull(9) ? null : dataReader.GetDecimal(9);
                        reviewModel.ContentComments         = dataReader.IsDBNull(10) ? null : dataReader.GetString(10);
                        reviewModel.OrganizationOfPaper     = dataReader.IsDBNull(11) ? null : dataReader.GetDecimal(11);
                        reviewModel.ClarityOfMainMessage    = dataReader.IsDBNull(12) ? null :dataReader.GetDecimal(12);
                        reviewModel.Mechanics               = dataReader.IsDBNull(13) ? null : dataReader.GetDecimal(13);
                        reviewModel.WrittenDocumentComments = dataReader.IsDBNull(14) ? null : dataReader.GetString(14);
                        reviewModel.SuitabilityForPresentation = dataReader.IsDBNull(15) ? null : dataReader.GetDecimal(15);
                        reviewModel.PotentialInterestInTopic = dataReader.IsDBNull(16) ? null : dataReader.GetDecimal(16);
                        reviewModel.PotentialForOralPresentationComments = dataReader.IsDBNull(17) ? null : dataReader.GetString(17);
                        reviewModel.OverallRating           = dataReader.IsDBNull(18) ? null : dataReader.GetDecimal(18);
                        reviewModel.OverallRatingComments   = dataReader.IsDBNull(19) ? null : dataReader.GetString(19);
                        reviewModel.ComfortLevelTopic       = dataReader.IsDBNull(20) ? null : dataReader.GetDecimal(20);
                        reviewModel.ComfortLevelAcceptability = dataReader.IsDBNull(21) ? null : dataReader.GetDecimal(21);
                        reviewModel.Complete = dataReader.IsDBNull(22) ? null : dataReader.GetBoolean(22);

                        reviewList.Add(reviewModel);
                    }
                }
            }
            return reviewList;
        }
    }
}

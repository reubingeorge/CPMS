using CPMS.Models;
using System.Data.SqlClient;

namespace CPMS.Data
{
    /// <summary>
    /// Class <c>ReviewDAO</c> performs the role of the Data Access Object. This DAO is essentially the connector
    /// between the controller and the database containing the Review table.
    /// </summary>
    internal class ReviewDAO : DAO
    {
        /*private readonly string connectionString =
             @"Data Source=(localdb)\ProjectModels;
                Initial Catalog=CPMS;
                Integrated Security=True;
                Connect Timeout=30;Encrypt=False;
                TrustServerCertificate=False;
                ApplicationIntent=ReadWrite;
                MultiSubnetFailover=False";*/

        /// <summary>
        /// Method <c>FetchAll</c> extracts a list of all reviews available in the database from ONE particular reviewer.
        /// </summary>
        /// <param name="ReviewerID">ID of the reviewer (primary key in the database)</param>
        /// <returns>a list of all reviews made by a reviewer</returns>
        internal List<ReviewModel> FetchAll(int ReviewerID)
        {
            List<ReviewModel> reviewList = new();
            using (SqlConnection sqlConnection = new(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Review WHERE ReviewerID = @ReviewerID";
                SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
                sqlCommand.Parameters.Add("@ReviewerID", System.Data.SqlDbType.Int).Value = ReviewerID;
                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ReviewModel reviewModel = new();
                        reviewModel.ReviewID = dataReader.GetInt32(0);
                        reviewModel.PaperID = dataReader.GetInt32(1);
                        reviewModel.ReviewerID = dataReader.GetInt32(2);
                        reviewModel.AppropriatenessOfTopic = dataReader.GetDecimal(3);
                        reviewModel.TimelinessOfTopic = dataReader.GetDecimal(4);
                        reviewModel.SupportiveEvidence = dataReader.GetDecimal(5);
                        reviewModel.TechnicalQuality = dataReader.GetDecimal(6);
                        reviewModel.ScopeOfCoverage = dataReader.GetDecimal(7);
                        reviewModel.CitationOfPreviousWork = dataReader.GetDecimal(8);
                        reviewModel.Originality = dataReader.GetDecimal(9);
                        reviewModel.ContentComments = dataReader.IsDBNull(10) ? null : dataReader.GetString(10);
                        reviewModel.OrganizationOfPaper = dataReader.GetDecimal(11);
                        reviewModel.ClarityOfMainMessage = dataReader.GetDecimal(12);
                        reviewModel.Mechanics = dataReader.GetDecimal(13);
                        reviewModel.WrittenDocumentComments = dataReader.IsDBNull(14) ? null : dataReader.GetString(14);
                        reviewModel.SuitabilityForPresentation = dataReader.GetDecimal(15);
                        reviewModel.PotentialInterestInTopic = dataReader.GetDecimal(16);
                        reviewModel.PotentialForOralPresentationComments = dataReader.IsDBNull(17) ? null : dataReader.GetString(17);
                        reviewModel.OverallRating = dataReader.GetDecimal(18);
                        reviewModel.OverallRatingComments = dataReader.IsDBNull(19) ? null : dataReader.GetString(19);
                        reviewModel.ComfortLevelTopic = dataReader.GetDecimal(20);
                        reviewModel.ComfortLevelAcceptability = dataReader.GetDecimal(21);
                        reviewModel.Complete = dataReader.GetBoolean(22);

                        reviewList.Add(reviewModel);
                    }
                }
            }
            return reviewList;
        }

        /// <summary>
        /// Method <c>FetchAll</c> extracts a list of all reviews available in the database.
        /// </summary>
        /// <returns>a list of all reviews</returns>
        internal List<ReviewModel> FetchAll()
        {
            List<ReviewModel> reviewList = new();
            using (SqlConnection sqlConnection = new(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Review";
                SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ReviewModel reviewModel = new();
                        reviewModel.ReviewID = dataReader.GetInt32(0);
                        reviewModel.PaperID = dataReader.GetInt32(1);
                        reviewModel.ReviewerID = dataReader.GetInt32(2);
                        reviewModel.AppropriatenessOfTopic = dataReader.GetDecimal(3);
                        reviewModel.TimelinessOfTopic = dataReader.GetDecimal(4);
                        reviewModel.SupportiveEvidence = dataReader.GetDecimal(5);
                        reviewModel.TechnicalQuality = dataReader.GetDecimal(6);
                        reviewModel.ScopeOfCoverage = dataReader.GetDecimal(7);
                        reviewModel.CitationOfPreviousWork = dataReader.GetDecimal(8);
                        reviewModel.Originality = dataReader.GetDecimal(9);
                        reviewModel.ContentComments = dataReader.IsDBNull(10) ? null : dataReader.GetString(10);
                        reviewModel.OrganizationOfPaper = dataReader.GetDecimal(11);
                        reviewModel.ClarityOfMainMessage = dataReader.GetDecimal(12);
                        reviewModel.Mechanics = dataReader.GetDecimal(13);
                        reviewModel.WrittenDocumentComments = dataReader.IsDBNull(14) ? null : dataReader.GetString(14);
                        reviewModel.SuitabilityForPresentation = dataReader.GetDecimal(15);
                        reviewModel.PotentialInterestInTopic = dataReader.GetDecimal(16);
                        reviewModel.PotentialForOralPresentationComments = dataReader.IsDBNull(17) ? null : dataReader.GetString(17);
                        reviewModel.OverallRating = dataReader.GetDecimal(18);
                        reviewModel.OverallRatingComments = dataReader.IsDBNull(19) ? null : dataReader.GetString(19);
                        reviewModel.ComfortLevelTopic = dataReader.GetDecimal(20);
                        reviewModel.ComfortLevelAcceptability = dataReader.GetDecimal(21);
                        reviewModel.Complete = dataReader.GetBoolean(22);

                        reviewList.Add(reviewModel);
                    }
                }
            }
            return reviewList;
        }

        /// <summary>
        /// Method <c>FetchAllReviews</c> extracts a list of all reviews alongside the corresponding paper 
        /// available in the database from ONE particular reviewer.
        /// </summary>
        /// <param name="ReviewerID">ID of the reviewer (primary key in the database)</param>
        /// <returns>a list of all reviews and corresponding made by a reviewer</returns>
        internal List<ReviewReviewerModel> FetchAllReviews(int ReviewerID)
        {
            List<ReviewReviewerModel> reviewReviewerList = new();
            using (SqlConnection sqlConnection = new(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Review WHERE ReviewerID = @ReviewerID";
                SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
                sqlCommand.Parameters.Add("@ReviewerID", System.Data.SqlDbType.Int).Value = ReviewerID;
                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ReviewReviewerModel reviewReviewerModel = new();
                        reviewReviewerModel.ReviewID = dataReader.GetInt32(0);
                        reviewReviewerModel.PaperID = dataReader.GetInt32(1);
                        reviewReviewerModel.ReviewerID = dataReader.GetInt32(2);
                        reviewReviewerModel.AppropriatenessOfTopic = dataReader.GetDecimal(3);
                        reviewReviewerModel.TimelinessOfTopic = dataReader.GetDecimal(4);
                        reviewReviewerModel.SupportiveEvidence = dataReader.GetDecimal(5);
                        reviewReviewerModel.TechnicalQuality = dataReader.GetDecimal(6);
                        reviewReviewerModel.ScopeOfCoverage = dataReader.GetDecimal(7);
                        reviewReviewerModel.CitationOfPreviousWork = dataReader.GetDecimal(8);
                        reviewReviewerModel.Originality = dataReader.GetDecimal(9);
                        reviewReviewerModel.ContentComments = dataReader.IsDBNull(10) ? null : dataReader.GetString(10);
                        reviewReviewerModel.OrganizationOfPaper = dataReader.GetDecimal(11);
                        reviewReviewerModel.ClarityOfMainMessage = dataReader.GetDecimal(12);
                        reviewReviewerModel.Mechanics = dataReader.GetDecimal(13);
                        reviewReviewerModel.WrittenDocumentComments = dataReader.IsDBNull(14) ? null : dataReader.GetString(14);
                        reviewReviewerModel.SuitabilityForPresentation = dataReader.GetDecimal(15);
                        reviewReviewerModel.PotentialInterestInTopic = dataReader.GetDecimal(16);
                        reviewReviewerModel.PotentialForOralPresentationComments = dataReader.IsDBNull(17) ? null : dataReader.GetString(17);
                        reviewReviewerModel.OverallRating = dataReader.GetDecimal(18);
                        reviewReviewerModel.OverallRatingComments = dataReader.IsDBNull(19) ? null : dataReader.GetString(19);
                        reviewReviewerModel.ComfortLevelTopic = dataReader.GetDecimal(20);
                        reviewReviewerModel.ComfortLevelAcceptability = dataReader.GetDecimal(21);
                        reviewReviewerModel.Complete = dataReader.GetBoolean(22);

                        PaperDAO paperDAO = new();
                        PaperModel paperModel = paperDAO.FetchOne(reviewReviewerModel.PaperID);

                        reviewReviewerModel.Title = paperModel.Title;
                        reviewReviewerModel.FilenameOriginal = paperModel.FilenameOriginal;
                        reviewReviewerList.Add(reviewReviewerModel);
                    }
                }
            }
            return reviewReviewerList;
        }

        /// <summary>
        /// Method <c>FetchOne</c> extracts one review alongside the corresponding paper 
        /// available in the database.
        /// </summary>
        /// <param name="reviewID">ID of the review (primary key in the database)</param>
        /// <returns>An object that contains the information about the review.</returns>
        internal ReviewReviewerModel FetchOne(int reviewID)
        {
            ReviewReviewerModel reviewReviewerModel = new();
            using (SqlConnection sqlConnection = new(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Review WHERE ReviewID = @ReviewID";
                SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
                sqlCommand.Parameters.Add("@ReviewID", System.Data.SqlDbType.Int).Value = reviewID;
                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        reviewReviewerModel.ReviewID = dataReader.GetInt32(0);
                        reviewReviewerModel.PaperID = dataReader.GetInt32(1);
                        reviewReviewerModel.ReviewerID = dataReader.GetInt32(2);
                        reviewReviewerModel.AppropriatenessOfTopic = dataReader.GetDecimal(3);
                        reviewReviewerModel.TimelinessOfTopic = dataReader.GetDecimal(4);
                        reviewReviewerModel.SupportiveEvidence = dataReader.GetDecimal(5);
                        reviewReviewerModel.TechnicalQuality = dataReader.GetDecimal(6);
                        reviewReviewerModel.ScopeOfCoverage = dataReader.GetDecimal(7);
                        reviewReviewerModel.CitationOfPreviousWork = dataReader.GetDecimal(8);
                        reviewReviewerModel.Originality = dataReader.GetDecimal(9);
                        reviewReviewerModel.ContentComments = dataReader.IsDBNull(10) ? null : dataReader.GetString(10);
                        reviewReviewerModel.OrganizationOfPaper = dataReader.GetDecimal(11);
                        reviewReviewerModel.ClarityOfMainMessage = dataReader.GetDecimal(12);
                        reviewReviewerModel.Mechanics = dataReader.GetDecimal(13);
                        reviewReviewerModel.WrittenDocumentComments = dataReader.IsDBNull(14) ? null : dataReader.GetString(14);
                        reviewReviewerModel.SuitabilityForPresentation = dataReader.GetDecimal(15);
                        reviewReviewerModel.PotentialInterestInTopic = dataReader.GetDecimal(16);
                        reviewReviewerModel.PotentialForOralPresentationComments = dataReader.IsDBNull(17) ? null : dataReader.GetString(17);
                        reviewReviewerModel.OverallRating = dataReader.GetDecimal(18);
                        reviewReviewerModel.OverallRatingComments = dataReader.IsDBNull(19) ? null : dataReader.GetString(19);
                        reviewReviewerModel.ComfortLevelTopic = dataReader.GetDecimal(20);
                        reviewReviewerModel.ComfortLevelAcceptability = dataReader.GetDecimal(21);
                        reviewReviewerModel.Complete = dataReader.GetBoolean(22);

                        PaperDAO paperDAO = new();
                        PaperModel paperModel = paperDAO.FetchOne(reviewReviewerModel.PaperID);

                        reviewReviewerModel.Title = paperModel.Title;
                        reviewReviewerModel.FilenameOriginal = paperModel.FilenameOriginal;

                    }
                }
            }
            return reviewReviewerModel;
        }

        /// <summary>
        /// Method <c>CreateOrUpdate</c> can either edit an existing review or create a new review in the
        /// review table. The operation is chosen based on the ID in the input object. If the ID is less
        /// than or equal to 0 then a create operation is performed or else an update operation is performed.
        /// </summary>
        /// <param name="reviewReviewerModel">Model containing the information of review.</param>
        /// <returns>integer that depicts if the insertion or the update operation has been successfully performed.</returns>
        internal int CreateOrUpdate(ReviewReviewerModel reviewReviewerModel)
        {
            int newID = -1;
            using (SqlConnection sqlConnection = new(connectionString))
            {
                string sqlQuery = "";
                if (reviewReviewerModel.ReviewID <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.Review VALUES(" +
                        "@AppropriatenessOfTopic, " +
                        "@TimelinessOfTopic, " +
                        "@SupportiveEvidence, " +
                        "@TechnicalQuality, " +
                        "@ScopeOfCoverage, " +
                        "@CitationOfPreviousWork, " +
                        "@Originality, " +
                        "@ContentComments, " +
                        "@OrganizationOfPaper, " +
                        "@ClarityOfMainMessage, " +
                        "@Mechanics, " +
                        "@WrittenDocumentComments, " +
                        "@SuitabilityForPresentation, " +
                        "@PotentialInterestInTopic, " +
                        "@PotentialForOralPresentationComments, " +
                        "@OverallRating, " +
                        "@OverallRatingComments, " +
                        "@ComfortLevelTopic, " +
                        "@ComfortLevelAcceptability, " +
                        "@Complete)";
                }
                else
                {
                    sqlQuery = "UPDATE dbo.Review SET " +
                        "AppropriatenessOfTopic = @AppropriatenessOfTopic, " +
                        "TimelinessOfTopic = @TimelinessOfTopic, " +
                        "SupportiveEvidence = @SupportiveEvidence, " +
                        "TechnicalQuality = @TechnicalQuality, " +
                        "ScopeOfCoverage = @ScopeOfCoverage, " +
                        "CitationOfPreviousWork = @CitationOfPreviousWork, " +
                        "Originality = @Originality, " +
                        "ContentComments = @ContentComments, " +
                        "OrganizationOfPaper = @OrganizationOfPaper, " +
                        "ClarityOfMainMessage = @ClarityOfMainMessage, " +
                        "Mechanics= @Mechanics, " +
                        "WrittenDocumentComments = @WrittenDocumentComments, " +
                        "SuitabilityForPresentation = @SuitabilityForPresentation, " +
                        "PotentialInterestInTopic = @PotentialInterestInTopic, " +
                        "PotentialForOralPresentationComments = @PotentialForOralPresentationComments, " +
                        "OverallRating = @OverallRating, " +
                        "OverallRatingComments = @OverallRatingComments, " +
                        "ComfortLevelTopic = @ComfortLevelTopic, " +
                        "ComfortLevelAcceptability = @ComfortLevelAcceptability, " +
                        "Complete = @Complete WHERE " +
                        "ReviewID = @ReviewID";
                }
                SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
                sqlCommand.Parameters.Add("@AppropriatenessOfTopic", System.Data.SqlDbType.Decimal).Value = reviewReviewerModel.AppropriatenessOfTopic;
                sqlCommand.Parameters.Add("@SupportiveEvidence", System.Data.SqlDbType.Decimal).Value = reviewReviewerModel.SupportiveEvidence;
                sqlCommand.Parameters.Add("@TimelinessOfTopic", System.Data.SqlDbType.Decimal).Value = reviewReviewerModel.TimelinessOfTopic;
                sqlCommand.Parameters.Add("@TechnicalQuality", System.Data.SqlDbType.Decimal).Value = reviewReviewerModel.TechnicalQuality;
                sqlCommand.Parameters.Add("@ScopeOfCoverage", System.Data.SqlDbType.Decimal).Value = reviewReviewerModel.ScopeOfCoverage;
                sqlCommand.Parameters.Add("@CitationOfPreviousWork", System.Data.SqlDbType.Decimal).Value = reviewReviewerModel.CitationOfPreviousWork;
                sqlCommand.Parameters.Add("@Originality", System.Data.SqlDbType.Decimal).Value = reviewReviewerModel.Originality;
                sqlCommand.Parameters.Add("@ContentComments", System.Data.SqlDbType.NVarChar, int.MaxValue).Value =
                    string.IsNullOrEmpty(reviewReviewerModel.ContentComments) ? DBNull.Value : reviewReviewerModel.ContentComments;
                sqlCommand.Parameters.Add("@OrganizationOfPaper", System.Data.SqlDbType.Decimal).Value = reviewReviewerModel.OrganizationOfPaper;
                sqlCommand.Parameters.Add("@ClarityOfMainMessage", System.Data.SqlDbType.Decimal).Value = reviewReviewerModel.ClarityOfMainMessage;
                sqlCommand.Parameters.Add("@Mechanics", System.Data.SqlDbType.Decimal).Value = reviewReviewerModel.Mechanics;
                sqlCommand.Parameters.Add("@WrittenDocumentComments", System.Data.SqlDbType.NVarChar, int.MaxValue).Value =
                    string.IsNullOrEmpty(reviewReviewerModel.WrittenDocumentComments) ? DBNull.Value : reviewReviewerModel.WrittenDocumentComments;
                sqlCommand.Parameters.Add("@SuitabilityForPresentation", System.Data.SqlDbType.Decimal).Value = reviewReviewerModel.SuitabilityForPresentation;
                sqlCommand.Parameters.Add("@PotentialInterestInTopic", System.Data.SqlDbType.Decimal).Value = reviewReviewerModel.PotentialInterestInTopic;
                sqlCommand.Parameters.Add("@PotentialForOralPresentationComments", System.Data.SqlDbType.NVarChar, int.MaxValue).Value =
                    string.IsNullOrEmpty(reviewReviewerModel.PotentialForOralPresentationComments) ? DBNull.Value : reviewReviewerModel.PotentialForOralPresentationComments;
                sqlCommand.Parameters.Add("@OverallRating", System.Data.SqlDbType.Decimal).Value = reviewReviewerModel.OverallRating;
                sqlCommand.Parameters.Add("@OverallRatingComments", System.Data.SqlDbType.NVarChar, int.MaxValue).Value =
                    string.IsNullOrEmpty(reviewReviewerModel.OverallRatingComments) ? DBNull.Value : reviewReviewerModel.OverallRatingComments;
                sqlCommand.Parameters.Add("@ComfortLevelTopic", System.Data.SqlDbType.Decimal).Value = reviewReviewerModel.ComfortLevelTopic;
                sqlCommand.Parameters.Add("@ComfortLevelAcceptability", System.Data.SqlDbType.Decimal).Value = reviewReviewerModel.ComfortLevelAcceptability;
                sqlCommand.Parameters.Add("@Complete", System.Data.SqlDbType.Bit).Value = reviewReviewerModel.Complete;
                sqlCommand.Parameters.Add("@ReviewID", System.Data.SqlDbType.Int).Value = reviewReviewerModel.ReviewID;
                sqlConnection.Open();
                newID = sqlCommand.ExecuteNonQuery();
            }

            return newID;
        }

    }
}
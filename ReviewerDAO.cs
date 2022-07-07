using CPMS.Data;
using System.Data.SqlClient;
using CPMS.Models;

namespace CPMS.Data
{
    internal class ReviewerDAO
    {
        private string connectionString = 
            @"Data Source=(localdb)\ProjectModels;
                Initial Catalog=CPMS;
                Integrated Security=True;
                Connect Timeout=30;Encrypt=False;
                TrustServerCertificate=False;
                ApplicationIntent=ReadWrite;
                MultiSubnetFailover=False";

        public List<ReviewerModel> FetchAll()
        {
            List<ReviewerModel> reviewerList = new();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Reviewer";
                SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ReviewerModel reviewerModel = new();
                        reviewerModel.ReviewerID = dataReader.GetInt32(0);
                        reviewerModel.Active = dataReader.GetBoolean(1);
                        reviewerModel.FirstName       = dataReader.IsDBNull(2) ? null : dataReader.GetString(2);
                        reviewerModel.MiddleInitial   = dataReader.IsDBNull(3) ? null : dataReader.GetString(3);
                        reviewerModel.LastName        = dataReader.IsDBNull(4) ? null : dataReader.GetString(4);
                        reviewerModel.Affiliation     = dataReader.IsDBNull(5) ? null : dataReader.GetString(5);
                        reviewerModel.Department      = dataReader.IsDBNull(6) ? null : dataReader.GetString(6);
                        reviewerModel.Address         = dataReader.IsDBNull(7) ? null : dataReader.GetString(7);
                        reviewerModel.City            = dataReader.IsDBNull(8) ? null : dataReader.GetString(8);
                        reviewerModel.State           = dataReader.IsDBNull(9) ? null : dataReader.GetString(9);
                        reviewerModel.ZipCode         = dataReader.IsDBNull(10) ? null : dataReader.GetString(10);
                        reviewerModel.PhoneNumber     = dataReader.IsDBNull(11) ? null : dataReader.GetString(11);
                        reviewerModel.Email           = dataReader.GetString(12);
                        reviewerModel.Password        = dataReader.GetString(13);
                        reviewerModel.AnalysisOfAlgorithms = dataReader.GetBoolean(14);
                        reviewerModel.Architecture = dataReader.GetBoolean(14);
                        reviewerModel.Applications = dataReader.GetBoolean(14);
                        reviewerModel.ArtificialIntelligence = dataReader.GetBoolean(14);
                        reviewerModel.ComputerEngineering = dataReader.GetBoolean(15);
                        reviewerModel.Curriculum = dataReader.GetBoolean(16);
                        reviewerModel.DataStructures = dataReader.GetBoolean(17);
                        reviewerModel.Databases = dataReader.GetBoolean(18);
                        reviewerModel.DistanceLearning = dataReader.GetBoolean(19);
                        reviewerModel.DistributedSystems = dataReader.GetBoolean(20);
                        reviewerModel.EthicalSocialIssues = dataReader.GetBoolean(21);
                        reviewerModel.FirstYearComputing = dataReader.GetBoolean(22);
                        reviewerModel.GenderIssues = dataReader.GetBoolean(23);
                        reviewerModel.GrantWriting = dataReader.GetBoolean(24);
                        reviewerModel.GraphicsImageProcessing = dataReader.GetBoolean(25);
                        reviewerModel.HumanComputerInteraction = dataReader.GetBoolean(26);
                        reviewerModel.LaboratoryEnvironments = dataReader.GetBoolean(27);
                        reviewerModel.Literacy = dataReader.GetBoolean(28);
                        reviewerModel.MathematicsInComputing = dataReader.GetBoolean(29);
                        reviewerModel.Multimedia = dataReader.GetBoolean(30);
                        reviewerModel.NetworkingDataCommunications = dataReader.GetBoolean(31);
                        reviewerModel.NonMajorCourses = dataReader.GetBoolean(32);
                        reviewerModel.ObjectOrientedIssues = dataReader.GetBoolean(33);
                        reviewerModel.OperatingSystems = dataReader.GetBoolean(34);
                        reviewerModel.ParallelProcessing = dataReader.GetBoolean(35);
                        reviewerModel.Pedagogy = dataReader.GetBoolean(36);
                        reviewerModel.ProgrammingLanguages = dataReader.GetBoolean(37);
                        reviewerModel.Research = dataReader.GetBoolean(38);
                        reviewerModel.Security = dataReader.GetBoolean(39);
                        reviewerModel.SoftwareEngineering = dataReader.GetBoolean(40);
                        reviewerModel.SystemsAnalysisAndDesign = dataReader.GetBoolean(41);
                        reviewerModel.UsingTechnologyInTheClassroom = dataReader.GetBoolean(42);
                        reviewerModel.WebAndInternetProgramming = dataReader.GetBoolean(43);
                        reviewerModel.Other = dataReader.GetBoolean(44);
                        reviewerModel.OtherDescription = dataReader.GetString(45);
                        reviewerModel.ReviewsAcknowledged = dataReader.GetBoolean(46);
 
                        reviewerList.Add(reviewerModel);
                    }
                }
            }

            return reviewerList;
        }
         public ReviewerModel FetchOne(int id)
        {
            ReviewerModel reviewerModel = new();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Reviewer where ReviewerID = @id";
                SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
                sqlCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        reviewerModel.ReviewerID = dataReader.GetInt32(0);
                        reviewerModel.Active = dataReader.GetBoolean(1);
                        reviewerModel.FirstName       = dataReader.IsDBNull(2) ? null : dataReader.GetString(2);
                        reviewerModel.MiddleInitial   = dataReader.IsDBNull(3) ? null : dataReader.GetString(3);
                        reviewerModel.LastName        = dataReader.IsDBNull(4) ? null : dataReader.GetString(4);
                        reviewerModel.Affiliation     = dataReader.IsDBNull(5) ? null : dataReader.GetString(5);
                        reviewerModel.Department      = dataReader.IsDBNull(6) ? null : dataReader.GetString(6);
                        reviewerModel.Address         = dataReader.IsDBNull(7) ? null : dataReader.GetString(7);
                        reviewerModel.City            = dataReader.IsDBNull(8) ? null : dataReader.GetString(8);
                        reviewerModel.State           = dataReader.IsDBNull(9) ? null : dataReader.GetString(9);
                        reviewerModel.ZipCode         = dataReader.IsDBNull(10) ? null : dataReader.GetString(10);
                        reviewerModel.PhoneNumber     = dataReader.IsDBNull(11) ? null : dataReader.GetString(11);
                        reviewerModel.Email           = dataReader.GetString(12);
                        reviewerModel.Password        = dataReader.GetString(13);
                        reviewerModel.AnalysisOfAlgorithms = dataReader.GetBoolean(14);
                        reviewerModel.Architecture = dataReader.GetBoolean(14);
                        reviewerModel.Applications = dataReader.GetBoolean(14);
                        reviewerModel.ArtificialIntelligence = dataReader.GetBoolean(14);
                        reviewerModel.ComputerEngineering = dataReader.GetBoolean(15);
                        reviewerModel.Curriculum = dataReader.GetBoolean(16);
                        reviewerModel.DataStructures = dataReader.GetBoolean(17);
                        reviewerModel.Databases = dataReader.GetBoolean(18);
                        reviewerModel.DistanceLearning = dataReader.GetBoolean(19);
                        reviewerModel.DistributedSystems = dataReader.GetBoolean(20);
                        reviewerModel.EthicalSocialIssues = dataReader.GetBoolean(21);
                        reviewerModel.FirstYearComputing = dataReader.GetBoolean(22);
                        reviewerModel.GenderIssues = dataReader.GetBoolean(23);
                        reviewerModel.GrantWriting = dataReader.GetBoolean(24);
                        reviewerModel.GraphicsImageProcessing = dataReader.GetBoolean(25);
                        reviewerModel.HumanComputerInteraction = dataReader.GetBoolean(26);
                        reviewerModel.LaboratoryEnvironments = dataReader.GetBoolean(27);
                        reviewerModel.Literacy = dataReader.GetBoolean(28);
                        reviewerModel.MathematicsInComputing = dataReader.GetBoolean(29);
                        reviewerModel.Multimedia = dataReader.GetBoolean(30);
                        reviewerModel.NetworkingDataCommunications = dataReader.GetBoolean(31);
                        reviewerModel.NonMajorCourses = dataReader.GetBoolean(32);
                        reviewerModel.ObjectOrientedIssues = dataReader.GetBoolean(33);
                        reviewerModel.OperatingSystems = dataReader.GetBoolean(34);
                        reviewerModel.ParallelProcessing = dataReader.GetBoolean(35);
                        reviewerModel.Pedagogy = dataReader.GetBoolean(36);
                        reviewerModel.ProgrammingLanguages = dataReader.GetBoolean(37);
                        reviewerModel.Research = dataReader.GetBoolean(38);
                        reviewerModel.Security = dataReader.GetBoolean(39);
                        reviewerModel.SoftwareEngineering = dataReader.GetBoolean(40);
                        reviewerModel.SystemsAnalysisAndDesign = dataReader.GetBoolean(41);
                        reviewerModel.UsingTechnologyInTheClassroom = dataReader.GetBoolean(42);
                        reviewerModel.WebAndInternetProgramming = dataReader.GetBoolean(43);
                        reviewerModel.Other = dataReader.GetBoolean(44);
                        reviewerModel.OtherDescription = dataReader.GetString(45);
                        reviewerModel.ReviewsAcknowledged = dataReader.GetBoolean(46);
                        
                    }
                }
            }

            return reviewerModel;
        }

        public int CreateOrUpdate(ReviewerModel reviewerModel)
        {
            
        int newID = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                string sqlQuery = "";
                if (reviewerModel.ReviewerID <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.Reviewer VALUES(" +
                               "@Active, " +
                        "@FirstName, " +
                        "@MiddleInitial, " +
                        "@LastName, " +
                        "@Affiliation, " +
                        "@Department, " +
                        "@Address, " +
                        "@City, " +
                        "@State, " +
                        "@ZipCode, " +
                        "@PhoneNumber, " +
                        "@EmailAddress, " +
                        "@Password" + 
                               "@AnalysisOfAlgorithms" +
                               "@Applications" +
                               "@Architecture" +
                               "@ArtificialIntelligence" +
                               "@ComputerEngineering" +
                               "@Curriculum" +
                               "@DataStructures" +
                               "@Databases" + 
                               "@DistanceLearning"+
                               "@DistributedSystems" +
                               "@EthicalSocialIssues"+
                               "@FirstYearComputing"+
                               "@GenderIssues" +
                               "@GrantWriting"+
                               "@GraphicsImageProcessing" +
                               "@HumanComputerInteraction" +
                               "@LaboratoryEnvironments" +
                               "@Literacy" +
                               "@MathematicsInComputing" +
                               "@Multimedia" +
                               "@NetworkingDataCommunications" +
                               "@NonMajorCourses" +
                               "@ObjectOrientedIssues"+
                               "@OperatingSystems" +
                               "@ParalelProcessing" +
                               "@Pedagogy" +
                               "@ProgrammingLanguages" +
                               "@Research" +
                               "@Security" +
                               "@SoftwareEngineering" +
                               "@SystemAnalysisAndDesign" +
                               "@UsingTechnologyInTheClassroom" +
                               "@WebAndInternetProgramming" +
                               "@Other" +
                               "@OtherDescription" +
                               "@ReviewsAcknowledged)";
                }
                else
                {
                    sqlQuery = "UPDATE dbo.Reviewer SET " +
                        "FirstName = @FirstName, " +
                        "MiddleInitial = @MiddleInitial, " +
                        "LastName = @LastName, " +
                        "Affiliation = @Affiliation, " +
                        "Department = @Department, " +
                        "Address = @Address, " +
                        "City = @City, " +
                        "State = @State, " +
                        "ZipCode = @ZipCode, " +
                        "PhoneNumber = @PhoneNumber, " +
                        "EmailAddress = @EmailAddress, " +
                        "Password = @Password " +
                        "AnalysisOfAlgorithms = @Analysis"+
                        "Applications = @Applications" +
                        "Architecture = @Architecture" +
                               "ArtificialIntelligence = @ArtificialIntelligence" +
                               "ComputerEngineering = @ComputerEngineering" +
                               "Curriculum = @Curriculum" +
                               "DataStructures = @DataStructures" +
                               "Databases = @Databases" +
                               "DistanceLearning = @DistanceLearning" +
                               "DistributedSystems = @DistributedSystems" +
                               "EthicalSocialIssues = @EthicalSocialIssues" +
                               "FirstYearComputing = @FirstYearComputing" +
                               "GenderIssues = @GenderIssues" +
                               "GrantWriting = @GrantWriting" +
                               "GraphicsImageProcessing = @GraphicsImageProcessing" +
                               "HumanComputerInteraction = @HumanComputerInteraction" +
                               "LaboratoryEnvironments = @LaboratoryEnvironments" +
                               "Literacy = @Literacy" +
                               "MathematicsInComputing = @MathematicsInComputing" +
                               "Multimedia = @Multimedia" +
                               "NetworkingDataCommunications = @NetworkingDataCommunications" +
                               "NonMajorCourses = @NonMajorCourses" +
                               "ObjectOrientedIssues = @ObjectOrientedIssues" +
                               "OperatingSystems = @OperatingSystems" +
                               "ParalelProcessing = @ParalelProcessing" +
                               "Pedagogy = @Pedagogy" +
                               "ProgrammingLanguages = @ProgrammingLanguages" +
                               "Research = @Research" +
                               "Security = @Security" +
                               "SoftwareEngineering = @SoftwareEngineering" +
                               "SystemAnalysisAndDesign = @SystemAnalysisAndDesign" +
                               "UsingTechnologyInTheClassroom = @UsingTechnologyInTheClassroom" +
                               "WebAndInternetProgramming = @WebAndInternetProgramming" +
                               "Other = @Other" +
                               "OtherDescription = @OtherDescription" +
                               "ReviewsAcknowledged = @ReviewsAcknowledged" +
                    "WHERE ReviewerID = @ReviewerID";
                }

                SqlCommand sqlCommand = new(sqlQuery, connection);

                sqlCommand.Parameters.Add("@FirstName",System.Data.SqlDbType.NVarChar, 50).Value = 
                    string.IsNullOrEmpty(reviewerModel.FirstName) ? DBNull.Value : reviewerModel.FirstName;

                sqlCommand.Parameters.Add("@MiddleInitial", System.Data.SqlDbType.NVarChar, 1).Value =
                    string.IsNullOrEmpty(reviewerModel.MiddleInitial) ? DBNull.Value : reviewerModel.MiddleInitial;

                sqlCommand.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrEmpty(reviewerModel.LastName) ? DBNull.Value : reviewerModel.LastName;

                sqlCommand.Parameters.Add("@Affiliation", System.Data.SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrEmpty(reviewerModel.Affiliation) ? DBNull.Value : reviewerModel.Affiliation;

                sqlCommand.Parameters.Add("@Department", System.Data.SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrEmpty(reviewerModel.Department) ? DBNull.Value : reviewerModel.Department;

                sqlCommand.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrEmpty(reviewerModel.Address) ? DBNull.Value : reviewerModel.Address;

                sqlCommand.Parameters.Add("@City", System.Data.SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrEmpty(reviewerModel.City) ? DBNull.Value : reviewerModel.City;

                sqlCommand.Parameters.Add("@State", System.Data.SqlDbType.NVarChar, 2).Value =
                    string.IsNullOrEmpty(reviewerModel.State) ? DBNull.Value : reviewerModel.State;

                sqlCommand.Parameters.Add("@ZipCode", System.Data.SqlDbType.NVarChar, 10).Value =
                    string.IsNullOrEmpty(reviewerModel.ZipCode) ? DBNull.Value : reviewerModel.ZipCode;

                sqlCommand.Parameters.Add("@PhoneNumber", System.Data.SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrEmpty(reviewerModel.PhoneNumber) ? DBNull.Value : reviewerModel.PhoneNumber;

                sqlCommand.Parameters.Add("@EmailAddress", System.Data.SqlDbType.NVarChar, 100).Value =
                    string.IsNullOrEmpty(reviewerModel.Email) ? DBNull.Value : reviewerModel.Email;

                sqlCommand.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 5).Value =
                    string.IsNullOrEmpty(reviewerModel.Password) ? DBNull.Value : reviewerModel.Password;


                sqlCommand.Parameters.Add("@ReviewerID", System.Data.SqlDbType.Int).Value = reviewerModel.ReviewerID;
                connection.Open();
                newID = sqlCommand.ExecuteNonQuery();
            }
            
            return newID;
        }
    }
}
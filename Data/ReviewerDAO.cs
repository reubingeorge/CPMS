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
                        reviewerModel.ReviewerID                = dataReader.GetInt32(0);
                        reviewerModel.Active                    = dataReader.GetBoolean(1);
                        reviewerModel.FirstName                 = dataReader.IsDBNull(2) ? null : dataReader.GetString(2);
                        reviewerModel.MiddleInitial             = dataReader.IsDBNull(3) ? null : dataReader.GetString(3);
                        reviewerModel.LastName                  = dataReader.IsDBNull(4) ? null : dataReader.GetString(4);
                        reviewerModel.Affiliation               = dataReader.IsDBNull(5) ? null : dataReader.GetString(5);
                        reviewerModel.Department                = dataReader.IsDBNull(6) ? null : dataReader.GetString(6);
                        reviewerModel.Address                   = dataReader.IsDBNull(7) ? null : dataReader.GetString(7);
                        reviewerModel.City                      = dataReader.IsDBNull(8) ? null : dataReader.GetString(8);
                        reviewerModel.State                     = dataReader.IsDBNull(9) ? null : dataReader.GetString(9);
                        reviewerModel.ZipCode                   = dataReader.IsDBNull(10) ? null : dataReader.GetString(10);
                        reviewerModel.PhoneNumber               = dataReader.IsDBNull(11) ? null : dataReader.GetString(11);
                        reviewerModel.Email                     = dataReader.GetString(12);
                        reviewerModel.Password                  = dataReader.GetString(13);
                        reviewerModel.AnalysisOfAlgorithms      = dataReader.IsDBNull(14) ? false : dataReader.GetBoolean(14);
                        reviewerModel.Architecture              = dataReader.IsDBNull(15) ? false : dataReader.GetBoolean(15);
                        reviewerModel.Applications              = dataReader.IsDBNull(16) ? false : dataReader.GetBoolean(16);
                        reviewerModel.ArtificialIntelligence    = dataReader.IsDBNull(17) ? false : dataReader.GetBoolean(17);
                        reviewerModel.ComputerEngineering       = dataReader.IsDBNull(18) ? false : dataReader.GetBoolean(18);
                        reviewerModel.Curriculum                = dataReader.IsDBNull(19) ? false : dataReader.GetBoolean(19);
                        reviewerModel.DataStructures            = dataReader.IsDBNull(20) ? false : dataReader.GetBoolean(20);
                        reviewerModel.Databases                 = dataReader.IsDBNull(21) ? false : dataReader.GetBoolean(21);
                        reviewerModel.DistancedLearning         = dataReader.IsDBNull(22) ? false : dataReader.GetBoolean(22);
                        reviewerModel.DistributedSystems        = dataReader.IsDBNull(23) ? false : dataReader.GetBoolean(23);
                        reviewerModel.EthicalSocietalIssues       = dataReader.IsDBNull(24) ? false : dataReader.GetBoolean(24);
                        reviewerModel.FirstYearComputing        = dataReader.IsDBNull(25) ? false : dataReader.GetBoolean(25);
                        reviewerModel.GenderIssues              = dataReader.IsDBNull(26) ? false : dataReader.GetBoolean(26);
                        reviewerModel.GrantWriting              = dataReader.IsDBNull(27) ? false : dataReader.GetBoolean(27);
                        reviewerModel.GraphicsImageProcessing   = dataReader.IsDBNull(28) ? false : dataReader.GetBoolean(28);
                        reviewerModel.HumanComputerInteraction  = dataReader.IsDBNull(29) ? false : dataReader.GetBoolean(29);
                        reviewerModel.LaboratoryEnvironments    = dataReader.IsDBNull(30) ? false : dataReader.GetBoolean(30);
                        reviewerModel.Literacy                  = dataReader.IsDBNull(31) ? false : dataReader.GetBoolean(31);
                        reviewerModel.MathematicsInComputing    = dataReader.IsDBNull(32) ? false : dataReader.GetBoolean(32);
                        reviewerModel.Multimedia                = dataReader.IsDBNull(33) ? false : dataReader.GetBoolean(33);
                        reviewerModel.NetworkingDataCommunications = dataReader.IsDBNull(34) ? false : dataReader.GetBoolean(34);
                        reviewerModel.NonMajorCourses           = dataReader.IsDBNull(35) ? false : dataReader.GetBoolean(35);
                        reviewerModel.ObjectOrientedIssues      = dataReader.IsDBNull(36) ? false : dataReader.GetBoolean(36);
                        reviewerModel.OperatingSystems          = dataReader.IsDBNull(37) ? false : dataReader.GetBoolean(37);
                        reviewerModel.ParallelProcessing        = dataReader.IsDBNull(38) ? false : dataReader.GetBoolean(38);
                        reviewerModel.Pedagogy                  = dataReader.IsDBNull(39) ? false : dataReader.GetBoolean(39);
                        reviewerModel.ProgrammingLanguages      = dataReader.IsDBNull(40) ? false : dataReader.GetBoolean(40);
                        reviewerModel.Research                  = dataReader.IsDBNull(41) ? false : dataReader.GetBoolean(41);
                        reviewerModel.Security                  = dataReader.IsDBNull(42) ? false : dataReader.GetBoolean(42);
                        reviewerModel.SoftwareEngineering       = dataReader.IsDBNull(43) ? false : dataReader.GetBoolean(43);
                        reviewerModel.SystemsAnalysisAndDesign  = dataReader.IsDBNull(44) ? false : dataReader.GetBoolean(44);
                        reviewerModel.UsingTechnologyInTheClassroom = dataReader.IsDBNull(45) ? false : dataReader.GetBoolean(45);
                        reviewerModel.WebAndInternetProgramming = dataReader.IsDBNull(46) ? false : dataReader.GetBoolean(46);
                        reviewerModel.Other                     = dataReader.IsDBNull(47) ? false : dataReader.GetBoolean(47);
                        reviewerModel.OtherDescription          = dataReader.IsDBNull(48) ? null : dataReader.GetString(48);
                        reviewerModel.ReviewsAcknowledged       = dataReader.IsDBNull(49) ? false : dataReader.GetBoolean(49);

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
                        reviewerModel.ReviewerID                = dataReader.GetInt32(0);
                        reviewerModel.Active                    = dataReader.GetBoolean(1);
                        reviewerModel.FirstName                 = dataReader.IsDBNull(2) ? null : dataReader.GetString(2);
                        reviewerModel.MiddleInitial             = dataReader.IsDBNull(3) ? null : dataReader.GetString(3);
                        reviewerModel.LastName                  = dataReader.IsDBNull(4) ? null : dataReader.GetString(4);
                        reviewerModel.Affiliation               = dataReader.IsDBNull(5) ? null : dataReader.GetString(5);
                        reviewerModel.Department                = dataReader.IsDBNull(6) ? null : dataReader.GetString(6);
                        reviewerModel.Address                   = dataReader.IsDBNull(7) ? null : dataReader.GetString(7);
                        reviewerModel.City                      = dataReader.IsDBNull(8) ? null : dataReader.GetString(8);
                        reviewerModel.State                     = dataReader.IsDBNull(9) ? null : dataReader.GetString(9);
                        reviewerModel.ZipCode                   = dataReader.IsDBNull(10) ? null : dataReader.GetString(10);
                        reviewerModel.PhoneNumber               = dataReader.IsDBNull(11) ? null : dataReader.GetString(11);
                        reviewerModel.Email                     = dataReader.GetString(12);
                        reviewerModel.Password                  = dataReader.GetString(13);
                        reviewerModel.AnalysisOfAlgorithms      = dataReader.IsDBNull(14) ? false : dataReader.GetBoolean(14);
                        reviewerModel.Architecture              = dataReader.IsDBNull(15) ? false : dataReader.GetBoolean(15);
                        reviewerModel.Applications              = dataReader.IsDBNull(16) ? false : dataReader.GetBoolean(16);
                        reviewerModel.ArtificialIntelligence    = dataReader.IsDBNull(17) ? false : dataReader.GetBoolean(17);
                        reviewerModel.ComputerEngineering       = dataReader.IsDBNull(18) ? false : dataReader.GetBoolean(18);
                        reviewerModel.Curriculum                = dataReader.IsDBNull(19) ? false : dataReader.GetBoolean(19);
                        reviewerModel.DataStructures            = dataReader.IsDBNull(20) ? false : dataReader.GetBoolean(20);
                        reviewerModel.Databases                 = dataReader.IsDBNull(21) ? false : dataReader.GetBoolean(21);
                        reviewerModel.DistancedLearning         = dataReader.IsDBNull(22) ? false : dataReader.GetBoolean(22);
                        reviewerModel.DistributedSystems        = dataReader.IsDBNull(23) ? false : dataReader.GetBoolean(23);
                        reviewerModel.EthicalSocietalIssues       = dataReader.IsDBNull(24) ? false : dataReader.GetBoolean(24);
                        reviewerModel.FirstYearComputing        = dataReader.IsDBNull(25) ? false : dataReader.GetBoolean(25);
                        reviewerModel.GenderIssues              = dataReader.IsDBNull(26) ? false : dataReader.GetBoolean(26);
                        reviewerModel.GrantWriting              = dataReader.IsDBNull(27) ? false : dataReader.GetBoolean(27);
                        reviewerModel.GraphicsImageProcessing   = dataReader.IsDBNull(28) ? false : dataReader.GetBoolean(28);
                        reviewerModel.HumanComputerInteraction  = dataReader.IsDBNull(29) ? false : dataReader.GetBoolean(29);
                        reviewerModel.LaboratoryEnvironments    = dataReader.IsDBNull(30) ? false : dataReader.GetBoolean(30);
                        reviewerModel.Literacy                  = dataReader.IsDBNull(31) ? false : dataReader.GetBoolean(31);
                        reviewerModel.MathematicsInComputing    = dataReader.IsDBNull(32) ? false : dataReader.GetBoolean(32);
                        reviewerModel.Multimedia                = dataReader.IsDBNull(33) ? false : dataReader.GetBoolean(33);
                        reviewerModel.NetworkingDataCommunications = dataReader.IsDBNull(34) ? false : dataReader.GetBoolean(34);
                        reviewerModel.NonMajorCourses           = dataReader.IsDBNull(35) ? false : dataReader.GetBoolean(35);
                        reviewerModel.ObjectOrientedIssues      = dataReader.IsDBNull(36) ? false : dataReader.GetBoolean(36);
                        reviewerModel.OperatingSystems          = dataReader.IsDBNull(37) ? false : dataReader.GetBoolean(37);
                        reviewerModel.ParallelProcessing        = dataReader.IsDBNull(38) ? false : dataReader.GetBoolean(38);
                        reviewerModel.Pedagogy                  = dataReader.IsDBNull(39) ? false : dataReader.GetBoolean(39);
                        reviewerModel.ProgrammingLanguages      = dataReader.IsDBNull(40) ? false : dataReader.GetBoolean(40);
                        reviewerModel.Research                  = dataReader.IsDBNull(41) ? false : dataReader.GetBoolean(41);
                        reviewerModel.Security                  = dataReader.IsDBNull(42) ? false : dataReader.GetBoolean(42);
                        reviewerModel.SoftwareEngineering       = dataReader.IsDBNull(43) ? false : dataReader.GetBoolean(43);
                        reviewerModel.SystemsAnalysisAndDesign  = dataReader.IsDBNull(44) ? false : dataReader.GetBoolean(44);
                        reviewerModel.UsingTechnologyInTheClassroom = dataReader.IsDBNull(45) ? false : dataReader.GetBoolean(45);
                        reviewerModel.WebAndInternetProgramming = dataReader.IsDBNull(46) ? false : dataReader.GetBoolean(46);
                        reviewerModel.Other                     = dataReader.IsDBNull(47) ? false : dataReader.GetBoolean(47);
                        reviewerModel.OtherDescription          = dataReader.IsDBNull(48) ? null : dataReader.GetString(48);
                        reviewerModel.ReviewsAcknowledged       = dataReader.IsDBNull(49) ? false : dataReader.GetBoolean(49);

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
                        "@Password, " +
                               "@AnalysisOfAlgorithms, " +
                               "@Applications, " +
                               "@Architecture, " +
                               "@ArtificialIntelligence, " +
                               "@ComputerEngineering, " +
                               "@Curriculum, " +
                               "@DataStructures, " +
                               "@Databases, " +
                               "@DistancedLearning, " +
                               "@DistributedSystems, " +
                               "@EthicalSocietalIssues, " +
                               "@FirstYearComputing, " +
                               "@GenderIssues, " +
                               "@GrantWriting, " +
                               "@GraphicsImageProcessing, " +
                               "@HumanComputerInteraction, " +
                               "@LaboratoryEnvironments, " +
                               "@Literacy, " +
                               "@MathematicsInComputing, " +
                               "@Multimedia, " +
                               "@NetworkingDataCommunications, " +
                               "@NonMajorCourses, " +
                               "@ObjectOrientedIssues, " +
                               "@OperatingSystems, " +
                               "@ParallelProcessing, " +
                               "@Pedagogy, " +
                               "@ProgrammingLanguages, " +
                               "@Research, " +
                               "@Security, " +
                               "@SoftwareEngineering, " +
                               "@SystemsAnalysisAndDesign, " +
                               "@UsingTechnologyInTheClassroom, " +
                               "@WebAndInternetProgramming, " +
                               "@Other, " +
                               "@OtherDescription, " +
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
                        "AnalysisOfAlgorithms = @Analysis" +
                        "Applications = @Applications" +
                        "Architecture = @Architecture" +
                               "ArtificialIntelligence = @ArtificialIntelligence" +
                               "ComputerEngineering = @ComputerEngineering" +
                               "Curriculum = @Curriculum" +
                               "DataStructures = @DataStructures" +
                               "Databases = @Databases" +
                               "DistancedLearning = @DistanceLearning" +
                               "DistributedSystems = @DistributedSystems" +
                               "EthicalSocietalIssues = @EthicalSocietalIssues" +
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

                sqlCommand.Parameters.Add("@Active", System.Data.SqlDbType.Bit).Value = reviewerModel.Active;

                sqlCommand.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar, 50).Value =
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

                sqlCommand.Parameters.Add("@AnalysisOfAlgorithms", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.AnalysisOfAlgorithms;

                sqlCommand.Parameters.Add("@Applications", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.Applications;

                sqlCommand.Parameters.Add("@Architecture", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.Architecture;

                sqlCommand.Parameters.Add("@ArtificialIntelligence", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.ArtificialIntelligence;

                sqlCommand.Parameters.Add("@ComputerEngineering", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.ComputerEngineering;

                sqlCommand.Parameters.Add("@Curriculum", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.Curriculum;

                sqlCommand.Parameters.Add("@DataStructures", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.DataStructures;

                sqlCommand.Parameters.Add("@Databases", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.Databases;

                sqlCommand.Parameters.Add("@DistancedLearning", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.DistancedLearning;

                sqlCommand.Parameters.Add("@DistributedSystems", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.DistributedSystems;

                sqlCommand.Parameters.Add("@EthicalSocietalIssues", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.EthicalSocietalIssues;

                sqlCommand.Parameters.Add("@FirstYearComputing", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.FirstYearComputing;

                sqlCommand.Parameters.Add("@GenderIssues", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.GenderIssues;

                sqlCommand.Parameters.Add("@GrantWriting", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.GrantWriting;

                sqlCommand.Parameters.Add("@GraphicsImageProcessing", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.GraphicsImageProcessing;

                sqlCommand.Parameters.Add("@HumanComputerInteraction", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.HumanComputerInteraction;

                sqlCommand.Parameters.Add("@LaboratoryEnvironments", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.LaboratoryEnvironments;

                sqlCommand.Parameters.Add("@Literacy", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.Literacy;

                sqlCommand.Parameters.Add("@MathematicsInComputing", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.MathematicsInComputing;

                sqlCommand.Parameters.Add("@Multimedia", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.Multimedia;

                sqlCommand.Parameters.Add("@NetworkingDataCommunications", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.NetworkingDataCommunications;

                sqlCommand.Parameters.Add("@NonMajorCourses", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.NonMajorCourses;

                sqlCommand.Parameters.Add("@ObjectOrientedIssues", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.ObjectOrientedIssues;

                sqlCommand.Parameters.Add("@OperatingSystems", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.OperatingSystems;

                sqlCommand.Parameters.Add("@ParallelProcessing", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.ParallelProcessing;

                sqlCommand.Parameters.Add("@Pedagogy", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.Pedagogy;

                sqlCommand.Parameters.Add("@ProgrammingLanguages", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.ProgrammingLanguages;

                sqlCommand.Parameters.Add("@Research", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.Research;

                sqlCommand.Parameters.Add("@Security", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.Security;

                sqlCommand.Parameters.Add("@SoftwareEngineering", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.SoftwareEngineering;

                sqlCommand.Parameters.Add("@SystemsAnalysisAndDesign", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.SystemsAnalysisAndDesign;

                sqlCommand.Parameters.Add("@UsingTechnologyInTheClassroom", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.UsingTechnologyInTheClassroom;

                sqlCommand.Parameters.Add("@WebAndInternetProgramming", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.WebAndInternetProgramming;

                sqlCommand.Parameters.Add("@Other", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.Other;

                sqlCommand.Parameters.Add("@OtherDescription", System.Data.SqlDbType.NVarChar).Value =
                    string.IsNullOrEmpty(reviewerModel.OtherDescription) ? DBNull.Value : reviewerModel.OtherDescription;

                sqlCommand.Parameters.Add("@ReviewsAcknowledged", System.Data.SqlDbType.Bit).Value =
                    reviewerModel.ReviewsAcknowledged;

                connection.Open();
                newID = sqlCommand.ExecuteNonQuery();
            }

            return newID;
        }

        public bool LoginCheck(string email, string password)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Reviewer where EmailAddress = @email AND Password = @pw";
                SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
                sqlCommand.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
                sqlCommand.Parameters.Add("@pw", System.Data.SqlDbType.NVarChar).Value = password;
                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                return dataReader.HasRows;
            }
        }
    }
}
using CPMS.Models;
using System.Data.SqlClient;

namespace CPMS.Data
{
    /// <summary>
    /// Class <c>PaperDAO</c> performs the role of the Data Access Object. This DAO is essentially the connector
    /// between the controller and the database containing the Paper table.
    /// </summary>
    internal class PaperDAO : DAO
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
        /// Method <c>FetchOne</c> extracts only one paper from the database based on the ID.
        /// </summary>
        /// <param name="PaperID"></param>
        /// <returns></returns>
        internal PaperModel FetchOne(int PaperID)
        {
            PaperModel paperModel = new();
            using (SqlConnection sqlConnection = new (connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Paper WHERE PaperID = @PaperID";
                SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
                sqlCommand.Parameters.Add("@PaperID",System.Data.SqlDbType.Int).Value = PaperID;
                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    if (dataReader.Read())
                    {
                        paperModel.PaperID = PaperID;
                        paperModel.AuthorID = dataReader.GetInt32(1);
                        paperModel.Active = dataReader.GetBoolean(2);
                        paperModel.FilenameOriginal = dataReader.GetString(3);
                        paperModel.Filename = dataReader.GetString(4);
                        paperModel.Title = dataReader.GetString(5);
                        paperModel.Certification = dataReader.GetString(6);
                        paperModel.NotesToReviewers = dataReader.GetString(7);
                        paperModel.AnalysisOfAlgorithms = dataReader.GetBoolean(8);
                        paperModel.Applications = dataReader.GetBoolean(9);
                        paperModel.Architecture = dataReader.GetBoolean(10);
                        paperModel.ArtificialIntelligence = dataReader.GetBoolean(11);
                        paperModel.ComputerEngineering = dataReader.GetBoolean(12);
                        paperModel.Curriculum = dataReader.GetBoolean(13);
                        paperModel.DataStructures = dataReader.GetBoolean(14);
                        paperModel.Databases = dataReader.GetBoolean(15);
                        paperModel.DistancedLearning = dataReader.GetBoolean(16);
                        paperModel.DistributedSystems = dataReader.GetBoolean(17);
                        paperModel.EthicalSocietalIssues = dataReader.GetBoolean(18);
                        paperModel.FirstYearComputing = dataReader.GetBoolean(19);
                        paperModel.GenderIssues = dataReader.GetBoolean(20);
                        paperModel.GrantWriting = dataReader.GetBoolean(21);
                        paperModel.GraphicsImageProcessing = dataReader.GetBoolean(22);
                        paperModel.HumanComputerInteraction = dataReader.GetBoolean(23);
                        paperModel.LaboratoryEnvironments = dataReader.GetBoolean(24);
                        paperModel.Literacy = dataReader.GetBoolean(25);
                        paperModel.MathematicsInComputing = dataReader.GetBoolean(26);
                        paperModel.Multimedia = dataReader.GetBoolean(27);
                        paperModel.NetworkingDataCommunications = dataReader.GetBoolean(28);
                        paperModel.NonMajorCourses = dataReader.GetBoolean(29);
                        paperModel.ObjectOrientedIssues = dataReader.GetBoolean(30);
                        paperModel.OperatingSystems = dataReader.GetBoolean(31);
                        paperModel.ParallelProcessing = dataReader.GetBoolean(32);
                        paperModel.Pedagogy = dataReader.GetBoolean(33);
                        paperModel.ProgrammingLanguages = dataReader.GetBoolean(34);
                        paperModel.Research = dataReader.GetBoolean(35);
                        paperModel.Security = dataReader.GetBoolean(36);
                        paperModel.SoftwareEngineering = dataReader.GetBoolean(37);
                        paperModel.SystemsAnalysisAndDesign = dataReader.GetBoolean(38);
                        paperModel.UsingTechnologyInTheClassroom = dataReader.GetBoolean(39);
                        paperModel.WebAndInternetProgramming = dataReader.GetBoolean(40);
                        paperModel.Other = dataReader.GetBoolean(41);
                        paperModel.OtherDescription = dataReader.IsDBNull(42) ? null : dataReader.GetString(42);
                    }
                }
            }
            return paperModel;
        }

        /// <summary>
        /// Method <c>CreateOrUpdate</c> can either edit an existing user or create a new paper in the
        /// paper table. The operation is chosen based on the ID in the input object. If the ID is less
        /// than or equal to 0 then a create operation is performed or else an update operation is performed.
        /// </summary>
        /// <param name="paperModel">Model containing the information of paper.</param>
        /// <returns>integer that depicts if the insertion or the update operation has been successfully performed.</returns>
        internal int CreateOrUpdate(PaperSubmissionModel paperModel)
        {
            int newID = -1;
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery;
                if (paperModel.PaperID <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.Paper VALUES(" +
                        "@AuthorID, " +
                        "@Active, " +
                        "@FilenameOriginal, " +
                        "@Filename, "+
                        "@Title, " +
                        "@Certification, " +
                        "@NotesToReviewers, " +
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
                        "@OtherDescription)";
                }
                else
                {
                    sqlQuery = "";
                }

                SqlCommand sqlCommand = new (sqlQuery, connection);
                sqlCommand.Parameters.Add("@PaperID", System.Data.SqlDbType.Int).Value = paperModel.PaperID;
                sqlCommand.Parameters.Add("@AuthorID", System.Data.SqlDbType.Int).Value = paperModel.AuthorID;
                sqlCommand.Parameters.Add("@Active", System.Data.SqlDbType.Bit).Value = paperModel.Active;
                sqlCommand.Parameters.Add("@FilenameOriginal", System.Data.SqlDbType.NVarChar, 100).Value = paperModel.FilenameOriginal;
                sqlCommand.Parameters.Add("@Filename", System.Data.SqlDbType.NVarChar, 100).Value = paperModel.Filename;
                sqlCommand.Parameters.Add("@Title", System.Data.SqlDbType.NVarChar, 200).Value = paperModel.Title;
                sqlCommand.Parameters.Add("@Certification", System.Data.SqlDbType.NVarChar, 3).Value =
                    string.IsNullOrEmpty(paperModel.Certification) ? DBNull.Value : paperModel.Certification;
                sqlCommand.Parameters.Add("@NotesToReviewers", System.Data.SqlDbType.NVarChar, int.MaxValue).Value =
                    string.IsNullOrEmpty(paperModel.NotesToReviewers) ? DBNull.Value : paperModel.NotesToReviewers;

                sqlCommand.Parameters.Add("@Applications", System.Data.SqlDbType.Bit).Value = paperModel.Applications;
                sqlCommand.Parameters.Add("@AnalysisOfAlgorithms", System.Data.SqlDbType.Bit).Value = paperModel.AnalysisOfAlgorithms;
                sqlCommand.Parameters.Add("@Architecture", System.Data.SqlDbType.Bit).Value = paperModel.Architecture;
                sqlCommand.Parameters.Add("@ArtificialIntelligence", System.Data.SqlDbType.Bit).Value = paperModel.ArtificialIntelligence;
                sqlCommand.Parameters.Add("@ComputerEngineering", System.Data.SqlDbType.Bit).Value = paperModel.ComputerEngineering;
                sqlCommand.Parameters.Add("@Curriculum", System.Data.SqlDbType.Bit).Value = paperModel.Curriculum;
                sqlCommand.Parameters.Add("@DataStructures", System.Data.SqlDbType.Bit).Value = paperModel.DataStructures;
                sqlCommand.Parameters.Add("@Databases", System.Data.SqlDbType.Bit).Value = paperModel.Databases;
                sqlCommand.Parameters.Add("@DistancedLearning", System.Data.SqlDbType.Bit).Value = paperModel.DistancedLearning;
                sqlCommand.Parameters.Add("@DistributedSystems", System.Data.SqlDbType.Bit).Value = paperModel.DistributedSystems;
                sqlCommand.Parameters.Add("@EthicalSocietalIssues", System.Data.SqlDbType.Bit).Value = paperModel.EthicalSocietalIssues;
                sqlCommand.Parameters.Add("@FirstYearComputing", System.Data.SqlDbType.Bit).Value = paperModel.FirstYearComputing;
                sqlCommand.Parameters.Add("@GenderIssues", System.Data.SqlDbType.Bit).Value = paperModel.GenderIssues;
                sqlCommand.Parameters.Add("@GrantWriting", System.Data.SqlDbType.Bit).Value = paperModel.GrantWriting;
                sqlCommand.Parameters.Add("@GraphicsImageProcessing", System.Data.SqlDbType.Bit).Value = paperModel.GraphicsImageProcessing;
                sqlCommand.Parameters.Add("@HumanComputerInteraction", System.Data.SqlDbType.Bit).Value = paperModel.HumanComputerInteraction;
                sqlCommand.Parameters.Add("@LaboratoryEnvironments", System.Data.SqlDbType.Bit).Value = paperModel.LaboratoryEnvironments;
                sqlCommand.Parameters.Add("@Literacy", System.Data.SqlDbType.Bit).Value = paperModel.Literacy;
                sqlCommand.Parameters.Add("@MathematicsInComputing", System.Data.SqlDbType.Bit).Value = paperModel.MathematicsInComputing;
                sqlCommand.Parameters.Add("@Multimedia", System.Data.SqlDbType.Bit).Value = paperModel.Multimedia;
                sqlCommand.Parameters.Add("@NetworkingDataCommunications", System.Data.SqlDbType.Bit).Value = paperModel.NetworkingDataCommunications;
                sqlCommand.Parameters.Add("@NonMajorCourses", System.Data.SqlDbType.Bit).Value = paperModel.NonMajorCourses;
                sqlCommand.Parameters.Add("@ObjectOrientedIssues", System.Data.SqlDbType.Bit).Value = paperModel.ObjectOrientedIssues;
                sqlCommand.Parameters.Add("@OperatingSystems", System.Data.SqlDbType.Bit).Value = paperModel.OperatingSystems;
                sqlCommand.Parameters.Add("@ParallelProcessing", System.Data.SqlDbType.Bit).Value = paperModel.ParallelProcessing;
                sqlCommand.Parameters.Add("@Pedagogy", System.Data.SqlDbType.Bit).Value = paperModel.Pedagogy;
                sqlCommand.Parameters.Add("@ProgrammingLanguages", System.Data.SqlDbType.Bit).Value = paperModel.ProgrammingLanguages;
                sqlCommand.Parameters.Add("@Research", System.Data.SqlDbType.Bit).Value = paperModel.Research;
                sqlCommand.Parameters.Add("@Security", System.Data.SqlDbType.Bit).Value = paperModel.Security;
                sqlCommand.Parameters.Add("@SoftwareEngineering", System.Data.SqlDbType.Bit).Value = paperModel.SoftwareEngineering;
                sqlCommand.Parameters.Add("@SystemsAnalysisAndDesign", System.Data.SqlDbType.Bit).Value = paperModel.SystemsAnalysisAndDesign;
                sqlCommand.Parameters.Add("@UsingTechnologyInTheClassroom", System.Data.SqlDbType.Bit).Value = paperModel.UsingTechnologyInTheClassroom;
                sqlCommand.Parameters.Add("@WebAndInternetProgramming", System.Data.SqlDbType.Bit).Value = paperModel.WebAndInternetProgramming;
                sqlCommand.Parameters.Add("@Other", System.Data.SqlDbType.Bit).Value = paperModel.Other;
                sqlCommand.Parameters.Add("@OtherDescription", System.Data.SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrEmpty(paperModel.OtherDescription) ? DBNull.Value : paperModel.OtherDescription;
                connection.Open();
                newID = sqlCommand.ExecuteNonQuery();
            }
            

            return newID;
        }

        internal List<PaperModel> FetchAll()
        {
            List<PaperModel> paperList = new();
            using (SqlConnection sqlConnection = new(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Paper";
                SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        PaperModel paperModel = new();
                        paperModel.PaperID = dataReader.GetInt32(0);
                        paperModel.AuthorID = dataReader.GetInt32(1);
                        paperModel.Active = dataReader.GetBoolean(2);
                        paperModel.FilenameOriginal = dataReader.GetString(3);
                        paperModel.Filename = dataReader.GetString(4);
                        paperModel.Title = dataReader.GetString(5);
                        paperModel.Certification = dataReader.GetString(6);
                        paperModel.NotesToReviewers = dataReader.GetString(7);
                        paperModel.AnalysisOfAlgorithms = dataReader.GetBoolean(8);
                        paperModel.Applications = dataReader.GetBoolean(9);
                        paperModel.Architecture = dataReader.GetBoolean(10);
                        paperModel.ArtificialIntelligence = dataReader.GetBoolean(11);
                        paperModel.ComputerEngineering = dataReader.GetBoolean(12);
                        paperModel.Curriculum = dataReader.GetBoolean(13);
                        paperModel.DataStructures = dataReader.GetBoolean(14);
                        paperModel.Databases = dataReader.GetBoolean(15);
                        paperModel.DistancedLearning = dataReader.GetBoolean(16);
                        paperModel.DistributedSystems = dataReader.GetBoolean(17);
                        paperModel.EthicalSocietalIssues = dataReader.GetBoolean(18);
                        paperModel.FirstYearComputing = dataReader.GetBoolean(19);
                        paperModel.GenderIssues = dataReader.GetBoolean(20);
                        paperModel.GrantWriting = dataReader.GetBoolean(21);
                        paperModel.GraphicsImageProcessing = dataReader.GetBoolean(22);
                        paperModel.HumanComputerInteraction = dataReader.GetBoolean(23);
                        paperModel.LaboratoryEnvironments = dataReader.GetBoolean(24);
                        paperModel.Literacy = dataReader.GetBoolean(25);
                        paperModel.MathematicsInComputing = dataReader.GetBoolean(26);
                        paperModel.Multimedia = dataReader.GetBoolean(27);
                        paperModel.NetworkingDataCommunications = dataReader.GetBoolean(28);
                        paperModel.NonMajorCourses = dataReader.GetBoolean(29);
                        paperModel.ObjectOrientedIssues = dataReader.GetBoolean(30);
                        paperModel.OperatingSystems = dataReader.GetBoolean(31);
                        paperModel.ParallelProcessing = dataReader.GetBoolean(32);
                        paperModel.Pedagogy = dataReader.GetBoolean(33);
                        paperModel.ProgrammingLanguages = dataReader.GetBoolean(34);
                        paperModel.Research = dataReader.GetBoolean(35);
                        paperModel.Security = dataReader.GetBoolean(36);
                        paperModel.SoftwareEngineering = dataReader.GetBoolean(37);
                        paperModel.SystemsAnalysisAndDesign = dataReader.GetBoolean(38);
                        paperModel.UsingTechnologyInTheClassroom = dataReader.GetBoolean(39);
                        paperModel.WebAndInternetProgramming = dataReader.GetBoolean(40);
                        paperModel.Other = dataReader.GetBoolean(41);
                        paperModel.OtherDescription = dataReader.IsDBNull(42) ? null : dataReader.GetString(42);
                        paperList.Add(paperModel);
                    }
                }
            }

            return paperList;
        }
    }
}

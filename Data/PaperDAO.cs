﻿using CPMS.Models;
using System.Data.SqlClient;

namespace CPMS.Data
{
    internal class PaperDAO
    {
        private string connectionString =
            @"Data Source=(localdb)\ProjectModels;
                Initial Catalog=CPMS;
                Integrated Security=True;
                Connect Timeout=30;Encrypt=False;
                TrustServerCertificate=False;
                ApplicationIntent=ReadWrite;
                MultiSubnetFailover=False";

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
    }
}

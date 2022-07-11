using CPMS.Data;
using System.Data.SqlClient;
using CPMS.Models;

namespace CPMS.Data;

    internal class PaperMatchingDAO
    {
        private string connectionString =
            @"Data Source=(localdb)\ProjectModels;
                Initial Catalog=CPMS;
                Integrated Security=True;
                Connect Timeout=30;Encrypt=False;
                TrustServerCertificate=False;
                ApplicationIntent=ReadWrite;
                MultiSubnetFailover=False";
        
        public bool Check(int paperId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Review where PaperID = @paperId";
                SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
                sqlCommand.Parameters.Add("@paperId", System.Data.SqlDbType.Int).Value = paperId;
                sqlConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                return dataReader.HasRows;
            }
        }

        internal void InsertThreeTimes(ReviewModel reviewModel, int i)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "INSERT INTO dbo.Review () VALUES (" +
                                  "@ReviewID, " +
                                  "@PaperID, " +
                                  "@ReviewerID";
                                  
                SqlCommand sqlCommand = new (sqlQuery, connection);
                sqlCommand.Parameters.Add("@ReviewID", System.Data.SqlDbType.Int).Value = reviewModel.ReviewID;
                sqlCommand.Parameters.Add("@PaperID", System.Data.SqlDbType.Int).Value = reviewModel.PaperID;
                sqlCommand.Parameters.Add("@ReviewerID", System.Data.SqlDbType.Int).Value = reviewModel.ReviewerID;
                


            }
        }
    }
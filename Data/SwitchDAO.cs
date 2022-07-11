using System.Data.SqlClient;
using CPMS.Models;

namespace CPMS.Data;

internal class SwitchDAO
{
    private string connectionString =
        @"Data Source=(localdb)\ProjectModels;
                Initial Catalog=CPMS;
                Integrated Security=True;
                Connect Timeout=30;Encrypt=False;
                TrustServerCertificate=False;
                ApplicationIntent=ReadWrite;
                MultiSubnetFailover=False";

    public SwitchModel fetchSwitches()
    {
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            string sqlQuery = "SELECT * from dbo.Defaults";
            SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            dataReader.Read();
            return new SwitchModel(dataReader.GetBoolean(0), dataReader.GetBoolean(1));
        }
    }

    public bool paperEnabled()
    {
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            string sqlQuery = "SELECT EnabledAuthors from dbo.Defaults";
            SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            dataReader.Read();
            return dataReader.GetBoolean(0);
        }
    }

    public bool reviewEnabled()
    {
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            string sqlQuery = "SELECT EnabledReviewers from dbo.Defaults";
            SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            dataReader.Read();
            return dataReader.GetBoolean(0);
        }
    }

    public void togglePaper()
    {
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            string sqlQuery = "UPDATE dbo.Defaults SET EnabledAuthors = ~EnabledAuthors";
            SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
        }
    }

    public void toggleReviewer()
    {
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            string sqlQuery = "UPDATE dbo.Defaults SET EnabledReviewers = ~EnabledReviewers";
            SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
        }
    }
}

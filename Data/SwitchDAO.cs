using System.Data.SqlClient;
using CPMS.Models;

namespace CPMS.Data;

/// <summary>
/// Class <c>SwitchDAO</c> performs the role of the Data Access Object. This DAO is essentially the connector
/// between the controller and the database containing the State table. The State table determines if an author
/// can submit a paper or if a reviewer can submit a review.
/// </summary>
internal class SwitchDAO : DAO
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
    /// Method <c>FetchSwitches</c> determines the state of the authors or reviewers.
    /// </summary>
    /// <returns>A model containing the states</returns>
    public SwitchModel FetchSwitches()
    {
        using (SqlConnection sqlConnection = new (connectionString))
        {
            string sqlQuery = "SELECT * from dbo.Defaults";
            SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            dataReader.Read();
            return new SwitchModel(dataReader.GetBoolean(0), dataReader.GetBoolean(1));
        }
    }

    /// <summary>
    /// Method <c>PaperEnabled</c> determines the state of the Authors.
    /// </summary>
    /// <returns>True if the authors can submit a paper</returns>
    public bool PaperEnabled()
    {
        using (SqlConnection sqlConnection = new (connectionString))
        {
            string sqlQuery = "SELECT EnabledAuthors from dbo.Defaults";
            SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            dataReader.Read();
            return dataReader.GetBoolean(0);
        }
    }

    /// <summary>
    /// Method <c>PaperEnabled</c> determines the state of the Reviewers.
    /// </summary>
    /// <returns>True if the reviewers can submit a review</returns>
    public bool ReviewEnabled()
    {
        using (SqlConnection sqlConnection = new (connectionString))
        {
            string sqlQuery = "SELECT EnabledReviewers from dbo.Defaults";
            SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            dataReader.Read();
            return dataReader.GetBoolean(0);
        }
    }

    /// <summary>
    /// Method <c>TogglePaper</c> toggles between the state of the authors.
    /// </summary>
    public void TogglePaper()
    {
        using (SqlConnection sqlConnection = new (connectionString))
        {
            string sqlQuery = "UPDATE dbo.Defaults SET EnabledAuthors = ~EnabledAuthors";
            SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
        }
    }

    /// <summary>
    /// Method <c>TogglePaper</c> toggles between the state of the reviewers.
    /// </summary>
    public void ToggleReviewer()
    {
        using (SqlConnection sqlConnection = new (connectionString))
        {
            string sqlQuery = "UPDATE dbo.Defaults SET EnabledReviewers = ~EnabledReviewers";
            SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
        }
    }
}

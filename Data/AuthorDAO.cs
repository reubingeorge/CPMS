using CPMS.Models;
using System.Data.SqlClient;

namespace CPMS.Data
{
    /// <summary>
    /// Class <c>AuthorDAO</c> performs the role of the Data Access Object. This DAO is essentially the connector
    /// between the controller and the database containing the Author table.
    /// </summary>
    internal class AuthorDAO
    {
        private readonly string connectionString = 
            @"Data Source=(localdb)\ProjectModels;
                Initial Catalog=CPMS;
                Integrated Security=True;
                Connect Timeout=30;Encrypt=False;
                TrustServerCertificate=False;
                ApplicationIntent=ReadWrite;
                MultiSubnetFailover=False";

        /// <summary>
        /// Method <c>FetchAll</c> extracts a list of all authors available in the database.
        /// </summary>
        /// <returns>a list of all authors in the database</returns>
        internal List<AuthorModel> FetchAll()
        {
            List<AuthorModel> authorList = new();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Author";
                SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        AuthorModel authorModel     = new();
                        authorModel.AuthorID        = dataReader.GetInt32(0);
                        authorModel.FirstName       = dataReader.IsDBNull(1) ? null : dataReader.GetString(1);
                        authorModel.MiddleInitial   = dataReader.IsDBNull(2) ? null : dataReader.GetString(2);
                        authorModel.LastName        = dataReader.IsDBNull(3) ? null : dataReader.GetString(3);
                        authorModel.Affiliation     = dataReader.IsDBNull(4) ? null : dataReader.GetString(4);
                        authorModel.Department      = dataReader.IsDBNull(5) ? null : dataReader.GetString(5);
                        authorModel.Address         = dataReader.IsDBNull(6) ? null : dataReader.GetString(6);
                        authorModel.City            = dataReader.IsDBNull(7) ? null : dataReader.GetString(7);
                        authorModel.State           = dataReader.IsDBNull(8) ? null : dataReader.GetString(8);
                        authorModel.ZipCode         = dataReader.IsDBNull(9) ? null : dataReader.GetString(9);
                        authorModel.PhoneNumber     = dataReader.IsDBNull(10) ? null : dataReader.GetString(10);
                        authorModel.Email           = dataReader.GetString(11);
                        authorModel.Password        = dataReader.GetString(12);

                        authorList.Add(authorModel);
                    }
                }
            }
            return authorList;
        }


        /// <summary>
        /// Method <c>FetchOne</c> extracts only one author from the database based on the ID.
        /// </summary>
        /// <param name="id">ID of the author (primary key in the database)</param>
        /// <returns>An object containing the information of the extracted author</returns>
        internal AuthorModel FetchOne(int id)
        {
            AuthorModel authorModel = new();
            using (SqlConnection sqlConnection = new (connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Author where AuthorID = @id";
                SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
                sqlCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        
                        authorModel.AuthorID = dataReader.GetInt32(0);
                        authorModel.FirstName = dataReader.IsDBNull(1) ? null : dataReader.GetString(1);
                        authorModel.MiddleInitial = dataReader.IsDBNull(2) ? null : dataReader.GetString(2);
                        authorModel.LastName = dataReader.IsDBNull(3) ? null : dataReader.GetString(3);
                        authorModel.Affiliation = dataReader.IsDBNull(4) ? null : dataReader.GetString(4);
                        authorModel.Department = dataReader.IsDBNull(5) ? null : dataReader.GetString(5);
                        authorModel.Address = dataReader.IsDBNull(6) ? null : dataReader.GetString(6);
                        authorModel.City = dataReader.IsDBNull(7) ? null : dataReader.GetString(7);
                        authorModel.State = dataReader.IsDBNull(8) ? null : dataReader.GetString(8);
                        authorModel.ZipCode = dataReader.IsDBNull(9) ? null : dataReader.GetString(9);
                        authorModel.PhoneNumber = dataReader.IsDBNull(9) ? null : dataReader.GetString(10);
                        authorModel.Email = dataReader.GetString(11);
                        authorModel.Password = dataReader.GetString(12);

                        
                    }
                }
            }
            return authorModel;
        }

        /// <summary>
        /// Method <c>CreateOrUpdate</c> can either edit an existing user or create a new user in the
        /// author table. The operation is chosen based on the ID in the input object. If the ID is less
        /// than or equal to 0 then a create operation is performed or else an update operation is performed.
        /// </summary>
        /// <param name="authorModel">Model containing the information of author.</param>
        /// <returns>integer that depicts if the insertion or the update operation has been successfully performed.</returns>
        internal int CreateOrUpdate(AuthorModel authorModel)
        {
            int newID = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                string sqlQuery = "";
                if (authorModel.AuthorID <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.Author VALUES(" +
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
                        "@Password)";
                }
                else
                {
                    sqlQuery = "UPDATE dbo.Author SET " +
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
                        "Password = @Password WHERE " +
                        "AuthorID = @AuthorID";
                }

                SqlCommand sqlCommand = new(sqlQuery, connection);

                sqlCommand.Parameters.Add("@FirstName",System.Data.SqlDbType.NVarChar, 50).Value = 
                    string.IsNullOrEmpty(authorModel.FirstName) ? DBNull.Value : authorModel.FirstName;

                sqlCommand.Parameters.Add("@MiddleInitial", System.Data.SqlDbType.NVarChar, 1).Value =
                    string.IsNullOrEmpty(authorModel.MiddleInitial) ? DBNull.Value : authorModel.MiddleInitial;

                sqlCommand.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrEmpty(authorModel.LastName) ? DBNull.Value : authorModel.LastName;

                sqlCommand.Parameters.Add("@Affiliation", System.Data.SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrEmpty(authorModel.Affiliation) ? DBNull.Value : authorModel.Affiliation;

                sqlCommand.Parameters.Add("@Department", System.Data.SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrEmpty(authorModel.Department) ? DBNull.Value : authorModel.Department;

                sqlCommand.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrEmpty(authorModel.Address) ? DBNull.Value : authorModel.Address;

                sqlCommand.Parameters.Add("@City", System.Data.SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrEmpty(authorModel.City) ? DBNull.Value : authorModel.City;

                sqlCommand.Parameters.Add("@State", System.Data.SqlDbType.NVarChar, 2).Value =
                    string.IsNullOrEmpty(authorModel.State) ? DBNull.Value : authorModel.State;

                sqlCommand.Parameters.Add("@ZipCode", System.Data.SqlDbType.NVarChar, 10).Value =
                    string.IsNullOrEmpty(authorModel.ZipCode) ? DBNull.Value : authorModel.ZipCode;

                sqlCommand.Parameters.Add("@PhoneNumber", System.Data.SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrEmpty(authorModel.PhoneNumber) ? DBNull.Value : authorModel.PhoneNumber;

                sqlCommand.Parameters.Add("@EmailAddress", System.Data.SqlDbType.NVarChar, 100).Value =
                    string.IsNullOrEmpty(authorModel.Email) ? DBNull.Value : authorModel.Email;

                sqlCommand.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 5).Value =
                    string.IsNullOrEmpty(authorModel.Password) ? DBNull.Value : authorModel.Password;


                sqlCommand.Parameters.Add("@AuthorID", System.Data.SqlDbType.Int).Value = authorModel.AuthorID;
                connection.Open();
                newID = sqlCommand.ExecuteNonQuery();
            }
            
            return newID;
        }

        /// <summary>
        /// Method <c>Delete</c> perform a deletion operation on the author table.
        /// </summary>
        /// <param name="id">ID of the author (primary key in the database)</param>
        internal void Delete(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlQuery = "DELETE from dbo.Author WHERE AuthorID = @id";
                SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
                sqlCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Method <c>GetIDByCredential</c> gets the ID of the author based on the entered email and password.
        /// </summary>
        /// <param name="email">Email of the author</param>
        /// <param name="password">Password of the author</param>
        /// <returns>ID of the author.</returns>
        internal int GetIdByCredential(string email, string password)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT AuthorID from dbo.Author where EmailAddress = @email AND Password = @pw";
                SqlCommand sqlCommand = new(sqlQuery, sqlConnection);
                sqlCommand.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
                sqlCommand.Parameters.Add("@pw", System.Data.SqlDbType.NVarChar).Value = password;
                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    return dataReader.GetInt32(0);
                }
                else
                {
                    return 0;
                }
            }
        }
    }
        
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Railwayproject
{
    public class UserService
    {
        private readonly string _connectionString;

        public UserService(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Registers a new user
        public bool RegisterUser(string username, string password, string email, string fullName)
        {
            string query = "INSERT INTO Users (Username, Password, Email, FullName) VALUES (@username, @password, @email, @fullName)";
            SqlParameter[] parameters = {
            new SqlParameter("@username", username),
            new SqlParameter("@password", password), // Store hashed password in production
            new SqlParameter("@email", email),
            new SqlParameter("@fullName", fullName)
        };

            return ExecuteNonQuery(query, parameters);
        }

        // Authenticates a user
        public bool AuthenticateUser(string username, string password)
        {
            string query = "SELECT Password FROM Users WHERE Username = @username";
            SqlParameter[] parameters = { new SqlParameter("@username", username) };

            string storedPassword = ExecuteScalar(query, parameters) as string;
            return storedPassword != null && password == storedPassword; // Compare passwords in production
        }

        // Executes a query that does not return any data
        private bool ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Executes a query that returns a single value
        private object ExecuteScalar(string query, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Railwayproject
{
    public class AdminService
    {
        private readonly string _connectionString;

        public AdminService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool RegisterAdmin(string username, string password, string fullName)
        {
            string query = "INSERT INTO Admins (Username, Password, FullName) VALUES (@username, @password, @fullName)";
            SqlParameter[] parameters = {
            new SqlParameter("@username", username),
            new SqlParameter("@password", password), // Use hashed passwords in production
            new SqlParameter("@fullName", fullName)
        };
            return ExecuteNonQuery(query, parameters);
        }

        public bool AuthenticateAdmin(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM Admins WHERE Username = @username AND Password = @password";
            SqlParameter[] parameters = {
            new SqlParameter("@username", username),
            new SqlParameter("@password", password) // Use hashed passwords in production
        };
            return ExecuteScalar(query, parameters) > 0;
        }

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

        private int ExecuteScalar(string query, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
    }
}

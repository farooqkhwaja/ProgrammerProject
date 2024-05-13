using Dapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace DataAccess.Dapper
{
    public class UserRepository
    {
        private string _connectionString = "Data Source=.;Initial Catalog=SalsaManagment2;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public User GetUserByFirstName(string firstname)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<User>("SELECT * FROM [User] WHERE FirstName = @FirstName", new { FirstName = firstname });
            }
        }
        public IEnumerable<User> GetUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<User>("SELECT * FROM [User]");
            }
        }
        public User GetUserByUsernamePassword(string username, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<User>("SELECT * FROM [User] WHERE Username = @Username AND Password = @Password", new { Username = username, Password = password });
            }
        }
        public bool CreateUser(User user)
        {
            string query = "INSERT INTO [User] (Username, Password, FirstName, LastName, Sex, Email, IsManager) " +
                           "VALUES (@Username, @Password, @FirstName, @LastName, @Sex, @Email, @IsManager)";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int rowsAffected = connection.Execute(query, user);
                return rowsAffected > 0;
            }
        }
        public bool GetUserByUsername(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<bool>("SELECT 1 FROM [User] WHERE Username = @Username", new { Username = username }) != default(bool);
            }
        }
        public User GetUser(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<User>("SELECT * FROM [User] WHERE Id = @Id", new { Id = userId });
            }
        }
        public void UpdateUser(User user)
        {
            string query = "UPDATE [User] SET Username = @Username, Password = @Password WHERE FirstName = @FirstName";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(query, user);
            }
        }
        public void DeleteUser(int userId)
        {
            string query = "DELETE FROM [User] WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(query, new { Id = userId });
            }
        }
    }
}

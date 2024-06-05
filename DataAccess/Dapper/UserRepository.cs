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

      
        public List<User> GetFirstnames()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Firstname FROM [User]";
                connection.Open();
                var users = connection.Query<User>(query).ToList();
                return users;
            }
        }
        public User GetUserByFirstName(string firstname)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.QueryFirstOrDefault<User>("SELECT * FROM [User] WHERE Firstname = @Firstname", new { Firstname = firstname });
                return result;
            }
        }
        public List<User> GetUsersByFirstName(string firstname)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<User>("SELECT * FROM [User] WHERE FirstName = @FirstName", new { FirstName = firstname });
                return result.ToList();
            }
        }
        public List<User> GetUsersWithForeignKeys()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = @"SELECT u.*, dc.CategoryName 
                                FROM [User] u
                                JOIN DanceCategory dc ON u.CategoryId = dc.Id;
                                ";
                connection.Open();
                var result = connection.Query<User>(query);
                return result.ToList();
            }
        }
        public List<User> GetUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM [User];";
                connection.Open();
                var result = connection.Query<User>(query);
                return result.ToList();
            }
        }
        public List<User> GetUserWithEvents(int eventId)
        {
            using (SqlConnection con = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
            {
                string query = @"
                       SELECT [User].FirstName
                        FROM [User]
                        JOIN Events ON [User].EventId = Events.Id
                        WHERE Events.Id = @EventId;
                                            ";

                con.Open();
                var result = con.Query<User>(query, new { EventId = eventId });
                return result.ToList();
            }
        }
        public User GetUserByUsernamePassword(string username, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.QueryFirstOrDefault<User>("SELECT * FROM [User] WHERE Username = @Username AND Password = @Password", new { Username = username, Password = password });
                return result;
            }
        }
        public bool CreateUser(User user)
        {
            string query = "INSERT INTO [User] (Username, Password, FirstName, LastName, Sex, Email, IsManager, CategoryId) " +
                           "VALUES (@Username, @Password, @FirstName, @LastName, @Sex, @Email, @IsManager,@CategoryId)";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int rowsAffected = connection.Execute(query, user);
                var result = rowsAffected > 0;
                return result;
            }
        }
        public bool GetUserByUsername(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.QueryFirstOrDefault<bool>("SELECT 1 FROM [User] WHERE Username = @Username", new { Username = username }) != default(bool);
                return result;
            }
        }
        public User GetUser(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.QueryFirstOrDefault<User>("SELECT * FROM [User] WHERE Id = @Id", new { Id = userId });
                return result;
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
        public void UpdateUserEventId(int userId, int eventId)
        {
            using (SqlConnection con = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
            {
                string query = @"
                            UPDATE [User]
                            SET EventId = @EventId
                            WHERE Id = @UserId;
                        ";

                con.Open();
                con.Execute(query, new { UserId = userId, EventId = eventId });
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

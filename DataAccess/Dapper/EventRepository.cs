using Dapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess.Dapper
{
    public class EventRepository
    {
        private string _connectionString;

        public EventRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool CreateEvent(string eventName, string date, string studentAssigned, int? fkLocation)     
        {
            string query = "INSERT INTO Events (Name, Date, UserId, LocationId) " +
                           "VALUES (@Name, @Date, @UserId, @LocationId)";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                try
                {
                    connection.Execute(query, new { Name = eventName, Date = date, StudentAssigned = studentAssigned, Fk_Location = fkLocation });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        }

        public Events GetEvent(int id)
        {
            string query = "SELECT * FROM Events WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<Events>(query, new { Id = id });
            }
        }

        public List<Events> GetEvents()
        {
            string query = "SELECT * FROM Events";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<Events>(query).ToList();
            }
        }

        public void UpdateEvent(Events uploadEvent)
        {
            string query = "UPDATE Events SET Name = @Name, Date = @Date WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(query, uploadEvent);
            }
        }

        public void DeleteEvent(int id)
        {
            string query = "DELETE FROM Events WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(query, new { Id = id });
            }
        }
    }
}

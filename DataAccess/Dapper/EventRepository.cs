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
        private string _connectionString = "Data Source=.;Initial Catalog=SalsaManagment2;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public bool CreateEvent(string eventName, string date, int locationID, int danceCategoryId)     
        {
            string query = "INSERT INTO Events (Name, Date, DanceCategory, UserId, LocationId) " +
                           "VALUES (@Name, @Date, @DanceCategory @UserId, @LocationId)";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                try
                {
                    connection.Execute(query, new { Name = eventName, Date = date, DanceCategoryId = danceCategoryId, LocationId = locationID });
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
                var result = connection.QueryFirstOrDefault<Events>(query, new { Id = id });
                return result;
            }
        }

        public List<Events> GetEvents()
        {
            string query = "SELECT * FROM Events";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Events>(query).ToList();
                return result;
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

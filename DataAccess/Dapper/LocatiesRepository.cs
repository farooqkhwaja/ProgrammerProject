using Dapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess.Dapper
{
    public class LocatiesRepository
    {
        private string _connectionString;

        public LocatiesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Locations CreateLocation(Locations location)
        {
            string query = "INSERT INTO Locations (StreetName, City) " +
                           "VALUES (@StreetName, @City); " +
                           "SELECT SCOPE_IDENTITY();";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int newId = connection.QuerySingle<int>(query, location);
                location.Id = newId;
            }

            return location;
        }

        public Locations ReadLocation(int id)
        {
            string query = "SELECT * FROM Locations WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<Locations>(query, new { Id = id });
            }
        }

        public void UpdateLocation(Locations location)
        {
            string query = "UPDATE Locations SET StreetName = @StreetName, City = @City  WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(query, location);
            }
        }

        public void DeleteLocation(int id)
        {
            string query = "DELETE FROM Locations WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(query, new { Id = id });
            }
        }
    }
}

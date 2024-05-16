using Dapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess.Dapper
{
    public class LocationRepository
    {
        private string _connectionString = "Data Source=.;Initial Catalog=SalsaManagment2;Integrated Security=True;Connect Timeout=30;Encrypt=False";

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

        public List<Locations> GetLocations()
        {
            string query = "SELECT * FROM Locations" ;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Locations>(query);
                return result.ToList();
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

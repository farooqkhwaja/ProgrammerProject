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
        public Location CreateLocation(Location location)
        {
            string query = "INSERT INTO Location (StreetName, City) " +
                           "VALUES (@StreetName, @City); " +
                           "SELECT SCOPE_IDENTITY();";

            using (var connection = new SqlConnection(DbConfigurations.SalsaManagementConnectionString))
            {
                connection.Open();
                int newId = connection.QuerySingle<int>(query, location);
                location.Id = newId;
            }

            return location;
        }

        public List<Location> GetLocations()
        {
            string query = "SELECT * FROM Location";

            using (var connection = new SqlConnection(DbConfigurations.SalsaManagementConnectionString))
            {
                connection.Open();
                var result = connection.Query<Location>(query);
                return result.ToList();
            }
        }

        public void UpdateLocation(Location location)
        {
            string query = "UPDATE Location SET StreetName = @StreetName, City = @City  WHERE Id = @Id";

            using (var connection = new SqlConnection(DbConfigurations.SalsaManagementConnectionString))
            {
                connection.Open();
                connection.Execute(query, location);
            }
        }

        public void DeleteLocation(int id)
        {
            string query = "DELETE FROM Location WHERE Id = @Id";

            using (var connection = new SqlConnection(DbConfigurations.SalsaManagementConnectionString))
            {
                connection.Open();
                connection.Execute(query, new { Id = id });
            }
        }
    }
}

using Dapper;
using DataAccess.Models;
using System.Data.SqlClient;

namespace DataAccess.Dapper;

public class DanceCategoryRepository
{
    public List<DanceCategory> GetdanceCategories()
    {
        using(var connection = new SqlConnection(DbConfigurations.SalsaManagementConnectionString))
        {
            string query = "SELECT * FROM DanceCategory";
            connection.Open();
            var danceCategory = connection.Query<DanceCategory>(query).AsList();
            return danceCategory;
        }
    }
}

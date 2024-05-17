using Dapper;
using DataAccess.Models;
using System.Data.SqlClient;

namespace DataAccess.Dapper;

public class EventRepository
{
    public bool SaveEvent(Models.Events _event)
    {
         string query = "INSERT INTO Events (Name, Date, DanceCategoryId, UserId, LocationId) " +
                        "VALUES (@Name, @Date, @DanceCategoryId, @UserId, @LocationId)";

         using (var connection = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
         {
             connection.Open();
             try
             {
                 connection.Execute(query, new { Name = _event.Name, Date = _event.Date, DanceCategoryId = _event.DanceCategoryId, UserId = _event.UserId, LocationId = _event.LocationId });
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

        using (var connection = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
        {
            connection.Open();
            var result = connection.QueryFirstOrDefault<Events>(query, new { Id = id });
            return result;
        }
    }

    public List<Events> GetEvents()
    {
        string query = "SELECT * FROM Events";

        using (var connection = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
        {
            connection.Open();
            var result = connection.Query<Events>(query).ToList();
            return result;
        }
    }

    public void UpdateEvent(Events uploadEvent)
    {
        string query = "UPDATE Events SET Name = @Name, Date = @Date WHERE Id = @Id";

        using (var connection = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
        {
            connection.Open();
            connection.Execute(query, uploadEvent);
        }
    }

    public void DeleteEvent(int id)
    {
        string query = "DELETE FROM Events WHERE Id = @Id";

        using (var connection = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
        {
            connection.Open();
            connection.Execute(query, new { Id = id });
        }
    }
}

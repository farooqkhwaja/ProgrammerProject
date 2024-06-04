using Dapper;
using DataAccess.Models;
using Microsoft.SqlServer.Server;
using Microsoft.VisualBasic;
using System;
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
    public void UpdateUserEvent(int eventId, int currentUserId, int newUserId)
    {
        string query = @"
                UPDATE UserEvent 
                SET UserId = @NewUserId 
                WHERE EventId = @EventId AND UserId = @CurrentUserId;";

        using (SqlConnection con = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
        {
            con.Open();
            con.Execute(query, new { NewUserId = newUserId, EventId = eventId, CurrentUserId = currentUserId });
        }
    }


    public List<Events> GetEventsAndStudents(int eventId)
    {
        string query = @"
            SELECT e.Name AS EventName, e.Date AS EventDate, u.Firstname AS FirstName 
             FROM Events e 
             JOIN [User] u ON e.UserId = u.Id 
             WHERE e.Id = @eventId AND u.IsManager = 0;";

        using (SqlConnection con = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
        {
            con.Open();
            var result = con.Query<Events>(query, new { EventId = eventId }).ToList();
            return result;
        }
    }

    public List<Events> GetEvents()
    {
        string query = @"SELECT e.Id, e.Name, e.Date, e.DanceCategoryId, dc.CategoryName, 
                e.UserId, u.Firstname, e.LocationId, l.StreetName
                FROM Events e
                JOIN DanceCategory dc ON e.DanceCategoryId = dc.Id
                JOIN [User] u ON e.UserId = u.Id
                JOIN Location l ON e.LocationId = l.Id";

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

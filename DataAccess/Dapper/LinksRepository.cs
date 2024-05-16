using Dapper;
using DataAccess.Models;
using System.Data.SqlClient;

namespace DataAccess.Dapper;

public class LinksRepository
{
    public int CreateLink(Links uploadLink)
    {
        int affectedRows = 0;
        
        string query = "INSERT INTO Links (Url, CreatedBy) VALUES (@Url, @CreatedBy)";

        using (var connection = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
        {
            connection.Open();
            try
            {
                affectedRows = connection.Execute(query, uploadLink);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        return affectedRows;
    }

    public List<Links> GetLinks()
    {
        string query = "SELECT * FROM Links";

        using (var connection = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
        {
            connection.Open();
            var result = connection.Query<Links>(query).ToList();
            return result;
        }
    }

    public Links GetLink(int id)
    {
        string query = "SELECT * FROM Links WHERE Id = @Id";

        using (var connection = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
        {
            connection.Open();
            var result = connection.QueryFirstOrDefault<Links>(query, new { Id = id });
            return result;
        }
    }

    public void UpdateLinks(Links uploadlink)
    {
        string query = "UPDATE Links SET Url = @Url WHERE Id = @Id";

        using (var connection = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
        {
            connection.Open();
            connection.Execute(query, uploadlink);
        }
    }

    public void DeleteLink(int linkId)
    {
        string query = "DELETE FROM Links WHERE Id = @Id";

        using (var connection = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
        {
            connection.Open();
            connection.Execute(query, new { Id = linkId });
        }
    }
}

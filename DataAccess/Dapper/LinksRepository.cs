using Dapper;
using DataAccess.Models;
using System.Data.SqlClient;

namespace DataAccess.Dapper;

public class LinksRepository
{
    public int CreateLink(Links uploadLink)
    {
        int affectedRows = 0;
        
        string query = "INSERT INTO Links (Name, Url, CreatedBy,DanceCategoryId) VALUES (@Name,@Url, @CreatedBy,@DanceCategoryId)";

        using (var connection = new SqlConnection(DbConfigurations.SalsaManagementConnectionString))
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
        string query = @"SELECT l.Id, l.Name, l.url, l.CreatedBy, l.DanceCategoryId, 
                       u.Firstname , 
                       dc.CategoryName 
                    FROM Links l
                    INNER JOIN[User] u ON l.CreatedBy = u.Id
                    INNER JOIN DanceCategory dc ON l.DanceCategoryId = dc.Id;";

        using (var connection = new SqlConnection(DbConfigurations.SalsaManagementConnectionString))
        {
            connection.Open();
            var result = connection.Query<Links>(query).ToList();
            return result;
        }
    }

    public Links GetLink(int id)
    {
        string query = "SELECT * FROM Links WHERE Id = @Id";

        using (var connection = new SqlConnection(DbConfigurations.SalsaManagementConnectionString))
        {
            connection.Open();
            var result = connection.QueryFirstOrDefault<Links>(query, new { Id = id });
            return result;
        }
    }

    public void UpdateLinks(Links uploadlink)
    {
        string query = "UPDATE Links SET Url = @Url WHERE Id = @Id";

        using (var connection = new SqlConnection(DbConfigurations.SalsaManagementConnectionString))
        {
            connection.Open();
            connection.Execute(query, uploadlink);
        }
    }

    public void DeleteLink(int linkId)
    {
        string query = "DELETE FROM Links WHERE Id = @Id";

        using (var connection = new SqlConnection(DbConfigurations.SalsaManagementConnectionString))
        {
            connection.Open();
            connection.Execute(query, new { Id = linkId });
        }
    }
}

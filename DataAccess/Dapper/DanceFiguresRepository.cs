using Dapper;
using DataAccess.Models;
using System.Data.SqlClient;

namespace DataAccess.Dapper;

public class DanceFiguresRepository
{
    public List<DanceFigures> GetDanceFigures()
    {
        using (var connection = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
        {
            var sql = "SELECT * FROM DanceFigures";
            var danceFigures = connection.QuerySingle<DanceFigures>(sql);
            var result = new List<DanceFigures>();
            return result;
        }
    }
    public IEnumerable<DanceFigures> GetFigures()
    {
        using (var connection = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
        {
            connection.Open();
            var result = connection.Query<DanceFigures>("SELECT * FROM DanceFigures");
            return result;
        }
    }
    public void AddDanceFigures(DanceFigures figures)
    {
        using (var connection = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
        {
            connection.Open();
            connection.Execute("insert into DanceFigures (FigureName, Progress, CategoryId)Values (@FigureName, @Progress, @CategoryId) ", figures);
        }
    }
    public void UpdateDanceFigures(DanceFigures figures)
    {
        using(var connection = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
        {
            connection.Open();
            connection.Execute("Update DanceFigures SET FigureName = @Value1, Progress = @Value2, CategoryId= @Value3 ",figures);
            connection.Close();
        }
    }
   
}

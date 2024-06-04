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
            string sql = @" SELECT df.Id, df.FigureName, df.Progress, dc.CategoryName, dc.Id AS CategoryId
                            FROM DanceFigures df
                            INNER JOIN (
                                SELECT Id, CategoryName
                                FROM DanceCategory
                            ) dc ON df.CategoryId = dc.Id;"
;
            var danceFigures = connection.Query<DanceFigures>(sql).ToList();
            return danceFigures;
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
            connection.Execute("Update DanceFigures SET FigureName = @Value1, CategoryId= @Value2 ",figures);
        }
    }
    public bool UpdateProgress(bool progress)
    {
        using(SqlConnection con = new SqlConnection(DbConfigurations.SalsaManagement2ConnectionString))
        {
            con.Open();
            con.Execute("UPDATE DanceFigures SET Progress = @Progress", new { Progress = progress });
            return progress;
        }
    }
   
}

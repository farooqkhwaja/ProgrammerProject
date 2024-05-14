
using Dapper;
using DataAccess.Models;
using System.Data.SqlClient;

namespace DataAccess.Dapper
{
    public class DanceFiguresRepository
    {
        private string _connectionString;
        public DanceFiguresRepository(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        public List<DanceFigures> GetDanceFigures()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM DanceFigures";
                var danceFigures = connection.QuerySingle<DanceFigures>(sql);
                return new List<DanceFigures>();
            }
        }
        public IEnumerable<DanceFigures> GetFigures()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<DanceFigures>("SELECT * FROM DanceFigures");
            }
        }
        public void AddDanceFigures(DanceFigures figures)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("insert into DanceFigures (FigureName, Progress, CategoryId)Values (@FigureName, @Progress, @CategoryId) ", figures);
            }
        }
        public void UpdateDanceFigures(DanceFigures figures)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("Update DanceFigures SET FigureName = @Value1, Progress = @Value2, CategoryId= @Value3 ",figures);
                connection.Close();
            }
        }
       
    }
}

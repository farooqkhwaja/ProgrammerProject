
using Dapper;
using DataAccess.Models;
using System.Data.SqlClient;

namespace DataAccess.Dapper
{
    public class DanceFiguresRepository
    {
        private readonly string _connectionString = "";
        public DanceFiguresRepository()
        {
            _connectionString = "Data Source=FAROOQKHWAJA;Initial Catalog=SalsaManagment2;Integrated Security=True;Encrypt=False";
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
    }
}

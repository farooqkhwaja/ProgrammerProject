using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DataAccess.Dapper;

public class SqlDataAccess
{
    private string _connectionString = "Data Source=.;Initial Catalog=SalsaManagment2;Integrated Security=True;Connect Timeout=30;Encrypt=False";
    
    public void SaveData<T>(string storedProcedures, T parameters)
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            try
            {
                connection.Execute(storedProcedures, parameters, commandType: CommandType.StoredProcedure);
            }
            catch(SqlException ex)
            {
                throw;
            }
        }
    }
    
    public List<T> LoadData<T, U>(string storedProcedure, U parameters)
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            var rows = connection.Query <T> (storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return rows.ToList();
        }
    }
}
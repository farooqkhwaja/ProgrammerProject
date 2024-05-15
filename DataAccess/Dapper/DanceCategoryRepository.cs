using Dapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dapper
{
    public class DanceCategoryRepository
    {
        private string _connectionString= "Data Source=.;Initial Catalog=SalsaManagment2;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public List<DanceCategory> GetdanceCategories()
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM DanceCategory";
                connection.Open();
                var danceCategory = connection.Query<DanceCategory>(query).AsList();
                return danceCategory;
            }
        }
    }
}

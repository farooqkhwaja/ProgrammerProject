using System.Data.SqlClient;
using DataAccess.Models;

namespace DataAccess.ADO
{
    public class DanceFiguresRepository
    {
        static string connectionString = "Data Source=FAROOQKHWAJA;Initial Catalog=SalsaManagement-db;Integrated Security=True;Encrypt=False";

        public bool AddDance(string figurename)
        {
            string query = $"INSERT INTO DanceFigures (FigureName) VALUES ('{figurename}') ";

            using(SqlConnection  con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        
        }
        public List<DanceFigures> GetFigures()
        {
            List<DanceFigures> uploadDances = new List<DanceFigures>();

            string query = $"SELECT * FROM [DanceFigures]";
            using(SqlConnection con = new SqlConnection(connectionString)) 
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DanceFigures danceFigures = new DanceFigures();

                        danceFigures.Id = Convert.ToInt32( dataReader["Id"]);
                        danceFigures.FigureName = dataReader["FigureName"].ToString();
                        danceFigures.Progress = Convert.ToBoolean( dataReader["Progress"]);

                        uploadDances.Add(danceFigures);
                    }
                }
                catch(Exception ex)
                {
                    string message = "Event did not found" + ex.Message;
                }
               
            }
            return uploadDances;
        }
    }
}

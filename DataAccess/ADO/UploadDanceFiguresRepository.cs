using DataAccess.Models;
using System.Data.SqlClient;


namespace DataAccess
{
    public class UploadDanceFiguresRepository
    {
        static string connectionString = "Data Source=FAROOQKHWAJA;Initial Catalog=SalsaManagement-db;Integrated Security=True;Encrypt=False";

        public bool AddDance(string figurename)
        {
            string query = $"INSERT INTO UploadDanceFigures (FigureName) VALUES ('{figurename}') ";

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
        public List<UploadDanceFigures> GetFigures()
        {
            List<UploadDanceFigures> uploadDances = new List<UploadDanceFigures>();

            string query = $"SELECT * FROM [UploadDanceFigures]";
            using(SqlConnection con = new SqlConnection(connectionString)) 
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        UploadDanceFigures danceFigures = new UploadDanceFigures();

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

using System.Data.SqlClient;
using DataAccess.Models;

namespace DataAccess.ADO
{
    public class LinksRepository
    {
        //static string connectionString = "Data Source=FAROOQKHWAJA;Initial Catalog=SalsaManagement-db;Integrated Security=True;Encrypt=False";
        static string connectionString = "Data Source=DESKTOP-DIPI9BT;Initial Catalog=Salsadb;Integrated Security=True;Encrypt=False";
        public CreateLinksModel CreateLink(Links uploadLink)
        {
            CreateLinksModel model = new CreateLinksModel();
            string queryString = $"INSERT INTO Links(LinkAdres) VALUES ('{uploadLink}')";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, con);


                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    model.succesful = true;
                }
                catch
                (Exception ex)
                {
                    model.succesful = false;
                    model.msg = "Link did not added. " + ex.Message;

                }
            }
            return model;
        }
        public List<Links> GetLinks()
        {
            List<Links> uploadLinks = new List<Links>();
            string queryString = $"SELECT * FROM Links";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Links uploadlink = new Links();
                        uploadlink.Id = Convert.ToInt32(reader["Id"]);
                        //uploadlink.LinkAdres = reader["LinkAdres"].ToString();

                        uploadLinks.Add(uploadlink);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return uploadLinks;
        }
        public Links GetLink(int Id)
        {
            string queryString = $"SELECT * FROM Links WHERE Id = {Id}";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                Links uploadLinks = null;
                SqlCommand cmd = new SqlCommand(queryString, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    while (reader.Read())
                    {

                        uploadLinks = new Links();
                        uploadLinks.Id = Convert.ToInt32(reader["Id"].ToString());
                        //uploadLinks.LinkAdres = reader["LinkAdres"].ToString();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return uploadLinks;
            }
        }
        public void UpdateLinks(Links uploadlink)
        {
            string queryString = ""; //$"UPDATE Links SET LinkAdres = '{uploadlink.LinkAdres}'  WHERE Id = {uploadlink.Id}";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, con);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void DeleteLink(int linkId)
        {
            string queryString = $"DELETE FROM Links WHERE Id = {linkId}";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, con);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

    }
   
}

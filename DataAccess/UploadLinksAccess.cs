using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataAccess.Models;

namespace DataAccess
{
    public class UploadLinksAccess
    {
        static string connectionString = "Data Source=FAROOQKHWAJA;Initial Catalog=SalsaManagement-db;Integrated Security=True;Encrypt=False";
        static List<UploadLinks> uploadlinks = new List<UploadLinks>();

        public UploadLinks CreateLink(UploadLinks uploadLink)
        {
            string queryString = $"INSERT INTO UploadLinks(Id,Link) VALUES {uploadLink.Id},'{uploadLink.Link}'";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, con);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch
                (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return uploadLink;
        }
        public List<UploadLinks> GetLinks()
        {
            List<UploadLinks> uploadLinks = new List<UploadLinks>();
            string queryString = $"SELECT * FROM UploadLinks";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UploadLinks uploadlink = new UploadLinks();
                        uploadlink.Id = Convert.ToInt32(reader["Id"]);
                        uploadlink.Link = reader["Link"].ToString();

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
        public UploadLinks GetLink(int Id)
        {
            string queryString = $"SELECT * FROM UploadLinks WHERE Id = {Id}";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                UploadLinks uploadLinks = null;
                SqlCommand cmd = new SqlCommand(queryString, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    while (reader.Read())
                    {
                       
                        uploadLinks = new UploadLinks();
                        uploadLinks.Id = Convert.ToInt32(reader["Id"].ToString());
                        uploadLinks.Link = reader["Link"].ToString();
                       
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return uploadLinks;
            }
        }
        public void UpdateLinks(UploadLinks uploadlink)
        {
            string queryString = $"UPDATE UploadLinks SET Link = '{uploadlink.Link}'  WHERE Id = {uploadlink.Id}";

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
        public void DeleteLink(int DeleteId)
        {
            string queryString = $"DELETE FROM UploadLinks WHERE Id = {DeleteId}";

            using(SqlConnection con = new SqlConnection(connectionString))
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

using DataAccess.Models;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;


namespace DataAccess
{
    public class UploadEventAccess
    {
        static List<UploadEvents> eventen = new List<UploadEvents>();

        static string connectionString = "Data Source=FAROOQKHWAJA;Initial Catalog=SalsaManagement-db;Integrated Security=True;Encrypt=False";

        public bool CreateEvent(UploadEvents events)
        {
            string queryString = string.Format("INSERT INTO UploadEvents(Name,Date) VALUES('{0}','{1}' )", events.Name, events.Date);

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
                    return false;
                }
            }
            return true;
        }
        public UploadEvents ReadEvents(int Id)
        {
            string query = $"Select * FROM Users WHERE Id = {Id}";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UploadEvents events = new UploadEvents();

                        events.Id = Convert.ToInt32(reader["Id"].ToString());

                        events.Name = reader["Username"].ToString();
                        events.Date = Convert.ToDateTime(reader["Date"].ToString());
                        events.Fk_Locations = Convert.ToInt32(reader["Fk_Location"].ToString());

                        eventen.Add(events);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            return ReadEvents(Id);
        }
        public void UpdateEvent (UploadEvents uploadEvents)
        {
            string queryString = $"UPDATE UploadEvents SET NAME = '{uploadEvents.Name}', Date = '{uploadEvents.Date} WHERE Id = '{uploadEvents.Id}'";

            using(SqlConnection con = new SqlConnection (connectionString)) 
            {
                SqlCommand cmd = new SqlCommand(queryString, con);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message);}
            }
        }
        public void DeleteEvents(UploadEvents Id)
        {
            string sqlQuery = $"DELETE FROM UploadEvents WHERE Id = '{Id}'  ";

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch(Exception ex)
                { 
                    Console.WriteLine(ex.Message);
                }
            }
            
        }  
    }
}


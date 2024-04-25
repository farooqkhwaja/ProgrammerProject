using DataAccess.Models;
using Microsoft.VisualBasic;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;


namespace DataAccess
{
    public class UploadEventRepository
    {

        static string connectionString = "Data Source=FAROOQKHWAJA;Initial Catalog=SalsaManagement-db;Integrated Security=True;Encrypt=False";

       // static string connectionString = "Data Source=DESKTOP-DIPI9BT;Initial Catalog=Salsadb;Integrated Security=True;Encrypt=False";

        public bool CreateEvent(string eventname, string date)
        {
            string queryString = string.Format("INSERT INTO UploadEvents(Name,Date) VALUES('{0}','{1}' )", eventname, date);

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
        public UploadEvents GetEvent(int Id)
        {
            string query = $"Select * FROM Users WHERE Id = {Id}";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                List<UploadEvents> eventen = new List<UploadEvents>();
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
                        events.Date = reader["Date"].ToString();                 

                        eventen.Add(events);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            return GetEvent(Id);
        }
        public List<UploadEvents> GetEvents()
        {
            List<UploadEvents> uploadEvents = new List<UploadEvents>();
            string query = "SELECT * FROM [UploadEvents]";

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UploadEvents uploadevent = new UploadEvents();
                        uploadevent.Id = Convert.ToInt32(reader["Id"]);
                        uploadevent.Name = reader["Name"].ToString();
                        uploadevent.Date = reader["Date"].ToString();

                        uploadEvents.Add(uploadevent);
                    }
                }
                catch(Exception e)
                {
                    string message= "Event did not found" + e.Message;
                }
            }return uploadEvents;
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
        public void DeleteEvents(int Id)
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


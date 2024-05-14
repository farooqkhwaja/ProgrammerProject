using System.Data.SqlClient;
using DataAccess.Models;

namespace DataAccess.ADO
{
    public class EventRepository
    {
        // static List<Events> eventen = new List<Events>();

        // static string connectionString = "Data Source=FAROOQKHWAJA;Initial Catalog=SalsaManagement-db;Integrated Security=True;Encrypt=False";

        static string connectionString = "Data Source=DESKTOP-DIPI9BT;Initial Catalog=Salsadb;Integrated Security=True;Encrypt=False";

        public bool CreateEvent(string eventname, string date, string student, int? Fk_location)
        {
            string queryString = string.Format("INSERT INTO Events(Name,Date,StudentAssigned,Fk_Location) VALUES('{0}','{1}','{2}','{3}' )", eventname, date, student, Fk_location);

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
        public Events GetEvent(int Id)
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
                        Events events = new Events();

                        events.Id = Convert.ToInt32(reader["Id"].ToString());

                        events.Name = reader["Username"].ToString();
                        events.Date = reader["Date"].ToString();

                        //eventen.Add(events);
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
        public List<Events> GetEvents()
        {
            List<Events> uploadEvents = new List<Events>();
            string query = "SELECT * FROM [Events]";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Events uploadevent = new Events();
                        uploadevent.Id = Convert.ToInt32(reader["Id"]);
                        uploadevent.Name = reader["Name"].ToString();
                        //uploadevent.Date = reader["Date"].ToString();
                        //uploadevent.StudentAssigned = reader["StudentAssigned"].ToString();
                        //uploadevent.Fk_Locations = Convert.ToInt32(reader["Fk_Location"].ToString());

                        uploadEvents.Add(uploadevent);
                    }
                }
                catch (Exception e)
                {
                    string message = "Event did not found" + e.Message;
                }
            }
            return uploadEvents;
        }
        public void UpdateEvent(Events uploadEvents)
        {
            string queryString = $"UPDATE Events SET NAME = '{uploadEvents.Name}', Date = '{uploadEvents.Date} WHERE Id = '{uploadEvents.Id}'";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, con);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
        public void DeleteEvents(int Id)
        {
            string sqlQuery = $"DELETE FROM Events WHERE Id = '{Id}'  ";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

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


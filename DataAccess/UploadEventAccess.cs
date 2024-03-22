using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UploadEventAccess
    {
        static List<UploadEvents> events = new List<UploadEvents>();

        const string connectionString = "Data Source=FAROOQKHWAJA;Initial Catalog=SalsaManagement-db;Integrated Security=True;Encrypt=False";

        public bool CreateEvent(UploadEvents events)
        {
            string queryString =string.Format ("INSERT INTO UploadEvents(Name,Date,Fk_Location) VALUES('{0}','{1}','{2}' )", events.Name, events.Date, events.Fk_Locations);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, con);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        }


       /* public List<User> GetAllEvents()
        {
            const string queryString = "SELECT * FROM UploadEvents";


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, con);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //convert reader to User
                        User user = new User();

                        user.Id = Convert.ToInt32(reader["Id"]);
                        user.Username = reader["Username"].ToString();
                        user.Password = reader["Password"].ToString();
                        user.FirstName = reader["FirstName"].ToString();
                        user.Email = reader["Email"].ToString();
                        user.Sex = reader["Sex"].ToString();
                        user.LastName = reader["LastName"].ToString();

                        users.Add(user);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            return users;
        }


        public bool CreateUser(User user)
        {
            string query = string.Format("INSERT INTO Users(Username, Password,FirstName,LastName, Sex, Email) VALUES ('{0}',{1},'{2}','{3}','{4}','{5}')"
                , user.Username, user.Password, user.FirstName, user.LastName, user.Sex, user.Email);

            using (SqlConnection con = new SqlConnection(connectionString))
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

        public User ReadUser(int userId)
        {
            string query = $"Select * FROM Users WHERE Id = {userId}";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User();

                        user.Username = reader["Username"].ToString();
                        user.Password = reader["Password"].ToString();
                        user.FirstName = reader["FirstName"].ToString();
                        user.Email = reader["Email"].ToString();
                        user.Sex = reader["Sex"].ToString();
                        user.LastName = reader["LastName"].ToString();

                        users.Add(user);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            return ReadUser(userId);
        }
        public void UpdateUser(User user)
        {
            string query = $"UPDATE Users SET Username = '{user.Username}', Password = '{user.Password}' Where FirstName = '{user.FirstName}'";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    int affectedRows = cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void DeleteUser(int userId)
        {
            string query = $"DELETE FROM Users WHERE Id = {userId}";

            using (SqlConnection con = new SqlConnection(connectionString))
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
                }
            }
        }*/
    }
}


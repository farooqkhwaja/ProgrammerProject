
using DataAccess.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace DataAccess
{
    public class UserAccess
    {

        //const string connectionString = "Data Source=FAROOQKHWAJA;Initial Catalog=SalsaManagement-db;Integrated Security=True;Encrypt=False";
        const string connectionString = "Data Source=DESKTOP-DIPI9BT;Initial Catalog=Salsadb;Integrated Security=True;Encrypt=False";

        public List<User> GetUsers()
        {

            List<User> users = new List<User>();
            User user = null;
            string query = $"SELECT * FROM [User] ";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                       
                        user = new User() { Username = reader["Username"].ToString() };
                        user.Id = Convert.ToInt32(reader["Id"]);
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
        public User? GetUserByUsernamePassword(string username, string password)
        {
            User user = null; 
            string queryString = $"SELECT * FROM [User] WHERE Username = '{username}' AND Password = '{password}'";

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, con);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new User() { 
                        Username = reader["Username"].ToString() };
                        user.Password = reader["Password"].ToString();
                        user.FirstName = reader["FirstName"].ToString();
                        user.Email = reader["Email"].ToString();
                        user.Sex = reader["Sex"].ToString();
                        user.LastName = reader["LastName"].ToString();
                        user.IsManager = Convert.ToBoolean( reader["IsManager"].ToString());
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return user;
        }
        public bool CreateUser(User user)
        {
            string query =string.Format("INSERT INTO [User](Username, Password,FirstName,LastName, Sex, Email,IsManager) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')"
                ,user.Username,user.Password,user.FirstName, user.LastName,user.Sex, user.Email, user.IsManager);

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
        public bool GetUserByUsername(string username)
        {
            string query = $"SELECT * FROM [User] Where Username = '{username}'";
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query ,con);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        return true;
                    }
                    con.Close();    
                }
                catch(Exception ex)
                {
                    //log exception
                    throw;
                }
            }
            return false;
        }
        public User GetUser(int userId)
        {
          
            User user = null;
            string query = $"SELECT * FROM User WHERE Id = {userId}";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                   
                    while (reader.Read())
                    {
                        user = new User() { Username = reader["Username"].ToString() };
                        user.Password = reader["Password"].ToString();
                        user.FirstName = reader["FirstName"].ToString();
                        user.Email = reader["Email"].ToString();
                        user.Sex = reader["Sex"].ToString();
                        user.LastName = reader["LastName"].ToString();

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            return user;
        }
        public void UpdateUser(User user)
        {     
            string query = $"UPDATE User SET Username = '{user.Username}', Password = '{user.Password}' Where FirstName = '{user.FirstName}'";

            using(SqlConnection con = new SqlConnection(connectionString))
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
            string query = $"DELETE FROM [User] WHERE Id = {userId}";

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);

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


using DataAccess.Models;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DummyDatabase
    {
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            const string connectionString = "Data Source=FAROOQKHWAJA;Initial Catalog=SalsaManagement-db;Integrated Security=True;Encrypt=False";
            const string queryString = "SELECT * FROM Users";
            

            using(SqlConnection con = new SqlConnection(connectionString))
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
                Console.ReadLine();
            }

            //var users = new List<User>()
            //{
            //    new User() { Username = "John", Password = "111", IsManager = true },
            //    new User() { Username = "Mechenko", Password = "222", IsManager = false },
            //    new User() { Username = "Khwaja", Password = "333", IsManager = false },
            //    new User() { Username = "Delalamon", Password = "333", IsManager = true },
            //};
            return users;
        }
    }
}

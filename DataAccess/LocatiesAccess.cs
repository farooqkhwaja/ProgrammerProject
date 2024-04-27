using System.Data.SqlClient;
using DataAccess.Models;

namespace DataAccess
{
    public class LocatiesAccess
    {
        //static string connectionString = "Data Source=FAROOQKHWAJA;Initial Catalog=SalsaManagement-db;Integrated Security=True;Encrypt=False";
        static string connectionString = "Data Source=DESKTOP-DIPI9BT;Initial Catalog=Salsadb;Integrated Security=True;Encrypt=False";
      

        public Locations CreateLocation(Locations location)
        {
            string queryString = $"INSERT INTO Locations (Id, StreetName, HouseNumber, PostCode, Country) VALUES {location.Id}, '{location.StreetName}','{location.HouseNumber}','{location.PostCode}','{location.Country}";

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
            return location;
        }

        public Locations ReadLocations(int Id)
        {
            List<Locations> LocationList = new List<Locations>();
            string queryString = $"SELECT * FROM Locations WHERE Id = {Id}";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    while (reader.Read())
                    {
                        Locations location = new Locations();

                        location.Id = Convert.ToInt32(reader["Id"].ToString());
                        location.StreetName = reader["StreetName"].ToString();
                        location.HouseNumber = reader["HouseNumber"].ToString();
                        location.PostCode = reader["PostCode"].ToString();
                        location.Country = reader["Country"].ToString();

                        LocationList.Add(location);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return ReadLocations(Id);
            }
        }
        public void UpdateLocations(Locations location)
        {
            string queryString = $"UPDATE Locations SET StreetName = '{location.StreetName}', HouseNumber = '{location.HouseNumber}', PostCode = '{location.PostCode}', Country = '{location.Country}' WHERE Id = {location.Id}";

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
        public void DeleteLocation(int Id)
        {
            string queryString = $"DELETE FROM Locations WHERE Id = {Id}";

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

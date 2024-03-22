using DataAccess;
using DataAccess.Models;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*UserAccess dataAccsess = new UserAccess();
            User user1 = new User();
            
            user1.Id = 2;
            user1.FirstName = "Balal";
            user1.LastName = "Scherbax";
            user1.Email = "Bilal123@gmail.com";
            user1.Sex = "Male";
            user1.Username = "Scherbaxbilal";
            user1.Password = "111";

            dataAccsess.CreateUser(user1);
            dataAccsess.UpdateUser(user1);
            dataAccsess.DeleteUser(user1.Id);
            */

            UploadEventAccess dataaccess = new UploadEventAccess();
            UploadEvents event1 = new UploadEvents();

            event1.Name = "Latin Rituals";
            event1.Date = DateTime.Now;
            event1.Fk_Locations = 1;

            dataaccess.CreateEvent(event1);

        }
    }
}

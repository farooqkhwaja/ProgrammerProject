using DataAccess;
using DataAccess.Models;

namespace Testapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoubleUsernameCheck();
              

        }
        static void DoubleUsernameCheck()
        {
            UserAccess userAcess = new UserAccess();
            var existedUser = userAcess.GetUserByUsername("Farooasdq");
        }
        static void LoginTest()
        {
            UserAccess useraccess = new UserAccess();
            var user = useraccess.GetUserByUsernamePassword("FarooqKhoja", "123");
            Console.WriteLine(user.FirstName);
        }
    }
}

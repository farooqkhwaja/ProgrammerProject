using DataAccess;
using DataAccess.ADO;
using DataAccess.Models;

namespace Testapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GG();
            //DoubleUsernameCheck();
              

        }

        private static void GG()
        {
            var dapperExample = new DataAccess.Dapper.DanceFiguresRepository();
            
            var result = dapperExample.GetDanceFigures();

        }

        static void DoubleUsernameCheck()
        {
            UserRepository userAcess = new UserRepository();
            var existedUser = userAcess.GetUserByUsername("Farooasdq");
        }
        static void LoginTest()
        {
            UserRepository useraccess = new UserRepository();
            var user = useraccess.GetUserByUsernamePassword("FarooqKhoja", "123");
            Console.WriteLine(user.FirstName);
        }
    }
}

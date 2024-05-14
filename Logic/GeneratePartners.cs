using DataAccess.Dapper;
using DataAccess.Models;
using System.Reflection.Metadata;


namespace Logic
{
    public class GeneratePartners
    {

        private readonly UserRepository _userrepository;

        public GeneratePartners()
        {
            _userrepository = new UserRepository();
        }

        public User GetRandomUser()
        {
            var users = _userrepository.GetFirstnames();

            var random = new Random(); 

            var randomIndex = random.Next(1, users.Count());

            return users[randomIndex];
        }
    }
}

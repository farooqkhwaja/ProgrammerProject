using DataAccess.Dapper;
using DataAccess.Models;
using System.ComponentModel.Design;
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

            if (users.Count() == null) 
            {
                return null;
            }
            else
            {
                var random = new Random();

                var randomIndex = random.Next(users.Count());

                return users[randomIndex];
            }
        }
    }
}
